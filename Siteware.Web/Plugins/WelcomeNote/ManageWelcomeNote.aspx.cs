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

namespace Siteware.Web.Plugins.WelcomeNote
{
	public partial class ManageWelcomeNote1 : System.Web.UI.Page
	{
        string PageName = "Welcome Note";
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
                        Session["StatisticsNoteIDSession"] = null;
                        FillData();
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Redirect("~/Login.aspx");
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
                Session["IDSelectPage"] = "~/Plugins/WelcomeNote/ManageWelcomeNote.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<StatisticNoteEntity> Result = new ResultList<StatisticNoteEntity>();

            Result = await StatisticNoteDomain.GetWelcomeNoteAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstWelcomeNote.DataSource = Result.List.ToList();
                lstWelcomeNote.DataBind();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            DeleteWelcomeNote();
            Response.Redirect("~/Plugins/WelcomeNote/ManageWelcomeNote.aspx", false);
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/WelcomeNote/AddWelcomeNote.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }

        protected void lstWelcomeNote_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }

        protected void lstWelcomeNote_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["StatisticsNoteIDSession"] = ID;

                Response.Redirect("~/Plugins/WelcomeNote/EditWelcomeNote.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["StatisticsNoteIDSession"] = ID;
                mpeSuccess.Show();
            }
        }
        protected async void DeleteWelcomeNote()
        {
            if (Session["StatisticsNoteIDSession"] != null)
            {
                StatisticNoteEntity entity = new StatisticNoteEntity();

                entity.ID = Convert.ToInt32(Session["StatisticsNoteIDSession"].ToString());
                entity.IsDeleted = true;

                var Result = await StatisticNoteDomain.UpdateWelcomeNoteIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {

                }
            }
            foreach (ListViewItem item in lstWelcomeNote.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label ID = ((Label)item.FindControl("lblID"));
                    StatisticNoteEntity entity = new StatisticNoteEntity();
                    entity.ID = Convert.ToInt32(ID.Text);
                    entity.IsDeleted = true;

                    var Result = await StatisticNoteDomain.UpdateWelcomeNoteIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {

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