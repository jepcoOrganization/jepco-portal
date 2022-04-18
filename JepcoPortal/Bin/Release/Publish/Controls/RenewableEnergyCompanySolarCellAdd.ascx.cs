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

public partial class Controls_RenewableEnergyCompanySolarCellAdd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;
            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

                Result = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
                if (Result.Status == ErrorEnums.Success)
                {

                    long CompanyId = Result.Entity.RenwabaleEnergyCompanyID;
                    hdnCompanyId.Value = CompanyId.ToString();
                    hdnemailId.Value = Result.Entity.EmailAddress;
                }
            }

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {



        long ServiceUserID = SessionManager.GetInstance.Users.ID;

        //    //---******* (For Local) ******-------------------------
       //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

        //    //---------------******* (For Live) ******-------------------------
       string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

        string guid = Guid.NewGuid().ToString().Substring(0, 6);


        RenewableEnergyCompanySolarCellEntity Entity = new RenewableEnergyCompanySolarCellEntity();

        try
        {
            //Here string ABCd is Entity of Table

            HttpPostedFile files1 = Request.Files["fileuploadfield_1"];
            if (files1 != null)
            {

                if (files1.FileName != "") // If file is Selected File
                {

                    string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                    //Entity.ChildPassport = dir + files1.FileName;

                    Entity.SolarCellDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files1.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files1.SaveAs(dir + files1.FileName);

                }
                else
                {
                    Entity.SolarCellDocument = string.Empty;
                }
            }
            else
            {
                Entity.SolarCellDocument = string.Empty;
            }
        }
        catch (Exception exp)
        {
            Console.Write("<script>console.log('fileuploadfield_1 :" + exp.Message + "');</script>");
        }



        try
        {
            //Here string ABCd is Entity of Table

            HttpPostedFile files2 = Request.Files["fileuploadfield_2"];
            if (files2 != null)
            {

                if (files2.FileName != "") // If file is Selected File
                {

                    string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                    //Entity.ChildPassport = dir + files1.FileName;

                    Entity.SolarCellDocument2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files2.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files2.SaveAs(dir + files2.FileName);

                }
                else
                {
                    Entity.SolarCellDocument2 = string.Empty;
                }
            }
            else
            {
                Entity.SolarCellDocument2 = string.Empty;
            }
        }
        catch (Exception exp)
        {
            Console.Write("<script>console.log('fileuploadfield_2 :" + exp.Message + "');</script>");
        }

        Entity.CompanyName = txtCompanyName.Text;
        Entity.ModelNo = txtModelNo.Text;
        Entity.DevicePower = txtDevicePower.Text;
        Entity.CountryOfOrigin = txtCountryOrigin.Text;
        Entity.Order = 0;
        Entity.LanguageID = 2;
        Entity.PublishDate = DateTime.Now;
        Entity.IsPublished = true;
        Entity.IsDeleted = false;
        Entity.AddDate = DateTime.Now;
        Entity.AddUser = ServiceUserID.ToString();
        Entity.EditDate = DateTime.Now;
        Entity.EditUser = ServiceUserID.ToString();
        Entity.Status = "2";
        Entity.IsApproved = true;
        Entity.CompanyID = Convert.ToInt64(hdnCompanyId.Value);

        var Result = RenewableEnergyCompanySolarCellDomain.InsertRecordNotAsync(Entity);
        if (Result.Status == ErrorEnums.Success)
        {

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
                string _subject = "Company Device Add Mail";
                string _toMail1 = hdnemailId.Value;
                string _toMail2 = ConfigurationManager.AppSettings["ToMailSolarCellAdmin"].ToString();

                bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                string _ccMail = ConfigurationManager.AppSettings["CCMailSolarCellAdmin1"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarCellAdmin2"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarCellAdmin3"].ToString();

                string bodyContent = SettingResult.List[0].RenewableDeviceUserMail;
                bodyContent = bodyContent.Replace("{Name}", "");
                bodyContent = bodyContent.Replace("{FormDetails}", "");
                string _Body = bodyContent;


                string _BodyForAdmin = "<h1>Company Device</h1>";

                string bodyContent2 = SettingResult.List[0].RenewableDeviceAdminMail;
                bodyContent2 = bodyContent2.Replace("{Name}", "");
                bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                string _Body2 = bodyContent2;

                try
                {

                    SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                    SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                }
                catch { }

            }
            #endregion

            mpeInquiry.Show();

        }

    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyCompanySolarCellList", false);
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
                mailMessage.To.Add("ajay.126186@gmail.com");
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

}