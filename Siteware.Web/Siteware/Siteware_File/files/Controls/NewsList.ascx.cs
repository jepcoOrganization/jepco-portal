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
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;

public partial class Controls_NewsList : System.Web.UI.UserControl
{
    DateTime currentDate = DateTime.Now;
    DataPager pager1;
    string lang = string.Empty;
    int newsCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }
            FillNews();
        }
    }

    protected void FillNews()
    {
        try
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();
            result = NewsDomain.GetNewsAllNotAsync();
            if (result.Status == ErrorEnums.Success)
            {
                var res = result.List;
                res = res.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Take(1).ToList();
                //imgLatestNews.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + res[0].NewsImage;
                string url = ConfigurationManager.AppSettings["ImagePath"].ToString() + res[0].NewsImage;
                divNewsBack.Style["background"] = "url(" + url + ") no-repeat center";
                divNewsBack.Style["background-size"] = "cover";
                DateTime Date = Convert.ToDateTime(res[0].NewsDate);
                string Day = Date.ToString("dd", new CultureInfo("en-US"));
                string Month = Date.ToString("MMMM", new CultureInfo("en-US"));
                string Year = Date.ToString("yyyy", new CultureInfo("en-US"));
                lblLatestNewsDate.Text = Day + " " + Month + " " + Year;
                lblLatestNewsHeadline.Text = res[0].Headline;
                string title = Regex.Replace(lblLatestNewsHeadline.Text, @"[\\:/*#]+", " ");
                if (title.Contains("."))
                {
                    title = title.Replace(".", "");
                }
                int ID = res[0].NewsID;
                lnkNewsDetail.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                lnkNewsDetail1.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                var recentNews = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Skip(1).Take(2).ToList();
                var otherNews = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Skip(3).ToList();
                int cnt = otherNews.Count;
                double d = (double)cnt / 2;
                int count = Convert.ToInt32(Math.Ceiling(d));
                var newsList = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Take(count).ToList();
                lstRecentNews.DataSource = recentNews.ToList();
                lstRecentNews.DataBind();
                lstNewsRow.DataSource = newsList.ToList();
                lstNewsRow.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lstRecentNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                string lang = string.Empty;
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                ListViewDataItem i = (ListViewDataItem)e.Item;
                var c = i.DataItemIndex;
                HiddenField hdNewsID = (HiddenField)e.Item.FindControl("hdNewsID");
                Literal lblNewsHeadLine = (Literal)e.Item.FindControl("lblNewsHeadLine");
                Literal lblNewsDate = (Literal)e.Item.FindControl("lblNewsDate");
                //Literal lblNewsSummary = (Literal)e.Item.FindControl("lblNewsSummary");
                HyperLink lnkNewsDetail = (HyperLink)e.Item.FindControl("lnkNewsDetail");
                HyperLink lnkNewsDetail1 = (HyperLink)e.Item.FindControl("lnkNewsDetail1");
                //HyperLink lnkNewsDetail2 = (HyperLink)e.Item.FindControl("lnkNewsDetail2");
                Image imgNews = (Image)e.Item.FindControl("imgNews");
                imgNews.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgNews.ImageUrl;
                HtmlGenericControl divOverlay = (HtmlGenericControl)e.Item.FindControl("divOverlay");
                DateTime Date = Convert.ToDateTime(lblNewsDate.Text);
                string Day = Date.ToString("dd", new CultureInfo("en-US"));
                string Month = Date.ToString("MMMM", new CultureInfo("en-US"));
                string Year = Date.ToString("yyyy", new CultureInfo("en-US"));
                lblNewsDate.Text = Day + " " + Month + " " + Year;
                if (c == 0)
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div darkred");
                }
                else
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div darkgreen");
                }
                string title = Regex.Replace(lblNewsHeadLine.Text, @"[\\:/*#]+", " ");
                if (title.Contains("."))
                {
                    title = title.Replace(".", "");
                }
                int ID = Convert.ToInt32(hdNewsID.Value.ToString());

                lnkNewsDetail.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                lnkNewsDetail1.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                //lnkNewsDetail2.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lstNewsRow_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem i = (ListViewDataItem)e.Item;
                var c = i.DataItemIndex;
                var skip = c * 2;
                ListView lstOtherNews = (ListView)e.Item.FindControl("lstOtherNews");
                ResultList<NewsEntity> result = new ResultList<NewsEntity>();
                result = NewsDomain.GetNewsAllNotAsync();
                if (result.Status == ErrorEnums.Success)
                {
                    var res = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]))
                                  .OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Skip(3).ToList();
                    res = res.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]))
                                  .OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Skip(skip).Take(2).ToList();
                    lstOtherNews.DataSource = res.ToList();
                    lstOtherNews.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lstOtherNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                string lang = string.Empty;
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                ListViewDataItem i = (ListViewDataItem)e.Item;
                var c = i.DataItemIndex;
                HiddenField hdNewsID = (HiddenField)e.Item.FindControl("hdNewsID");
                Literal lblNewsHeadLine = (Literal)e.Item.FindControl("lblNewsHeadLine");
                Literal lblNewsDate = (Literal)e.Item.FindControl("lblNewsDate");
                Literal lblNewsSummary = (Literal)e.Item.FindControl("lblNewsSummary");
                HyperLink lnkNewsDetail = (HyperLink)e.Item.FindControl("lnkNewsDetail");
                HyperLink lnkNewsDetail1 = (HyperLink)e.Item.FindControl("lnkNewsDetail1");
                HyperLink lnkNewsDetail2 = (HyperLink)e.Item.FindControl("lnkNewsDetail2");
                Image imgNews = (Image)e.Item.FindControl("imgNews");
                imgNews.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgNews.ImageUrl;
                HtmlGenericControl divOverlay = (HtmlGenericControl)e.Item.FindControl("divOverlay");
                DateTime Date = Convert.ToDateTime(lblNewsDate.Text);
                string Day = Date.ToString("dd", new CultureInfo("en-US"));
                string Month = Date.ToString("MMMM", new CultureInfo("en-US"));
                string Year = Date.ToString("yyyy", new CultureInfo("en-US"));
                lblNewsDate.Text = Day + " " + Month + " " + Year;
                if (newsCount == 1)
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div darkred");
                }
                if (newsCount == 2)
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div strongyellow");
                }
                if (newsCount == 3)
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div yellow");
                }
                if (newsCount == 4)
                {
                    divOverlay.Attributes.Add("class", "news_overlay_div darkgreen");
                }
                string title = Regex.Replace(lblNewsHeadLine.Text, @"[\\:/*#]+", " ");
                if (title.Contains("."))
                {
                    title = title.Replace(".", "");
                }
                int ID = Convert.ToInt32(hdNewsID.Value.ToString());

                lnkNewsDetail.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                lnkNewsDetail1.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                lnkNewsDetail2.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();
                newsCount++;
                if (newsCount > 4)
                {
                    newsCount = 1;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}