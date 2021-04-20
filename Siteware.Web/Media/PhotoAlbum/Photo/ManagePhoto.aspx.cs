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
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;

namespace Siteware.Web.Pages
{
    public partial class ManagePhoto : System.Web.UI.Page
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
                        FillData();
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

        protected async void FillData()
        {

            ResultList<PluginAlbumDetailEntity> Result = new ResultList<PluginAlbumDetailEntity>();

            Result = await PluginAlbumDetailDomain.GetAlbumByAlbumID(Convert.ToInt32(Session["PhotoAlbumIDSession"].ToString()));
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }
        protected async void GetBannerType(int ID)
        {
            var Result = await BannerTypeDomain.GetBodyBannerByID(ID);
            string BannerName;
            if (Result.Status == ErrorEnums.Success)
            {
                BannerName = Result.Entity.BannerName;
            }
        }
        protected void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["PhotoIDSession"] = ID;

                Response.Redirect("~/Media/PhotoAlbum/Photo/EditPhoto.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DeletData(ID);

            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/PhotoAlbum/Photo/ManagePhoto.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/PhotoAlbum/Photo/AddPhoto.aspx", false);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem lv in this.lstPages.Items)
            {
                CheckBox chk;
                chk = ((CheckBox)lv.FindControl("CheckBox1"));
                Label lblID = ((Label)lv.FindControl("lblPageID"));
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        DeletData(Convert.ToInt32(lblID.Text));
                    }
                }

            }
        }
        protected async void DeletData(int ID)
        {
            ResultEntity<PluginAlbumDetailEntity> Result = await PluginAlbumDetailDomain.DeletePluginAlbumDetail(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Media/PhotoAlbum/Photo/ManagePhoto.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}