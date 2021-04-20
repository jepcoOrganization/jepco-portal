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
    public partial class ManageSlider : System.Web.UI.Page
    {
        string PageName = "Slider";
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

                        Session["SliderIDSession"] = null;
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

                Session["IDSelectPage"] = "~/Plugins/Slider/ManageSlider.aspx";

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

            ResultList<PluginSliderEntity> Result = new ResultList<PluginSliderEntity>();

            Result = await PluginSliderDomain.GetSliderAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstPages.DataSource = Result.List.OrderBy(s => s.Order).ToList();
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
                Label lblTaget = (Label)e.Item.FindControl("lblTaget");

                if (lblTaget.Text == "_blank")
                {
                    lblTaget.Text = "New Window";
                }
                else { lblTaget.Text = "Same Window"; }
            }
        }
        protected void lstPages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SliderIDSession"] = ID;

                Response.Redirect("~/Plugins/Slider/EditSlider.aspx", false);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SliderIDSession"] = ID;
                mpeSuccess.Show();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeletData();
            Response.Redirect("~/Plugins/Slider/ManageSlider.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Slider/AddSlider.aspx", false);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void DeletData()
        {
            if (Session["SliderIDSession"] != null)
            {
                DeletDataByID(Convert.ToInt32(Session["SliderIDSession"].ToString()));

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
        protected async void DeletDataByID(int ID)
        {
            ResultEntity<PluginSliderEntity> Result = await PluginSliderDomain.Slider_Delete(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SliderIDSession"] = null;
                }
                else
                {
                    Response.Redirect("~/Plugins/Slider/ManageSlider.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
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
            catch(Exception e)
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