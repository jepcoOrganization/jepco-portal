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
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using System.Web.Services;

namespace Siteware.Web.Plugins.Project.SubProject
{
    public partial class ManageSubProject : System.Web.UI.Page
    {
        string PageName = "Project";
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
                        FillDetails();
                        // FillParentMenu();
                        //  FillLanguages();
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
                Session["IDSelectPage"] = "~/Plugins/Project/SubProject/ManageSubProject.aspx";

            }
        }
        protected void FillDetails()
        {
            try
            {
                if(Session["ProjectIDSession"] != null)
                {
                    ResultList<Plugin_ProjectEntities> result = new ResultList<Plugin_ProjectEntities>();
                    result = Plugin_Project_Domain.GetProjectAllNotAsync();
                    if (result.Status == ErrorEnums.Success)
                    {
                        lstProject.DataSource = result.List.Where(s => !s.IsDeleted && s.ParentID == Convert.ToInt64(Session["ProjectIDSession"].ToString())).ToList();
                        lstProject.DataBind();
                    }
                }               
            }
            catch (Exception ex)
            {

            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            List<String> checkedList = new List<string>();
            foreach (ListViewItem item in lstProject.Items)
            {

                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label FormID = ((Label)item.FindControl("lblID"));
                    checkedList.Add(FormID.Text);


                }

                Session.Add("SelectedItems", checkedList);
                var size = checkedList.Count();
            }
            mpeSuccess.Show();
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Project/SubProject/AddSubProject.aspx", false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/Project/SubProject/ManageSubProject.aspx", false);
        }

        protected async void DeleteItem()
        {
            if (Session["SubProjectIDSession"] != null)
            {
                Plugin_ProjectEntities entity = new Plugin_ProjectEntities();

                entity.ID = Convert.ToInt32(Session["SubProjectIDSession"].ToString());
                entity.IsDeleted = true;


                var Result = await Plugin_Project_Domain.Delete(Convert.ToInt32(Session["SubProjectIDSession"].ToString()));
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SubProjectIDSession"] = null;
                }


            }
            var sessionChecked = Session["SelectedItems"] as List<String>;
            if (sessionChecked != null)
            {
                foreach (var item in sessionChecked)
                {
                    Plugin_ProjectEntities entity = new Plugin_ProjectEntities();

                    entity.ID = Convert.ToInt32(Session["SubProjectIDSession"].ToString());
                    entity.IsDeleted = true;
                    var Result = await Plugin_Project_Domain.Delete(Convert.ToInt64(item));
                    if (Result.Status == ErrorEnums.Success)
                    {
                        Session["SubProjectIDSession"] = null;
                    }

                }
            }
        }
        protected void lstProject_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }

        protected void lstProject_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewEdit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    Session["SubProjectIDSession"] = ID;

                    Response.Redirect("~/Plugins/Project/SubProject/EditSubProject.aspx", false);
                }
                if (e.CommandName == "DeleteItem")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Session["SubProjectIDSession"] = ID;
                    mpeSuccess.Show();
                }

            }
            catch (Exception ex)
            {

            }
        }
      
    }
}