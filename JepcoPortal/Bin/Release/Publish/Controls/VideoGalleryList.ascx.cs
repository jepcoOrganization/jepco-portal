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
    DataPager pager1;
    int acount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
                {
                    LangID = 1;
                }
                else
                {
                    LangID = 2;
                }
                FillVideoAlbum();
            }
            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.English))
            {
                pager1 = lstAlbumMain.FindControl("DataPager1") as DataPager;

            }
            else
            {
                pager1 = lstAlbumMain.FindControl("DataPager1") as DataPager;

            }
            if (pager1 != null)
            {
                pager1.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["VGallerySize"]);
            }
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
            ResultList<PluginAlbumEntity> Result = new ResultList<PluginAlbumEntity>();
            ResultList<PluginAlbumDetailEntity> ResultVideo = new ResultList<PluginAlbumDetailEntity>();
            Result = PluginAlbumDomain.GetAlbumByTypeNotAsync(3);
            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.IsPublish && !s.IsDeleted && s.PublishDate <= currentDate && s.LanguageID == LangID).OrderBy(s => s.AlbumOrder).ToList();
                foreach (PluginAlbumEntity itm in Result.List)
                {
                    var subResult = PluginAlbumDetailDomain.GetAlbumByAlbumIDNotAsync(itm.ID);
                    if (subResult.Status == ErrorEnums.Success)
                    {
                        subResult.List = subResult.List.Where(s => !s.IsDeleted && s.IsPublish).OrderBy(s => s.ItemOredr).ToList();
                        ResultVideo.List.AddRange(subResult.List);
                    }
                }
                if (ResultVideo.List.Count > 0)
                {
                    lstAlbumMain.DataSource = ResultVideo.List.OrderBy(s => s.ItemOredr).ToList();
                    lstAlbumMain.DataBind();

                    vCount = 0;
                    int rowIndex = Convert.ToInt32(hdnRowIndex.Value);
                    int maxRow = Convert.ToInt32(ConfigurationManager.AppSettings["VGallerySize"]);

                    if (rowIndex == 0)
                    {
                        lstVideo.DataSource = ResultVideo.List.OrderBy(s => s.ItemOredr).Take(maxRow).ToList();
                        lstVideo.DataBind();
                    }
                    else
                    {
                        lstVideo.DataSource = ResultVideo.List.OrderBy(s => s.ItemOredr).Skip(rowIndex).Take(maxRow).ToList();
                        lstVideo.DataBind();
                    }

                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstAlbumMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgVideoAlbum = (Image)e.Item.FindControl("imgVideoAlbum");

                if (!string.IsNullOrEmpty(imgVideoAlbum.ImageUrl))
                    imgVideoAlbum.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgVideoAlbum.ImageUrl;
            }
        }
        catch
        {
        }
    }
    int vCount = 0;
    protected void lstVideo_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HiddenField lblSource = (HiddenField)e.Item.FindControl("lblSource");
                HiddenField lblOpenIn = (HiddenField)e.Item.FindControl("lblOpenIn");
                HtmlSource src1 = (HtmlSource)e.Item.FindControl("src1");
                HtmlVideo vidGallery = (HtmlVideo)e.Item.FindControl("vidGallery");
                HtmlGenericControl divImage = (HtmlGenericControl)e.Item.FindControl("divImage");
                HtmlIframe embed1 = (HtmlIframe)e.Item.FindControl("embed1");
                if (lblOpenIn.Value == "1")
                {
                    embed1.Src = string.Empty;
                    src1.Src = ConfigurationManager.AppSettings["ImagePath"] + lblSource.Value;
                    vidGallery.Style.Remove("display");
                }
                else
                {
                    embed1.Style.Remove("display");
                }
                if (vCount == 0)
                {
                    divImage.Attributes.Add("class", "carousel-item active");
                }

                vCount++;
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion
    #region--> Others
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
    #endregion

    protected void lstAlbumMain_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try
        {
            DataPager pager1;
            pager1 = lstAlbumMain.FindControl("DataPager1") as DataPager;
            (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            hdnRowIndex.Value = e.StartRowIndex.ToString();
            this.FillVideoAlbum();
            //upanel1.Focus();
        }
        catch (Exception ex)
        {

        }
    }
}