using SiteWare.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteWare.Entity.Entities;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Enums;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;


public partial class DetailsPage_VideoGalleryDetail : SiteBasePage
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
            //if(!IsPostBack)
            //{
            FillVideoAlbum();
            //}
            //DataPager pager;
            //pager = lstVideos.FindControl("DataPager1") as DataPager;

            //pager.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        }
        catch (Exception ex)
        {
        }
    }

    #region--> Fill Video Album 
    protected void FillVideoAlbum()
    {
        try
        {
            int ID = Convert.ToInt32(Page.RouteData.Values["ID"].ToString());
            ResultList<PluginAlbumEntity> Result = new ResultList<PluginAlbumEntity>();
            Result = PluginAlbumDomain.GetPluginAlbumByIDNotAsync(ID);
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();
            result = PluginAlbumDetailDomain.GetAlbumByAlbumIDNotAsync(ID);

            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            byte LangID = Convert.ToByte(Session["CurrentLanguage"]);
            int PageID = 0;
            string PageName = string.Empty;

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



            if (result.Status == ErrorEnums.Success)
            {
                result.List = result.List.Where(s => !s.IsDeleted && s.IsPublish).OrderBy(s => s.ItemOredr).ToList();
                lstVideoList.DataSource = result.List;
                lstVideoList.DataBind();
                lstVideo.DataSource = result.List;
                lstVideo.DataBind();
            }
            if (Result.Status == ErrorEnums.Success)
            {
                lblChildName.Text = Result.List[0].Title;
                lblPageTitle.Text = Result.List[0].Title;

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

                Page.Title = Result.List[0].Title + " - " + PageName;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstVideoList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgVideo = (Image)e.Item.FindControl("imgVideo");
                imgVideo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgVideo.ImageUrl;
            }
        }
        catch (Exception ex)
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

}