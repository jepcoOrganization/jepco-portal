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
    public partial class AddPhotoAlbum : System.Web.UI.Page
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
                        FillNavigation();
                        FillLanguages();
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
                Session["IDSelectPage"] = "~/Media/PhotoAlbum/ManagePhotoAlbum.aspx";

            }
        }
        protected async void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }

        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            PluginAlbumEntity entity = new PluginAlbumEntity();
            entity.Title = txtPageName.Text;
            entity.Image = newWinField.Value.ToString();
            entity.AlbumOrder = Convert.ToInt32(txtorder.Text);
            entity.TypeID = 1;
            entity.IsDeleted = false;
            entity.IsPublish = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.ImageTitle = txtMetaTitle.Text;
            entity.AltIamge = txtMetaDescription.Text;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await PluginAlbumDomain.InsertPluginAlbum(entity);
            if (Result.Status == ErrorEnums.Success)
            {

                mpeSuccess.Show();
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/PhotoAlbum/ManagePhotoAlbum.aspx", false);
        }
    }
}