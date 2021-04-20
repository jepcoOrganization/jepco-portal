using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Services;

public partial class Controls_EventList : System.Web.UI.UserControl
{
    int LangID = 0;
    protected List<DateList> dates = new List<DateList>();
    protected List<List<DateList>> ListDate = new List<List<DateList>>();
    protected List<DateList> ListDays = new List<DateList>();
    DateTime currentDate = DateTime.Now;
    string[] Months = {"January", "February", "March",
                    "April", "May", "June", "July",
                    "August", "September", "October", "November", "December" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdYear.Value = currentDate.Year.ToString();
            hdMonth.Value = currentDate.Month.ToString();
            //hdDate.Value = currentDate.Date.Day.ToString();
            lblMonthYear.Text = currentDate.ToString("MMMM", new CultureInfo("en-US")) + " " + currentDate.Year;
            LangID = Convert.ToInt32(Session["CurrentLanguage"].ToString());
            FillCalendar(Convert.ToInt32(currentDate.Year.ToString()), Convert.ToInt32(currentDate.Month.ToString()));
            //FillMonthDropdown();
        }
        else
        {
            //hdYear.Value = currentDate.Year.ToString();
            //hdMonth.Value = currentDate.Month.ToString();
        }
    }
    protected void FillMonthDropdown()
    {
        try
        {
            List<DateTime> months = new List<DateTime>();
            DateTime d = DateTime.Now;
            for (int i = 0; i <= 12; i++)
            {
                if (i == 0)
                {
                    d = d.AddMonths(0);
                }
                else
                {
                    d = d.AddMonths(1);
                }
                months.Add(d);
            }
            for (int j = 0; j < months.Count; j++)
            {
                DateTime Date = Convert.ToDateTime(months[j]);
                string Month = Date.ToString("MMMM", new CultureInfo("en-US"));
                //ddlMonths.Items.Add(new ListItem(Month + "-" + months[j].Year, months[j].Month.ToString()));
            }

            //for (int i = 0; i < DateTime.Now.Month; ++i)
            //{
            //    months.Add(new DateTime(DateTime.Now.Year, i, 1));
            //}
        }
        catch (Exception ex)
        {

        }
    }
    int count = 0;
    protected void FillCalendar(int CurrentYear, int CurrentMonth)
    {
        int monthIndex = Convert.ToInt32(CurrentMonth);
        int Year1 = Convert.ToInt32(CurrentYear);
        var firstDayOfMonth = new DateTime(Year1, monthIndex, 1).DayOfWeek;
        var month = new DateTime(Year1, monthIndex, 1, 0, 0, 0, DateTimeKind.Utc);
        List<DateTime> listMonth = GetDates(Year1, monthIndex);
        List<DateTime> lst = new List<DateTime>();
        //ListDate = SiteWare.Domain.Common.DomainCommonConstants.SplitList(dates);
        for (int k = 0; k < listMonth.Count; k++)
        {
            DateTime dt = listMonth[k];
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                count++;
            }
            if (count > 0)
            {
                lst.Add(dt);
            }
        }
        for (int i = lst.Count; i < 42; i++)
        {
            DateTime dt = lst[lst.Count - 1];

            string d = dt.Date.ToString("dd");

            DateTime month1;
            if (lst[lst.Count - 1].Month > monthIndex)
            {
                month1 = new DateTime(Year1, monthIndex + 1, Convert.ToInt32(d), 0, 0, 0, DateTimeKind.Utc);
            }
            else if (lst[lst.Count - 1].Month < monthIndex)
            {
                month1 = new DateTime(Year1, monthIndex - 1, Convert.ToInt32(d), 0, 0, 0, DateTimeKind.Utc);
            }
            else
            {
                month1 = new DateTime(Year1, monthIndex, Convert.ToInt32(d), 0, 0, 0, DateTimeKind.Utc);
            }
            TimeSpan duration = new TimeSpan(1, 0, 0, 0);
            DateTime date2 = month1.Add(duration);
            lst.Add(date2);


        }
        dates = (from a in lst
                 select new DateList
                 {
                     date = a
                 }).ToList();
        lstDates.DataSource = lst;
        lstDates.DataBind();
    }
    protected void lstDates_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            int i = dataItem.DisplayIndex;
            Literal lblDay = (Literal)e.Item.FindControl("lblDay");
            Literal lblDay1 = (Literal)e.Item.FindControl("lblDay1");
            Literal lblDay2 = (Literal)e.Item.FindControl("lblDay2");
            DateTime day = dates[i].date;
            lblDay.Text = day.Day.ToString();
            lblDay1.Text = day.Day.ToString();
            lblDay2.Text = day.Day.ToString();
            Literal lblEventCount = (Literal)e.Item.FindControl("lblEventCount");
            Literal lblEventSpanCount = (Literal)e.Item.FindControl("lblEventSpanCount");
            ListView lstEvents = (ListView)e.Item.FindControl("lstEvents");
            HtmlGenericControl divDate = (HtmlGenericControl)e.Item.FindControl("divDate");
            HtmlGenericControl pDate = (HtmlGenericControl)e.Item.FindControl("pDate");
            HtmlGenericControl strongDate = (HtmlGenericControl)e.Item.FindControl("strongDate");
            if (dates[i].date.Month != Convert.ToInt32(hdMonth.Value))
            {
                divDate.Attributes.Add("class", "event_list_date disabled");
            }
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();
            result = CalendarEventDomain.GetCalendarEventAllNotAsync();
            if (result.Status == ErrorEnums.Success)
            {
                result.List = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == LangID
                              && s.EventTime.Date == dates[i].date).ToList();
                var res = result.List.Take(3).ToList();
                if (result.List.Count > 0)
                {
                    strongDate.Visible = false;
                    foreach (var item in result.List)
                    {
                        if (item.EventTime.Month == Convert.ToInt32(hdMonth.Value))
                        {
                            divDate.Attributes.Add("class", "event_list_date enable");
                        }
                    }
                    lstEvents.DataSource = res;
                    lstEvents.DataBind();
                    int remEvents = result.List.Count - res.Count;
                    if (remEvents != 0)
                    {
                        lblEventCount.Text = "+" + remEvents.ToString() + " Events";
                        lblEventSpanCount.Text = "+" + remEvents.ToString() + " Events";
                    }

                }
                else
                {
                    pDate.Visible = false;
                }
            }

        }
    }

    protected void lstEvents_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Literal lblEventTitle = (Literal)e.Item.FindControl("lblEventTitle");
        }
    }
    public static List<DateTime> GetDates(int year, int month)
    {

        var first = new DateTime(year, month, 1);
        var last = first.AddMonths(1).AddDays(-1);
        var m = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
        int dIndex = (int)m.DayOfWeek;
        if (dIndex == 0)
        {
            var lst = Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                         .Select(day => new DateTime(year, month, day).Subtract(TimeSpan.FromDays(6))) // Map each day to a date
                         .ToList(); // Load dates into a list
            return lst;
        }
        return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                         .Select(day => new DateTime(year, month, day).Subtract(TimeSpan.FromDays((int)m.DayOfWeek))) // Map each day to a date
                         .ToList(); // Load dates into a list
    }
    public class DateList
    {
        public DateTime date { get; set; }
    }

    //protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selectItem = ddlMonths.SelectedItem.Text;
    //    string[] split = selectItem.Split('-');
    //    string Month = split[0].ToLower();
    //    int y = Convert.ToInt32(split[1]);
    //    int m = Array.FindIndex(Months, s => s.ToLower() == Month.ToLower());
    //    m = m + 1;
    //    hdMonth.Value = m.ToString();
    //    hdYear.Value = split[1];
    //    FillCalendar(y, m);
    //}


    protected void lnkPrevMonth_Click(object sender, EventArgs e)
    {
        try
        {
            int month = Convert.ToInt32(hdMonth.Value);
            int prevMonth = month - 1;
            DateTime date;
            if (prevMonth <= 0)
            {
                int year = Convert.ToInt32(hdYear.Value) - 1;
                date = new DateTime(year, 12, 1);

                hdMonth.Value = date.Month.ToString();
                hdYear.Value = date.Year.ToString();
                lblMonthYear.Text = date.ToString("MMMM", new CultureInfo("en-US")) + " " + date.Year;
            }
            else
            {
                int year = Convert.ToInt32(hdYear.Value);
                date = new DateTime(year, prevMonth, 1);

                hdMonth.Value = date.Month.ToString();
                hdYear.Value = date.Year.ToString();
                lblMonthYear.Text = date.ToString("MMMM", new CultureInfo("en-US")) + " " + date.Year;
            }

            FillCalendar(Convert.ToInt32(date.Year), Convert.ToInt32(date.Month));
        }
        catch(Exception ex)
        { }
    }

    protected void lnkNextMonth_Click(object sender, EventArgs e)
    {
        try
        {
            int month = Convert.ToInt32(hdMonth.Value);
            int nextMonth = month + 1;
            DateTime date;
            if (nextMonth >= 12)
            {
                int year = Convert.ToInt32(hdYear.Value) + 1;
                date = new DateTime(year, 1, 1);

                hdMonth.Value = date.Month.ToString();
                hdYear.Value = date.Year.ToString();
                lblMonthYear.Text = date.ToString("MMMM", new CultureInfo("en-US")) + " " + date.Year;
            }
            else
            {
                int year = Convert.ToInt32(hdYear.Value);
                date = new DateTime(year, nextMonth, 1);

                hdMonth.Value = date.Month.ToString();
                hdYear.Value = date.Year.ToString();
                lblMonthYear.Text = date.ToString("MMMM", new CultureInfo("en-US")) + " " + date.Year;
            }

            FillCalendar(Convert.ToInt32(date.Year), Convert.ToInt32(date.Month));
        }
        catch(Exception ex)
        { }
    }
}