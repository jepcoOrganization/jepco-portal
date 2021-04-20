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

namespace Siteware.Web.Navigation.SubMenu
{
    public partial class AddSubMenu : System.Web.UI.Page
    {
        string PageName = "Main Navigation";
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
                        FillParentMenu();
                        FillListPages();
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
        protected async void FillListPages()
        {
            ddListPages.Items.Insert(0, new ListItem("-- Please Select --", "#"));
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (PagesEntity item in Result.List)
                {

                    ddListPages.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));

                }
            }
        }
        protected void butOkPages_Click(object sender, EventArgs e)
        {
            if (ddListPages.SelectedValue != "#")
            { txtMenuURL.Text = ddListPages.SelectedValue; }
        }
        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liNavigation");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");
                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                //ulNav.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Navigation/ManageNavigation.aspx";

            }
        }
        protected async void FillParentMenu()
        {
            if (Session["NavigationIDSession"] != null && Session["NavigationIDSession"] != "")
            {
                int NavigationID = Convert.ToInt32(Session["NavigationIDSession"]);

                ResultEntity<NavigationEntity> Result = new ResultEntity<NavigationEntity>();
                Result = await NavigationDomain.GetNavigationByID(NavigationID);

                if (Result.Status == ErrorEnums.Success)
                {
                    ddlParentMenu.Items.Add(new ListItem(Result.Entity.MenuName.ToString(), Result.Entity.ID.ToString()));
                }
            }
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            NavigationEntity entity = new NavigationEntity();

            entity.MenuName = txtMenuName.Text;
            entity.URL = txtMenuURL.Text;
            //entity.MenuSummary = string.Empty;
            entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
            entity.ParentID = Convert.ToInt32(ddlParentMenu.SelectedValue);
            entity.MenuOrder = Convert.ToByte(txtMenuOrder.Text);
            entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue); 
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsPublished = CBIsPublished.Checked;
            entity.IsDeleted = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.MenuTitle = string.Empty;
            entity.MenuImage = string.Empty;
            entity.HoverImage = string.Empty;
            entity.Summary = string.Empty;
            entity.Summary2 = string.Empty;

            var Result = await NavigationDomain.InsertNavigation(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Navigation/SubMenu/ManageSubMenu.aspx", false);
        }
    }
}