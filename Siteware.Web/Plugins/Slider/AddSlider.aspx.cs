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
using System.Net;
using System.IO;
using System.Globalization;

namespace Siteware.Web.Pages
{
    public partial class AddSlider : System.Web.UI.Page
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
                        FillLanguages();
                   // divpageurl.Visible = false; 
                }
                else
                {

                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx",false);
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
            PluginSliderEntity entity = new PluginSliderEntity(); 
            string responseFromServer = "";

            responseFromServer = newWinField.Value.ToString(); 
             
            entity.Title = txtPageName.Text;
            entity.Image = responseFromServer.ToString();
            entity.Target = ddlParentPage.SelectedValue;
            entity.Sammery = txtDescription.Text;

            entity.IsDeleted = false;
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.ImageTitle = txtMetaTitle.Text;
            entity.AltIamge = txtMetaDescription.Text;

            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID;
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID;

            entity.Link = txtLink.Text;
            entity.Order =Convert.ToInt32(txtOredr.Text);
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsPublish = CBIsPublish.Checked;
            entity.IconImage =string.Empty;

            var Result = await PluginSliderDomain.InsertSlider(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                
                mpeSuccess.Show();
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Slider/ManageSlider.aspx",false);
        }
         
    }
}