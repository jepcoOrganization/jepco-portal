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

namespace Siteware.Web.Navigation
{
    public partial class ManageNavigation : System.Web.UI.Page
    {
        string PageName = "Main Navigation";

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
                        Session["NavigationIDSession"] = null;
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
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liNavigation");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");
                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                //ulNav.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Navigation/ManageNavigation.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();

            Result = await NavigationDomain.GetNavigationByRootMenu();
            if (Result.Status == ErrorEnums.Success)
            {
                lstNavigation.DataSource = Result.List.ToList();
                lstNavigation.DataBind();
            }
        }
        protected void lstNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTargetID = (Label)e.Item.FindControl("lblTargetID");

                if (lblTargetID.Text == "1")
                {
                    lblTargetID.Text = "New window";
                }
                else
                {
                    lblTargetID.Text = "Same window";
                }


                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstNavigation_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["NavigationIDSession"] = ID;

                Response.Redirect("~/Navigation/EditNavigation.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["NavigationIDSession"] = ID;
                DeleteRow();

            }
            if (e.CommandName == "SubMenuItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["NavigationIDSession"] = ID;

                Response.Redirect("~/Navigation/SubMenu/ManageSubMenu.aspx", false);
            }
        }
        protected async void DeleteRow()
        {
            if (Session["NavigationIDSession"] != null)
            {
                var Check_Parent = await NavigationDomain.GetNavigationByParentMenuID(Convert.ToInt32(Session["NavigationIDSession"].ToString()));

                if (Check_Parent.List.Count() > 0)
                {
                    mpeSuccess2.Show();
                    return;
                }
                else
                {
                    var Result = await NavigationDomain.UpdateNavigationByIsDeleted(Convert.ToInt32(Session["NavigationIDSession"].ToString()));
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                        Session["NavigationIDSession"] = null;
                    }
                }
            }
            foreach (ListViewItem item in lstNavigation.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label MenuID = ((Label)item.FindControl("lblID"));
                    var Check_Parent = await NavigationDomain.GetNavigationByParentMenuID(Convert.ToInt32(MenuID.Text));

                    if (Check_Parent.List.Count() > 0)
                    {
                        mpeSuccess2.Show();
                        return;
                    }
                    else
                    {
                        var Result = await NavigationDomain.UpdateNavigationByIsDeleted(Convert.ToInt32(MenuID.Text));
                        if (Result.Status == ErrorEnums.Success)
                        {
                            mpeSuccess.Show();
                            Session["NavigationIDSession"] = null;
                        }
                    }
                }
            }

        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Navigation/AddNavigation.aspx", false);
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Navigation/ManageNavigation.aspx", false);
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