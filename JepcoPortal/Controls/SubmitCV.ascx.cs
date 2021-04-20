using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_SubmitCV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (!IsPostBack)
            {
                FillContactdetail();
                //FillSocialIcon();
                //FillEntity();
                FillCapctha();
            }
          
        }
        catch
        {
        }
    }

    #region--> FillContactdetail | Add | 30-10-2019
    protected void FillContactdetail()
    {
        try
        {
            string urllang = Page.RouteData.Values["Language"].ToString();
            string AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
            string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;
            ResultEntity<PagesEntity> Result = new ResultEntity<PagesEntity>();

            Result = PagesDomain.GetPagesByAliasPathNotAsync(Alias, 1);
            if (Result.Status == ErrorEnums.Success)
            {
                //lblContentdetail.Text = FetchLinksFromSource(Result.Entity.ContentHTML.ToString());
                //lblContentdetail1.Text = FetchLinksFromSource(Result.Entity.ContentHTML1.ToString());
            }
        }
        catch
        {
        }
    }
    #endregion

    #region--> lnkSubmitFrm_Click | Add | 30-10-2019
    protected void lnkSubmitFrm_Click(object sender, EventArgs e)
    {

        try
        {
            //    //---******* (For Local) ******-------------------------
            string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();
            Page.Validate("1");
            if (Page.IsValid)
            {
                if (Session["captcha"].ToString() != txtCaptcha.Text)
                {
                    CaptchaErrorLabel.Text = "Invalid Captcha Code";

                    CaptchaErrorLabel.Visible = true;
                    FillCapctha();
                }
                else
                {
                    //    //---------------******* (For Live) ******-------------------------
                    //string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());
                    bool _isValid = false;
                    bool _isValMob = false;
                    bool _isValEmail = false;
                    ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();
                    Plugin_SubmitCVEntity entity = new Plugin_SubmitCVEntity();
                    entity.Name = txtName.Text;
                    entity.Email = txtEmail.Text;
                    entity.PhoneNo = txtMobile.Text;
                    entity.Interest = ddlInterest.SelectedValue;


                    HttpPostedFile files = Request.Files.Get("fileuploadfield_1");
                    string guid = Guid.NewGuid().ToString().Substring(0, 6);
                    if (files != null)
                    {
                        string dir = uploadPath1 + guid + txtName.Text + "//";
                        if (files.FileName != "") // If file is Selected File
                        {
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }

                            files.SaveAs(dir + files.FileName);
                            entity.AttachCV = dir + files.FileName;
                        }
                        else
                        {
                            entity.AttachCV = string.Empty;
                        }
                    }
                    else
                    {
                        entity.AttachCV = string.Empty;
                    }



                    // txtMessage.Text;
                    entity.LanguageID = 1;
                    entity.Order = 0;
                    entity.IsPublished = true;
                    entity.PublishedDate = DateTime.Now;
                    entity.IsDeleted = false;
                    entity.AddDate = DateTime.Now;
                    entity.AddUser = "9";
                    entity.EditDate = DateTime.Now;
                    entity.EditUser = "9";



                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _isValid = true;
                    }

                    if (!string.IsNullOrEmpty(txtMobile.Text))
                    {
                        _isValMob = true;
                    }

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

                    if (_isValid && _isValEmail && _isValMob)
                    {
                        result = Plugin_SubmitCVDomain.InsertNotAsync(entity);
                        if (result.Status == ErrorEnums.Success)
                        {
                            ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
                            SettingResult = SettingDomain.GetSettingAllWithoutAsync();
                            if (SettingResult.Status == ErrorEnums.Success)
                            {
                                string _fromMail = SettingResult.List[0].Email;
                                string _Password = SettingResult.List[0].PasswordEmail;
                                string _HOST = SettingResult.List[0].SMTPServer;
                                int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
                                string _subject = "NES CV submited";
                                string _toMail = txtEmail.Text;
                                string _Body = "<h1>Below are new Contact Person Detail</h1>" +
                                       "<p>Name :" + txtName.Text + "</p><br/>" +
                                       "<p>Email :" + txtEmail.Text + "</p><br/>" +
                                        "<p>Phone_No :" + txtMobile.Text + "</p><br/>";
                                SendMail(_toMail, _fromMail, _Body, _subject, _Password, _HOST, _Port);
                            }
                            txtName.Text = "";
                            txtEmail.Text = "";

                            txtMobile.Text = "";
                            txtName.Style.Add("border", "none");
                            txtMobile.Style.Add("border", "none");
                            txtEmail.Style.Add("border", "none");

                            lblInqTitle.Text = "Message";
                            lblInqMessage.Text = "Your inquiry submitted successfully";

                            mpeInquiry.Show();
                        }
                    }
                    else
                    {
                        if (_isValid)
                        {
                            txtName.Style.Add("border", "none");
                        }
                        else
                        {
                            txtName.Style.Add("border", "1px solid red");
                        }
                        if (_isValMob)
                        {
                            txtMobile.Style.Add("border", "none");
                        }
                        else
                        {
                            txtMobile.Style.Add("border", "1px solid red");
                        }
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
            }
        }
        catch
        {
        }
    }
    #endregion
    void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }

    #region Send Mail | Add | 31-10-2019
    protected void SendMail(string toMail, string fromMail, string Body, string Subject, string Password, string HOST, int Port)
    {

        string FROM = fromMail;

        string TO = toMail;

        // Replace smtp_username with your SMTP user name.
        // string SMTP_USERNAME = ConfigurationManager.AppSettings["UserName"].ToString();
        string SMTP_USERNAME = FROM;

        // Replace smtp_password with your  SMTP password.
        //string SMTP_PASSWORD = ConfigurationManager.AppSettings["Password"].ToString();
        string SMTP_PASSWORD = Password;

        //string HOST = ConfigurationManager.AppSettings["SMTPServer"].ToString();
        // string HOST = HOST;

        //int PORT = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
        // int PORT = 587;
        // The subject line of the email
        //string SUBJECT = Subject;

        // The body of the email
        // string BODY = Body;

        // Create and build a new MailMessage object
        MailMessage message = new MailMessage();
        message.IsBodyHtml = true;
        //message.From = new MailAddress(FROM, FROMNAME);
        message.From = new MailAddress(FROM);
        message.To.Add(new MailAddress(TO));
        message.CC.Add(new MailAddress(FROM));
        message.Subject = Subject;
        message.Body = Body;

        // Create and configure a new SmtpClient
        SmtpClient client = new SmtpClient(HOST, Port);
        // Pass SMTP credentials
        client.Credentials =
            new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
        // Enable SSL encryption
        client.EnableSsl = false;

        // Send the email. 
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
        }

    }
    #endregion
}