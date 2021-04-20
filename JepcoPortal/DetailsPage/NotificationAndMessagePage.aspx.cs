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

public partial class DetailsPage_NotificationAndMessagePage : SiteBasePage
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
            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            byte LangID = Convert.ToByte(Session["CurrentLanguage"]);
            int PageID = 0;
            string PageName = string.Empty;

           

            long NewsID = Convert.ToInt64(Page.RouteData.Values["ID"].ToString());

            ResultEntity<MessagesAndNotificationsEntity> ResultNews = new ResultEntity<MessagesAndNotificationsEntity>();
            ResultNews = MessagesAndNotificationsDomain.GetByIDNotAsync(NewsID);

            if (ResultNews.Status == ErrorEnums.Success)
            {


                lblDetail1.Text = FetchLinksFromSource(ResultNews.Entity.Description.ToString());

            }

           
        }
        catch (Exception e)
        {
            string lang = string.Empty;
          
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