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

namespace Siteware.Web.Plugins.SubmitCV
{
    public partial class ManageSubmitCV : System.Web.UI.Page
    {
        string PageName = "Career";
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
                        Session["SubmitCVIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/SubmitCV/ManageSubmitCV.aspx";

             
            }
        }
        protected async void FillData()
        {
            ResultList<Plugin_SubmitCVEntity> Result = new ResultList<Plugin_SubmitCVEntity>();

            Result = await Plugin_SubmitCVDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstdata.DataSource = Result.List.ToList();
                lstdata.DataBind();
            }
        }
        protected void lstdata_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                //Label lblNewsDate = (Label)e.Item.FindControl("lblNewsDate");
                //lblNewsDate.Text = Convert.ToDateTime(lblNewsDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstdata_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SubmitCVIDSession"] = ID;

                Response.Redirect("~/Plugins/SubmitCV/EditSubmitCV.aspx", false);
            }
            //if (e.CommandName == "DeleteItem")
            //{
            //    int ID = Convert.ToInt32(e.CommandArgument);
            //    Session["NewsIDSession"] = ID;
            //    mpeSuccess.Show();
            //}
        }
    }
}