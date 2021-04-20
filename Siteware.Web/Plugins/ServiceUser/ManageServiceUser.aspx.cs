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

namespace Siteware.Web.Plugins.ServiceUser
{
    public partial class ManageServiceUser : System.Web.UI.Page
    {
        string PageName = "ServiceUser";
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
                        Session["ServiceUserIDSession"] = null;
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
            catch (Exception ex)
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
                Session["IDSelectPage"] = "~/Plugins/ServiceUser/ManageServiceUser.aspx";
                
            }
        }

        protected async void FillData()
        {

            ResultList<Plugin_ServiceUserEntity> Result = new ResultList<Plugin_ServiceUserEntity>();

            Result = await Plugin_ServiceUserDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }
        
       
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["ServiceUserIDSession"] = ID;

                Response.Redirect("~/Plugins/ServiceUser/EditServiceUser.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["ServiceUserIDSession"] = ID;
                mpeSuccess.Show();


            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeletData();
            Response.Redirect("~/Plugins/ServiceUser/ManageServiceUser.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ServiceUser/AddServiceUser.aspx", false);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected async void DeletDataByID(int ID)
        {
            ResultEntity<Plugin_ServiceUserEntity> Result = await Plugin_ServiceUserDomain.Delete(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    //mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Plugins/ServiceUser/ManageServiceUser.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async void DeletData()
        {
            if (Session["ServiceUserIDSession"] != null)
            {
                ResultEntity<Plugin_ServiceUserEntity> Result = await Plugin_ServiceUserDomain.Delete(Convert.ToInt32(Session["ServiceUserIDSession"].ToString()));
                try
                {
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                    else
                    {
                        Response.Redirect("~/Plugins/ServiceUser/ManageServiceUser.aspx", false);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            foreach (ListViewDataItem lv in this.lstPages.Items)
            {
                CheckBox chk;
                chk = ((CheckBox)lv.FindControl("CheckBox1"));
                Label lblID = ((Label)lv.FindControl("lblPageID"));
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        DeletDataByID(Convert.ToInt32(lblID.Text));
                        //this.lstPages.DeleteItem(lv.DataItemIndex);
                    }
                }

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