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
    private byte CurrLangID;
    int newsCount = 1;
    public int MenuIDs = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }
            FillData();
            FillNews();
            FillCompnay();
            FillNotification();
        }
        //if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.English))
        //{
        //    pager1 = lstNews.FindControl("DataPager1") as DataPager;

        //}
        //else
        //{
        //    pager1 = lstNews.FindControl("DataPager1") as DataPager;

        //}
        //if (pager1 != null)
        //{
        //    pager1.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        //}
    }

    protected void FillData()
    {
        string urllang = Page.RouteData.Values["Language"].ToString();
        string AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
        string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;
      
      

        ResultEntity<NavigationEntity> Result1 = new ResultEntity<NavigationEntity>();
        //Result1 = await NavigationDomain.GetNavigationByUrl(Alias, 2);
        Result1 = NavigationDomain.GetNavigationByUrlnotAsync(Alias, 2);
        MenuIDs = Result1.Entity.ID;
        if (Result1.Entity.ParentID == 0)
        {
            ResultList<NavigationEntity> NavigationResult = new ResultList<NavigationEntity>();
            NavigationResult = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(1));
            lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == 1).OrderBy(q => q.MenuOrder).ToList();
            lstSecNav.DataBind();

        }
        else
        {
            ResultList<NavigationEntity> NavigationResult = new ResultList<NavigationEntity>();
            NavigationResult = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(Result1.Entity.ParentID));
            //lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == Convert.ToInt32(Result1.Entity.ParentID)).OrderBy(q => q.MenuOrder).ToList();
            //lstSecNav.DataBind();

            var NavCount = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == Convert.ToInt32(Result1.Entity.ParentID)).OrderBy(q => q.MenuOrder).ToList();

            if (NavCount.Count >= 1)
            {
                lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == Convert.ToInt32(Result1.Entity.ParentID)).OrderBy(q => q.MenuOrder).ToList();
                lstSecNav.DataBind();
            }
            else
            {
                lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == 1).OrderBy(q => q.MenuOrder).ToList();
                lstSecNav.DataBind();
            }
        }


    }

  protected  void FillNews()
    {
        try
        {
            ResultList<NewsEntity> res = new ResultList<NewsEntity>();
            res =  NewsDomain.GetNewsAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstNews.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderByDescending(s => s.NewsDate).ThenBy(s => s.NewsOrder).ToList();
                lstNews.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void lstNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HiddenField hdnNewsID = (HiddenField)e.Item.FindControl("hdnNewsID");
                Literal lblTitle = (Literal)e.Item.FindControl("lblTitle");
                HyperLink lnkNews = (HyperLink)e.Item.FindControl("lnkNews");
                Literal lblDate = (Literal)e.Item.FindControl("lblDate");
                string lang = string.Empty;
                if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                string title = Regex.Replace(lblTitle.Text, @"[\\:/*#.]+", string.Empty);
                int ID = Convert.ToInt32(hdnNewsID.Value.ToString());
                lnkNews.NavigateUrl = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();

                var date = Convert.ToDateTime(lblDate.Text);


                var m = date.ToString("MMM");
                var month = date.ToString("MMM", new CultureInfo("ar-AE"));
                var Date = date.ToString("dd", new CultureInfo("ar-AE"));

                lblDate.Text = " <span> " + Date + "<small> " + month + " </small></span>";

                Image imgNews = (Image)e.Item.FindControl("imgNews");
                if (!string.IsNullOrEmpty(imgNews.ImageUrl))
                    imgNews.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNews.ImageUrl.Replace("~/", "~/Siteware/");
                


            }
        }
        catch (Exception ex)
        {
        }
    }

    protected  void FillCompnay()
    {
        try
        {
            ResultList<Plugin_AboutCompanyEntity> res = new ResultList<Plugin_AboutCompanyEntity>();
            res =  Plugin_AboutCompanyDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstAboutCompant.DataSource = res.List.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
                lstAboutCompant.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }

    #region--> FillNotification
    protected void FillNotification()
    {
        try
        {
            ResultList<Plugin_NotificationEntity> res = new ResultList<Plugin_NotificationEntity>();
            res = Plugin_NOtificationDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstNotification.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.DateFrom <= currentDate.Date && s.DateTo >= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
                lstNotification.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }



    #endregion


    //protected void FillNews()
    //{
    //    try
    //    {
    //        ResultList<NewsEntity> result = new ResultList<NewsEntity>();
    //        result = NewsDomain.GetNewsAllNotAsync();
    //        if (result.Status == ErrorEnums.Success)
    //        {
    //            var res = result.List;
    //            res = res.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Take(1).ToList();
    //            lblFirstNewsTitle.Text = res[0].Headline;
    //            lblFirstNewsSummery.Text = res[0].Summary;
    //            hdnNeesid.Value = res[0].NewsID.ToString();
    //            //  hdnFirstNewsTime.Value = res[0].NewsDate.ToString();
    //            DateTime DateNews = Convert.ToDateTime(res[0].NewsDate);
    //            string Day = DateNews.ToString("dd", new CultureInfo("en-US"));
    //            string Month = DateNews.ToString("MMMM", new CultureInfo("en-US"));
    //            string Year = DateNews.ToString("yyyy", new CultureInfo("en-US"));
    //            long Views = Convert.ToInt64(res[0].ViewCount);
    //            lblFirstNewsTime.Text = "<span class='date'> " + Month + " " + Day + " " + Year + "</span> <i class='fa fa-eye'></i> " + Views + "";
    //            lnkNewsDetail1.NavigateUrl = "";
    //            imgfirstNews.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + res[0].NewsImage;

    //            string title = Regex.Replace(lblFirstNewsTitle.Text, @"[\\:/*#.]+", "");

    //            int ID = Convert.ToInt32(hdnNeesid.Value.ToString());
    //            lnkNewsDetail1.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();

    //            var newsList = result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.NewsOrder).ThenByDescending(s => s.NewsDate).Skip(1).ToList();
    //            lstNews.DataSource = newsList.ToList();
    //            lstNews.DataBind();


    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    //protected void lstRecentNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            string lang = string.Empty;
    //            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }

    //            ListViewDataItem i = (ListViewDataItem)e.Item;
    //            var c = i.DataItemIndex;
    //            HiddenField hdNewsID = (HiddenField)e.Item.FindControl("hdNewsID");
    //            HiddenField hdnnewsTime = (HiddenField)e.Item.FindControl("hdnnewsTime");

    //            Image imgNews = (Image)e.Item.FindControl("imgNews");
    //            imgNews.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNews.ImageUrl.Replace("~/", "~/Siteware/");

    //            Literal lblNewsTime = (Literal)e.Item.FindControl("lblNewsTime");
    //            HiddenField hdnViewCount = (HiddenField)e.Item.FindControl("hdnViewCount");
    //            DateTime DateNews = Convert.ToDateTime(hdnnewsTime.Value);
    //            string Day = DateNews.ToString("dd", new CultureInfo("en-US"));
    //            string Month = DateNews.ToString("MMMM", new CultureInfo("en-US"));
    //            string Year = DateNews.ToString("yyyy", new CultureInfo("en-US"));
    //            lblNewsTime.Text = "<span class='date'> " + Month + " " + Day + " " + Year + "</span> <i class='fa fa-eye'></i> " + hdnViewCount.Value + "";
    //            HyperLink lnkNewsDetail2 = (HyperLink)e.Item.FindControl("lnkNewsDetail2");

    //            Literal lblNewsTitle = (Literal)e.Item.FindControl("lblNewsTitle");
    //            string title = Regex.Replace(lblNewsTitle.Text, @"[\\:/*#.]+", "");
    //            int ID = Convert.ToInt32(hdNewsID.Value.ToString());
    //            lnkNewsDetail2.NavigateUrl = lang + "/NewsPage/" + title + "/" + ID.ToString();


    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void lstNewsRow_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    try
    //    {
    //        DataPager pager1;
    //        pager1 = lstNews.FindControl("DataPager1") as DataPager;
    //        (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //        this.FillNews();
    //        upanel1.Focus();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    int menucount = 1;
    protected void lstSecNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                HiddenField hndID = (HiddenField)e.Item.FindControl("hndID");

                if ((MenuIDs == Convert.ToInt32(hndID.Value)))
                {
                    //lnkSecondNav.Attributes.Add("Class", "new_custome_active");
                    lnkSecondNav.Style.Add("background", "#007fc3");
                    lnkSecondNav.Style.Add("color", "#fff");
                }


                //if (lnkSecondNav.Target == "1")
                //{
                //    lnkSecondNav.Target = "_blank";
                //}
                //else
                //{
                //    lnkSecondNav.Target = "_parent";
                //}
                menucount++;
            }
        }
        catch (Exception ex)
        {
        }
    }
}