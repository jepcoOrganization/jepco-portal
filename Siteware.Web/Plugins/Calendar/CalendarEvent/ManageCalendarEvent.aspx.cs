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

namespace Siteware.Web.Plugins.Calendar.CalendarEvent
{
    public partial class ManageCalendarEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillNavigation();
                    Session["CalendarEventIDSession"] = null;
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
            if(Session["CalendarIDSession"] != null)
            {
                int CalendarID = Convert.ToInt32(Session["CalendarIDSession"]);
                ResultList<CalendarEventEntity> Result = new ResultList<CalendarEventEntity>();

                Result = await CalendarEventDomain.GetCalendarEventByCalendarID(CalendarID);
                if (Result.Status == ErrorEnums.Success)
                {
                    lstEvent.DataSource = Result.List.ToList();
                    lstEvent.DataBind();
                }
            }
            
        }
        protected void lstEvent_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTargetID = (Label)e.Item.FindControl("lblTargetID");

                //if (lblTargetID.Text == "1")
                //{
                //    lblTargetID.Text = "New window";
                //}
                //else
                //{
                //    lblTargetID.Text = "Same window";
                //}

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                Label lblEventTime = (Label)e.Item.FindControl("lblEventTime");

                lblEventTime.Text = Convert.ToDateTime(lblEventTime.Text).ToString();
            }
        }
        protected void lstEvent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["CalendarEventIDSession"] = ID;

                Response.Redirect("~/Plugins/Calendar/CalendarEvent/EditCalendarEvent.aspx");
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DeleteRow(ID);

            }
        }
        protected async void DeleteRow(int CalendarID)
        {
            CalendarEventEntity entity = new CalendarEventEntity();
            entity.ID = CalendarID;
            entity.IsDeleted = true;
            var Result = await CalendarEventDomain.UpdateByIsDeleted(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }
        protected async void BtnDelete2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstEvent.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label CalendarEventID = ((Label)item.FindControl("lblID"));
                    CalendarEventEntity entity = new CalendarEventEntity();
                    entity.ID = Convert.ToInt32(CalendarEventID.Text);
                    entity.IsDeleted = true;
                    var Result = await CalendarEventDomain.UpdateByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
            }
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/CalendarEvent/AddCalendarEvent.aspx");
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/CalendarEvent/ManageCalendarEvent.aspx");
        }        
    }
}