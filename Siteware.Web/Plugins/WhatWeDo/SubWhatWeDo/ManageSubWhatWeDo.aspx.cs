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

namespace Siteware.Web.Plugins.What_We_Do.SubWhatWeDo
{
    public partial class ManageSubWhatWeDo : System.Web.UI.Page
    {
        string PageName = "What We Do";
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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liNavigation");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");
                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                ////liNavigation.Attributes.Add("class", "active");
                //ulNav.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/WhatWeDo/SubWhatWeDo/ManageSubWhatWeDo.aspx";

            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            List<String> checkedList = new List<string>();
            foreach (ListViewItem item in lstFacility.Items)
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
            Response.Redirect("~/Plugins/WhatWeDo/SubWhatWeDo/AddSubWhatWeDo.aspx", false);
        }

        protected void btnOk222_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/WhatWeDo/SubWhatWeDo/ManageSubWhatWeDo.aspx", false);
        }
        protected void FillDetails()
        {
            try
            {
                if (Session["FacilityIDSession"] != null)
                {
                    long ParentID = Convert.ToInt64(Session["FacilityIDSession"].ToString());
                    ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();
                    result = Plugin_Facility_Domain.GetFacilityByParentIDNotAsync(ParentID);
                    lstFacility.DataSource = result.List.Where(s => !s.IsDeleted).ToList();
                    lstFacility.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }
        protected void lstFacility_ItemDataBound1(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }

        protected void lstFacility_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewEdit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    Session["SubFacilityIDSession"] = ID;

                    Response.Redirect("~/Plugins/WhatWeDo/SubWhatWeDo/EditSubWhatWeDo.aspx", false);
                }
                if (e.CommandName == "DeleteItem")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Session["SubFacilityIDSession"] = ID;
                    mpeSuccess.Show();


                }
            }
            catch (Exception ex)
            {

            }
        }
        protected async void DeleteItem()
        {
            if (Session["SubFacilityIDSession"] != null)
            {
                Plugin_Facility_Entity entity = new Plugin_Facility_Entity();

                entity.ID = Convert.ToInt32(Session["SubFacilityIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await Plugin_Facility_Domain.Delete(Convert.ToInt32(Session["SubFacilityIDSession"].ToString()));
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SubFacilityIDSession"] = null;
                }
            }
            var sessionChecked = Session["SelectedItems"] as List<String>;
            if (sessionChecked != null)
            {
                foreach (var item in sessionChecked)
                {
                    Plugin_Facility_Entity entity = new Plugin_Facility_Entity();

                    entity.ID = Convert.ToInt32(Session["SubFacilityIDSession"].ToString());
                    entity.IsDeleted = true;
                    var Result = await Plugin_Facility_Domain.Delete(Convert.ToInt64(item));
                    if (Result.Status == ErrorEnums.Success)
                    {
                        //mpeSuccess.Show();
                    }

                }
            }
        }
    }
}