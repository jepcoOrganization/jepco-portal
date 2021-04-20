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
    public partial class AddServiceTab : System.Web.UI.Page
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
                Session["IDSelectPage"] = "~/Plugins/ServiceTab/ManageServiceTab.aspx";

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
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("d1");
                if (Page.IsValid)
                {
                    PluginServiceTabEntity entity = new PluginServiceTabEntity();
                    
                    entity.Title = txtTitle.Text;                    
                    entity.Image = newWinField.Value;
                    entity.Image2 = newWinField1.Value;
                    entity.Order = Convert.ToInt64(txtorderr.Text);
                    entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.IsDeleted = false;
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = await PluginServiceTabDomain.InsertDataPoint(entity);
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
            Response.Redirect("~/Plugins/ServiceTab/ManageServiceTab.aspx", false);
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);               
            }
            catch (Exception ex)
            {
            }
        }
    }
}