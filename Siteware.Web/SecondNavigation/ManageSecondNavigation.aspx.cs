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

namespace Siteware.Web.SecondNavigation
{
    public partial class ManageSecondNavigation : System.Web.UI.Page
    {
        string PageName = "Second Navigation";

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
                        Session["SecondNavigationIDSession"] = null;
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
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liSceNav");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                //ulNav.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Navigation/ManageNavigation.aspx";
            }
        }
        protected async void FillData()
        {
            ResultList<SecondNavigationEntity> Result = new ResultList<SecondNavigationEntity>();

            Result = await SecondNavigationDomain.GetNavigationAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstNavigation.DataSource = Result.List.ToList();
                lstNavigation.DataBind();
            }
        }
        protected void lstNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTargetID = (Label)e.Item.FindControl("lblTargetID");

                if (lblTargetID.Text == "1")
                {
                    lblTargetID.Text = "New window";
                }
                else
                {
                    lblTargetID.Text = "Same window";
                }

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                Label lblMenutype = (Label)e.Item.FindControl("lblMenutype");

                if (lblMenutype.Text == "1")
                {
                    lblMenutype.Text = "Header";
                }
                else
                {
                    lblMenutype.Text = "Footer";
                }

            }
        }
        protected void lstNavigation_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SecondNavigationIDSession"] = ID;

                Response.Redirect("~/SecondNavigation/EditSecondNavigation.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SecondNavigationIDSession"] = ID;
                DeletData();

            }
        }
        protected async void DeletData()
        {
            if (Session["SecondNavigationIDSession"] != null)
            {
                ResultEntity<SecondNavigationEntity> Result = await SecondNavigationDomain.DeleteByID(Convert.ToInt32(Session["SecondNavigationIDSession"]));
                try
                {
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                        Session["SecondNavigationIDSession"] = null;
                    }
                    else
                    {
                        Response.Redirect("~/SecondNavigation/ManageSecondNavigation.aspx", false);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            foreach (ListViewDataItem lv in this.lstNavigation.Items)
            {
                CheckBox chk;
                chk = ((CheckBox)lv.FindControl("CheckBox1"));
                Label lblID = ((Label)lv.FindControl("lblMenuID"));
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        DeletData2(Convert.ToInt32(lblID.Text));
                        //this.lstPages.DeleteItem(lv.DataItemIndex);
                    }
                }
            }
        }
        protected async void DeletData2(int ID)
        {
            ResultEntity<SecondNavigationEntity> Result = await SecondNavigationDomain.DeleteByID(ID);
            try
            {
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
                else
                {
                    Response.Redirect("~/SecondNavigation/ManageSecondNavigation.aspx", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            DeletData();
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SecondNavigation/AddSecondNavigation.aspx", false);
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SecondNavigation/ManageSecondNavigation.aspx", false);
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