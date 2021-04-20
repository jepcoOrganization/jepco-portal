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

namespace Siteware.Web.Pages
{
    public partial class EditContactUs : System.Web.UI.Page
    {
        string PageName = "Contact Us";

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
                        // divpageurl.Visible = false;
                        FillNavigation();
                        FillLanguages();
                        FillDetails();
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
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/ContactUs/ManageContactUs.aspx";

            }
        }

        protected async void FillDetails()
        {
            if (Session["ContactUsIDSession"] != null)
            {
                int BodyBannerID = Convert.ToInt32(Session["ContactUsIDSession"]);

                ResultEntity<PluginContactUsEntity> Result = new ResultEntity<PluginContactUsEntity>();

                Result = await PluginContactUsDomain.GetPluginContactByID(BodyBannerID);
                if (Result.Status == ErrorEnums.Success)
                {
                    ImagePage.ImageUrl = Result.Entity.Image;
                    newWinField.Value = Result.Entity.Image;
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPageName.Text = Result.Entity.Title;
                    txtURL.Text = Result.Entity.URL;
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    ddlTarget.SelectedValue = Result.Entity.Target;
                    txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    txtorderr.Text = Result.Entity.Order.ToString();
                    txtLatitude.Text = Result.Entity.Latitude;
                    txtLongitude.Text = Result.Entity.Longitude;
                    txtTitles.Text = Result.Entity.Description;
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            PluginContactUsEntity entity = new PluginContactUsEntity();
            if (Session["ContactUsIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["ContactUsIDSession"]);
                entity.Title = txtPageName.Text;
                entity.Description = txtTitles.Text;
                entity.Image = newWinField.Value.ToString();
                entity.IsDeleted = false;
                entity.IsPublished = CBIsPublished.Checked;
                entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                entity.URL = txtURL.Text;
                entity.Order = Convert.ToInt32(txtorderr.Text);
                entity.Target = ddlTarget.SelectedValue;
                entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.Latitude = txtLatitude.Text;
                entity.Longitude = txtLongitude.Text;

                var Result = await PluginContactUsDomain.UpdateContact(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    var DeleteKeyword = await PagesKeywordDomain.DeleteKeywordByPageID(entity.ID);
                    if (DeleteKeyword.Status == ErrorEnums.Success)
                    {
                        
                    }
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ContactUs/ManageContactUs.aspx", false);
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