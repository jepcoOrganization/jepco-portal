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

namespace Siteware.Web.Plugins.AboutUs
{
    public partial class ManageAboutUS : System.Web.UI.Page
    {
        string PageName = "AboutUs";
        bool isDelete = false;
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
                        Session["AboutUsIDSession"] = null;
                        FillNavigation();
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
                Session["IDSelectPage"] = "~/Plugins/AboutUs/ManageAboutUS.aspx";
            }
        }
        protected void FillData()
        {
            ResultList<Plugin_AboutUsEntity> Result = new ResultList<Plugin_AboutUsEntity>();
            Result = Plugin_AboutUsDomain.GetAllNotAsync();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            List<String> checkedList = new List<string>();

            foreach (ListViewItem item in lstPages.Items)
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
            lblMessage.Text = "Are you sure you want to delete?";
            mpeSuccess.Show();
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/AboutUs/AddAboutUS.aspx");
        }

        protected void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblID = (Label)e.Item.FindControl("lblID");
            Label lblTitle = (Label)e.Item.FindControl("lblTitle");
        }

        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["AboutUsIDSession"] = ID;
                Response.Redirect("~/Plugins/AboutUs/EditAboutUS.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["AboutUsIDSession"] = ID;
                lblMessage.Text = "Are you sure you want to delete?";
                mpeSuccess.Show();
            }
        }
        protected bool DeleteData()
        {
            try
            {
                if (Session["AboutUsIDSession"] != null)
                {
                    Plugin_AboutUsEntity entity = new Plugin_AboutUsEntity();

                    entity.ID = Convert.ToInt32(Session["AboutUsIDSession"].ToString());
                    entity.IsDeleted = true;
                    var Result = Plugin_AboutUsDomain.UpdateByIsDeletedNotAsync(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        Session["AboutUsIDSession"] = null;
                        isDelete = true;
                    }

                }
                var sessionChecked = Session["SelectedItems"] as List<String>;
                if (sessionChecked != null)
                {
                    foreach (var item in sessionChecked)
                    {

                        Plugin_AboutUsEntity entity = new Plugin_AboutUsEntity();
                        entity.ID = Convert.ToInt32(item);
                        entity.IsDeleted = true;
                        var Result = Plugin_AboutUsDomain.UpdateByIsDeletedNotAsync(entity);
                        //var documentResult = await Plugin_Provider_DocumentationDomain.UpdateDocumentByIsDeleted(documentEntity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            Session["AboutUsIDSession"] = null;
                            isDelete = true;
                        }

                    }
                }
                return isDelete;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
        }
        protected void btnOk11_Click(object sender, EventArgs e)
        {
            bool success = DeleteData();
            if (success)
            {
                lblMessage.Text = "Successfully Deleted";
                mpeSuccess.Show();
                Response.Redirect("~/Plugins/AboutUs/ManageAboutUS.aspx");
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