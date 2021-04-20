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
    public partial class ManageLogo : System.Web.UI.Page
    {
        string PageName = "Logo";

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
                        Session["LogoIDSession"] = null;
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
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/Logo/ManageLogo.aspx";

            }
        }

        protected async void FillData()
        {

            ResultList<PluginLogoEntity> Result = new ResultList<PluginLogoEntity>();

            Result = await PluginLogoDomain.GetPluginLogoAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }

        protected void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTaget = (Label)e.Item.FindControl("lblTaget");

                if (lblTaget.Text == "_blank")
                {
                    lblTaget.Text = "New Window";
                }
                else { lblTaget.Text = "Same Window"; }
            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["LogoIDSession"] = ID;

                Response.Redirect("~/Plugins/Logo/EditLogo.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["LogoIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/Logo/ManageLogo.aspx", false);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Logo/AddLogo.aspx", false);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }       
        protected async void DeleteItem()
        {
            if (Session["LogoIDSession"] != null)
            {
                PluginLogoEntity entity = new PluginLogoEntity();

                entity.ID = Convert.ToInt32(Session["LogoIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await PluginLogoDomain.DeleteLogo(entity.ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["LogoIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstPages.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label ID = ((Label)item.FindControl("lblID"));
                    PluginLogoEntity entity = new PluginLogoEntity();
                    entity.ID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await PluginLogoDomain.DeleteLogo(entity.ID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }


    }
}