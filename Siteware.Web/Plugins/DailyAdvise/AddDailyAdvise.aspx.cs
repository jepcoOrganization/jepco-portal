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

namespace Siteware.Web.Plugins.DailyAdvise
{
    public partial class AddDailyAdvise : System.Web.UI.Page
    {
        string PageName = "DailyAdvise";
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
                Session["IDSelectPage"] = "~/Plugins/DailyAdvise/ManageDailyAdvise.aspx";

                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
            }
        }

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            Plugin_DailyAdviseEntity entity = new Plugin_DailyAdviseEntity();
            entity.Title = txtTitle.Text;
            entity.Summary = txtSummary.Text;
            entity.Image = newWinField.Value.ToString();
            entity.Link = txtLink.Text;
            entity.DateTo = DateTime.ParseExact(txtDateTo.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.DateFrom = DateTime.ParseExact(txtDateFrom.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDeleted = false;
            entity.Order = Convert.ToInt32(txtorderr.Text);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.Target = ddlParentPage.SelectedValue;

            var Result = await Plugin_DailyAdviseDomain.Insert(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/DailyAdvise/ManageDailyAdvise.aspx", false);
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