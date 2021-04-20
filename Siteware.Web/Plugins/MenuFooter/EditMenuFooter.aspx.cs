using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Siteware.Web.Plugins.MenuFooter
{
    public partial class EditMenuFooter : System.Web.UI.Page
    {
        string PageName = "Menu Footer";

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
                Session["IDSelectPage"] = "~/Plugins/MenuFooter/ManageMenuFooter.aspx";

            }
        }
        protected async void FillDetails()
        {
            if (Session["MenuFooterIDSession"] != null)
            {
                int MenuFooterID = Convert.ToInt32(Session["MenuFooterIDSession"]);

                ResultEntity<MenuFooterEntity> Result = new ResultEntity<MenuFooterEntity>();

                Result = await MenuFooterDomain.GetMenuFooterByID(MenuFooterID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    lblMenuFootername1.Text = Result.Entity.Title;
                    lblMenuFootername2.Text = Result.Entity.Title;
                    txtURL.Text = Result.Entity.URL;
                    ddlTargetID.SelectedValue = Result.Entity.Target.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                }
            }

        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("m12");
                if (Page.IsValid)
                {
                    MenuFooterEntity entity = new MenuFooterEntity();
                    if (Session["MenuFooterIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["MenuFooterIDSession"]);
                        entity.Title = txtTitle.Text;
                        entity.URL = txtURL.Text;
                        entity.Target = ddlTargetID.SelectedValue;

                        entity.LanguageID = 1;
                        entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        entity.IsPublished = CBIsPublished.Checked;
                        entity.IsDeleted = false;
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await MenuFooterDomain.Update(entity);
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
            Response.Redirect("~/Plugins/MenuFooter/ManageMenuFooter.aspx", false);
        }
    }
}