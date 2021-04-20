using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
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
    public partial class AddSubFooterNavigation : System.Web.UI.Page
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
                        if (Session["MenuFooterIDSession"] != null && Session["FooterLanguageID"] != null)
                        {
                            lblLanguageID.Value = Session["FooterLanguageID"].ToString();
                            FooterNavID.Value = Session["MenuFooterIDSession"].ToString();
                        }
                       // FillLanguages();
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

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            if (Session["MenuFooterIDSession"] != null && Session["FooterLanguageID"] != null)
            {
                FooterNavigationEntity entity = new FooterNavigationEntity();

                entity.Title = txtTitle.Text;
                entity.URL = txtURL.Text;
                entity.Target = ddlTargetID.SelectedValue;
                entity.LanguageID = Convert.ToByte(lblLanguageID.Value);
                entity.MenuOrder = Convert.ToInt32(txtMenuOrder.Text);
                entity.IsPublished = CBIsPublished.Checked;
                entity.ParentID = Convert.ToInt32(FooterNavID.Value);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsDeleted = false;
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await FooterNavigationDomain.InsertFooter(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
            else
            {
            }
                
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FooterNavigation/SubFooterNavigation/ManageSubFooterNavigation.aspx", false);
        }
    }
}