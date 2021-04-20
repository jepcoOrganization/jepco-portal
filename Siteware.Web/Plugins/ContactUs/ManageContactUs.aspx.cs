using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.Services;

namespace Siteware.Web.Pages
{
    public partial class ManageContactUs : System.Web.UI.Page
    {
        string PageName = "Contact Us";

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
                        Session["ContactUsIDSession"] = null;
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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/ContactUs/ManageContactUs.aspx";

            }
        }

        protected async void FillData()
        {

            ResultList<PluginContactUsEntity> Result = new ResultList<PluginContactUsEntity>();

            Result = await PluginContactUsDomain.GetPluginContactAll();
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
        protected async void lstPages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // Label lblTaget = (Label)e.Item.FindControl("lblTaget");



                //switch (lblCategory.Text)
                //{
                //    case "1":
                //        lblCategory.Text = "Body Banner";
                //        break;
                //    case "2":
                //        lblCategory.Text = "Footer Banner";
                //        break;
                //    case "3":
                //        lblCategory.Text = "Inner Banner";
                //        break;
                //    case "4":
                //        lblCategory.Text = "Header Banner";
                //        break;
                //}
                //if (lblTaget.Text == "_blank")
                //{
                //    lblTaget.Text = "New Window";
                //}
                //else { lblTaget.Text = "Same Window"; }
            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["ContactUsIDSession"] = ID;

                Response.Redirect("~/Plugins/ContactUs/EditContactUs.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["ContactUsIDSession"] = ID;
                mpeSuccess.Show();


            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeletData();
            Response.Redirect("~/Plugins/ContactUs/ManageContactUs.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ContactUs/AddContactUs.aspx", false);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected async void DeletDataByID(int ID)
        {
            ResultEntity<PluginContactUsEntity> Result = await PluginContactUsDomain.DeleteContact(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    //mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/Plugins/ContactUs/ManageContactUs.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected async void DeletData()
        {
            if (Session["ContactUsIDSession"] != null)
            {
                ResultEntity<PluginContactUsEntity> Result = await PluginContactUsDomain.DeleteContact(Convert.ToInt32(Session["ContactUsIDSession"].ToString()));
                try
                {
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                    else
                    {
                        Response.Redirect("~/Plugins/ContactUs/ManageContactUs.aspx", false);
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