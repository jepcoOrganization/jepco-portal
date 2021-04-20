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

namespace Siteware.Web.Plugins.DataPoint
{
    public partial class AddDataPoint : System.Web.UI.Page
    {
        string PageName = "DataPoint";

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
                        ddlFocusArea.Items.Insert(0, new ListItem("Select Focus Area", "0"));
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
                Session["IDSelectPage"] = "~/Plugins/DataPoint/ManageDataPoint.aspx";

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
        protected async void FillFocusArea(int LangID)
        {
            ddlFocusArea.Items.Clear();
            ddlFocusArea.Items.Insert(0, new ListItem("Select Entity", "0"));

            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
            Result = await Plugin_FA_EntitiesDomain.GetAll();

            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.LanguageID == LangID && s.IsDelete == false).OrderBy(s => s.Order).ToList();
                foreach (Plugin_FA_EntitiesEntity item in Result.List)
                {
                    ddlFocusArea.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
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
                    PluginDataPointEntity entity = new PluginDataPointEntity();
                    entity.Image = newWinField.Value;
                    entity.FocusID = 0; // Convert.ToInt64(ddlFocusArea.SelectedValue);
                    entity.Title = txtTitle.Text;
                    entity.Link = txtLink.Text;
                    entity.Target = ddlParentPage.Text;
                    entity.Image = newWinField.Value;                   
                    entity.Points = txtPoints.Text;
                    entity.Summary = txtSummary.Text;
                    entity.Order = Convert.ToInt64(txtorderr.Text);
                    entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.IsDeleted = false;
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = await PluginDataPointDomain.InsertDataPoint(entity);
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
            Response.Redirect("~/Plugins/DataPoint/ManageDataPoint.aspx", false);
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                FillFocusArea(LangID);
            }
            catch (Exception ex)
            {
            }
        }
    }
}