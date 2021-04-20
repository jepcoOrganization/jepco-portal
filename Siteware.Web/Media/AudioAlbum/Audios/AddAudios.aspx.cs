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
    public partial class AddPhotos : System.Web.UI.Page
    {
        string PageName = "Audio Album";

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
                    FillNavigation();
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
                Session["IDSelectPage"] = "~/Media/AudioAlbum/ManageAudioAlbum.aspx";

            }
        } 
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Session["AudioAlbumIDSession"] != null )
            {
                PluginAlbumDetailEntity entity = new PluginAlbumDetailEntity();
                entity.Title = txtPageName.Text;
                entity.ItemLink = newWinField2.Value.ToString();
                entity.CoverImage = newWinField.Value.ToString();
                entity.AlbumID = Convert.ToInt32(Session["AudioAlbumIDSession"].ToString());
                entity.ItemOredr = Convert.ToInt32(txtorder.Text);
                entity.IsDeleted = false;
                entity.LanguageID = 1;
                entity.IsPublish = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);  
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await PluginAlbumDetailDomain.InsertPluginAlbumDetail(entity);
                if (Result.Status == ErrorEnums.Success)
                {

                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/AudioAlbum/Audios/ManageAudios.aspx", false);
        } 
    }
}