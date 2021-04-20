using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;

namespace Siteware.Web.Security
{
    public partial class ManageUser : System.Web.UI.Page
    {
        string PageName = "Manage User";

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
                        Session["ManageUserIDSession"] = null;
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


                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active");
                Session["IDSelectPage"] = "~/Security/ManageUser.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<UserEntity> Result = new ResultList<UserEntity>();

            Result = await UsersDomain.GetUserAll();

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

                HiddenField lblStatus = (HiddenField)e.Item.FindControl("lblStatus");
                LinkButton lnkActive = (LinkButton)e.Item.FindControl("lnkActive");
                Image imgActive = (Image)e.Item.FindControl("imgActive");
                if (Convert.ToBoolean(lblStatus.Value) == false)
                {
                    imgActive.ImageUrl = "../AppTheme/Images/Deactive_Mark.png";
                    lnkActive.Attributes.Add("title", "تفعيل");
                }
                else
                {
                    imgActive.ImageUrl = "../AppTheme/Images/Active_Mark.png";
                    lnkActive.Attributes.Add("title", "الغاء التفعيل");
                }


            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["ManageUserIDSession"] = ID;
                Response.Redirect("~/Security/ManageUserPermission.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {

                int ID = Convert.ToInt32(e.CommandArgument);
                Session["ManageUserIDSession"] = ID;
                mpeSuccess.Show();
            }

            if (e.CommandName == "ActiveUser")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                ResultEntity<UserEntity> Result = new ResultEntity<UserEntity>();
                UserEntity entity = new UserEntity();
                Result = UsersDomain.GetUserDataWithoutAsync(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    if (Result.Entity.Status == true)
                    { entity.Status = false; }
                    else
                    { entity.Status = true; }
                    entity.UserID = ID;
                    var Result2 = UsersDomain.UpdateUserStatus(entity);
                    if (Result2.Status == ErrorEnums.Success)
                    {
                        Response.Redirect("~/Security/ManageUser.aspx", false);
                    }
                }
            }


        }
        protected void DeleteData()
        {
            if (Session["ManageUserIDSession"] != null)
            {
                UserEntity entity = new UserEntity();
                entity.UserID = Convert.ToInt32(Session["ManageUserIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = UsersDomain.DeleteUser(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    //  mpeSuccess.Show();
                    Session["ManageUserIDSession"] = null;
                }
            }



        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Security/AddUser.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteData();
            Response.Redirect("~/Security/ManageUser.aspx", false);
        }
    }
}