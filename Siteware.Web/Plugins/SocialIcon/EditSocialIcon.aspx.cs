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
    public partial class EditSocialIcon : System.Web.UI.Page
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
                Session["IDSelectPage"] = "~/Plugins/SocialIcon/ManageSocialIcon.aspx";

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

        protected async void FillDetails()
        {
            if (Session["SocialIconIDSession"] != null)
            {
                int BodySocialIconID = Convert.ToInt32(Session["SocialIconIDSession"]);

                ResultEntity<PluginSocialIconEntity> Result = new ResultEntity<PluginSocialIconEntity>();

                Result = await PluginSocialIconDomain.GetPluginSocialIconByID(BodySocialIconID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtPageName.Text = Result.Entity.Title;
                    ddlTarget.SelectedValue = Result.Entity.Target;
                    //txtMetaTitle.Text = Result.Entity.ImageTitle;
                    txtLink.Text = Result.Entity.Link;
                    //txtMetaDescription.Text = Result.Entity.AltIamge;
                    txtOrder.Text = Result.Entity.IconOrder.ToString();
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();

                    if (Result.Entity.Image != null && Result.Entity.Image != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.Image.ToString();
                        newWinField.Value = Result.Entity.Image.ToString();
                    }
                    if (Result.Entity.Imageover != null && Result.Entity.Imageover != "")
                    {
                        ImagePage2.ImageUrl = Result.Entity.Imageover.ToString();
                        newWinField2.Value = Result.Entity.Imageover.ToString();
                    }
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("s5");
                if (Page.IsValid)
                {
                    PluginSocialIconEntity entity = new PluginSocialIconEntity();
                    if (Session["SocialIconIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["SocialIconIDSession"]);
                        entity.Title = txtPageName.Text;
                        entity.Image = newWinField.Value.ToString();
                        entity.Target = ddlTarget.SelectedValue;
                        entity.IsDeleted = false;
                        entity.Link = txtLink.Text;
                        entity.ImageTitle = string.Empty; //txtMetaTitle.Text;
                        entity.Imageover = newWinField2.Value.ToString();
                        entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                        entity.IconOrder = Convert.ToInt32(txtOrder.Text);
                        entity.AltIamge = string.Empty;//txtMetaDescription.Text;
                        entity.AddDate = Convert.ToDateTime(DateTime.Now);
                        entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await PluginSocialIconDomain.UpdatePluginSocialIcon(entity);
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
            Response.Redirect("~/Plugins/SocialIcon/ManageSocialIcon.aspx", false);
        }

    }
}