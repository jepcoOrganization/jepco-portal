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
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.Services;

namespace Siteware.Web.Plugins.Calendar
{
    public partial class ManageCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillNavigation();
                    Session["CalendarIDSession"] = null;
                    FillData();
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
        protected async void FillData()
        {
            ResultList<CalendarEntity> Result = new ResultList<CalendarEntity>();

            Result = await CalendarDomain.GetCalendarAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstCalendar.DataSource = Result.List.ToList();
                lstCalendar.DataBind();
            }
        }
        protected void lstCalendar_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                Label lblEventDate = (Label)e.Item.FindControl("lblEventDate");

                lblEventDate.Text = Convert.ToDateTime(lblEventDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstCalendar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["CalendarIDSession"] = ID;

                Response.Redirect("~/Plugins/Calendar/EditCalendar.aspx");
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DeleteRow(ID);

            }
            if (e.CommandName == "EventsItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["CalendarIDSession"] = ID;

                Response.Redirect("~/Plugins/Calendar/CalendarEvent/ManageCalendarEvent.aspx");
            }
        }
        protected async void DeleteRow(int CalendarID)
        {
            var Check_Events = await CalendarEventDomain.GetCalendarEventByCalendarID(CalendarID);

            if (Check_Events.List.Count() > 0)
            {
                mpeSuccess2.Show();
                return;
            }
            else
            {
                CalendarEntity entity = new CalendarEntity();
                entity.ID = CalendarID;
                entity.IsDeleted = true;
                var Result = await CalendarDomain.UpdateByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }

        }
        protected async void BtnDelete2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstCalendar.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label CalendarID = ((Label)item.FindControl("lblID"));
                    var Check_Events = await CalendarEventDomain.GetCalendarEventByCalendarID(Convert.ToInt32(CalendarID.Text));

                    if (Check_Events.List.Count() > 0)
                    {
                        mpeSuccess2.Show();
                        return;
                    }
                    else
                    {
                        CalendarEntity entity = new CalendarEntity();
                        entity.ID = Convert.ToInt32(CalendarID.Text);
                        entity.IsDeleted = true;
                        var Result = await CalendarDomain.UpdateByIsDeleted(entity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            mpeSuccess.Show();
                        }
                    }
                }
            }
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/AddCalendar.aspx");
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/ManageCalendar.aspx");
        }
        [WebMethod]
        public static LangDetails[] BindDatatoDropdown()
        {
            try
            {
                ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
                List<LangDetails> details = new List<LangDetails>();
                Result = LanguageDomain.GetLanguagesAllNotAsync();
                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (var item in Result.List)
                    {
                        LangDetails lang = new LangDetails();
                        lang.LangId = item.ID;
                        lang.LangName = item.Name;
                        details.Add(lang);
                    }
                }
                return details.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }
    }
}