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

namespace Siteware.Web.Setting
{
    public partial class ManageSetting : System.Web.UI.Page
    {
        string PageName = "Settings";

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
                        Session["SettingIDSession"] = null;
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
                //HtmlGenericControl liSettings = (HtmlGenericControl)masterPage.FindControl("liSettings");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liSettings.Attributes.Add("class", "active");
                Session["IDSelectPage"] = "~/Setting/ManageSetting.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<SettingEntity> Result = new ResultList<SettingEntity>();

            Result = await SettingDomain.GetSettingAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstSettings.DataSource = Result.List.ToList();
                lstSettings.DataBind();
            }
        }
        protected void lstSettings_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstSettings_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SettingIDSession"] = ID;

                Response.Redirect("~/Setting/EditSetting.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SettingIDSession"] = ID;
                mpeSuccess.Show();
            }
        }
        protected async void DeleteItem()
        {
            if (Session["SettingIDSession"] != null)
            {
                SettingEntity entity = new SettingEntity();

                entity.ID = Convert.ToInt32(Session["SettingIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await SettingDomain.UpdateByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SettingIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstSettings.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label ID = ((Label)item.FindControl("lblID"));
                    SettingEntity entity = new SettingEntity();
                    entity.ID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await SettingDomain.UpdateByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Setting/AddSetting.aspx", false);
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {

            DeleteItem();
            Response.Redirect("~/Setting/ManageSetting.aspx", false);
        }



    }
}