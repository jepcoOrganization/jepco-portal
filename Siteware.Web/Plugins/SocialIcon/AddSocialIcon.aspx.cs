using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;

namespace Siteware.Web.Pages
{
    public partial class AddSocialIcon : System.Web.UI.Page
    {
        string PageName = "Social Icon";

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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/SocialIcon/ManageSocialIcon.aspx";

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


        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("s4");
                if (Page.IsValid)
                {
                    PluginSocialIconEntity entity = new PluginSocialIconEntity();
                    entity.Title = txtPageName.Text;
                    entity.Link = txtLink.Text;
                    entity.Image = newWinField.Value.ToString();
                    entity.Target = ddlParentPage.SelectedValue;
                    entity.Imageover = newWinField2.Value.ToString();
                    entity.IsDeleted = false;
                    entity.IconOrder = Convert.ToInt32(txtOrder.Text);
                    entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                    entity.ImageTitle = string.Empty;//txtMetaTitle.Text;
                    entity.AltIamge = string.Empty; //txtMetaDescription.Text;
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = await PluginSocialIconDomain.InsertPluginSocialIcon(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {

                        mpeSuccess.Show();
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
            Response.Redirect("~/Plugins/SocialIcon/ManageSocialIcon.aspx", false);
        }

    }
}