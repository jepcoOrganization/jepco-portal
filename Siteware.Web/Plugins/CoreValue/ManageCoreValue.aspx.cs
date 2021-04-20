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

namespace Siteware.Web.Plugins.CoreValue
{
    public partial class ManageCoreValue : System.Web.UI.Page
    {
        string PageName = "Core Value";
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
                        Session["CoreIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/CoreValue/ManageCoreValue.aspx";

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
                throw e;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }

        protected async void FillData()
        {
            ResultList<Plugin_Core_ValueEntity> Result = new ResultList<Plugin_Core_ValueEntity>();

            Result = await Plugin_Core_ValueDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstCoreValue.DataSource = Result.List.ToList();
                lstCoreValue.DataBind();
            }
        }

        protected void lstCoreValue_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                    lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                }
            }
            catch (Exception ex) { }
           
        }

        protected void lstCoreValue_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["CoreIDSession"] = ID;

                Response.Redirect("~/Plugins/CoreValue/EditCoreValue.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["CoreIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected async void DeleteItem()
        {
            if (Session["CoreIDSession"] != null)
            {
                Plugin_Core_ValueEntity entity = new Plugin_Core_ValueEntity();

                entity.CoreID = Convert.ToInt64(Session["CoreIDSession"].ToString());
                entity.IsDelete = true;
                var Result = await Plugin_Core_ValueDomain.DeleteRecord(entity.CoreID);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["CoreIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstCoreValue.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label CoreID = ((Label)item.FindControl("lblID"));
                    Plugin_Core_ValueEntity entity = new Plugin_Core_ValueEntity();
                    entity.CoreID = Convert.ToInt64(CoreID.Text);
                    entity.IsDelete = true;

                    var Result = await Plugin_Core_ValueDomain.DeleteRecord(entity.CoreID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/CoreValue/AddCoreValue.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/CoreValue/ManageCoreValue.aspx", false);
        }







    }
}