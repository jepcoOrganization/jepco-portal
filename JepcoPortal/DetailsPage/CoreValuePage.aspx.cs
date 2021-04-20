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

public partial class DetailsPage_CoreValuePage : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 1;
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
                FillData();
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
            // int EventID = Convert.ToInt32(Page.RouteData.Values["ID"].ToString());
            long CoreID = Convert.ToInt64(Page.RouteData.Values["ID"].ToString());
            ResultEntity<Plugin_Core_ValueEntity> Result = new ResultEntity<Plugin_Core_ValueEntity>();
            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            byte LangID = Convert.ToByte(Session["CurrentLanguage"]);
            int PageID = 0;
            string PageName = string.Empty;

            if (LangID == Convert.ToInt32(EnumLanguage.English))
            {
                PageID = 0;
                //PageID = 3;
            }
            else
            {
                PageID = 0;
            }

            PageResult = await PagesDomain.GetPagesByPageID(PageID);
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

            Result = await Plugin_Core_ValueDomain.GetByID(CoreID);

            if (Result.Status == ErrorEnums.Success)
            {
                lblChildName.Text = Result.Entity.Title;
                lblPageTitle.Text = Result.Entity.Title;

                //  lblContentDetails.Text = FetchLinksFromSource(Result.Entity.EventDescription.ToString());

                Page.MetaDescription = Regex.Replace(Result.Entity.Title.ToString(), @"<[^>]+>|&nbsp;", "").Trim();
                if (string.IsNullOrEmpty(PageName))
                {
                    if (LangID == (byte)EnumLanguage.English)
                    {
                        PageName = "Home";
                    }
                    else
                    {
                        PageName = "الصفحة الرئيسية";
                    }
                }
                Page.Title = Result.Entity.Title.ToString() + " - " + PageName;
                lblDetails.Text = FetchLinksFromSource(Result.Entity.Description.ToString());
                //  Plugin_Core_ValueEntity entity = new Plugin_Core_ValueEntity();
                // entity.ID = EventID;
                // entity.ViewCount = Result.Entity.ViewCount;
                // var UpdateCount = await CalendarEventDomain.UpdateEventViewCount(entity);


            }
            else
            {
                string lang = string.Empty;
                if (LangID == (byte)EnumLanguage.English)
                {
                    lang = "/en/";
                }
                else
                {
                    lang = "/ar/";
                }
                Response.Redirect(lang + "home", false);
            }
        }
        catch (Exception e)
        {
            throw;
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
        try
        {
            if (doc.DocumentNode.SelectNodes("//table") != null)
            {
                foreach (var tab in doc.DocumentNode.SelectNodes("//table"))
                {
                    tab.SetAttributeValue("class", "Tblres");
                }
            }
        }
        catch
        {
        }
        return doc.DocumentNode.OuterHtml;
    }
}