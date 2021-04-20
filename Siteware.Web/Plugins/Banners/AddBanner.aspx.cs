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
    public partial class AddBanner : System.Web.UI.Page
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
                        FillBannerType();
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
                Session["IDSelectPage"] = "~/Plugins/Banners/ManagePages.aspx";
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
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            PluginBannerEntity entity = new PluginBannerEntity();
            entity.Sammery = txtDescription.Text; //txtSammery.Text.ToString();
            entity.Title = txtTitle1.Text;
            entity.Link = txtLink.Text;
            entity.BannerImage = newWinField.Value.ToString();
            entity.IconImage = string.Empty; // newWinField2.Value.ToString();
            entity.LinkTitle = txtTitle2.Text; //txtlinkName.Text;
            entity.Target = ddlParentPage.SelectedValue;
            entity.CategoryID = Convert.ToInt32(ddlBannerCtg.SelectedValue);
            entity.IsDeleted = false;
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.ImageTitle = string.Empty;// txtMetaTitle.Text;
            entity.AltIamge = string.Empty;// txtMetaDescription.Text;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
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


            var Result = await PluginBannerDomain.InsertPluginBanner(entity);
            if (Result.Status == ErrorEnums.Success)
            {

                mpeSuccess.Show();
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Banners/ManageBanner.aspx", false);
        }

        //protected void ddlBannerCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int SelectedBannerId = Convert.ToInt32(ddlBannerCtg.SelectedValue);
        //    if (SelectedBannerId == 1)
        //    {
        //        liSummary.Visible = true;
        //        a2.Visible = true;
        //        //Summerytxt.Visible = true; // a-2
        //        //a2.Visible = true;
        //        //formTitle2.Visible = false;
        //        //BannesImage.Visible = false;// a-3
        //        //a3.Visible = false;
        //        //a2.Style.Add("display", "none");
        //    }
        //    else if(SelectedBannerId == 5)
        //    {
        //        formTitle2.Visible = true;
        //        Summerytxt.Visible = true;
        //        a2.Visible = true;
        //        BannesImage.Visible = true;
        //        a3.Visible = true;
        //    }
        //    else if (SelectedBannerId == 3)
        //    {
        //        Summerytxt.Visible = true;
        //        a2.Visible = true;
        //        formTitle2.Visible = false;
        //        BannesImage.Visible = false;
        //        a3.Visible = false;

        //    }
        //    else
        //    {
        //        formTitle2.Visible = false;
        //        Summerytxt.Visible = false;
        //        a2.Visible = false;
        //        BannesImage.Visible = false;
        //        a3.Visible = false;
        //    }

        //}
    }
}