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

namespace Siteware.Web.Plugins.FinancePerformance.SubFinancePerformance
{
    public partial class ManageSubFinancePerformance : System.Web.UI.Page
    {
        string PageName = "FinancePerformance";
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
                        Session["SubFinanceIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/FinancePerformance/SubFinancePerformance/ManageSubFinancePerformance.aspx";

            }
        }
        protected void FillData()
        {
            ResultList<Plugin_FinancePerformanceEntity> Result1 = new ResultList<Plugin_FinancePerformanceEntity>();

            if (Session["FinanceIDSession"] != null && Session["FinanceLanguageID"] != null)
            {
                int ParentID = Convert.ToInt32(Session["FinanceIDSession"]);
                int LangID = Convert.ToInt32(Session["FinanceLanguageID"]);

                Result1 = Plugin_FinancePerformanceDomain.GetAllWithoutAsync();
                Result1.List = Result1.List.Where(s => s.ParentID == ParentID && s.LanguageID == LangID).ToList();
                if (Result1.Status == ErrorEnums.Success)
                {
                    lstFinance.DataSource = Result1.List.ToList();
                    lstFinance.DataBind();
                }
            }

        }

        protected void lstFinance_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTarget = (Label)e.Item.FindControl("lblTarget");
                if (lblTarget.Text == "_blank")
                {
                    lblTarget.Text = "New Window";
                }
                else { lblTarget.Text = "Same Window"; }
            }
        }

        protected void lstFinance_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SubFinanceIDSession"] = ID;

                Response.Redirect("~/Plugins/FinancePerformance/SubFinancePerformance/EditSubFinancePerformance.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SubFinanceIDSession"] = ID;
                mpeSuccess.Show();

            }
            //if (e.CommandName == "SubMenuItem")
            //{
            //    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            //    Session["FinanceIDSession"] = commandArgs[0];
            //    Session["FinanceLanguageID"] = commandArgs[1];

            //    Response.Redirect("~/Plugins/FinancePerformance/SubFinancePerformance/ManageSubFinancePerformance.aspx", false);
            //}

        }


        protected async void DeleteItem()
        {
            if (Session["SubFinanceIDSession"] != null)
            {
                Plugin_FinancePerformanceEntity entity = new Plugin_FinancePerformanceEntity();

                entity.FinanceID = Convert.ToInt32(Session["SubFinanceIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = await Plugin_FinancePerformanceDomain.UpdateByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SubFinanceIDSession"] = null;
                }

            }
            foreach (ListViewItem item in lstFinance.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label ID = ((Label)item.FindControl("lblID"));
                    Plugin_FinancePerformanceEntity entity = new Plugin_FinancePerformanceEntity();
                    entity.FinanceID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await Plugin_FinancePerformanceDomain.UpdateByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {

                    }
                }
            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FinancePerformance/SubFinancePerformance/AddSubFinancePerformance.aspx", false);
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/FinancePerformance/SubFinancePerformance/ManageSubFinancePerformance.aspx", false);
        }


    }
}