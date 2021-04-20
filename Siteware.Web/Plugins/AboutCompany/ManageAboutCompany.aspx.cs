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

namespace Siteware.Web.Plugins.AboutCompany
{
    public partial class ManageAboutCompany : System.Web.UI.Page
    {
        string PageName = "AboutCompany";
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
                        Session["CompanyIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/AboutCompany/ManageAboutCompany.aspx";

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
            ResultList<Plugin_AboutCompanyEntity> Result = new ResultList<Plugin_AboutCompanyEntity>();

            Result = await Plugin_AboutCompanyDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstCompany.DataSource = Result.List.ToList();
                lstCompany.DataBind();
            }
        }

        protected void lstCompany_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                    lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                }
            }
            catch (Exception ex) { }

        }

        protected void lstCompany_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                long ID = Convert.ToInt64(e.CommandArgument);

                Session["CompanyIDSession"] = ID;

                Response.Redirect("~/Plugins/AboutCompany/EditAboutCompany.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                long ID = Convert.ToInt64(e.CommandArgument);
                Session["CompanyIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected async void DeleteItem()
        {
            if (Session["CompanyIDSession"] != null)
            {
                Plugin_AboutCompanyEntity entity = new Plugin_AboutCompanyEntity();

                entity.CompanyID = Convert.ToInt64(Session["CompanyIDSession"].ToString());
                entity.IsDelete = true;
                var Result = await Plugin_AboutCompanyDomain.DeleteRecord(entity.CompanyID);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["CoreIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstCompany.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label CompanyID = ((Label)item.FindControl("lblID"));
                    Plugin_AboutCompanyEntity entity = new Plugin_AboutCompanyEntity();
                    entity.CompanyID = Convert.ToInt64(CompanyID.Text);
                    entity.IsDelete = true;

                    var Result = await Plugin_AboutCompanyDomain.DeleteRecord(entity.CompanyID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/AboutCompany/AddAboutCompany.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/Plugins/AboutCompany/ManageAboutCompany.aspx", false);
        }
    }
}