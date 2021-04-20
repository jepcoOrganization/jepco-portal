using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.WelcomeNote
{
    public partial class EditWelcomeNote1 : System.Web.UI.Page
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
                        FillLanguages();
                        FillDetails();
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
        protected void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = LanguageDomain.GetLanguagesAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }
        }
        protected async void FillDetails()
        {
            if (Session["StatisticsNoteIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["StatisticsNoteIDSession"]);

                ResultEntity<StatisticNoteEntity> Result = new ResultEntity<StatisticNoteEntity>();

                Result = await StatisticNoteDomain.GetWelcomeNoteByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtTitle.Text = Result.Entity.Title;
                    txtLink.Text = Result.Entity.Link;
                    ddlTargetID.SelectedValue = Result.Entity.TargetID.ToString();
                    lblWelcomeNoteName1.Text = Result.Entity.Title;
                    lblWelcomeNoteName2.Text = Result.Entity.Title;
                    txtDescription.Text = Result.Entity.Description;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    ddlLanguages.SelectedValue = Result.Entity.ToString();
                    newWinField.Value = Result.Entity.Image;
                    ImagePage.ImageUrl = Result.Entity.Image;
                }
            }
        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("1");
                if (Page.IsValid)
                {
                    StatisticNoteEntity entity = new StatisticNoteEntity();
                    if (Session["StatisticsNoteIDSession"] != null)
                    {
                        entity.ID = Convert.ToInt32(Session["StatisticsNoteIDSession"]);
                        entity.Image = newWinField.Value;
                        entity.Link = txtLink.Text.ToString();
                        entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
                        entity.Title = txtTitle.Text;
                        entity.Summary = string.Empty;
                        entity.Description = txtDescription.Text;
                        entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                        entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        entity.IsPublished = CBIsPublished.Checked;
                        entity.IsDeleted = false;
                        entity.EditDate = Convert.ToDateTime(DateTime.Now);
                        entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                        var Result = await StatisticNoteDomain.UpdateWelcomeNote(entity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            mpeSuccess.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/WelcomeNote/ManageWelcomeNote.aspx", false);
        }
    }
}