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
using System.Text.RegularExpressions;
using System.Configuration;
using System.Globalization;

public partial class Pages_SearchPage : SiteBasePage
{
    public int Count = 0;
    public int Counter = 0;
    DataPager pager1;
    byte CurrLang = 2;
    public DateTime currentDate = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)

    {
        try
        {
            Session["CurrentLanguage"] = CurrLang;
            if (!IsPostBack)
            {
                FillData();
                FillBage();
                //FillUpComingEvent();
                //FillSpeciality();
                //FillDoctor();
                //FillAnnouncement();
            }
           
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    protected void FillData()
    {
        try
        {
            //string LanguageId = "1"//;
            Session["Category"] = "Search";
            string keyword = Request.QueryString["keyword"].ToString();
            if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.Arabic)
            {
                Page.Title = "البحث في الموقع(" + keyword + ")";
                Page.MetaDescription = "البحث في الموقع";

                // lblHomelink.Text = "الصفحة الرئيسية";
                lblChildName.Text = "البحث في الموقع";
            }
            else
            {
                Page.Title = "Search the site";
                Page.MetaDescription = "Search the site ";
            }

            // imgBanner.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + "/Siteware/Siteware_File/image/OSJ/about_banner.jpg";

        }
        catch (Exception)
        {

            throw;
        }

    }

    protected async void FillBage()
    {
        try
        {
            DataPager pager;
            string keyword = Request.QueryString["keyword"].ToString();
            if (!string.IsNullOrEmpty(keyword))
            {

                byte LanguageId = Convert.ToByte(Session["CurrentLanguage"]);

                ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
                ResultList<NewsEntity> newsResult = new ResultList<NewsEntity>();
                ResultList<PluginServiceEntity> serviceResult = new ResultList<PluginServiceEntity>();
                ResultList<PluginAnnouncementEntity> announceResult = new ResultList<PluginAnnouncementEntity>();

                Result = await PagesDomain.GetPagesByKyeword(keyword, LanguageId);

                newsResult = NewsDomain.GetNewsAllNotAsync();
                serviceResult = PluginServiceDomain.GetDataPointAllNotAsync();
                announceResult = PluginAnnouncementDomain.GetAnnouncementAllNotAsync();

                string lang = string.Empty;
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }



                if (Result.Status == ErrorEnums.Success || newsResult.Status == ErrorEnums.Success || serviceResult.Status == ErrorEnums.Success || announceResult.Status == ErrorEnums.Success)
                {

                    if (newsResult.Status == ErrorEnums.Success)
                    {
                        newsResult.List = newsResult.List.Where(s => s.Headline.Trim().ToLower().Contains(keyword.ToLower()) || s.Summary.ToLower().Contains(keyword.ToLower()) || s.Description.ToLower().Contains(keyword.ToLower()) && (s.IsPublished && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate <= currentDate)).ToList();
                        if (newsResult.List.Count > 0)
                        {
                            foreach (NewsEntity entity in newsResult.List)
                            {
                                PagesEntity result1 = new PagesEntity();
                                string title = Regex.Replace(entity.Headline, @"[\\:/*#%]+", " ");
                                int ID = entity.NewsID;
                                string newsLink = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();
                                result1.Name = entity.Headline;
                                result1.ContentHTML = entity.Description;
                                result1.LivePath = newsLink;
                                result1.IsPublished = entity.IsPublished;
                                Result.List.Add(result1);
                            }
                        }

                        serviceResult.List = serviceResult.List.Where(x => x.ServiceName.Trim().ToLower().Contains(keyword.ToLower()) || x.Title.ToLower().Contains(keyword.ToLower()) && (x.IsPublished && x.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !x.IsDeleted && x.PublishDate <= currentDate)).ToList();
                        foreach (PluginServiceEntity entity in serviceResult.List)
                        {
                            PagesEntity result1 = new PagesEntity();
                            string title = Regex.Replace(entity.Title, @"[\\:/*#%]+", " ");
                            int ID = entity.ID;
                            result1.Name = entity.Title;
                            result1.ContentHTML = entity.ServiceName;
                            result1.LivePath = string.Empty;
                            result1.IsPublished = entity.IsPublished;
                            Result.List.Add(result1);
                        }

                        announceResult.List = announceResult.List.Where(x => x.Title.Trim().ToLower().Contains(keyword.ToLower()) && (x.IsPublished && x.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !x.IsDeleted && x.PublishDate <= currentDate)).ToList();
                        foreach (PluginAnnouncementEntity entity in announceResult.List)
                        {
                            PagesEntity result1 = new PagesEntity();
                            string title = Regex.Replace(entity.Title, @"[\\:/*#%]+", " ");
                            int ID = entity.AnnouncementID;
                            string ancLink = lang + "/AnnoucePage/" + title.Trim() + "/" + ID.ToString();
                            result1.Name = entity.Title;
                            result1.ContentHTML = entity.Title;
                            result1.LivePath = ancLink;//entity.Link;
                            result1.IsPublished = entity.IsPublished;
                            Result.List.Add(result1);
                        }

                    }


                    Counter = Result.List.Where(s => s.IsPublished == true && s.IsDeleted == false).Count();
                    ArKeyword.Text = " كلمة البحث : " + keyword;
                    lstArSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
                    lstArSearchData.DataBind();

                    lblArSearchCount.Text = Counter.ToString();
                }


                else
                {
                    ArKeyword.Text = keyword + " : كلمة البحث ";
                    if (Result.List.Count == 0)
                    {
                        Counter = Result.List.Where(s => s.IsPublished == true && s.IsDeleted == false).Count();
                        lstArSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
                        lstArSearchData.DataBind();
                        lblArSearchCount.Text = "لم يتم العثور على نتائج";
                    }
                }

                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    pager = lstArSearchData.FindControl("DataPager1") as DataPager;
                }
                else
                {
                    pager = lstArSearchData.FindControl("DataPager1") as DataPager;
                }
                pager.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["SearchPageSize"]);

            }
        }
        catch (Exception e)
        {

        }

    }

    //protected async void FillBage()
    //{
    //    try
    //    {
    //        DataPager pager;
    //        string keyword = Request.QueryString["keyword"].ToString();
    //        if (!string.IsNullOrEmpty(keyword))
    //        {

    //            byte LanguageId = Convert.ToByte(Session["CurrentLanguage"]);

    //            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
    //            ResultList<NewsEntity> newsResult = new ResultList<NewsEntity>();


    //            Result = await PagesDomain.GetPagesByKyeword(keyword, LanguageId);

    //            newsResult = NewsDomain.GetNewsAllNotAsync();


    //            string lang = string.Empty;
    //            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }



    //            if (Result.Status == ErrorEnums.Success || newsResult.Status == ErrorEnums.Success )
    //            {

    //                if (newsResult.Status == ErrorEnums.Success)
    //                {
    //                    newsResult.List = newsResult.List.Where(s => s.Headline.Trim().ToLower().Contains(keyword.ToLower()) || s.Summary.ToLower().Contains(keyword.ToLower()) || s.Description.ToLower().Contains(keyword.ToLower()) && (s.IsPublished && s.LanguageID == Convert.ToByte(Session["CurrentLanguage"]) && !s.IsDeleted && s.PublishDate <= currentDate)).ToList();
    //                    if (newsResult.List.Count > 0)
    //                    {
    //                        foreach (NewsEntity entity in newsResult.List)
    //                        {
    //                            PagesEntity result1 = new PagesEntity();
    //                            string title = Regex.Replace(entity.Headline, @"[\\:/*#%]+", " ");
    //                            int ID = entity.NewsID;
    //                            string newsLink = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();
    //                            result1.Name = entity.Headline;
    //                            result1.ContentHTML = entity.Description;
    //                            result1.LivePath = newsLink;
    //                            result1.IsPublished = entity.IsPublished;
    //                            Result.List.Add(result1);
    //                        }
    //                    }
    //                }

    //                Counter = Result.List.Where(s => s.IsPublished == true && s.IsDeleted == false).Count();
    //                ArKeyword.Text = " كلمة البحث : " + keyword;
    //                lstArSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
    //                lstArSearchData.DataBind();

    //                lblArSearchCount.Text = Counter.ToString();
    //            }


    //            else
    //            {
    //                ArKeyword.Text = keyword + " : كلمة البحث ";
    //                if (Result.List.Count == 0)
    //                {
    //                    Counter = Result.List.Where(s => s.IsPublished == true && s.IsDeleted == false).Count();
    //                    lstArSearchData.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList();
    //                    lstArSearchData.DataBind();
    //                    lblArSearchCount.Text = "لم يتم العثور على نتائج";
    //                }
    //            }

    //            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                pager = lstArSearchData.FindControl("DataPager1") as DataPager;
    //            }
    //            else
    //            {
    //                pager = lstArSearchData.FindControl("DataPager1") as DataPager;
    //            }
    //            pager.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["SearchPageSize"]);

    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }

    //}

    int item = 1;
    protected void lstData_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label lblContent = (Label)e.Item.FindControl("lblContent");
            HtmlGenericControl tr = (HtmlGenericControl)e.Item.FindControl("trBorder");
            lblContent.Text = Regex.Replace(lblContent.Text, "<[^>]*>", string.Empty);
            if (lblContent.Text.Length > 440)
            {
                lblContent.Text = lblContent.Text.Substring(0, 440) + "..";
            }
            if (item != Counter)
            {
                if (item != Counter)
                    tr.Style.Add("border-bottom", "1px dotted #928f8f");
            }

            item++;
        }

    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager pager1;

        pager1 = lstArSearchData.FindControl("DataPager1") as DataPager;

        (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.FillBage();
        //-------For call hightlight jquery function--------//
        string keyword = Request.QueryString["keyword"].ToString();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "highlightWord('.example','" + keyword + "', 'highlight');", true);
    }


    protected void lstData_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try
        {
            DataPager pager1;
            pager1 = lstArSearchData.FindControl("DataPager1") as DataPager;
            (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.FillBage();
            Update.Focus();
        }
        catch (Exception ex)
        {

        }
    }

}