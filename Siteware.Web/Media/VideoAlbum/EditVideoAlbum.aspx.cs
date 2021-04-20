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
    public partial class EditVideoAlbum : System.Web.UI.Page
    {
        string PageName = "Video Album";

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
                        Response.Redirect("~/Login.aspx", false);
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
                Session["IDSelectPage"] = "~/Media/VideoAlbum/ManageVideoAlbum.aspx";

            }
        }

        protected async void FillDetails()
        {
            if (Session["VideoAlbumIDSession"] != null)
            {
                int PluginAlbumID = Convert.ToInt32(Session["VideoAlbumIDSession"]);

                ResultEntity<PluginAlbumEntity> Result = new ResultEntity<PluginAlbumEntity>();

                Result = await PluginAlbumDomain.GetPluginAlbumByID(PluginAlbumID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtPageName.Text = Result.Entity.Title;
                    txtorder.Text = Result.Entity.AlbumOrder.ToString();
                    txtMetaTitle.Text = Result.Entity.ImageTitle;
                    CBIsPublished.Checked = Result.Entity.IsPublish;
                    txtMetaDescription.Text = Result.Entity.AltIamge;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                    if (Result.Entity.Image != null && Result.Entity.Image != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.Image.ToString();
                        newWinField.Value = Result.Entity.Image.ToString();
                    }
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            PluginAlbumEntity entity = new PluginAlbumEntity();
            if (Session["VideoAlbumIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["VideoAlbumIDSession"]);
                entity.Title = txtPageName.Text;
                entity.Image = newWinField.Value.ToString();
                entity.AlbumOrder = Convert.ToInt32(txtorder.Text);
                entity.TypeID = 3;
                entity.IsDeleted = false;
                entity.IsPublish = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.LanguageID = 1;
                entity.ImageTitle = txtMetaTitle.Text;
                entity.AltIamge = txtMetaDescription.Text;
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await PluginAlbumDomain.UpdatePluginAlbum(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/VideoAlbum/ManageVideoAlbum.aspx", false);
        }
    }
}