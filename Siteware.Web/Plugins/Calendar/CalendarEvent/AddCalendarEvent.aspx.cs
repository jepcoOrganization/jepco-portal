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
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Siteware.Web.Plugins.Calendar.CalendarEvent
{
    public partial class AddCalendarEvent : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillNavigation();
                    ddlMappedEvent1.Items.Insert(0, new ListItem("Select Event", "0"));
                    if (Session["CalendarIDSession"] != null)
                    {
                        int calID = Convert.ToInt32(Session["CalendarIDSession"]);
                        ResultEntity<CalendarEntity> Result_Calendar = new ResultEntity<CalendarEntity>();
                        Result_Calendar = await CalendarDomain.GetCalendarByID(calID);
                        if (Result_Calendar.Status == ErrorEnums.Success)
                        {
                            FillEventByLanguage(Convert.ToInt32(Result_Calendar.Entity.LanguageID));
                            FillEntity(Convert.ToInt32(Result_Calendar.Entity.LanguageID));
                        }
                        else
                        {
                            FillEventByLanguage(1);
                            FillEntity(1);
                        }

                    }
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx", false);
                }
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
                Session["IDSelectPage"] = "~/Plugins/Calendar/ManageCalendar.aspx";
            }
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            CalendarEventEntity entity = new CalendarEventEntity();

            if (Session["CalendarIDSession"] != null)
            {
               // entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                entity.CalendarID = Convert.ToInt32(Session["CalendarIDSession"]);
                entity.EventTitle = txtEventTitle.Text.Trim();
                entity.EventDescription = txtDescirption.Text;
                entity.EventURL = txtEventURL.Text;
                entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);

                ResultEntity<CalendarEntity> Result_Calendar = new ResultEntity<CalendarEntity>();
                Result_Calendar = await CalendarDomain.GetCalendarByID(entity.CalendarID);
                if (Result_Calendar.Status == ErrorEnums.Success)
                {
                    var time = Convert.ToDateTime(txtEventTime.Value).ToString("HH:mm:ss.fff");
                    string Datedtr = Result_Calendar.Entity.EventDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " " + time;
                    entity.EventTime = Convert.ToDateTime(Datedtr); //DateTime.ParseExact(Datedtr, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                    entity.LanguageID = Result_Calendar.Entity.LanguageID;
                }
                else
                {
                    entity.LanguageID = 1;
                }

                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.ViewCount = 0;
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.MapEventID1 = ddlMappedEvent1.SelectedValue;
                entity.MapEventID2 = ddlMappedEvent1.SelectedValue;
                entity.Summary = txtSummary.Text;
                entity.EntityID = Convert.ToInt64(ddlEntity.SelectedValue);

                var Result = await CalendarEventDomain.Insert(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected async void FillEventByLanguage(int LanguageId)
        {
            ResultList<CalendarEventEntity> Result = new ResultList<CalendarEventEntity>();
            Result = await CalendarEventDomain.GetCalendarEventAll();

            if (Result.Status == ErrorEnums.Success)
            {
                if (LanguageId == (int)EnumLanguage.Arabic)
                {
                    lblMapEvent1.Text = "Map English Event :";
                }
                else if (LanguageId == (int)EnumLanguage.English)
                {
                    lblMapEvent1.Text = "Map Arabic Event :";
                }

                ddlMappedEvent1.Items.Clear();

                ddlMappedEvent1.Items.Insert(0, new ListItem("Select Event", "0"));

                foreach (CalendarEventEntity item in Result.List.Where(s=>s.IsDeleted==false && s.IsPublished).ToList())
                {
                    if (item.LanguageID != LanguageId)
                    {
                        ddlMappedEvent1.Items.Add(new ListItem(item.EventTitle.ToString(), item.ID.ToString()));
                    }
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/CalendarEvent/ManageCalendarEvent.aspx");
        }

        protected void FillEntity(int LangID)
        {
            try
            {
                ddlEntity.Items.Clear();
                ddlEntity.Items.Insert(0, new ListItem("Select Entity", "0"));

                ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
                Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    Result.List = Result.List.Where(s => s.IsPublished && s.LanguageID == LangID && s.IsDelete == false).ToList();
                    foreach (Plugin_FA_EntitiesEntity item in Result.List)
                    {
                        ddlEntity.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
                    }
                }
            }
            catch
            {
            }
        }

        //protected async void FillLanguages()
        //{
        //    ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

        //    ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
        //    Result = await LanguageDomain.GetLanguagesAll();

        //    if (Result.Status == ErrorEnums.Success)
        //    {
        //        foreach (LanguageEntity item in Result.List)
        //        {
        //            ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
        //        }
        //    }
        //}
    }
}