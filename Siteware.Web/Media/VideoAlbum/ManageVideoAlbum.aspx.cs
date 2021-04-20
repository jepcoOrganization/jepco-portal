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
using System.Web.Services;

namespace Siteware.Web.Pages
{
    public partial class ManageVideoAlbum : System.Web.UI.Page
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
                        Session["VideoAlbumIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Media/VideoAlbum/ManageVideoAlbum.aspx";

            }
        }

        protected async void FillData()
        {

            ResultList<PluginAlbumEntity> Result = new ResultList<PluginAlbumEntity>();

            Result = await PluginAlbumDomain.GetAlbumByType(3);
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.Where(s => s.IsDeleted == false).ToList();
                lstPages.DataBind();
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

                Session["VideoAlbumIDSession"] = ID;

                Response.Redirect("~/Media/VideoAlbum/EditVideoAlbum.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["VideoAlbumIDSession"] = ID;
                mpeSuccess.Show();
            }
            if (e.CommandName == "AblumDetails")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["VideoAlbumIDSession"] = ID;

                Response.Redirect("~/Media/VideoAlbum/Video/ManageVideo.aspx", false);
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["PhotoAlbumIDSession"]);
            DeletData(ID);
            Response.Redirect("~/Media/VideoAlbum/ManageVideoAlbum.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Media/VideoAlbum/AddVideoAlbum.aspx", false);
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
                        //this.lstPages.DeleteItem(lv.DataItemIndex);
                    }
                }

            }
        }
        protected async void DeletData(int ID)
        {
            ResultEntity<PluginAlbumEntity> Result = await PluginAlbumDomain.DeletePluginAlbum(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Media/VideoAlbum/ManageVideoAlbum.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [WebMethod]
        public static LangDetails[] BindDatatoDropdown()
        {
            try
            {
                ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
                List<LangDetails> details = new List<LangDetails>();
                Result = LanguageDomain.GetLanguagesAllNotAsync();
                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (var item in Result.List)
                    {
                        LangDetails lang = new LangDetails();
                        lang.LangId = item.ID;
                        lang.LangName = item.Name;
                        details.Add(lang);
                    }
                }
                return details.ToArray();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }

    }
}