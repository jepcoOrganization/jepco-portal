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
    public partial class EditSetting : System.Web.UI.Page
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
                        FillDetails();

                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Redirect("~/Login.aspx");
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
        protected async void FillDetails()
        {
            if (Session["SettingIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["SettingIDSession"]);

                ResultEntity<SettingEntity> Result = new ResultEntity<SettingEntity>();

                Result = await SettingDomain.GetSettingByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    ImagePage.ImageUrl = Result.Entity.Logo;
                    newWinField.Value = Result.Entity.Logo;
                    ImageFooter.ImageUrl = Result.Entity.FooterLogo;
                    newWinField2.Value = Result.Entity.FooterLogo;
                    txtwebsite.Text = Result.Entity.Website;
                    txtGoogleAnalytic.Text = Result.Entity.GoogleAnalytic;
                    if (Result.Entity.DateFormat == "dd-MM-YYYY")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                    ddLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtPageName.Text = Result.Entity.PageName;
                    txtYear.Text = Result.Entity.Year;
                    txtContentHTML.Text = Result.Entity.CopyRights;
                    txtLongitude.Text = Result.Entity.Longitude;
                    txtLatitude.Text = Result.Entity.Latitude;
                    txtWorkingHours.Text = Result.Entity.WorkingHours;
                    txtSMTPServer.Text = Result.Entity.SMTPServer;
                    txtEmail.Text = Result.Entity.Email;
                    txtPassword.Text = Result.Entity.PasswordEmail;
                    txtPortNumber.Text = Result.Entity.PortNumber;
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtEmailContent.Text = Result.Entity.MailContent;
                    txtUserEmailContent.Text = Result.Entity.UserMailContent;
                    txtFromemail.Text = Result.Entity.FromMail;
                    cbEnableSSL.Checked = Result.Entity.IsEnableSSL;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                    txtDeviceAdmin.Text = Result.Entity.RenewableDeviceAdminMail;
                    txtDeviceUser.Text = Result.Entity.RenewableDeviceUserMail;

                    txtSolarAdmin.Text = Result.Entity.RenewableSolarCellAdminMail;
                    txtSolarUser.Text = Result.Entity.RenewableSolarCellUserMail;

                    txtRegistrationAdmin.Text = Result.Entity.RenewableRegistrationAdminMail;
                    txtRegistrationUser.Text = Result.Entity.RenewableRegistrationUserMail;

                    txtForgetPasswordAdmin.Text = Result.Entity.ForgetPasswordAdmin;
                    txtForgetPasswordUser.Text = Result.Entity.ForgetPasswordUser;

                }
            }


        }

        protected async void FillLanguages()
        {
            ddLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }

        }
        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            HeadlineImage.Attributes.Add("class", "ui-tabs-active ui-state-active");
        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            SettingEntity entity = new SettingEntity();
            if (Session["SettingIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["SettingIDSession"]);
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
                entity.Year = txtYear.Text;
                entity.PasswordEmail = txtPassword.Text;
                entity.LanguageID = Convert.ToByte(ddLanguages.SelectedValue);
                entity.PageName = txtPageName.Text;
                entity.CopyRights = txtContentHTML.Text;
                entity.WorkingHours = txtWorkingHours.Text;
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.PortNumber = txtPortNumber.Text;
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


                var Result = await SettingDomain.Update(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Setting/ManageSetting.aspx", false);
        }

        protected async void CBIsPublished_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["SettingIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["SettingIDSession"]);
                ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
                Result = await SettingDomain.GetSettingAll();
                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (SettingEntity item in Result.List)
                    {

                        if (item.IsPublished == true)
                        {
                            if (item.ID == ID)
                            {
                                mpeInformation.Show();
                            }
                        }
                    }
                }
            }

        }
        protected void btnInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Setting/ManageSetting.aspx", false);
        }
    }
}