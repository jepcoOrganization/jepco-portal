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
    public partial class EditSubMenu : System.Web.UI.Page
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
                        FillLanguages();
                        FillDetails();
                        FillListPages();
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
        protected async void FillDetails()
        {
            if (Session["SubMenuIDSession"] != null)
            {
                int NavigationID = Convert.ToInt32(Session["SubMenuIDSession"]);

                ResultEntity<NavigationEntity> Result = new ResultEntity<NavigationEntity>();

                Result = await NavigationDomain.GetNavigationByID(NavigationID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtMenuName.Text = Result.Entity.MenuName;
                    lblSubMenuName1.Text = Result.Entity.MenuName;
                    lblSubMenuName2.Text = Result.Entity.MenuName;
                    txtMenuURL.Text = Result.Entity.URL;
                    ddlTargetID.SelectedValue = Result.Entity.TargetID.ToString();
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    ddlParentMenu.SelectedValue = Result.Entity.ParentID.ToString();
                    txtMenuOrder.Text = Result.Entity.MenuOrder.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    ddListPages.SelectedValue = Result.Entity.URL;
                }
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
            if (Session["SubMenuIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["SubMenuIDSession"]);
                entity.MenuName = txtMenuName.Text;
              //  entity.MenuSummary = string.Empty;
                entity.URL = txtMenuURL.Text;
                entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
                entity.ParentID = Convert.ToByte(ddlParentMenu.SelectedValue);
                entity.MenuOrder = Convert.ToByte(txtMenuOrder.Text);
                entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue); ;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.MenuTitle = string.Empty;
                entity.MenuImage = string.Empty;
                entity.HoverImage = string.Empty;
                entity.Summary = string.Empty;
                entity.Summary2 = string.Empty;



                var Result = await NavigationDomain.UpdateNavigation(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Navigation/SubMenu/ManageSubMenu.aspx", false);
        }

        protected void butOkPages_Click(object sender, EventArgs e)
        {
            if (ddListPages.SelectedValue != "#")
            { txtMenuURL.Text = ddListPages.SelectedValue; }
        }
    }
}