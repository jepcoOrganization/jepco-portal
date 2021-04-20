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

namespace Siteware.Web.Plugins.What_We_Do
{
    public partial class ManageWhatWeDo : System.Web.UI.Page
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
                Session["IDSelectPage"] = "~/Plugins/WhatWeDo/ManageWhatWeDo.aspx";

            }
        }
        protected void FillDetails()
        {
            try
            {
                ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();
                result = Plugin_Facility_Domain.GetFacilityByParentIDNotAsync(0);
                lstFacility.DataSource = result.List.Where(s => !s.IsDeleted).ToList();
                lstFacility.DataBind();
            }
            catch (Exception ex)
            {

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
            Response.Redirect("~/Plugins/WhatWeDo/AddWhatWeDo.aspx", false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/WhatWeDo/ManageWhatWeDo.aspx", false);
        }

        protected async void DeleteItem()
        {
            if (Session["FacilityIDSession"] != null)
            {
                Plugin_Facility_Entity entity = new Plugin_Facility_Entity();

                entity.ID = Convert.ToInt32(Session["FacilityIDSession"].ToString());
                entity.IsDeleted = true;

                var result = await Plugin_Facility_Domain.DeleteByParentID(entity.ID);
                if (result.Status == ErrorEnums.Success)
                {
                    var Result = await Plugin_Facility_Domain.Delete(Convert.ToInt32(Session["FacilityIDSession"].ToString()));
                    if (Result.Status == ErrorEnums.Success)
                    {
                        Session["FacilityIDSession"] = null;
                    }
                }

            }
            var sessionChecked = Session["SelectedItems"] as List<String>;
            if (sessionChecked != null)
            {
                foreach (var item in sessionChecked)
                {
                    Plugin_Facility_Entity entity = new Plugin_Facility_Entity();

                    entity.ID = Convert.ToInt32(Session["FacilityIDSession"].ToString());
                    entity.IsDeleted = true;

                    var result = await Plugin_Facility_Domain.DeleteByParentID(Convert.ToInt64(item));
                    if (result.Status == ErrorEnums.Success)
                    {
                        var Result = await Plugin_Facility_Domain.Delete(Convert.ToInt64(item));
                        if (Result.Status == ErrorEnums.Success)
                        {
                            Session["FacilityIDSession"] = null;
                        }
                    }


                }
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

                    Session["FacilityIDSession"] = ID;

                    Response.Redirect("~/Plugins/WhatWeDo/EditWhatWeDo.aspx", false);
                }
                if (e.CommandName == "DeleteItem")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Session["FacilityIDSession"] = ID;
                    mpeSuccess.Show();
                }
                if (e.CommandName == "SubMenuItem")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    Session["FacilityIDSession"] = ID;

                    Response.Redirect("~/Plugins/WhatWeDo/SubWhatWeDo/ManageSubWhatWeDo.aspx", false);
                }
            }
            catch (Exception ex)
            {

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