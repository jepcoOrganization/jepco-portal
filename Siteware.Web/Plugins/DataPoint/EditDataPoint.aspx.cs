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
    public partial class EditDataPoint : System.Web.UI.Page
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
                Session["IDSelectPage"] = "~/Plugins/DataPoint/ManageDataPoint.aspx";

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
        protected void FillFocusArea(int LangID)
        {
            ddlFocusArea.Items.Clear();
            ddlFocusArea.Items.Insert(0, new ListItem("Select Entity", "0"));

            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
            Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.LanguageID == LangID && s.IsDelete == false).OrderBy(s => s.Order).ToList();
                foreach (Plugin_FA_EntitiesEntity item in Result.List)
                {
                    ddlFocusArea.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
                }
            }
        }
        protected async void FillDetails()
        {
            if (Session["DataPointIDSession"] != null)
            {
                int AnnouncementID = Convert.ToInt32(Session["DataPointIDSession"]);

                ResultEntity<PluginDataPointEntity> Result = new ResultEntity<PluginDataPointEntity>();

                Result = await PluginDataPointDomain.GetDataPointByID(AnnouncementID);
                if (Result.Status == ErrorEnums.Success)
                {
                    lblTitle.Text = Result.Entity.Title;
                    lblPageHead.Text = Result.Entity.Title;

                    lblDataPointID.Value = Result.Entity.ID.ToString();
                    lblFocusID.Value = Result.Entity.FocusID.ToString();
                    lblLangID.Value = Result.Entity.LanguageID.ToString();

                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    FillFocusArea(Result.Entity.LanguageID);
                    ddlFocusArea.SelectedValue = Result.Entity.FocusID.ToString();
                    txtPoints.Text = Result.Entity.Points;
                    newWinField.Value = Result.Entity.Image;
                    ImagePage.ImageUrl = Result.Entity.Image;
                    txtTitle.Text = Result.Entity.Title;
                    txtSummary.Text = Result.Entity.Summary;
                    txtLink.Text = Result.Entity.Link;
                    ddlParentPage.SelectedValue = Result.Entity.Target;
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
                    PluginDataPointEntity entity = new PluginDataPointEntity();
                    if (Session["DataPointIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["DataPointIDSession"]);
                        entity.Image = newWinField.Value;
                        entity.Title = txtTitle.Text.Trim();
                        entity.Link = txtLink.Text.Trim();
                        entity.Points = txtPoints.Text.Trim();
                        entity.FocusID = 0; // Convert.ToInt64(ddlFocusArea.SelectedValue);
                        entity.Target = ddlParentPage.SelectedValue;
                        entity.Summary = txtSummary.Text;
                        entity.Order = Convert.ToInt64(txtorderr.Text);
                        entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                        entity.IsPublished = CBIsPublished.Checked;
                        entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);                        
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await PluginDataPointDomain.UpdateDataPoint(entity);
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
            Response.Redirect("~/Plugins/DataPoint/ManageDataPoint.aspx", false);
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                int LID = Convert.ToInt32(lblLangID.Value);
                FillFocusArea(LangID);
                if (LangID == LID)
                {
                    ddlFocusArea.SelectedValue = lblFocusID.Value;
                }
            }
            catch
            {

            }
        }
    }
}