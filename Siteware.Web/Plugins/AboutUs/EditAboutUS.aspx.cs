using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.AboutUs
{
    public partial class EditAboutUS : System.Web.UI.Page
    {
        string PageName = "AboutUs";
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
                Session["IDSelectPage"] = "~/Plugins/Logo/ManageLogo.aspx";

            }
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
        protected async void btnUpdate2_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("a2");
                if (Page.IsValid)
                {
                    Plugin_AboutUsEntity entity = new Plugin_AboutUsEntity();
                    if (Session["AboutUsIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["AboutUsIDSession"]);
                        entity.Title = txtTitle.Text;
                        entity.Image = string.Empty;
                        entity.Link = txtLink.Text;
                        entity.Target = ddlTarget.SelectedValue;
                        entity.IsDeleted = false;
                        entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                        entity.Summary = txtSummary.Text;
                        entity.Order = Convert.ToInt32(txtorderr.Text);
                        entity.IsPublished = CBIsPublished.Checked;
                        entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        entity.AddDate = Convert.ToDateTime(DateTime.Now);
                        entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await Plugin_AboutUsDomain.UpdateAboutUs(entity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            mpeSuccess.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/AboutUs/ManageAboutUS.aspx");
        }
        protected async void FillDetails()
        {
            if (Session["AboutUsIDSession"] != null)
            {
                int BodyBannerID = Convert.ToInt32(Session["AboutUsIDSession"]);

                ResultEntity<Plugin_AboutUsEntity> Result = new ResultEntity<Plugin_AboutUsEntity>();
                Result = await Plugin_AboutUsDomain.GetByID(BodyBannerID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    txtLink.Text = Result.Entity.Link;
                    ddlTarget.SelectedValue = Result.Entity.Target;
                    txtSummary.Text = Result.Entity.Summary;
                    txtorderr.Text = Result.Entity.Order.ToString();
                    txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;                   
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                }
            }
        }
    }
}