using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;

namespace Siteware.Web.Setting
{
    public partial class AddSetting : System.Web.UI.Page
    {
        string PageName = "Settings";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!FunctionSecurity.TestUserPermissionPage(SessionManager.GetInstance.Users.UserID, PageName))
                {

                    Response.Redirect("~/DashBoard.aspx", false);
                }

                if (!IsPostBack)
                {
                    if (SessionManager.GetInstance.Users != null)
                    {
                        FillNavigation();
                        FillLanguages();
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Redirect("~/Login.aspx", false);
                    }
                }
            }
            catch
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/Login.aspx", false);

            }
        }
        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liSettings = (HtmlGenericControl)masterPage.FindControl("liSettings");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liSettings.Attributes.Add("class", "active");
                Session["IDSelectPage"] = "~/Setting/ManageSetting.aspx";

            }
        }
        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            HeadlineImage.Attributes.Add("class", "ui-tabs-active ui-state-active");
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            SettingEntity entity = new SettingEntity();

            entity.Logo = newWinField.Value.ToString();
            entity.FooterLogo = newWinField2.Value.ToString();
            entity.Website = txtwebsite.Text;
            entity.GoogleAnalytic = txtGoogleAnalytic.Text;
            if (RadioButton1.Checked)
            {
                entity.DateFormat = RadioButton1.Text;
            }
            if (RadioButton2.Checked)
            {
                entity.DateFormat = RadioButton2.Text;
            }
            entity.Longitude = txtLongitude.Text;
            entity.Latitude = txtLatitude.Text;
            entity.SMTPServer = txtSMTPServer.Text;
            entity.Email = txtEmail.Text;
            entity.PasswordEmail = txtPassword.Text;
            entity.Year = txtYear.Text;
            entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
            entity.PageName = txtPageName.Text;
            entity.CopyRights = txtContentHTML.Text;
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDeleted = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.PortNumber = txtPortNumber.Text;
            entity.WorkingHours = txtWorkingHours.Text;
            entity.IsEnableSSL = cbEnableSSL.Checked;
            entity.FromMail = txtFromemail.Text;
            entity.MailContent = txtEmailContent.Text;
            entity.UserMailContent = txtUserEmailContent.Text;

            entity.RenewableDeviceAdminMail = txtDeviceAdmin.Text;
            entity.RenewableDeviceUserMail = txtDeviceUser.Text;

            entity.RenewableSolarCellAdminMail = txtSolarAdmin.Text;
            entity.RenewableSolarCellUserMail = txtSolarUser.Text;

            entity.RenewableRegistrationAdminMail = txtRegistrationAdmin.Text;
            entity.RenewableRegistrationUserMail = txtRegistrationUser.Text;
            entity.ForgetPasswordAdmin = txtForgetPasswordAdmin.Text;
            entity.ForgetPasswordUser = txtForgetPasswordUser.Text;


            ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
            SettingResult = await SettingDomain.GetSettingAll();
            if (SettingResult.Status == ErrorEnums.Success)
            {
                byte langID = Convert.ToByte(ddlLanguages.SelectedValue);
                var t = SettingResult.List.FirstOrDefault(q => q.LanguageID == langID);

                if (t != null)
                {                    
                   mpeInformation.Show();
                }
                else
                {
                    var Result = await SettingDomain.InsertSetting(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                
            }

           
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Setting/ManageSetting.aspx", false);
        }

        protected async void CBIsPublished_CheckedChanged(object sender, EventArgs e)
        {
            ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
            Result = await SettingDomain.GetSettingAll();
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (SettingEntity item in Result.List)
                {
                    if (item.IsPublished == true && item.LanguageID == Convert.ToInt16(ddlLanguages.SelectedValue))
                    {
                        mpeInformation.Show();
                    }
                }
            }
        }

        protected void btnInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Setting/ManageSetting.aspx", false);
        }

        protected async void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }

        }
    }
}