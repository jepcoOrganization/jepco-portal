using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailsPage_AnnoucePage : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 2;
    public int MenuIDs = 0;
    private byte CurrLangID;

    protected void Page_Load(object sender, EventArgs e)
    {
        CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
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
                FillData();
                FillCompnay();
                FillNotification();
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

    protected async void FillData()
    {
        try
        {
            // int NewsID = 1;

            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            byte LangID = Convert.ToByte(Session["CurrentLanguage"]);
            int PageID = 0;
            string PageName = string.Empty;

            string Alias = string.Empty;
            if (LangID == Convert.ToInt32(EnumLanguage.Arabic))
            {
                PageID = 5056;
                //PageID = 3;
            }
            else
            {
                PageID = 5056;
            }

            PageResult = PagesDomain.GetPagesByPageIDNotAsync(PageID);
            PageName = Convert.ToString(PageResult.Entity.Name);

            if (PageResult.Status == ErrorEnums.Success)
            {
                if (PageResult.Entity.LanguageID == Convert.ToInt32(EnumLanguage.English))
                {
                    lnkParentName.NavigateUrl = PageResult.Entity.AliasPath;
                    lnkParentName.Text = PageResult.Entity.Name;
                }
                else
                {
                    lnkParentName.NavigateUrl = PageResult.Entity.AliasPath;
                    lnkParentName.Text = PageResult.Entity.Name;
                }
            }
            else
            {
                lstParent.Visible = false;
            }

            int AnnouncementID = Convert.ToInt32(Page.RouteData.Values["ID"].ToString());

            ResultEntity<PluginAnnouncementEntity> ResultNews = new ResultEntity<PluginAnnouncementEntity>();
            ResultNews = await PluginAnnouncementDomain.GetPagesByAnnouncementID(AnnouncementID);

            if (ResultNews.Status == ErrorEnums.Success)
            {

                Page.MetaDescription = Regex.Replace(ResultNews.Entity.Description.ToString(), @"<[^>]+>|&nbsp;", "").Trim();
                Page.Title = ResultNews.Entity.Title + "-" + PageName;
                lblPageName.Text = ResultNews.Entity.Title;
                lblChildName.Text = ResultNews.Entity.Title;
                lblContentDetails.Text = FetchLinksFromSource(ResultNews.Entity.Description.ToString());

            }

            string urllang = Page.RouteData.Values["Language"].ToString();
            string AliasPath = string.Empty;
            Alias = PageResult.Entity.AliasPath;
            //try {
            //    AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
            //}
            //catch (Exception ex) {
            //}
            // Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;

            ResultEntity<NavigationEntity> Result1 = new ResultEntity<NavigationEntity>();
            Result1 = await NavigationDomain.GetNavigationByUrl(Alias, 2);

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
        catch (Exception e)
        {
            throw;
        }
    }

    protected async void FillCompnay()
    {
        try
        {
            ResultList<Plugin_AboutCompanyEntity> res = new ResultList<Plugin_AboutCompanyEntity>();
            res = await Plugin_AboutCompanyDomain.GetAll();
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


    public string FetchLinksFromSource(string htmlSource)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        if (doc.DocumentNode.SelectNodes("//img") != null)
        {
            foreach (var img in doc.DocumentNode.SelectNodes("//img"))
            {
                string orig = img.Attributes["src"].Value;
                if (orig.Contains("http://") || orig.Contains("https://"))
                {
                    img.SetAttributeValue("src", orig);
                }
                else
                {
                    string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                    img.SetAttributeValue("src", newsrc);
                }

            }
        }
        if (doc.DocumentNode.SelectNodes("//table") != null)
        {
            foreach (var table in doc.DocumentNode.SelectNodes("//table"))
            {
                //table.SetAttributeValue("class", "Tblres");
                table.SetAttributeValue("class", "comntable");
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
    int menucount = 1;
    protected void lstSecNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                HiddenField hndID = (HiddenField)e.Item.FindControl("hndID");

                if (MenuIDs == Convert.ToInt32(hndID.Value))
                {

                    //lnkSecondNav.Style.Add("background", "#007fc3");
                    //lnkSecondNav.Style.Add("color", "#fff");
                    lnkSecondNav.Attributes.Add("class", "active");
                    //lnkSecondNav.Attributes.CssStyle.Add("class", "asdasd");
                }

                if (lnkSecondNav.Target == "1")
                {
                    lnkSecondNav.Target = "_blank";
                }
                else
                {
                    lnkSecondNav.Target = "_parent";
                }
                menucount++;
            }
        }
        catch (Exception ex)
        {
        }
    }
}