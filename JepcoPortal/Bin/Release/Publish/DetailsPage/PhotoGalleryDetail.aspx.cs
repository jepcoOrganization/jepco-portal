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

public partial class DetailsPage_PhotoGalleryDetail : SiteBasePage
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

            FillPhotoAlbum();
            //}

        }
        catch (Exception ex)
        {
        }
    }
    #region--> Fill Photo Album | Add | Jigar Patel | 11022019
    protected async void FillPhotoAlbum()
    {
        try
        {
            //-----------------Get Parent Link -----------------------------------------
            string PageName = string.Empty;
            int PageID = 0;
            string Alias = string.Empty;
            if (LangID == Convert.ToInt32(EnumLanguage.Arabic))
            {
                PageID = 4042;
                //PageID = 3;
            }
            else
            {
                PageID = 4042;
            }
            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            PageResult = PagesDomain.GetPagesByPageIDNotAsync(PageID);

            if (PageResult.Status == ErrorEnums.Success)
            {
                lstParent.Visible = true;
                lnkParentName.Text = PageResult.Entity.Name;
                lnkParentName.NavigateUrl = PageResult.Entity.AliasPath;
                Alias = PageResult.Entity.AliasPath;
                PageName = Convert.ToString(PageResult.Entity.Name);
            }
            else
            {
                lstParent.Visible = false;
            }


            int ID = Convert.ToInt32(Page.RouteData.Values["ID"].ToString());
            ResultEntity<PluginAlbumEntity> res = new ResultEntity<PluginAlbumEntity>();
            res = await PluginAlbumDomain.GetPluginAlbumByID(ID);
            if (res.Status == ErrorEnums.Success)
            {
                lblPageTitle.Text = res.Entity.Title;
                //lblAlbumTitle.Text = res.Entity.Title;
                lblChildName.Text = res.Entity.Title;

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

                Page.Title = res.Entity.Title + " - " + PageName;
            }
            ResultList<PluginAlbumDetailEntity> Result = new ResultList<PluginAlbumDetailEntity>();
            Result = PluginAlbumDetailDomain.GetAlbumByAlbumIDNotAsync(ID);
            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.IsPublish && !s.IsDeleted && s.PublishDate <= currentDate && s.LanguageID == LangID).OrderBy(s => s.ItemOredr).ToList();
                lstPhotoList.DataSource = Result.List;
                lstPhotoList.DataBind();
                lstPhoto.DataSource = Result.List;
                lstPhoto.DataBind();


               
            }



        }
        catch (Exception ex)
        {
        }
    }
    protected void lstPhotoList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                imgPhoto.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgPhoto.ImageUrl;
            }
        }
        catch
        { }
    }
    int pCount = 0;
    protected void lstPhoto_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                imgPhoto.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgPhoto.ImageUrl;

                HtmlGenericControl divImage = (HtmlGenericControl)e.Item.FindControl("divImage");
                if (pCount == 0)
                {
                    divImage.Attributes.Add("class", "carousel-item active");
                }

                pCount++;
            }
        }
        catch
        { }
    }
    #endregion

}