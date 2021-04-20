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

namespace Siteware.Web.Plugins.News
{
    public partial class ManageNews : System.Web.UI.Page
    {
        string PageName = "News";
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
                        Session["NewsIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/News/ManageNews.aspx";

                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
            }
        }
        protected async void FillData()
        {
            ResultList<NewsEntity> Result = new ResultList<NewsEntity>();

            Result = await NewsDomain.GetNewsAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstNews.DataSource = Result.List.ToList();
                lstNews.DataBind();
            }
        }
        protected void lstNews_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                Label lblNewsDate = (Label)e.Item.FindControl("lblNewsDate");
                lblNewsDate.Text = Convert.ToDateTime(lblNewsDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstNews_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["NewsIDSession"] = ID;

                Response.Redirect("~/Plugins/News/EditNews.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["NewsIDSession"] = ID;
                mpeSuccess.Show();
            }
        }
        protected async void DeleteItem()
        {
            if (Session["NewsIDSession"] != null)
            {
                NewsEntity entity = new NewsEntity();

                entity.NewsID = Convert.ToInt32(Session["NewsIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await NewsDomain.UpdateNewsByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["NewsIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstNews.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label NewsID = ((Label)item.FindControl("lblID"));
                    NewsEntity entity = new NewsEntity();
                    entity.NewsID = Convert.ToInt32(NewsID.Text);
                    entity.IsDeleted = true;

                    var Result = await NewsDomain.UpdateNewsByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/News/AddNews.aspx", false);
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {

            DeleteItem();
            Response.Redirect("~/Plugins/News/ManageNews.aspx", false);
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
                throw e;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }
    }
}