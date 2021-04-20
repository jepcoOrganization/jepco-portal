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
using System.IO;

namespace Siteware.Web.SecondNavigation
{
    public partial class EditSecondNavigation : System.Web.UI.Page
    {
        string PageName = "Second Navigation";

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
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liSceNav");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");
                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                //ulNav.Attributes.Add("style", "display: block;");
            Session["IDSelectPage"] = "~/Navigation/ManageNavigation.aspx";

            }

        }
        protected async void FillDetails()
        {
            if (Session["SecondNavigationIDSession"] != null)
            {
                int NavigationID = Convert.ToInt32(Session["SecondNavigationIDSession"]);

                ResultEntity<SecondNavigationEntity> Result = new ResultEntity<SecondNavigationEntity>();

                Result = await SecondNavigationDomain.GetNavigationByID(NavigationID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtMenuName.Text = Result.Entity.MenuName;
                    newWinField.Value = Result.Entity.Icon;
                    ImagePage.ImageUrl = Result.Entity.Icon;
                    lblNavigationName1.Text = Result.Entity.MenuName;
                    lblNavigationName2.Text = Result.Entity.MenuName;
                    txtMenuURL.Text = Result.Entity.URL;
                    ddlTargetID.SelectedValue = Result.Entity.TargetID.ToString();
                    ddrMenuType.SelectedValue = Result.Entity.MenuType.ToString();
                    txtMenuOrder.Text = Result.Entity.MenuOrder.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    ddNewsLanguages.SelectedValue = Result.Entity.LanguageID.ToString();

                }
            }


        }

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            SecondNavigationEntity entity = new SecondNavigationEntity();
            if (Session["SecondNavigationIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["SecondNavigationIDSession"]);
                entity.MenuName = txtMenuName.Text;
                entity.URL = txtMenuURL.Text;
                entity.Icon = newWinField.Value.ToString();
                //entity.Icon = string.Empty;
                entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
                entity.MenuType = Convert.ToInt32(ddrMenuType.SelectedValue);
                entity.MenuOrder = Convert.ToByte(txtMenuOrder.Text);
                entity.LanguageID = Convert.ToByte(ddNewsLanguages.SelectedValue);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await SecondNavigationDomain.UpdateNavigation(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SecondNavigation/ManageSecondNavigation.aspx", false);
        }

        protected async void FillLanguages()
        {
            ddNewsLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddNewsLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }
        }
    }
}