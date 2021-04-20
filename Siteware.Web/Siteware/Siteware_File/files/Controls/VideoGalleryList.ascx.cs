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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_VideoGalleryList : System.Web.UI.UserControl
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 1;
    int acount = 0;
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
            //if(!IsPostBack)
            //{
            FillVideoAlbum();
            //}

        }
        catch (Exception ex)
        {
        }
    }
    #region--> Fill Photo Album 
    List<List<PluginAlbumEntity>> splitResult = new List<List<PluginAlbumEntity>>();
    protected void FillVideoAlbum()
    {
        try
        {
            string PageName = string.Empty;
            int PageID = 0;
            string Alias = string.Empty;
            if (LangID == Convert.ToInt32(EnumLanguage.Arabic))
            {
                PageID = 4043;
                //PageID = 3;
            }
            else
            {
                PageID = 4043;
            }
            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            PageResult = PagesDomain.GetPagesByPageIDNotAsync(PageID);
            //lblContent.Text = FetchLinksFromSource(PageResult.Entity.ContentHTML);
            ResultList<PluginAlbumEntity> Result = new ResultList<PluginAlbumEntity>();
            Result = PluginAlbumDomain.GetAlbumByTypeNotAsync(3);
            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.IsPublish && !s.IsDeleted && s.PublishDate <= currentDate && s.LanguageID == LangID).OrderBy(s => s.AlbumOrder).ToList();
                splitResult = CommonFunction.SplitList(Result.List, 6);
                if (splitResult.Count > 0)
                {
                    lstAlbumDots.DataSource = splitResult;
                    lstAlbumDots.DataBind();
                    dotCount = 0;
                    lstAlbumMain.DataSource = splitResult;
                    lstAlbumMain.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    int dotCount = 0;
    protected void lstAlbumDots_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HtmlGenericControl liAlbum = (HtmlGenericControl)e.Item.FindControl("liAlbum");
                if (dotCount == 0)
                {
                    liAlbum.Attributes.Add("class", "active");
                }
                liAlbum.Attributes.Add("data-slide-to", dotCount.ToString());
                dotCount++;
            }
        }
        catch
        {
        }
    }

    protected void lstAlbumMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HtmlGenericControl divAlbum = (HtmlGenericControl)e.Item.FindControl("divAlbum");
                ListView lstVideoAlbum = (ListView)e.Item.FindControl("lstVideoAlbum");
                if (dotCount == 0)
                {
                    divAlbum.Attributes.Add("class", "carousel-item active");
                }

                lstVideoAlbum.DataSource = splitResult[dotCount];
                lstVideoAlbum.DataBind();

                dotCount++;
            }
        }
        catch
        {
        }
    }

    protected void lstVideoAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkVideoAlbum = (HyperLink)e.Item.FindControl("lnkVideoAlbum");
                HyperLink lnkVideoAlbum1 = (HyperLink)e.Item.FindControl("lnkVideoAlbum1");
                HyperLink lnkVideoAlbum2 = (HyperLink)e.Item.FindControl("lnkVideoAlbum2");
                HiddenField lblAlbumID = (HiddenField)e.Item.FindControl("lblAlbumID");
                Literal lblAlbumTitle = (Literal)e.Item.FindControl("lblAlbumTitle");
                Image imgVideoAlbum = (Image)e.Item.FindControl("imgVideoAlbum");

                if (!string.IsNullOrEmpty(imgVideoAlbum.ImageUrl))
                    imgVideoAlbum.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgVideoAlbum.ImageUrl;

                string lang = string.Empty;
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                string title = Regex.Replace(lblAlbumTitle.Text, @"[\\:/*#.]+", " ");
                int ID = Convert.ToInt32(lblAlbumID.Value.ToString());

                lnkVideoAlbum.NavigateUrl = lang + "/VideoGalleryDetail/" + title + "/" + ID.ToString();
                lnkVideoAlbum1.NavigateUrl = lang + "/VideoGalleryDetail/" + title + "/" + ID.ToString();
                lnkVideoAlbum2.NavigateUrl = lang + "/VideoGalleryDetail/" + title + "/" + ID.ToString();
            }
        }
        catch
        { }
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
                string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                img.SetAttributeValue("src", newsrc);
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
}