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

namespace Siteware.Web.Plugins.FocusArea
{
    public partial class EditFocusArea : System.Web.UI.Page
    {
        string PageName = "Focus Area";
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
                Session["IDSelectPage"] = "~/Plugins/FocusArea/ManageFocusArea.aspx";

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
            try
            {
                if (Session["FocusIDSession"] != null)
                {
                    long FocusID = Convert.ToInt64(Session["FocusIDSession"]);

                    ResultEntity<Plugin_Focus_AreaEntity> Result = new ResultEntity<Plugin_Focus_AreaEntity>();

                    Result = await Plugin_Focus_AreaDomain.GetByID(FocusID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lblHeadName1.Text = Result.Entity.Title;
                        lblHeadName2.Text = Result.Entity.Title;
                        ImagePage.ImageUrl = Result.Entity.Icon;
                        newWinField.Value = Result.Entity.Icon;
                        ImagePage2.ImageUrl = Result.Entity.Image;
                        newWinField2.Value = Result.Entity.Image;
                        txtTitle.Text = Result.Entity.Title;
                        txtSummary.Text = Result.Entity.Summary;
                        txtLink.Text = Result.Entity.Link;
                        ddlParentPage.SelectedValue = Result.Entity.Target;
                        hdnFocusID.Value = Result.Entity.FocusID.ToString();
                        hdnColor.Value = Result.Entity.Color;
                        txtorderr.Text = Result.Entity.FocusOrder.ToString();
                        CBIsPublished.Checked = Result.Entity.IsPublished;
                        ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                        txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["FocusIDSession"] != null)
                {
                    Plugin_Focus_AreaEntity entity = new Plugin_Focus_AreaEntity();
                    entity.FocusID = Convert.ToInt64(hdnFocusID.Value);
                    entity.Title = txtTitle.Text.Trim();
                    entity.Summary = txtSummary.Text;
                    entity.Link = txtLink.Text.Trim();
                    entity.Icon = newWinField.Value;
                    entity.Image = newWinField2.Value;
                    entity.Target = ddlParentPage.SelectedValue;
                    entity.FocusOrder = Convert.ToInt64(txtorderr.Text);
                    entity.Color = hdnColor.Value;
                    entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = await Plugin_Focus_AreaDomain.UpdateRecord(entity);

                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                else
                {
                    Response.Redirect("~/Plugins/FocusArea/ManageFocusArea.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FocusArea/ManageFocusArea.aspx", false);
        }
    }
}