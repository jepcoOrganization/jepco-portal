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

namespace Siteware.Web.Navigation
{
    public partial class EditNavigation : System.Web.UI.Page
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
            if (Session["NavigationIDSession"] != null)
            {
                int NavigationID = Convert.ToInt32(Session["NavigationIDSession"]);

                ResultEntity<NavigationEntity> Result = new ResultEntity<NavigationEntity>();

                Result = await NavigationDomain.GetNavigationByID(NavigationID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtMenuName.Text = Result.Entity.MenuName;
                   // txtMenuSummary.Text = Result.Entity.MenuSummary;
                    lblNavigationName1.Text = Result.Entity.MenuName;
                    lblNavigationName2.Text = Result.Entity.MenuName;
                    txtMenuURL.Text = Result.Entity.URL;
                    ddlTargetID.SelectedValue = Result.Entity.TargetID.ToString();
                    ddlParentMenu.SelectedValue = Result.Entity.ParentID.ToString();
                    txtMenuOrder.Text = Result.Entity.MenuOrder.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    ddLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtMenuTitle.Text = Result.Entity.MenuTitle;
                    txtSummary.Text = Result.Entity.Summary;
                    txtSummary2.Text = Result.Entity.Summary2;
                    chkShowUser.Checked = Result.Entity.ShowUser;
                    chkShowCompany.Checked = Result.Entity.ShowCompany;

                    if (Result.Entity.MenuImage != null && Result.Entity.MenuImage != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.MenuImage.ToString();
                        newWinField.Value = Result.Entity.MenuImage.ToString();
                    }

                    if (Result.Entity.HoverImage != null && Result.Entity.HoverImage != "")
                    {
                        ImagePage2.ImageUrl = Result.Entity.HoverImage.ToString();
                        newWinField2.Value = Result.Entity.HoverImage.ToString();
                    }
                                   

                }
            }


        }
        protected void FillParentMenu()
        {
            ddlParentMenu.Items.Insert(0, new ListItem("Home", "0"));

            //if (Session["NavigationIDSession"] != null)
            //{
            //    int NavigationID = Convert.ToInt32(Session["NavigationIDSession"]);

            //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
            //    Result = await NavigationDomain.GetNavigationByRootMenu();

            //    if (Result.Status == ErrorEnums.Success)
            //    {
            //        foreach (NavigationEntity item in Result.List)
            //        {
            //            if (NavigationID != item.ID)
            //            {
            //                ddlParentMenu.Items.Add(new ListItem(item.MenuName.ToString(), item.ID.ToString()));
            //            }

            //        }
            //    }
            //}

        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            NavigationEntity entity = new NavigationEntity();
            if (Session["NavigationIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["NavigationIDSession"]);
                entity.MenuName = txtMenuName.Text;
                //entity.MenuSummary = txtMenuSummary.Text;
                entity.URL = txtMenuURL.Text;
                entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
                entity.ParentID = Convert.ToByte(ddlParentMenu.SelectedValue);
                entity.MenuOrder = Convert.ToByte(txtMenuOrder.Text);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.LanguageID = Convert.ToByte(ddLanguages.SelectedValue);
                entity.MenuTitle = txtMenuTitle.Text;
                entity.Summary = txtSummary.Text;
                entity.MenuImage = newWinField.Value.ToString();
                entity.HoverImage = newWinField2.Value.ToString();
                entity.Summary2 = txtSummary2.Text;
                entity.ShowUser = chkShowUser.Checked;
                entity.ShowCompany = chkShowCompany.Checked;

                var Result = await NavigationDomain.UpdateNavigation(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Navigation/ManageNavigation.aspx", false);
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
    }
}