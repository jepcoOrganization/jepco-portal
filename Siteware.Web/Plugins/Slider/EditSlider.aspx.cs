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
using System.Globalization;

namespace Siteware.Web.Pages
{
    public partial class EditSlider : System.Web.UI.Page
    {
        string PageName = "Slider";

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
                        // FillBannerType();
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

                Session["IDSelectPage"] = "~/Plugins/Slider/ManageSlider.aspx";

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

       
        protected async void FillDetails()
        {
            if (Session["SliderIDSession"] != null)
            {
                int BodyBannerID = Convert.ToInt32(Session["SliderIDSession"]);

                ResultEntity<PluginSliderEntity> Result = new ResultEntity<PluginSliderEntity>();

                Result = await PluginSliderDomain.GetSliderByID(BodyBannerID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtPageName.Text = Result.Entity.Title;
                    ddlTarget.SelectedValue = Result.Entity.Target;
                    txtMetaTitle.Text = Result.Entity.ImageTitle;
                    txtMetaDescription.Text = Result.Entity.AltIamge;

                    txtDescription.Text = Result.Entity.Sammery.ToString();
                    //txtPublishDate.Value = DateTime.Now.ToString();
                    //IsPublished.Checked = true;
                    txtOredr.Text = Result.Entity.Order.ToString();
                    ddLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    CBIsPublish.Checked = Result.Entity.IsPublish;
                    txtLink.Text = Result.Entity.Link;
                    txtPublishDate.Value=Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    if (Result.Entity.Image != null && Result.Entity.Image != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.Image.ToString();
                        newWinField.Value = Result.Entity.Image.ToString();
                    }                  
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {


            //if session has file 
            //take Image from session 
            //else
            //take Image from Image Src


            PluginSliderEntity entity = new PluginSliderEntity();
            if (Session["SliderIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["SliderIDSession"]);
                entity.Title = txtPageName.Text;
                entity.Image = newWinField.Value.ToString();
                entity.Target = ddlTarget.SelectedValue;
                entity.Sammery = txtDescription.Text;
                entity.Link = txtLink.Text;
                entity.Order = Convert.ToInt32(txtOredr.Text);
                entity.IsDeleted = false;
                entity.LanguageID = Convert.ToInt16(ddLanguages.SelectedValue);
                entity.ImageTitle = txtMetaTitle.Text;
                entity.AltIamge = txtMetaDescription.Text;

                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublish = CBIsPublish.Checked;

                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID;
                entity.IconImage = string.Empty;

                var Result = await PluginSliderDomain.UpdateSliderBanner(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Slider/ManageSlider.aspx");
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