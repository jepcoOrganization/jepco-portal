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

namespace Siteware.Web.Plugins.ServiceTab
{
    public partial class EditServiceTab : System.Web.UI.Page
    {
        string PageName = "ServiceTab";

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
                Session["IDSelectPage"] = "~/Plugins/ServiceTab/ManageServiceTab.aspx";

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
        protected void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = LanguageDomain.GetLanguagesAllNotAsync();

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
            if (Session["ServiceTabIDSession"] != null)
            {
                int AnnouncementID = Convert.ToInt32(Session["ServiceTabIDSession"]);

                ResultEntity<PluginServiceTabEntity> Result = new ResultEntity<PluginServiceTabEntity>();

                Result = await PluginServiceTabDomain.GetDataPointByID(AnnouncementID);
                if (Result.Status == ErrorEnums.Success)
                {
                    lblTitle.Text = Result.Entity.Title;
                    lblPageHead.Text = Result.Entity.Title;

                    lblServiceTabID.Value = Result.Entity.ID.ToString();                   
                    lblLangID.Value = Result.Entity.LanguageID.ToString();

                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();                                       
                    newWinField.Value = Result.Entity.Image;
                    ImagePage.ImageUrl = Result.Entity.Image;
                    newWinField1.Value = Result.Entity.Image2;
                    ImagePage1.ImageUrl = Result.Entity.Image2;

                    txtTitle.Text = Result.Entity.Title;                   
                    txtorderr.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                }
            }
        }       
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("d1");
                if (Page.IsValid)
                {
                    PluginServiceTabEntity entity = new PluginServiceTabEntity();
                    if (Session["ServiceTabIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["ServiceTabIDSession"]);
                        entity.Image = newWinField.Value;
                        entity.Image2 = newWinField1.Value;
                        entity.Title = txtTitle.Text.Trim();
                        
                        entity.Order = Convert.ToInt64(txtorderr.Text);
                        entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                        entity.IsPublished = CBIsPublished.Checked;
                        entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);                        
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await PluginServiceTabDomain.UpdateDataPoint(entity);
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
            Response.Redirect("~/Plugins/ServiceTab/ManageServiceTab.aspx", false);
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                int LID = Convert.ToInt32(lblLangID.Value);              
            }
            catch
            {

            }
        }
    }
}