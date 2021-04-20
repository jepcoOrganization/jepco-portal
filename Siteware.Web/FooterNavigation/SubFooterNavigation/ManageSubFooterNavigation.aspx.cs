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

namespace Siteware.Web.FooterNavigation.SubFooterNavigation
{
    public partial class ManageSubFooterNavigation : System.Web.UI.Page
    {
        string PageName = "Footer Navigation";

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
                        Session["SubFooterIDSession"] = null;
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
                Session["IDSelectPage"] = "~/FooterNavigation/SubFooterNavigation/ManageSubFooterNavigation.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
            if (Session["MenuFooterIDSession"] != null && Session["FooterLanguageID"] != null)
            {
                int ParentID = Convert.ToInt32(Session["MenuFooterIDSession"]);
                int LangID = Convert.ToInt32(Session["FooterLanguageID"]);
                Result = await FooterNavigationDomain.GetFooterAll();
                Result.List = Result.List.Where(s => s.ParentID == ParentID && s.LanguageID == LangID).ToList();
                if (Result.Status == ErrorEnums.Success)
                {
                    lstMenuFooter.DataSource = Result.List.ToList();
                    lstMenuFooter.DataBind();
                }
            }
        }
        protected void lstMenuFooter_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstMenuFooter_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["SubFooterIDSession"] = ID;

                Response.Redirect("~/FooterNavigation/SubFooterNavigation/EditSubFooterNavigation.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SubFooterIDSession"] = ID;
                mpeSuccess.Show();

            }
        }
        protected async void DeleteItem()
        {
            if (Session["SubFooterIDSession"] != null)
            {
                FooterNavigationEntity entity = new FooterNavigationEntity();

                entity.ID = Convert.ToInt32(Session["SubFooterIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = await FooterNavigationDomain.UpdateByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["SubFooterIDSession"] = null;
                }

            }
            foreach (ListViewItem item in lstMenuFooter.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label ID = ((Label)item.FindControl("lblID"));
                    FooterNavigationEntity entity = new FooterNavigationEntity();
                    entity.ID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await FooterNavigationDomain.UpdateByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {

                    }
                }
            }
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FooterNavigation/SubFooterNavigation/AddSubFooterNavigation.aspx", false);
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteItem();
            Response.Redirect("~/FooterNavigation/SubFooterNavigation/ManageSubFooterNavigation.aspx", false);
        }

        //[WebMethod]
        //public static LangDetails[] BindDatatoDropdown()
        //{
        //    try
        //    {
        //        ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
        //        List<LangDetails> details = new List<LangDetails>();
        //        Result = LanguageDomain.GetLanguagesAllNotAsync();
        //        if (Result.Status == ErrorEnums.Success)
        //        {
        //            foreach (var item in Result.List)
        //            {
        //                LangDetails lang = new LangDetails();
        //                lang.LangId = item.ID;
        //                lang.LangName = item.Name;
        //                details.Add(lang);
        //            }
        //        }
        //        return details.ToArray();
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //}

        //public class LangDetails
        //{
        //    public int LangId { get; set; }
        //    public string LangName { get; set; }
        //}
    }
}