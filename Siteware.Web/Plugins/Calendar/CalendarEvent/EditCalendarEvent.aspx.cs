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
    public partial class EditCalendarEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillNavigation();
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
        protected async void FillDetails()
        {
            if (Session["CalendarEventIDSession"] != null)
            {
                int EventID = Convert.ToInt32(Session["CalendarEventIDSession"]);

                ResultEntity<CalendarEventEntity> Result = new ResultEntity<CalendarEventEntity>();

                Result = await CalendarEventDomain.GetCalendarEventByID(EventID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtEventTitle.Text = Result.Entity.EventTitle;
                    lblCalendarEventName1.Text = Result.Entity.EventTitle;
                    lblCalendaEventrName2.Text = Result.Entity.EventTitle;
                    lblEventID.Value = Result.Entity.ID.ToString();
                    lblLangID.Value = Result.Entity.LanguageID.ToString();
                    txtDescirption.Text = Result.Entity.EventDescription;
                    txtEventURL.Text = Result.Entity.EventURL;
                    ddlTargetID.SelectedValue = Result.Entity.TargetID.ToString();

                    txtEventTime.Value = Result.Entity.EventTime.ToString("hh:mm tt");

                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    int languageId = Convert.ToInt32(Result.Entity.LanguageID);
                    txtSummary.Text = Convert.ToString(Result.Entity.Summary);

                    FillEventByLanguage(languageId);
                    ddlMappedEvent1.SelectedValue = Result.Entity.MapEventID1;

                    FillEntity(languageId);
                    ddlEntity.SelectedValue = Result.Entity.EntityID.ToString();
                }
            }
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                CalendarEventEntity entity = new CalendarEventEntity();
                if (Session["CalendarEventIDSession"] != null)
                {
                    entity.ID = Convert.ToInt32(Session["CalendarEventIDSession"]);
                    entity.CalendarID = Convert.ToInt32(Session["CalendarIDSession"]);
                    entity.EventTitle = txtEventTitle.Text;
                    entity.EventDescription = txtDescirption.Text;
                    entity.EventURL = txtEventURL.Text;
                    entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);

                    ResultEntity<CalendarEntity> Result_Calendar = new ResultEntity<CalendarEntity>();
                    Result_Calendar = await CalendarDomain.GetCalendarByID(entity.CalendarID);
                    if (Result_Calendar.Status == ErrorEnums.Success)
                    {
                        var time = Convert.ToDateTime(txtEventTime.Value).ToString("HH:mm:ss.fff");
                        string Datedtr = Result_Calendar.Entity.EventDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " " + time;
                        entity.EventTime = Convert.ToDateTime(Datedtr);
                    }
                    entity.LanguageID = Convert.ToByte(lblLangID.Value);
                    entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.IsDeleted = false;
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.MapEventID1 = ddlMappedEvent1.SelectedValue;
                    entity.MapEventID2 = ddlMappedEvent1.SelectedValue;
                    entity.Summary = Convert.ToString(txtSummary.Text);
                    entity.IsNotification = false;
                    entity.EntityID = Convert.ToInt64(ddlEntity.SelectedValue);

                    var Result = await CalendarEventDomain.Update(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        protected void FillEventByLanguage(int LanguageId)
        {
            ResultList<CalendarEventEntity> Result = new ResultList<CalendarEventEntity>();
            Result = CalendarEventDomain.GetCalendarEventAllNotAsync();

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
                        if (LanguageId == (int)EnumLanguage.Arabic)
                        {
                            if (item.LanguageID == (int)EnumLanguage.English)
                            {
                                ddlMappedEvent1.Items.Add(new ListItem(item.EventTitle.ToString(), item.ID.ToString()));
                            }
                        }
                        if (LanguageId == (int)EnumLanguage.English)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddlMappedEvent1.Items.Add(new ListItem(item.EventTitle.ToString(), item.ID.ToString()));
                            }
                        }
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
    }
}