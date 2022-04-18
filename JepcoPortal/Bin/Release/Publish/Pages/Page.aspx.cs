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
using HtmlAgilityPack;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Pages_Page : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 2;
    public int MenuIDs = 0;
    private byte CurrLangID;
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
        FillData();
        FillCompnay();
        FillNotification();

        //FillNews();
        if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
        {
            LangID = 1;
        }
        else
        {
            LangID = 2;
        }
    }
    protected async void FillData()
    {
        try
        {
            string urllang = Page.RouteData.Values["Language"].ToString();
            string abcd = Page.RouteData.Values["RequestedPage"].ToString();
            string AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
            string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + abcd;
            //string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;
            List<String> keywordList = new List<String>();
            ResultEntity<PagesEntity> Result = new ResultEntity<PagesEntity>();
            ResultEntity<NavigationEntity> Result1 = new ResultEntity<NavigationEntity>();
            ResultList<PagesKeywordEntity> KeywordResult = new ResultList<PagesKeywordEntity>();
            var CountResult = await PagesDomain.UpdateViewCountByAliasPath(Alias);
            Result = await PagesDomain.GetPagesByAliasPath(Alias, 2);
            Result1 = await NavigationDomain.GetNavigationByUrl(Alias, 2);
            if (Result.Status == ErrorEnums.Success)
            {
                if (Result.Entity.IsList)
                {
                    var controlname = Result.Entity.ListLink.Split('/');
                    int cnt = controlname.Count();
                    Control control = LoadControl("/Controls/" + controlname[cnt - 1]);
                    if (!string.IsNullOrEmpty(Result.Entity.ListLink.ToString()))
                    {
                        lblDetail1.Controls.Add(control);
                        //divInner.Visible = false;
                        lblDetail1.Visible = true;

                        //if(Result.Entity.PageID == 4079)   //For Live 4079 When JobApplication For Local 4059
                        //{
                        //    lblJobappDetails.Controls.Add(control);
                        //    divInner.Visible = true;
                        //    lblDetail1.Visible = false;
                        //}
                        //else {
                        //    lblDetail1.Controls.Add(control);
                        //    divInner.Visible = false;
                        //    lblDetail1.Visible = true;
                        //}

                        //if (Result.Entity.PageID == 4057)
                        //{
                        //    lblDetail1.Controls.Add(control); //For Contact us in Arebic
                        //    divInner.Visible = false;
                        //    lblDetail1.Visible = true;
                        //}
                        //else
                        //{
                        //    //lblDetail1.Visible = false;
                        //    //lblControl2.Visible = true;
                        //    //lblControl2.Controls.Add(control);
                        //    //lblDetail.Controls.Add(control);
                        //}

                        //if (Result.Entity.ContentHTML.Length > 0)
                        //{
                        //    lblContentDetails.Text = FetchLinksFromSource(Result.Entity.ContentHTML.ToString());
                        //}
                    }
                }
                else
                {
                    // lblDetail.Visible = false;                    
                    if (Result.Entity.ContentHTML.Length > 0)
                    {
                        if (Result.Entity.PageID == 4059) //When UI-Kit for Local 4058 || For Live 4059 
                        {
                            lblDetail1.Text = FetchLinksFromSource(Result.Entity.ContentHTML.ToString());
                            //divInner.Visible = false;
                            lblDetail1.Visible = true;
                        }
                        else
                        {
                            //lblContentDetails.Text = FetchLinksFromSource(Result.Entity.ContentHTML.ToString());
                            //divInner.Visible = true;
                            //lblDetail1.Visible = false;
                        }

                    }
                    
                }
                if (Result.Entity.ParentID > 0)
                {
                    ResultEntity<PagesEntity> ParentResult = new ResultEntity<PagesEntity>();
                    ParentResult = await PagesDomain.GetPagesByPageID(Result.Entity.ParentID);
                    //lnkParentName.Text = ParentResult.Entity.Name;
                    //lnkParentName.NavigateUrl = ParentResult.Entity.AliasPath;
                    //lstParent.Visible = true;
                }
                else
                {
                    //lstParent.Visible = false;
                }
                //lblChildName.Text = Result.Entity.Name;
                //lblPageName.Text = Result.Entity.Name;
                Page.Title = Result.Entity.MetaTitle;

                Page.MetaDescription = Result.Entity.MetaDescription.ToString();

                KeywordResult = await PagesKeywordDomain.GetKeywordByPageID(Result.Entity.PageID);
                string keywords = string.Empty;
                if (KeywordResult.Status == ErrorEnums.Success)
                {
                    foreach (PagesKeywordEntity item in KeywordResult.List)
                    {
                        if (keywords.Length == 0)
                        {
                            keywords = item.Keyword;
                        }
                        else
                        {
                            keywords = keywords + "," + item.Keyword;
                        }
                    }
                }

                Page.MetaKeywords = keywords;

                HtmlMeta htmlMeta = new HtmlMeta();
                htmlMeta.HttpEquiv = "author";
                htmlMeta.Name = "author";
                htmlMeta.Content = Result.Entity.SEOAttribute;
                this.Page.Header.Controls.Add(htmlMeta);

                MenuIDs = Result1.Entity.ID;

                if (Result1.Entity.ParentID == 0)
                {
                    //ResultList<NavigationEntity> NavigationResult = new ResultList<NavigationEntity>();
                    //NavigationResult = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(1));
                    //lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == 1).OrderBy(q => q.MenuOrder).ToList();
                    //lstSecNav.DataBind();

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
                        //lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == Convert.ToInt32(Result1.Entity.ParentID)).OrderBy(q => q.MenuOrder).ToList();
                        //lstSecNav.DataBind();
                    }
                    else
                    {
                        //lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == 1).OrderBy(q => q.MenuOrder).ToList();
                        //lstSecNav.DataBind();
                    }
                }



                //if (Result1.Entity.ParentID > 0)
                //{


                //}
                //else
                //{
                //    //lstSecNav.DataSource = NavigationResult.List.Where(q => q.IsPublished == true && q.IsDeleted == false && q.LanguageID == CurrLangID && q.ParentID == 1).OrderBy(q => q.MenuOrder).ToList();
                //    //lstSecNav.DataBind();
                //}
            }
            else
            {
                Response.Redirect("/" + urllang + "/home", false);
            }
        }
        catch (Exception e)
        {
            string lang = string.Empty;
            //if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            //{
            //    lang = "/ar";
            //}
            //else
            //{
            //    lang = "/en";
            //}
            //Response.Redirect(lang + "/home", false);
            //throw e;
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

                //lstAboutCompant.DataSource = res.List.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
                //lstAboutCompant.DataBind();

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

                //lstNotification.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.DateFrom <= currentDate.Date && s.DateTo >= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
                //lstNotification.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }


   
    #endregion
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