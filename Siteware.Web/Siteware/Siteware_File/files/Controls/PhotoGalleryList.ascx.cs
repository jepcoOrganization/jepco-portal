using SiteWare.Entity.Common.Entities;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using SiteWare.Entity.Entities;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Enums;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class Controls_PhotoGalleryList : System.Web.UI.UserControl
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

            FillPhotoAlbum();
            //}

        }
        catch (Exception ex)
        {
        }
    }
    #region--> Fill Photo Album | Add | Jigar Patel | 11022019
    protected void FillPhotoAlbum()
    {
        try
        {
            string PageName = string.Empty;
            int PageID = 0;
            // albumCount = 0;
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
            // lblContent.Text = FetchLinksFromSource(PageResult.Entity.ContentHTML);
            ResultList<PluginAlbumEntity> Result = new ResultList<PluginAlbumEntity>();
            Result = PluginAlbumDomain.GetAlbumByTypeNotAsync(1);
            if (Result.Status == ErrorEnums.Success)
            {
                Result.List = Result.List.Where(s => s.IsPublish && !s.IsDeleted && s.PublishDate <= currentDate && s.LanguageID == LangID && s.TypeID == 1).OrderBy(s => s.AlbumOrder).ToList();
                lstTopPhotoAlbum.DataSource = Result.List.Take(2).ToList();
                lstTopPhotoAlbum.DataBind();

                lstPhotoAlbum2.DataSource = Result.List.Skip(2).Take(2).ToList();
                lstPhotoAlbum2.DataBind();

                lstPhotoAlbum3.DataSource = Result.List.Skip(4).ToList();
                lstPhotoAlbum3.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lstTopPhotoAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
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
                HiddenField lblAlbumID = (HiddenField)e.Item.FindControl("lblAlbumID");
                Literal lblAlbumTitle = (Literal)e.Item.FindControl("lblAlbumTitle");
                HyperLink lnkPhotoAlbum = (HyperLink)e.Item.FindControl("lnkPhotoAlbum");
                HyperLink lnkPhotoAlbum1 = (HyperLink)e.Item.FindControl("lnkPhotoAlbum1");
                Image imgPhotoAlbum = (Image)e.Item.FindControl("imgPhotoAlbum");
                HtmlGenericControl brTag = (HtmlGenericControl)e.Item.FindControl("brTag");

                imgPhotoAlbum.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgPhotoAlbum.ImageUrl;
                string title = Regex.Replace(lblAlbumTitle.Text, @"[\\:/*#.]+", " ");

                int ID = Convert.ToInt32(lblAlbumID.Value.ToString());

                lnkPhotoAlbum.NavigateUrl = lang + "/PhotoGalleryDetail/" + title + "/" + ID.ToString();
                lnkPhotoAlbum1.NavigateUrl = lang + "/PhotoGalleryDetail/" + title + "/" + ID.ToString();
            }
        }
        catch
        {

        }
    }

    protected void lstPhotoAlbum2_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

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