using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.FinancePerformance
{
    public partial class ManageFinancePerformance : System.Web.UI.Page
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
                        Session["FinanceIDSession"] = null;
                        Session["FinanceLanguageID"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/FinancePerformance/ManageFinancePerformance.aspx";

            }
        }
        protected void FillData()
        {
            ResultList<Plugin_FinancePerformanceEntity> Result = new ResultList<Plugin_FinancePerformanceEntity>();

            Result = Plugin_FinancePerformanceDomain.GetAllWithoutAsync();
            Result.List = Result.List.Where(s => s.ParentID == 0).ToList();
            if (Result.Status == ErrorEnums.Success)
            {
                lstFinance.DataSource = Result.List.ToList();
                lstFinance.DataBind();
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

                Session["FinanceIDSession"] = ID;

                Response.Redirect("~/Plugins/FinancePerformance/EditFinancePerformance.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["FinanceIDSession"] = ID;
                mpeSuccess.Show();

            }
            if (e.CommandName == "SubMenuItem")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                Session["FinanceIDSession"] = commandArgs[0];
                Session["FinanceLanguageID"] = commandArgs[1];

                Response.Redirect("~/Plugins/FinancePerformance/SubFinancePerformance/ManageSubFinancePerformance.aspx", false);
            }

        }


        protected async void DeleteItem()
        {
            if (Session["FinanceIDSession"] != null)
            {
                Plugin_FinancePerformanceEntity entity = new Plugin_FinancePerformanceEntity();

                entity.FinanceID = Convert.ToInt32(Session["FinanceIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = await Plugin_FinancePerformanceDomain.UpdateByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["FinanceIDSession"] = null;
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
            Response.Redirect("~/Plugins/FinancePerformance/AddFinancePerformance.aspx", false);
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/FinancePerformance/ManageFinancePerformance.aspx", false);
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