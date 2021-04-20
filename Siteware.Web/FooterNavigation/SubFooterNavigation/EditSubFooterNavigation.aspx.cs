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

namespace Siteware.Web.FooterNavigation.SubFooterNavigation
{
    public partial class EditSubFooterNavigation : System.Web.UI.Page
    {
        string PageName = "Footer Navigation";

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
                        //FillLanguages();
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
                Session["IDSelectPage"] = "~/FooterNavigation/ManageMenuFooter.aspx";

            }
        }
        //protected async void FillLanguages()
        //{
        //    ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

        //    ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
        //    Result = await LanguageDomain.GetLanguagesAll();

        //    if (Result.Status == ErrorEnums.Success)
        //    {
        //        foreach (LanguageEntity item in Result.List)
        //        {
        //            ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
        //        }
        //    }
        //}
        protected async void FillDetails()
        {
            if (Session["SubFooterIDSession"] != null)
            {
                int MenuFooterID = Convert.ToInt32(Session["SubFooterIDSession"]);

                ResultEntity<FooterNavigationEntity> Result = new ResultEntity<FooterNavigationEntity>();

                Result = await FooterNavigationDomain.GetFooterByID(MenuFooterID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    lblMenuFootername1.Text = Result.Entity.Title;
                    lblMenuFootername2.Text = Result.Entity.Title;
                    txtMenuOrder.Text = Result.Entity.MenuOrder.ToString();
                    txtURL.Text = Result.Entity.URL;
                    ddlTargetID.SelectedValue = Result.Entity.Target.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    //ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    lblLanguageID.Value = Result.Entity.LanguageID.ToString();
                    FooterNavID.Value = Result.Entity.ParentID.ToString();
                }
            }
        }

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            FooterNavigationEntity entity = new FooterNavigationEntity();
            if (Session["SubFooterIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["SubFooterIDSession"]);
                entity.Title = txtTitle.Text;
                entity.URL = txtURL.Text;
                entity.Target = ddlTargetID.SelectedValue;
                entity.LanguageID = Convert.ToByte(lblLanguageID.Value);
                entity.MenuOrder = Convert.ToInt32(txtMenuOrder.Text);
                entity.ParentID = Convert.ToInt32(FooterNavID.Value);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await FooterNavigationDomain.Update(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FooterNavigation/SubFooterNavigation/ManageSubFooterNavigation.aspx", false);
        }
    }
}