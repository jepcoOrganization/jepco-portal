using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.WelcomeNote.WelcomeNoteImage
{
    public partial class ManageNoteImage : System.Web.UI.Page
    {
        string PageName = "Welcome Note";
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
                        if (Session["WelcomeNoteIDSession"] != null)
                        {
                            Session["ImageIDSession"] = null;
                            FillNavigation();
                            FillData();
                        }
                        else
                        {
                            Response.Redirect("~/Plugins/WelcomeNote/ManageWelcomeNote.aspx", false);
                        }
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
                Session["IDSelectPage"] = "~/Plugins/WelcomeNote/ManageWelcomeNote.aspx";

            }
        }

        protected async void FillData()
        {
            try
            {
                if (Session["WelcomeNoteIDSession"] != null)
                {
                    ResultList<WelcomeNote_ImageEntity> Result = new ResultList<WelcomeNote_ImageEntity>();

                    Result = await WelcomeNote_ImageDomain.GetAll(Convert.ToInt32(Session["WelcomeNoteIDSession"].ToString()));
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lstPages.DataSource = Result.List.ToList();
                        lstPages.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
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

                Session["ImageIDSession"] = ID;

                Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/EditNoteImage.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DeletData(ID);

            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/ManageNoteImage.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/AddNoteImage.aspx", false);
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
        protected async void DeletData(long ID)
        {
            ResultEntity<WelcomeNote_ImageEntity> Result = await WelcomeNote_ImageDomain.DeleteImage(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/ManageNoteImage.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}