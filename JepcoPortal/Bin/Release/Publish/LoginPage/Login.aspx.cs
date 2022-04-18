using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiteWare.DataAccess.Repositories;
using HtmlAgilityPack;
using System.Web.Services;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using Newtonsoft.Json.Linq;


using System.Text;



using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using System.Net.Mail;
using System.Security.Cryptography;

public partial class LoginPage_Login : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (SessionManager.GetInstance.Users != null)
            //{

            //    if (RouteData.Values["language"] == null)
            //    {
            //        //Response.Redirect("ar/Home");
            //    }
            //}
                FillFooterNavigation();
           // FillLink();
        }
    }

    protected async void lnkSubmitFrm_Click(object sender, EventArgs e)
    {
        try
        {
           
            bool _isValEmail = false;
            //ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();
            //ContactUsFormEntity entity = new ContactUsFormEntity();
            
            //entity.Email = txtEmail.Text;
           
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(txtEmail.Text);
                if (match.Success)
                {
                    _isValEmail = true;
                }
                else
                    _isValEmail = false;
            }
            if ( _isValEmail )
            {
                string Email = string.Empty;
                Email = txtEmail.Text;
                string Password = string.Empty;
                Password = txtPassword.Text;
                string encryptedPass = EncryptPass(Password);
                ResultEntity<Plugin_ServiceUserEntity> Result = await Plugin_ServiceUserDomain.CheckUserLogin(Email, encryptedPass);
                if (Result.Status == ErrorEnums.Success)
                {

                    long UserId = Result.Entity.ID;
                    //imgSuccessLogin.Visible = true;
                    if (Result.Entity.IsPublished == true)
                    {


                        if (Result.Entity.UserType == "2")  // If USerType == 2
                        {
                            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyResult = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

                            RenwabaleEnergyResult = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(UserId);
                            if (RenwabaleEnergyResult.Status == ErrorEnums.Success)
                            {

                               if (RenwabaleEnergyResult.Entity.IsPublished == true) // If User IsApproved 
                                {
                                    #region  Send OTP For User 2

                                    ResultEntity<MobileRegistationEntity> MobileRegistrationResult = new ResultEntity<MobileRegistationEntity>();
                                    MobileRegistrationResult = MobileRegistationDomain.GetByIDNotAsync(UserId);


                                    if (MobileRegistrationResult.Status == ErrorEnums.Success)
                                    {


                                        //Boolean isRegisterd = GetMobileVerifyed[0].IsVerify;
                                        Boolean isRegisterd = MobileRegistrationResult.Entity.IsVerify;

                                        if (isRegisterd == true)
                                        {
                                            SessionManager.GetInstance.Users = Result.Entity;
                                            Response.Redirect("/ar/Home", false);
                                        }
                                        else
                                        {

                                            #region--> New API
                                            //*************************---New API Integration---------- ****************************************************

                                            //----------------------------------------- Latest Code --------------------------------------
                                            var getSMSCred = await GetAccessToken();
                                            Page.Response.Write("<script>console.log(' Call For OTP 1');</script>");
                                            string smsException = string.Empty;

                                            string dyna_otp = Generatenumber();
                                            if (!string.IsNullOrEmpty(getSMSCred.SenderID) && !string.IsNullOrEmpty(getSMSCred.AccessToken))
                                            {
                                                List<string> MobileNumber = new List<string>();
                                                MobileNumber.Add(Result.Entity.MobileNumber);
                                                var Body = new
                                                {
                                                    //service_type = "bulk_sms",
                                                    //recipient_numbers_type = "single_numbers",
                                                    //phone_numbers = MobileNumber.ToArray(),
                                                    //content = "JepcoPortal Send : " + dyna_otp,
                                                    //sender_id = "SENDER"

                                                    service_type = "bulk_sms",
                                                    recipient_numbers_type = "single_numbers",
                                                    phone_numbers = MobileNumber.ToArray(),
                                                    // content = "JepcoPortal Send : " + dyna_otp,
                                                    content = "اهلا وسهلا بكم في البوابة الالكترونية لشركة الكهرباء رقم التعريف الخاص بك هو " + dyna_otp,
                                                    sender_id = "JEPCO"

                                                };
                                                Page.Response.Write("<script>console.log('Mobile No 1: " + Result.Entity.MobileNumber + "');</script>");
                                                string inputJson = (new JavaScriptSerializer()).Serialize(Body);
                                                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["SMSURL"].ToString()));
                                                httpRequest.ContentType = "application/json";
                                                httpRequest.Method = "POST";
                                                httpRequest.Headers.Add("integration_token", getSMSCred.AccessToken);

                                                byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                                                using (Stream stream = httpRequest.GetRequestStream())
                                                {
                                                    stream.Write(bytes, 0, bytes.Length);
                                                    stream.Close();
                                                }
                                                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                                                {
                                                    using (Stream stream = httpResponse.GetResponseStream())
                                                    {
                                                        var res = (new StreamReader(stream)).ReadToEnd();
                                                        var data = (JObject)JsonConvert.DeserializeObject(res);

                                                        string status = data["status"].Value<string>();
                                                        smsException = status;

                                                        Page.Response.Write("<script>console.log('OTP Suss 1');</script>");

                                                        try
                                                        {
                                                            MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                                                            MemberOTPEntity.ServiceUserID = UserId;
                                                            MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                                                            MemberOTPEntity.OTP = dyna_otp;
                                                            MemberOTPEntity.IsVerify = false;
                                                            MemberOTPEntity.AddDate = DateTime.Now;
                                                            MemberOTPEntity.VerifyDate = DateTime.Now;

                                                            var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                                                            Page.Response.Write("<script>console.log('new Data Added 1');</script>");
                                                        }
                                                        catch { }



                                                    }
                                                }
                                            }
                                            //**************************************************************************************************************
                                            #endregion

                                            SessionManager.GetInstance.Users = Result.Entity;
                                            lblOTPMobile.Text = Result.Entity.MobileNumber;
                                            ModalOTP.Show();

                                        }

                                    }
                                    else
                                    {

                                        #region--> New API
                                        //*************************---New API Integration---------- ****************************************************

                                        //----------------------------------------- Latest Code --------------------------------------
                                        var getSMSCred = await GetAccessToken();
                                        Page.Response.Write("<script>console.log(' Call For OTP 2');</script>");
                                        string smsException = string.Empty;

                                        string dyna_otp = Generatenumber();
                                        if (!string.IsNullOrEmpty(getSMSCred.SenderID) && !string.IsNullOrEmpty(getSMSCred.AccessToken))
                                        {
                                            List<string> MobileNumber = new List<string>();
                                            MobileNumber.Add(Result.Entity.MobileNumber);
                                            var Body = new
                                            {

                                                service_type = "bulk_sms",
                                                recipient_numbers_type = "single_numbers",
                                                phone_numbers = MobileNumber.ToArray(),
                                                // content = "JepcoPortal Send : " + dyna_otp,
                                                content = "اهلا وسهلا بكم في البوابة الالكترونية لشركة الكهرباء رقم التعريف الخاص بك هو " + dyna_otp,
                                                sender_id = "JEPCO"

                                            };
                                            Page.Response.Write("<script>console.log('Mobile No 2: " + Result.Entity.MobileNumber + "');</script>");
                                            string inputJson = (new JavaScriptSerializer()).Serialize(Body);
                                            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["SMSURL"].ToString()));
                                            httpRequest.ContentType = "application/json";
                                            httpRequest.Method = "POST";
                                            httpRequest.Headers.Add("integration_token", getSMSCred.AccessToken);

                                            byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                                            using (Stream stream = httpRequest.GetRequestStream())
                                            {
                                                stream.Write(bytes, 0, bytes.Length);
                                                stream.Close();
                                            }
                                            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                                            {
                                                using (Stream stream = httpResponse.GetResponseStream())
                                                {
                                                    var res = (new StreamReader(stream)).ReadToEnd();
                                                    var data = (JObject)JsonConvert.DeserializeObject(res);

                                                    string status = data["status"].Value<string>();
                                                    smsException = status;

                                                    Page.Response.Write("<script>console.log('OTP Suss 2');</script>");

                                                    try
                                                    {
                                                        MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                                                        MemberOTPEntity.ServiceUserID = UserId;
                                                        MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                                                        MemberOTPEntity.OTP = dyna_otp;
                                                        MemberOTPEntity.IsVerify = false;
                                                        MemberOTPEntity.AddDate = DateTime.Now;
                                                        MemberOTPEntity.VerifyDate = DateTime.Now;

                                                        var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                                                        Page.Response.Write("<script>console.log('Mobile Data addded2');</script>");
                                                    }
                                                    catch { }



                                                }
                                            }
                                        }
                                        //**************************************************************************************************************
                                        #endregion
                                        SessionManager.GetInstance.Users = Result.Entity;
                                        lblOTPMobile.Text = Result.Entity.MobileNumber;
                                        ModalOTP.Show();
                                    }
                                    #endregion
                                  

                                }
                               else
                                {
                                    lblOTPString.Text = "موافقتك معلقة";
                                    ModalPopupExtender1.Show();
                                }

                                
                            }
                        }
                        else { 
                       
                        ResultEntity<MobileRegistationEntity> MobileRegistrationResult = new ResultEntity<MobileRegistationEntity>();
                        MobileRegistrationResult = MobileRegistationDomain.GetByIDNotAsync(UserId);


                        if (MobileRegistrationResult.Status == ErrorEnums.Success)
                        {


                            //Boolean isRegisterd = GetMobileVerifyed[0].IsVerify;
                            Boolean isRegisterd = MobileRegistrationResult.Entity.IsVerify;

                            if (isRegisterd == true)
                            {
                                SessionManager.GetInstance.Users = Result.Entity;
                                Response.Redirect("/ar/Home", false);
                            }
                            else
                            {

                                #region--> New API
                                //*************************---New API Integration---------- ****************************************************

                                //----------------------------------------- Latest Code --------------------------------------
                                var getSMSCred = await GetAccessToken();
                                Page.Response.Write("<script>console.log(' Call For OTP 1');</script>");
                                string smsException = string.Empty;

                                string dyna_otp = Generatenumber();
                                if (!string.IsNullOrEmpty(getSMSCred.SenderID) && !string.IsNullOrEmpty(getSMSCred.AccessToken))
                                {
                                    List<string> MobileNumber = new List<string>();
                                    MobileNumber.Add(Result.Entity.MobileNumber);
                                    var Body = new
                                    {
                                        //service_type = "bulk_sms",
                                        //recipient_numbers_type = "single_numbers",
                                        //phone_numbers = MobileNumber.ToArray(),
                                        //content = "JepcoPortal Send : " + dyna_otp,
                                        //sender_id = "SENDER"

                                        service_type = "bulk_sms",
                                        recipient_numbers_type = "single_numbers",
                                        phone_numbers = MobileNumber.ToArray(),
                                        // content = "JepcoPortal Send : " + dyna_otp,
                                        content = "اهلا وسهلا بكم في البوابة الالكترونية لشركة الكهرباء رقم التعريف الخاص بك هو " + dyna_otp,
                                        sender_id = "JEPCO"

                                    };
                                    Page.Response.Write("<script>console.log('Mobile No 1: " + Result.Entity.MobileNumber + "');</script>");
                                    string inputJson = (new JavaScriptSerializer()).Serialize(Body);
                                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["SMSURL"].ToString()));
                                    httpRequest.ContentType = "application/json";
                                    httpRequest.Method = "POST";
                                    httpRequest.Headers.Add("integration_token", getSMSCred.AccessToken);

                                    byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                                    using (Stream stream = httpRequest.GetRequestStream())
                                    {
                                        stream.Write(bytes, 0, bytes.Length);
                                        stream.Close();
                                    }
                                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                                    {
                                        using (Stream stream = httpResponse.GetResponseStream())
                                        {
                                            var res = (new StreamReader(stream)).ReadToEnd();
                                            var data = (JObject)JsonConvert.DeserializeObject(res);

                                            string status = data["status"].Value<string>();
                                            smsException = status;

                                            Page.Response.Write("<script>console.log('OTP Suss 1');</script>");

                                            try
                                            {
                                                MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                                                MemberOTPEntity.ServiceUserID = UserId;
                                                MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                                                MemberOTPEntity.OTP = dyna_otp;
                                                MemberOTPEntity.IsVerify = false;
                                                MemberOTPEntity.AddDate = DateTime.Now;
                                                MemberOTPEntity.VerifyDate = DateTime.Now;

                                                var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                                                Page.Response.Write("<script>console.log('new Data Added 1');</script>");
                                            }
                                            catch { }



                                        }
                                    }
                                }
                                //**************************************************************************************************************
                                #endregion

                                SessionManager.GetInstance.Users = Result.Entity;
                                lblOTPMobile.Text = Result.Entity.MobileNumber;
                                ModalOTP.Show();

                            }

                        }
                        else
                        {

                            #region--> New API
                            //*************************---New API Integration---------- ****************************************************

                            //----------------------------------------- Latest Code --------------------------------------
                            var getSMSCred = await GetAccessToken();
                            Page.Response.Write("<script>console.log(' Call For OTP 2');</script>");
                            string smsException = string.Empty;

                            string dyna_otp = Generatenumber();
                            if (!string.IsNullOrEmpty(getSMSCred.SenderID) && !string.IsNullOrEmpty(getSMSCred.AccessToken))
                            {
                                List<string> MobileNumber = new List<string>();
                                MobileNumber.Add(Result.Entity.MobileNumber);
                                var Body = new
                                {

                                    service_type = "bulk_sms",
                                    recipient_numbers_type = "single_numbers",
                                    phone_numbers = MobileNumber.ToArray(),
                                    // content = "JepcoPortal Send : " + dyna_otp,
                                    content = "اهلا وسهلا بكم في البوابة الالكترونية لشركة الكهرباء رقم التعريف الخاص بك هو " + dyna_otp,
                                    sender_id = "JEPCO"

                                };
                                Page.Response.Write("<script>console.log('Mobile No 2: " + Result.Entity.MobileNumber + "');</script>");
                                string inputJson = (new JavaScriptSerializer()).Serialize(Body);
                                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["SMSURL"].ToString()));
                                httpRequest.ContentType = "application/json";
                                httpRequest.Method = "POST";
                                httpRequest.Headers.Add("integration_token", getSMSCred.AccessToken);

                                byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                                using (Stream stream = httpRequest.GetRequestStream())
                                {
                                    stream.Write(bytes, 0, bytes.Length);
                                    stream.Close();
                                }
                                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                                {
                                    using (Stream stream = httpResponse.GetResponseStream())
                                    {
                                        var res = (new StreamReader(stream)).ReadToEnd();
                                        var data = (JObject)JsonConvert.DeserializeObject(res);

                                        string status = data["status"].Value<string>();
                                        smsException = status;

                                        Page.Response.Write("<script>console.log('OTP Suss 2');</script>");

                                        try
                                        {
                                            MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                                            MemberOTPEntity.ServiceUserID = UserId;
                                            MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                                            MemberOTPEntity.OTP = dyna_otp;
                                            MemberOTPEntity.IsVerify = false;
                                            MemberOTPEntity.AddDate = DateTime.Now;
                                            MemberOTPEntity.VerifyDate = DateTime.Now;

                                            var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                                            Page.Response.Write("<script>console.log('Mobile Data addded2');</script>");
                                        }
                                        catch { }



                                    }
                                }
                            }
                            //**************************************************************************************************************
                            #endregion
                            SessionManager.GetInstance.Users = Result.Entity;
                            lblOTPMobile.Text = Result.Entity.MobileNumber;
                            ModalOTP.Show();
                        }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username Or Password');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username Or Password');", true);
                }

            }
            else
            {
                
                if (_isValEmail)
                {
                    txtEmail.Style.Add("border", "none");
                }
                else
                {
                    txtEmail.Style.Add("border", "1px solid red");
                }
                lnkSubmitFrm.Focus();
            }
        }
        catch
        {
        }
    }
    protected static string EncryptPass(string pass)
    {

        var crypt = new SHA256Managed();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(pass));
        foreach (byte theByte in crypto)
        {
            hash += theByte.ToString("x2");
        }
        return hash;
    }
    protected void lnkClear_Click(object sender, EventArgs e)
    {

    }

   

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/LoginPage/Registration.aspx", false);
    }

    protected void FillFooterNavigation()
    {
        try
        {
            ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
            Result = FooterNavigationDomain.GetFooterAllWithoutAsync();
            if (Result.Status == ErrorEnums.Success)
            {
                long _parentID = 0;

                Result.List = Result.List.Where(s => s.ParentID == _parentID && s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Take(4).ToList();

                lstFooterNav.DataSource = Result.List.ToList();
                lstFooterNav.DataBind();
            }
        }
        catch (Exception e)
        {
        }
    }

    //protected async void FillLink()
    //{
    //    try
    //    {
    //        ResultList<PluginBannerEntity> res = new ResultList<PluginBannerEntity>();
    //        res = await PluginBannerDomain.GetPluginBannerAll();

    //        if (res.Status == ErrorEnums.Success)
    //        {



    //            var abcd = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.CategoryID == 4 && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.BannerOrder).Take(1).ToList();
    //            string abcdstring = abcd.FirstOrDefault().Title.ToString();
    //            string abcdstring2 = abcd.FirstOrDefault().Link.ToString();
    //            //linklbl.Text = abcdstring.ToString();
    //            //lnk1.NavigateUrl = abcdstring2;


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    public async Task<GetSMSCred> GetAccessToken()
    {
        GetSMSCred sMSCred = new GetSMSCred();
        try
        {
            var httpClient = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
            var request = new HttpRequestMessage(HttpMethod.Post, ConfigurationManager.AppSettings["TokenURL"].ToString());

            string UserName = ConfigurationManager.AppSettings["SMSUName"].ToString();
            string Password = ConfigurationManager.AppSettings["SMSPWD"].ToString();

            request.Headers.Add("username", UserName);
            request.Headers.Add("password", Password);

            HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            sMSCred.AccessToken = Convert.ToString(item["result"]["integration_token"]);
            sMSCred.SenderID = Convert.ToString(item["result"]["accountSid"]);
        }
        catch
        {
        }
        return sMSCred;
    }

    public class GetSMSCred
    {
        public string AccessToken { get; set; }
        public string SenderID { get; set; }
    }

    public static string Generatenumber()
    {
        var chars = "0123456789";
        var stringChars = new char[6];
        var random = new Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        var finalString = new String(stringChars);
        return finalString;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string OTp = txtOPT.Text;


        long UserId = SessionManager.GetInstance.Users.ID;



        try {
            ResultEntity<MobileRegistationEntity> MobileRegiEntity = new ResultEntity<MobileRegistationEntity>();
            MobileRegiEntity = MobileRegistationDomain.GetByIDNotAsync(UserId);
            if (MobileRegiEntity.Status == ErrorEnums.Success)
            {

                if (MobileRegiEntity.Entity.OTP == OTp)
                {
                    try
                    {

                        MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                        MemberOTPEntity.RegistationID = MobileRegiEntity.Entity.RegistationID;
                        MemberOTPEntity.ServiceUserID = MobileRegiEntity.Entity.ServiceUserID;
                        MemberOTPEntity.MobileNumber = MobileRegiEntity.Entity.MobileNumber;
                        MemberOTPEntity.OTP = MobileRegiEntity.Entity.OTP;
                        MemberOTPEntity.IsVerify = true;
                        MemberOTPEntity.AddDate = MobileRegiEntity.Entity.AddDate;
                        MemberOTPEntity.VerifyDate = DateTime.Now;

                        var MemberOTPResult = MobileRegistationDomain.UpdateNotAsync(MemberOTPEntity);
                        if (MemberOTPResult.Status == ErrorEnums.Success)
                        {

                            Response.Redirect("/ar/Home", false);
                        }
                        else
                        {
                            lblErroreOTP.Visible = true;
                            ModalOTP.Show();
                        }

                    }
                    catch { }


                }
                else
                {
                    lblErroreOTP.Visible = true;
                    ModalOTP.Show();
                }

            }

        }
        catch { }

       
    }


    protected async void lnkForgetPasswordSubmitFrm_Click(object sender, EventArgs e)
    {


    }


    public void SendMail2(string UserName, string toMail, string fromMail, string ccmail, string Body, string Subject, string Password, string HOST, int Port, bool ssl)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            if (HOST == "")
            {
                HOST = "smtp.office365.com";
            }
            if (string.IsNullOrEmpty(fromMail))
            {
                fromMail = "info3@aura-techs.com";
            }


            SmtpClient SmtpServer = new SmtpClient(HOST);
            mailMessage.From = new MailAddress(fromMail);



            if (toMail == "")
            {
                mailMessage.To.Add("info3@aura-techs.com");
            }
            else
            {
                mailMessage.To.Add(toMail);
            }

            foreach (string sCC in ccmail.Split(",".ToCharArray()))
                mailMessage.CC.Add(sCC);

            if (Subject == "")
            {
                mailMessage.Subject = "testc";
            }
            else
            {
                mailMessage.Subject = Subject;
            }
            if (Body == "")
            {
                mailMessage.Body = "test";
            }
            else
            {
                mailMessage.Body = Body;
            }

            mailMessage.IsBodyHtml = true;


            SmtpServer.Port = Port;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.EnableSsl = ssl;
            if(HOST.ToLower().Contains("office365"))
            {
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            SmtpServer.Credentials = new System.Net.NetworkCredential(UserName, Password);

            try
            {
                SmtpServer.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected async void btnForgetPass_Click(object sender, EventArgs e)
    {

        bool _isValEmail = false;
        if (!string.IsNullOrEmpty(txtForgetPassEmail.Text))
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtForgetPassEmail.Text);
            if (match.Success)
            {
                _isValEmail = true;
            }
            else
                _isValEmail = false;
        }
        if (_isValEmail)
        {

            //ResultEntity<Plugin_ServiceUserEntity> Result = await Plugin_ServiceUserDomain.CheckUserLogin(Email, Password);
            string Email = string.Empty;
            Email = txtForgetPassEmail.Text;

            ResultList<Plugin_ServiceUserEntity> result = new ResultList<Plugin_ServiceUserEntity>();
            result = await Plugin_ServiceUserDomain.GetAll();
            if (result.Status == ErrorEnums.Success)
            {
                var Passresult = result.List.Where(s => s.Email == Email).ToList();
                if (Passresult.Count > 0)
                {
                    string newPassword = Passresult[0].Password.ToString();


                    #region admission mail
                    ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
                    SettingResult = SettingDomain.GetSettingAllWithoutAsync();

                    if (SettingResult.Status == ErrorEnums.Success)
                    {
                        string UserName = SettingResult.List[0].Email;
                        string _fromMail = SettingResult.List[0].FromMail;
                        string _Password = SettingResult.List[0].PasswordEmail;
                        string _HOST = SettingResult.List[0].SMTPServer;
                        int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
                        string _subject = "Forget Password";
                        //string _toMail1 = ConfigurationManager.AppSettings["ToMailCompanyApprovals"].ToString();
                        string _toMail2 = txtForgetPassEmail.Text;

                        bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                        string _ccMail = txtForgetPassEmail.Text;//ConfigurationManager.AppSettings["CCMAilCompanyApprovals1"].ToString();

                        //string bodyContent = SettingResult.List[0].RenewableRegistrationAdminMail;
                        //bodyContent = bodyContent.Replace("{Name}", txtForgetPassEmail.Text);
                        //bodyContent = bodyContent.Replace("{Password}", newPassword);
                        //bodyContent = bodyContent.Replace("{FormDetails}", "");
                        //string _Body = bodyContent;


                        string bodyContent2 = FetchLinksFromSource(SettingResult.List[0].ForgetPasswordUser);
                        bodyContent2 = bodyContent2.Replace("{Name}", txtForgetPassEmail.Text);
                        bodyContent2 = bodyContent2.Replace("{Password}", newPassword);
                        bodyContent2 = bodyContent2.Replace("{FormDetails}", "");
                        string _Body2 = bodyContent2;

                        try
                        {

                            //SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                            SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);

                        }
                        catch { }

                        lblOTPString.Text = "تم ارسال كلمة المرور الخاصة بكم على البريد الالكتروني المسجل لدينا.";
                        ModalPopupExtender1.Show();

                    }
                    #endregion

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username');", true);

            }

        }
        else
        {
            if (_isValEmail)
            {
                txtForgetPassEmail.Style.Add("border", "none");
               
            }
            else
            {
                txtForgetPassEmail.Style.Add("border", "1px solid red");
            }
            txtForgetPassEmail.Focus();
        }

        
    }

    public string FetchLinksFromSource(string htmlSource)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        if (doc.DocumentNode.SelectNodes("//img") != null)
        {
            foreach (var img in doc.DocumentNode.SelectNodes("//img"))
            {
                string orig = img.Attributes["src"].Value;
                if (orig.Contains("http://") || orig.Contains("https://"))
                {
                    img.SetAttributeValue("src", orig);
                }
                else
                {
                    string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                    img.SetAttributeValue("src", newsrc);
                }

            }
        }
        //if (doc.DocumentNode.SelectNodes("//table") != null)
        //{
        //    foreach (var table in doc.DocumentNode.SelectNodes("//table"))
        //    {
        //        //table.SetAttributeValue("class", "Tblres");
        //        table.SetAttributeValue("class", "comntable");
        //    }
        //}
        return doc.DocumentNode.OuterHtml;
    }
}