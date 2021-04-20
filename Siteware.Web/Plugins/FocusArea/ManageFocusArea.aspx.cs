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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.FocusArea
{
    public partial class ManageFocusArea : System.Web.UI.Page
    {
        string PageName = "Focus Area";
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
                        Session["FocusIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/FocusArea/ManageFocusArea.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();

            Result = await Plugin_Focus_AreaDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstFocusArea.DataSource = Result.List.ToList();
                lstFocusArea.DataBind();
            }
        }
        protected void lstFocusArea_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                Label lblColor = (Label)e.Item.FindControl("lblColor");
                HtmlGenericControl divColor = (HtmlGenericControl)e.Item.FindControl("divColor");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
                if (!string.IsNullOrEmpty(lblColor.Text))
                {
                    divColor.Style.Add("background-color", lblColor.Text);
                }
            }
        }

        protected void lstFocusArea_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["FocusIDSession"] = ID;

                Response.Redirect("~/Plugins/FocusArea/EditFocusArea.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["FocusIDSession"] = ID;
                mpeSuccess.Show();
            }
        }
        protected async void DeleteItem()
        {
            if (Session["FocusIDSession"] != null)
            {
                Plugin_Focus_AreaEntity entity = new Plugin_Focus_AreaEntity();

                entity.FocusID = Convert.ToInt32(Session["FocusIDSession"].ToString());
                entity.IsDelete = true;
                var Result = await Plugin_Focus_AreaDomain.DeleteRecord(entity.FocusID);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["FocusIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstFocusArea.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label FocusID = ((Label)item.FindControl("lblID"));
                    Plugin_Focus_AreaEntity entity = new Plugin_Focus_AreaEntity();
                    entity.FocusID = Convert.ToInt32(FocusID.Text);
                    entity.IsDelete = true;

                    var Result = await Plugin_Focus_AreaDomain.DeleteRecord(entity.FocusID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FocusArea/AddFocusArea.aspx", false);
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {

            DeleteItem();
            Response.Redirect("~/Plugins/FocusArea/ManageFocusArea.aspx", false);
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
                throw e;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }
    }
}