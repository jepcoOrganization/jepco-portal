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
using System.Globalization;

namespace Siteware.Web.Pages
{
    public partial class EditBanner : System.Web.UI.Page
    {
        string PageName = "Banners";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!FunctionSecurity.TestUserPermissionPage(SessionManager.GetInstance.Users.UserID, PageName))
                //{

                //    Response.Redirect("~/DashBoard.aspx", false);
                //}

                if (!IsPostBack)
                {
                    if (SessionManager.GetInstance.Users != null)
                    {
                        // divpageurl.Visible = false;
                        FillNavigation();
                        FillBannerType();
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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/Banners/ManagePages.aspx";
            }
        }
        protected async void FillBannerType()
        {
            ddlBannerCtg.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<BannerTypeEntity> Result = new ResultList<BannerTypeEntity>();
            Result = await BannerTypeDomain.GetBodyBannerAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (BannerTypeEntity item in Result.List)
                {

                    ddlBannerCtg.Items.Add(new ListItem(item.BannerName.ToString(), item.ID.ToString()));

                }
            }
        }
        protected async void FillDetails()
        {
            if (Session["BodyBannerIDSession"] != null)
            {
                int BodyBannerID = Convert.ToInt32(Session["BodyBannerIDSession"]);

                ResultEntity<PluginBannerEntity> Result = new ResultEntity<PluginBannerEntity>();

                Result = await PluginBannerDomain.GetPluginBannerByID(BodyBannerID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtPageName.Text = Result.Entity.Title;
                    ddlTarget.SelectedValue = Result.Entity.Target;
                   // txtMetaTitle.Text = Result.Entity.ImageTitle;
                    txtTitle2.Text = Result.Entity.LinkTitle;
                    txtLinkName.Text = Result.Entity.LinkTitle;
                    txtLink.Text = Result.Entity.Link;
                    // txtMetaDescription.Text = Result.Entity.AltIamge;
                    // txtSammery.Text  
                    txtDescription.Text= Result.Entity.Sammery;
                    ddlBannerCtg.SelectedValue = Result.Entity.CategoryID.ToString();

                    ddLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtorderr.Text = Result.Entity.BannerOrder.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    if ((Result.Entity.BannerImage != null && Result.Entity.BannerImage != "") ||
                        (Result.Entity.IconImage != null && Result.Entity.IconImage != ""))
                    {
                        ImagePage.ImageUrl = Result.Entity.BannerImage.ToString();
                        newWinField.Value = Result.Entity.BannerImage.ToString();
                       // imgSchoolIcon.ImageUrl = Result.Entity.IconImage.ToString();
                        //newWinField2.Value = Result.Entity.IconImage.ToString();
                    }
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            PluginBannerEntity entity = new PluginBannerEntity();
            if (Session["BodyBannerIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["BodyBannerIDSession"]);
                entity.Sammery = txtDescription.Text; //txtSammery.Text.ToString();
                entity.Title = txtPageName.Text;
                entity.Link = txtLink.Text;
                entity.BannerImage = newWinField.Value.ToString();
                entity.IconImage = string.Empty; //newWinField2.Value.ToString();
                entity.Target = ddlTarget.SelectedValue;
                entity.CategoryID = Convert.ToInt32(ddlBannerCtg.SelectedValue);
                entity.IsDeleted = false;
                entity.LanguageID = Convert.ToInt32(ddLanguages.SelectedValue);
                entity.LinkTitle = txtTitle2.Text; //txtLinkName.Text;              
                entity.ImageTitle = string.Empty; // txtMetaTitle.Text;
                entity.AltIamge = string.Empty; // txtMetaDescription.Text;
               // entity.AddDate = Convert.ToDateTime(DateTime.Now);
               // entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
              
                entity.BannerOrder = int.Parse(txtorderr.Text);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                entity.Link1 = string.Empty;
                entity.Target1 = string.Empty;
                entity.Link2 = string.Empty;
                entity.Target2 = string.Empty;
                entity.LinkImage1 = string.Empty;
                entity.LinkImage2 = string.Empty;

                var Result = await PluginBannerDomain.UpdatePluginBanner(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Banners/ManageBanner.aspx", false);
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