using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Configuration;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using System.IO;
//using System.Data.SQLite.dll;
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

public partial class Controls_AddFileNumber : System.Web.UI.UserControl
{
    DateTime currentDate = DateTime.Now;
    DataPager pager1;
    string lang = string.Empty;
    int newsCount = 1;
    int Certificatecount = 1;
    int addmoreCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }
                //ddlTypeDocument.Items.Insert(0, new ListItem("الرجاء اختيار نوع الوثيقة", "0"));

                FillNationality();
                FillUserData();
                //FillComplainType();
                // FillTypeDocumnet();

                FillGovernate();
                FillArea();


            }
            ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
            Result = SettingDomain.GetSettingAllWithoutAsync();
            if (Result.Status == ErrorEnums.Success)
            {
                if (!string.IsNullOrEmpty(Result.List[0].Latitude))
                    lblLatitude.Value = Result.List[0].Latitude;
                else
                    lblLatitude.Value = "32.465717";

                if (!string.IsNullOrEmpty(Result.List[0].Longitude))
                    lblLongiude.Value = Result.List[0].Longitude;
                else
                    lblLongiude.Value = "35.563362";
            }
        }
        catch
        {
        }
    }


    protected void FillUserData()
    {

        try
        {

            long UserId = SessionManager.GetInstance.Users.ID;

            ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();

            //ServiceUserEntity = await Plugin_ServiceUserDomain.GetByID(UserId);
            ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(UserId);
            if (ServiceUserEntity.Status == ErrorEnums.Success)
            {
                txtfirstName.Text = ServiceUserEntity.Entity.FirstName;
                txtSecondNAme.Text = ServiceUserEntity.Entity.SecondName;
                txtThirdName.Text = ServiceUserEntity.Entity.ThirdName;
                txtFamilyName.Text = ServiceUserEntity.Entity.FamilyName;

                //lblUserAddress.Text = ServiceUserEntity.Entity.Address;
                txtEmail.Text = ServiceUserEntity.Entity.Email;
                txtMobileNo.Text = ServiceUserEntity.Entity.MobileNumber;
                hdnServiceID.Value = ServiceUserEntity.Entity.ID.ToString();
                ddlNationality.SelectedValue = ServiceUserEntity.Entity.NationalityID.ToString();

                if (ServiceUserEntity.Entity.NationalityID != 0)
                {
                    FillTypeDocumnet();
                    //ddlTypeDocument.SelectedValue = ServiceUserEntity.Entity.IDType.ToString();

                }
                txtDocumnetNo.Text = ServiceUserEntity.Entity.IDNumber;



            }
        }
        catch { }
    }

    //protected void FillComplainType()
    //{
    //    try
    //    {

    //        ddlComplainType.Items.Insert(0, new ListItem("لرجاء اختيار نوع الشكوى", "0"));
    //        // ddlComplainType.Items.Insert(1, new ListItem(" 1 اختيار الجنسية", "1"));

    //        ResultList<Lookup_ComplainTypeEntity> Result = new ResultList<Lookup_ComplainTypeEntity>();
    //        Result = Lookup_ComplainTypeDomain.GetAllNotAsync();

    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            foreach (Lookup_ComplainTypeEntity item in Result.List)
    //            {
    //                ddlComplainType.Items.Add(new ListItem(item.ComplainType.ToString(), item.ComplainTypeID.ToString()));
    //            }
    //        }



    //    }
    //    catch { }

    //}

    protected void FillTypeDocumnet()
    {
        try
        {

            //ddlTypeDocument.Items.Insert(0, new ListItem("بطاقة احوال مدنية", "0"));
            //ddlTypeDocument.Items.Insert(1, new ListItem(" بطاقة احوال مدنية 1 ", "1"));

            if (ddlNationality.SelectedValue.ToString() == "1")
            {
                //ddlTypeDocument.Items.Clear();
                //ddlTypeDocument.Items.Insert(0, new ListItem("الرجاء اختيار نوع الوثيقة", "0"));
                ResultList<Lookup_DocumentTypeEntity> Result = new ResultList<Lookup_DocumentTypeEntity>();
                Result = Lookup_DocumentTypeDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_DocumentTypeEntity item in Result.List)
                    {
                        //ddlTypeDocument.Items.Add(new ListItem(item.DocumentType.ToString(), item.DocumentTypeID.ToString()));
                    }
                }
            }
            else
            {
                //ddlTypeDocument.Items.Clear();
                //ddlTypeDocument.Items.Insert(0, new ListItem("بطاقة احوال مدنية", "0"));
                ResultList<Lookup_DocumentTypeEntity> Result = new ResultList<Lookup_DocumentTypeEntity>();
                Result = Lookup_DocumentTypeDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_DocumentTypeEntity item in Result.List)
                    {
                        //ddlTypeDocument.Items.Add(new ListItem(item.DocumentType.ToString(), item.DocumentTypeID.ToString()));
                    }
                    //ddlTypeDocument.Items.RemoveAt()

                    //ddlTypeDocument.Items.FindByValue("1").Enabled = false;
                }
            }

        }
        catch { }




    }

    protected void FillNationality()
    {
        try
        {

            ddlNationality.Items.Insert(0, new ListItem("اختيار الجنسية", "0"));
            //ddlNationality.Items.Insert(1, new ListItem(" 1 اختيار الجنسية", "1"));

            ResultList<NewSub_Lookup_NationalityEntity> Result = new ResultList<NewSub_Lookup_NationalityEntity>();
            Result = NewSub_Lookup_NationalityDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (NewSub_Lookup_NationalityEntity item in Result.List)
                {
                    ddlNationality.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }


        }
        catch { }

    }

    //protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillTypeDocumnet();
    //}

    protected void FillGovernate()
    {
        try
        {

            //ddlGovernate.Items.Insert(0, new ListItem("اختيار الجنسية", "0"));
            //ddlGovernate.Items.Insert(1, new ListItem(" 1 اختيار الجنسية", "1"));
            ResultList<Plugin_GovernateEntity> Result = new ResultList<Plugin_GovernateEntity>();
            Result = Plugin_Provider_GovernateDomain.GetGovernateAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_GovernateEntity item in Result.List)
                {
                    // ddlGovernate.Items.Add(new ListItem(item.Name.ToString(), item.GovernateID.ToString()));
                }
            }



        }
        catch { }

    }

    protected void FillArea()
    {
        try
        {

            //ddlArea.Items.Insert(0, new ListItem("اختيار الجنسية", "0"));
            //ddlArea.Items.Insert(1, new ListItem(" 1 اختيار الجنسية", "1"));
            ResultList<Lookup_AreaEntity> Result = new ResultList<Lookup_AreaEntity>();
            Result = Lookup_AreaDomain.GetLookupAreaAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_AreaEntity item in Result.List)
                {
                    // ddlArea.Items.Add(new ListItem(item.AreaName.ToString(), item.AreaID.ToString()));
                }
            }



        }
        catch { }

    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{

    //    //    //---******* (For Local) ******-------------------------
    //    //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

    //    //    //---------------******* (For Live) ******-------------------------
    //    //string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());




    //    #region Insert All
    //    string guid = Guid.NewGuid().ToString().Substring(0, 6);


    //    Plugin_UserComplainEntity Entity = new Plugin_UserComplainEntity();


    //    Entity.ComplainTitle = txtComplianTitle.Text;
    //    //Entity.ComplainDetails = txtComplainDetail.Text;
    //    //Entity.ComplainType = Convert.ToInt32(ddlComplainType.SelectedValue);
    //    Entity.FirstName = txtfirstName.Text;
    //    Entity.SecondName = txtSecondNAme.Text;
    //    Entity.ThirdName = txtThirdName.Text;
    //    Entity.FamilyName = txtFamilyName.Text;
    //    //Entity.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
    //    //Entity.DocumentType = Convert.ToInt32(ddlTypeDocument.SelectedValue);
    //    Entity.DocumentNumber = txtDocumnetNo.Text;
    //    Entity.MobileNo = txtMobileNo.Text;
    //    Entity.Email = txtEmail.Text;
    //    Entity.MeterNumber = txtMeterNo.Text;

    //    Entity.Governate = Convert.ToInt32(Request.Form["ddlGeove"]);


    //    //Entity.Governate = Convert.ToInt32(ddlGovernate.SelectedValue);
    //    //Entity.Area = Convert.ToInt32(ddlArea.SelectedValue);
    //    Entity.Area = Convert.ToInt32(Request.Form["ddlAreas"]);
    //    Entity.StreetName = string.Empty;// txtSteetNamne.Text;
    //    Entity.Latitude = lblLongiude.Value;
    //    Entity.Longitude = lblLatitude.Value;
    //    Entity.Order = 0;
    //    Entity.LanguageID = 2;
    //    Entity.IsPublished = true;
    //    Entity.IsDeleted = false;
    //    Entity.PublishedDate = DateTime.Now;
    //    Entity.AddDate = DateTime.Now;
    //    Entity.AddUser = "9";
    //    Entity.EditDate = DateTime.Now;
    //    Entity.EditUser = "9";
    //    Entity.Area2 = Convert.ToInt32(Request.Form["ddlAreas2"]); ;
    //    Entity.StreetID = Convert.ToInt32(Request.Form["ddlsteet"]);

    //    if (hdnSaveResultStatus.Value == "1")
    //    {
    //        Entity.IssueStatus = true;
    //    }
    //    else
    //    {
    //        Entity.IssueStatus = false;
    //    }

    //    Entity.IssueResultNo = hdnSaveResultVAlue.Value.ToString();
    //    Entity.LanguageIDAPI = 1;
    //    Entity.ServiceUserID = Convert.ToInt64(hdnServiceID.Value);


    //    var Result = Plugin_UserComplainDomain.InsertNotAsync(Entity);
    //    if (Result.Status == ErrorEnums.Success)
    //    {


    //        #region admission mail

    //        ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
    //        SettingResult = SettingDomain.GetSettingAllWithoutAsync();

    //        //if (SettingResult.Status == ErrorEnums.Success)
    //        //{
    //        //    string UserName = SettingResult.List[0].Email;
    //        //    string _fromMail = SettingResult.List[0].FromMail;
    //        //    string _Password = SettingResult.List[0].PasswordEmail;
    //        //    string _HOST = SettingResult.List[0].SMTPServer;
    //        //    int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
    //        //    string _subject = "Jepco Complain";
    //        //    string _toMail1 = txtEmail.Text;
    //        //    // string _toMail2 = txtMEmail.Text;
    //        //    string _toMail3 = ConfigurationManager.AppSettings["ComplainAdminTo"].ToString();
    //        //    bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
    //        //    string _ccMail = ConfigurationManager.AppSettings["ComplainAdminCC1"].ToString() + "," + ConfigurationManager.AppSettings["ComplainAdminCC2"].ToString() + "," + ConfigurationManager.AppSettings["ComplainAdminCC3"].ToString();

    //        //    string bodyContent = SettingResult.List[0].UserComplainMail;
    //        //    bodyContent = bodyContent.Replace("{C_Name}", txtfirstName.Text);
    //        //    //bodyContent = bodyContent.Replace("{FormDetails}", "");
    //        //    string _Body = bodyContent;


    //        //    string _BodyForAdmin = "<h1>Complain</h1>" +
    //        //                  "<p> Name : " + txtfirstName.Text + " " + txtSecondNAme.Text + " " + txtThirdName.Text + " " + txtFamilyName.Text + "</p>" +
    //        //                  "<p>Complain Type : " + ddlComplainType.SelectedItem.ToString() + "</p>"+
    //        //                  "<p>Complain Title : "+ txtComplianTitle.Text + " </p>" + "<p>Complain Details: " + txtComplainDetail.Text + " </p>";


    //        //    string bodyContent2 = SettingResult.List[0].ComplainMail;
    //        //    bodyContent2 = bodyContent2.Replace("{Name}", txtfirstName.Text);
    //        //    bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
    //        //    string _Body2 = bodyContent2;

    //        //    try
    //        //    {

    //        //        SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
    //        //        //SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
    //        //        SendMail2(UserName, _toMail3, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


    //        //    }
    //        //    catch { }

    //        //}
    //        #endregion

    //        mpeInquiry.Show();
    //    }



    //    #endregion

    //}

    #region 
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
                mailMessage.To.Add("laluram54@gmail.com");
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
            SmtpServer.EnableSsl = ssl;
            SmtpServer.UseDefaultCredentials = false;

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
    #endregion

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}