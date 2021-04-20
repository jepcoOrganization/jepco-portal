using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;
using System.Web.Services;

namespace Siteware.Web.Pages
{
    public partial class ManagePages : System.Web.UI.Page
    {
        string PageName = "Pages";

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
                        Session["PageIDSession"] = null;
                        if (SessionManager.GetInstance.Users.Passwordd == "q/s?qs# m lc@")
                        {

                            FillDataSuperAdmin();
                        }
                        else
                        {

                            FillData();
                        }
                        
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
                

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active");
                Session["IDSelectPage"] = "~/Pages/ManagePages.aspx";

            }
        }
        protected async void FillDataSuperAdmin()
        {
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();

            Result = await PagesDomain.GetPagesAllSuperAdmin();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }

        protected async void FillData()
        {
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();

            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }

        protected void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //Label lblEditDate = (Label)e.Item.FindControl("lblEditDate");

                //lblEditDate.Text = Convert.ToDateTime(lblEditDate.Text).ToString("dd-MM-yyyy HH:mm:ss tt");

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["PageIDSession"] = ID; 
                Response.Redirect("~/Pages/EditPages.aspx",false);
            }
            if (e.CommandName == "DeleteItem")
            {
             
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["PageIDSession"] = ID;
                mpeSuccess.Show();
            }

        }
        protected async void DeleteData()
        {
            if(Session["PageIDSession"] != null)
            { 
                PagesEntity entity = new PagesEntity();
                entity.PageID = Convert.ToInt32(Session["PageIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = await PagesDomain.UpdatePagesByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                  //  mpeSuccess.Show();
                    Session["PageIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstPages.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label PageID = ((Label)item.FindControl("lblID"));
                    PagesEntity entity = new PagesEntity();
                    entity.PageID = Convert.ToInt32(PageID.Text);
                    entity.IsDeleted = true;

                    var Result = await PagesDomain.UpdatePagesByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                     //   mpeSuccess.Show();
                    }
                }
            }
            
        
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AddPages.aspx",false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteData();
            Response.Redirect("~/Pages/ManagePages.aspx",false);
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