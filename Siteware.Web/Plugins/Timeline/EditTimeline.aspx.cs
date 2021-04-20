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

namespace Siteware.Web.Plugins.Timeline
{
    public partial class EditTimeline : System.Web.UI.Page
    {
        string PageName = "Timeline";
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
                Session["IDSelectPage"] = "~/Plugins/Timeline/ManageTimeline.aspx";

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
            try
            {
                if (Session["TimelineID"] != null)
                {
                    long TimelineID = Convert.ToInt64(Session["TimelineID"]);

                    ResultEntity<Plugin_TimelineEntity> Result = new ResultEntity<Plugin_TimelineEntity>();

                    Result = await Plugin_TimelineDomain.GetByID(TimelineID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        hdnTimelineId.Value = Result.Entity.TimelineID.ToString();
                        lblHeadName1.Text = Result.Entity.Title;
                        lblHeadName2.Text = Result.Entity.Title;                       
                        txtTitle.Text = Result.Entity.Title;
                        txtSummary.Text = Result.Entity.Summary;                       
                        txtDescription.Text = Result.Entity.Description;
                        txtYear.Text = Result.Entity.Year;
                        //txtLink.Text = Result.Entity.Link;
                        //ddlParentPage.SelectedValue = Result.Entity.Target;
                        //hdnFocusID.Value = Result.Entity.FocusID.ToString();
                        //hdnColor.Value = Result.Entity.Color;
                        txtorderr.Text = Result.Entity.Order.ToString();
                        CBIsPublished.Checked = Result.Entity.IsPublished;
                        ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                        int selectedLanguageid = Result.Entity.LanguageID;
                        FillFocus(selectedLanguageid);
                        ddlFocusID.SelectedValue = Result.Entity.FocusID.ToString();
                        txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                       
                     
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void FillFocus(int LangID)
        {
            ddlFocusID.Items.Clear();
            ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));

            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
            Result = Plugin_Focus_AreaDomain.GetAllNotAsync();

            Result.List = Result.List.Where(s => s.IsPublished == true && !s.IsDelete && s.LanguageID == LangID).OrderBy(s => s.FocusOrder).ToList();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_Focus_AreaEntity item in Result.List)
                {
                    ddlFocusID.Items.Add(new ListItem(item.Title.ToString(), item.FocusID.ToString()));
                }
            }
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                FillFocus(LangID);
                
                if (Convert.ToInt32(lblLanguageID.Value) == LangID)
                {
                    ddlFocusID.SelectedValue = lblFocusID.Value;
                  
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["TimelineID"] != null)
                {
                    Plugin_TimelineEntity entity = new Plugin_TimelineEntity();

                    entity.TimelineID = Convert.ToInt32(hdnTimelineId.Value);
                    entity.Title = txtTitle.Text.Trim();
                    entity.Summary = txtSummary.Text;
                    entity.FocusID = Convert.ToInt64(ddlFocusID.SelectedValue);                
                    entity.Description = txtDescription.Text;
                    entity.Year = txtYear.Text;
                    entity.Order = Convert.ToInt32(txtorderr.Text);
                    entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                   

                    var Result = await Plugin_TimelineDomain.UpdateRecord(entity);

                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                else
                {
                    Response.Redirect("~/Plugins/Timeline/ManageTimeline.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Timeline/ManageTimeline.aspx", false);
        }
    }
}