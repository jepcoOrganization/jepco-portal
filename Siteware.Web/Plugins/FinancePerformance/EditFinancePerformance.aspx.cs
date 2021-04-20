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

namespace Siteware.Web.Plugins.FinancePerformance
{
    public partial class EditFinancePerformance : System.Web.UI.Page
    {
        string PageName = "FinancePerformance";
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
                Session["IDSelectPage"] = "~/Plugins/FinancePerformance/ManagFinancePerformance.aspx";
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

        protected async void FillDetails()
        {
            if (Session["FinanceIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["FinanceIDSession"]);

                ResultEntity<Plugin_FinancePerformanceEntity> Result = new ResultEntity<Plugin_FinancePerformanceEntity>();

                Result = await Plugin_FinancePerformanceDomain.GetByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    txtSummary.Text = Result.Entity.Summary;
                    txtURL.Text = Result.Entity.Link;
                    ddlTargetID.SelectedValue = Result.Entity.Target;
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtMenuOrder.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //if (Result.Entity.Image != null && Result.Entity.Image != "")
                    //{
                    //    ImagePage.ImageUrl = Result.Entity.Image.ToString();
                    //    newWinField.Value = Result.Entity.Image.ToString();
                    //}
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            Plugin_FinancePerformanceEntity entity = new Plugin_FinancePerformanceEntity();
            if (Session["FinanceIDSession"] != null)
            {
                entity.FinanceID = Convert.ToInt32(Session["FinanceIDSession"]);
                entity.Title = txtTitle.Text;
                entity.Summary = txtSummary.Text;
                entity.Image = string.Empty; //newWinField.Value.ToString();
                entity.Title2 = string.Empty;
                entity.Description = string.Empty;
                entity.IsDeleted = false;
                entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                entity.Link = txtURL.Text;
                entity.ParentID = 0;
                entity.Order = Convert.ToInt32(txtMenuOrder.Text);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.Target = ddlTargetID.SelectedValue;

                var Result = await Plugin_FinancePerformanceDomain.Update(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
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
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FinancePerformance/ManageFinancePerformance.aspx", false);
        }

    }
}