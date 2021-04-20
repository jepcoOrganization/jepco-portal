using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;


namespace Siteware.Web.Pages
{
    public partial class EditPhoto : System.Web.UI.Page
    {
        string PageName = "Photo Album";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!FunctionSecurity.TestUserPermissionPage(SessionManager.GetInstance.Users.UserID, PageName))
                {

                    Response.Redirect("~/DashBoard.aspx", false);
                }
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                   // divpageurl.Visible = false;
                    FillNavigation(); 
                    FillDetails();
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx",false);
                }
            }
             }
            catch
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/Login.aspx", false);
            }
        }
        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liMedia = (HtmlGenericControl)masterPage.FindControl("liMedia");
                //HtmlGenericControl ulMedia = (HtmlGenericControl)masterPage.FindControl("ulMedia");

                //liDashboard.Attributes.Add("class", "");
                //liMedia.Attributes.Add("class", "active dropdown");
                //ulMedia.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Media/PhotoAlbum/ManagePhotoAlbum.aspx";

            }
        } 
        protected async void FillDetails()
        {
            if (Session["PhotoIDSession"] != null)
            {
                int PhotoID = Convert.ToInt32(Session["PhotoIDSession"]);

                ResultEntity<PluginAlbumDetailEntity> Result = new ResultEntity<PluginAlbumDetailEntity>();

                Result = await PluginAlbumDetailDomain.GetPluginAlbumDetailByID(PhotoID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtPageName.Text = Result.Entity.Title; 
                    txtorder.Text = Result.Entity.ItemOredr.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublish;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);                    

                    if (Result.Entity.CoverImage != null && Result.Entity.CoverImage != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.CoverImage.ToString();
                        newWinField.Value = Result.Entity.CoverImage.ToString();
                    }
                }
            } 
        } 
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            PluginAlbumDetailEntity entity = new PluginAlbumDetailEntity();
            if (Session["PhotoIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["PhotoIDSession"]);
                entity.Title = txtPageName.Text;
                entity.ItemLink = newWinField.Value.ToString();
                entity.CoverImage = newWinField.Value.ToString();
                entity.AlbumID = Convert.ToInt32(Session["PhotoAlbumIDSession"].ToString());
                entity.ItemOredr = Convert.ToInt32(txtorder.Text);
                entity.IsDeleted = false;
                entity.LanguageID = 1;
                entity.IsPublish = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.OpenIn = string.Empty;

                var Result = await PluginAlbumDetailDomain.UpdatePluginAlbumDetail(entity);
                if (Result.Status == ErrorEnums.Success)
                { 
                    mpeSuccess.Show();
                }
            }
            
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/PhotoAlbum/Photo/ManagePhoto.aspx", false);
        } 
    }
} 