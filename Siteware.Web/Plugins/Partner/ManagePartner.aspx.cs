using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.Partner
{
    public partial class ManagePartner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string PageName = "Partner";
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
                        Session["PartnerIDSession"] = null;
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
            catch(Exception ex)
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
                Session["IDSelectPage"] = "~/Plugins/Partner/ManagePartner.aspx";

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

            ResultList<PluginPartnerEntity> Result = new ResultList<PluginPartnerEntity>();

            Result = await PluginPartnerDomain.GetPluginpartnerAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.ToList();
                lstPages.DataBind();
            }
        }
        protected async void GetBannerType(int ID)
        {
            var Result = await BannerTypeDomain.GetBodyBannerByID(ID);
            string BannerName;
            if (Result.Status == ErrorEnums.Success)
            {
                BannerName = Result.Entity.BannerName;
            }
        }
        protected void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
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
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["PartnerIDSession"] = ID;

                Response.Redirect("~/Plugins/Partner/EditPartner.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["PartnerIDSession"] = ID;
                mpeSuccess.Show();


            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeletData();
            Response.Redirect("~/Plugins/Partner/ManagePartner.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Partner/AddPartner.aspx", false);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected async void DeletDataByID(int ID)
        {
            ResultEntity<PluginPartnerEntity> Result = await PluginPartnerDomain.DeletePartner(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    //mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Plugins/Partner/ManagePartner.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async void DeletData()
        {
            if (Session["PartnerIDSession"] != null)
            {
                ResultEntity<PluginPartnerEntity> Result = await PluginPartnerDomain.DeletePartner(Convert.ToInt32(Session["PartnerIDSession"].ToString()));
                try
                {
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                    else
                    {
                        Response.Redirect("~/Plugins/Partner/ManagePartner.aspx", false);
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