using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DetailsPage_en_SearchPage : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 1;
    public int Count = 0;
    public int Counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
            {
                LangID = 1;
            }
            else
            {
                LangID = 2;
            }
            if (!IsPostBack)
            {
                FillBage();
                lblChildName.Text = "Search";
                string keyword = Request.QueryString["keyword"].ToString();
                Page.Title = "search result for " + keyword + " - KHF";
                Page.MetaDescription = "search result for " + keyword + " - KHF";
                lblPageTitle.Text = "Search";
                lblChildName.Text = "Search result for - " + keyword;
            }
        }
        catch (Exception ex)
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
            Response.Redirect(lang + "/home", false);
        }

    }
    public string FetchLinksFromSource(string htmlSource)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        if (doc.DocumentNode.SelectNodes("//img") != null)
        {
            foreach (var img in doc.DocumentNode.SelectNodes("//img"))
            {
                string orig = img.Attributes["src"].Value;
                string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                img.SetAttributeValue("src", newsrc);
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
    #region--> Fill Search | Add | Simran| 14062019  
    protected async void FillBage()
    {
        try
        {
            Session["Category"] = "Search";
            //imgBanner.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + "/Siteware/Siteware_File/image/CIS/inner-banner.jpg";
            //imgMobBanner.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + "/Siteware/Siteware_File/image/CIS/mob-inner-banner.jpg";
            lstParent.Visible = false;
            DataPager pager;
            string keyword = Request.QueryString["keyword"].ToString();
            //string keyword = Page.RouteData.Values["Title"].ToString();
            string lang = string.Empty;
            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                EnKeyword.Text = "Word Search : " + keyword;
                lblEnSearchCount.Text = "0";
                byte LanguageId = Convert.ToByte(Session["CurrentLanguage"]);
                ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
                ResultList<NewsEntity> newsResult = new ResultList<NewsEntity>();
                ResultList<CalendarEventEntity> eventResult = new ResultList<CalendarEventEntity>();
                ResultList<PluginAlbumEntity> albumResult = new ResultList<PluginAlbumEntity>();
                ResultList<PluginAlbumDetailEntity> albumDetailResult = new ResultList<PluginAlbumDetailEntity>();
                Result = await PagesDomain.GetPagesByKyeword(keyword, LanguageId);
                newsResult = NewsDomain.GetNewsAllNotAsync();
                eventResult = CalendarEventDomain.GetCalendarEventAllNotAsync();
                albumResult = PluginAlbumDomain.GetPluginAlbumAllNotAsync();
                albumDetailResult = PluginAlbumDetailDomain.GetPluginAlbumDetailAllNotAsync();
                if (Result.Status == ErrorEnums.Success || newsResult.Status == ErrorEnums.Success || eventResult.Status == ErrorEnums.Success || albumResult.Status == ErrorEnums.Success || albumDetailResult.Status == ErrorEnums.Success)
                {
                    if (newsResult.Status == ErrorEnums.Success)
                    {
                        //Response.Write("<script>alert('12')</script>");
                        newsResult.List = newsResult.List.Where(s => s.Headline.Contains(keyword) || s.Summary.Contains(keyword) || s.Description.Contains(keyword) && (s.IsPublished && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate.Date <= currentDate.Date)).ToList();
                        if (newsResult.List.Count > 0)
                        {
                            //Response.Write("<script>alert('13')</script>");
                            foreach (NewsEntity entity in newsResult.List)
                            {
                                PagesEntity result1 = new PagesEntity();
                                string title = Regex.Replace(entity.Headline, @"[\\:/*#%]+", " ");
                                long ID = entity.NewsID;
                                string newsLink = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();
                                result1.Name = entity.Headline;
                                result1.ContentHTML = entity.Summary;
                                result1.LivePath = newsLink;
                                result1.IsPublished = entity.IsPublished;
                                Result.List.Add(result1);
                            }
                        }
                    }
                    //if (eventResult.Status == ErrorEnums.Success)
                    //{
                    //    // Response.Write("<script>alert('14')</script>");
                    //    eventResult.List = eventResult.List.Where(s => s.EventTitle.Contains(keyword) || s.Summary.Contains(keyword) || s.EventDescription.Contains(keyword) && (s.IsPublished && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate <= currentDate)).ToList();
                    //    if (eventResult.List.Count > 0)
                    //    {
                    //        // Response.Write("<script>alert('15')</script>");
                    //        foreach (CalendarEventEntity entity in eventResult.List)
                    //        {
                    //            PagesEntity result2 = new PagesEntity();
                    //            string title = Regex.Replace(entity.EventTitle, @"[\\:/*#%]+", " ");
                    //            int ID = entity.ID;
                    //            // string eventLink = lang + "/EventDetailsPage/" + title + "/" + ID.ToString();
                    //            result2.Name = entity.EventTitle;
                    //            result2.ContentHTML = entity.EventDescription;
                    //            //result2.LivePath = eventLink;
                    //            result2.IsPublished = entity.IsPublished;
                    //            Result.List.Add(result2);
                    //        }
                    //    }
                    //}
                    if (albumResult.Status == ErrorEnums.Success)
                    {
                        // Response.Write("<script>alert('14')</script>");
                        albumResult.List = albumResult.List.Where(s => s.Title.Contains(keyword) && (s.IsPublish && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate.Date <= currentDate.Date)).ToList();
                        if (albumResult.List.Count > 0)
                        {
                            // Response.Write("<script>alert('15')</script>");
                            foreach (PluginAlbumDetailEntity entity in albumDetailResult.List)
                            {
                                PagesEntity result4 = new PagesEntity();
                                string title = Regex.Replace(entity.Title, @"[\\:/*#%]+", " ");
                                int ID = entity.ID;

                                string albumLink = lang + "/PhotoGalleryDetail/" + title + "/" + ID.ToString();

                                result4.Name = entity.Title;
                                result4.ContentHTML = string.Empty;
                                result4.LivePath = albumLink;
                                result4.IsPublished = entity.IsPublish;
                                Result.List.Add(result4);
                            }
                        }
                    }
                    if (albumDetailResult.Status == ErrorEnums.Success)
                    {
                        // Response.Write("<script>alert('14')</script>");
                        albumDetailResult.List = albumDetailResult.List.Where(s => s.Title.Contains(keyword) && (s.IsPublish && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate.Date <= currentDate.Date)).ToList();
                        if (albumDetailResult.List.Count > 0)
                        {
                            // Response.Write("<script>alert('15')</script>");
                            foreach (PluginAlbumDetailEntity entity in albumDetailResult.List)
                            {
                                PagesEntity result3 = new PagesEntity();
                                string title = Regex.Replace(entity.Title, @"[\\:/*#%]+", " ");
                                int ID = entity.ID;
                                //string albumLink = lang + "/PhotoGalleryDetail/" + title + "/" + ID.ToString();
                                result3.Name = entity.Title;
                                result3.ContentHTML = string.Empty;
                                //result3.LivePath = albumLink;
                                result3.IsPublished = entity.IsPublish;
                                Result.List.Add(result3);
                            }
                        }
                    }
                   
                    var count = Result.List.Where(a => a.IsDeleted == false).Count();
                    //hdLstCount.Value = count.ToString();
                    lstEnSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
                    lstEnSearchData.DataBind();

                    if (lstEnSearchData.Items.Count > 0)
                    {
                        Counter = Result.List.Where(a => a.IsDeleted == false).ToList().Count;
                    }
                    lblEnSearchCount.Text = Counter.ToString();

                }
                else
                {
                    EnKeyword.Text = "Word Search : " + keyword;
                    if (Result.List.Count == 0)
                    {
                        lstEnSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
                        lstEnSearchData.DataBind();
                        lblEnSearchCount.Text = "No result found";
                    }

                }

                pager = lstEnSearchData.FindControl("DataPager1") as DataPager;

                pager.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["SearchPageSize"]);

            }
        }
        catch (Exception e)
        {

        }

    }
    protected void lstData_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label lblContent = (Label)e.Item.FindControl("lblContent");
            lblContent.Text = Regex.Replace(lblContent.Text, "<[^>]*>", string.Empty);
            if (lblContent.Text.Length > 440)
            {
                lblContent.Text = lblContent.Text.Substring(0, 440) + "..";
            }
        }

    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager pager1;

        pager1 = lstEnSearchData.FindControl("DataPager1") as DataPager;

        (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.FillBage();
        PanelUpdate.Focus();
        //-------For call hightlight jquery function--------//
        string keyword = Request.QueryString["keyword"].ToString();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "highlightWord('.example','" + keyword + "', 'highlight');", true);
    }
    #endregion
}