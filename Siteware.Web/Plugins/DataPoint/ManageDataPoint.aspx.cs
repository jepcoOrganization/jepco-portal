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
using System.Web.Services;
using System.Globalization;

namespace Siteware.Web.Plugins.DataPoint
{
    public partial class ManageDataPoint : System.Web.UI.Page
    {
        string PageName = "DataPoint";
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
                        Session["DataPointIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/DataPoint/ManageDataPoint.aspx";

                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
            }
        }
        protected async void FillData()
        {
            ResultList<PluginDataPointEntity> Result = new ResultList<PluginDataPointEntity>();

            Result = await PluginDataPointDomain.GetDataPointAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstDataPoint.DataSource = Result.List.ToList();
                lstDataPoint.DataBind();
            }
        }

        protected void lstDataPoint_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                System.Web.UI.WebControls.Label lblPublishDate = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");                
            }
        }
        protected void lstDataPoint_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["DataPointIDSession"] = ID;

                Response.Redirect("~/Plugins/DataPoint/EditDataPoint.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["DataPointIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected async void DeleteItem()
        {
            if (Session["DataPointIDSession"] != null)
            {
                PluginDataPointEntity entity = new PluginDataPointEntity();

                entity.ID = Convert.ToInt32(Session["DataPointIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await PluginDataPointDomain.UpdateDataPointByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["DataPointIDSession"] = null;
                }
            }
            foreach (System.Web.UI.WebControls.ListViewItem item in lstDataPoint.Items)
            {
                System.Web.UI.WebControls.CheckBox CBID = ((System.Web.UI.WebControls.CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    System.Web.UI.WebControls.Label ID = ((System.Web.UI.WebControls.Label)item.FindControl("lblID"));
                    PluginDataPointEntity entity = new PluginDataPointEntity();
                    entity.ID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await PluginDataPointDomain.UpdateDataPointByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/DataPoint/AddDataPoint.aspx", false);
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/DataPoint/ManageDataPoint.aspx", false);
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