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

namespace Siteware.Web.Plugins.FocusEntity
{
    public partial class EditFocusEntities : System.Web.UI.Page
    {
        string PageName = "Entities";
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
                Session["IDSelectPage"] = "~/Plugins/FocusEntity/ManageFocusEntities.aspx";

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
                if (Session["FocusEntityIDSession"] != null)
                {
                    long FocusID = Convert.ToInt64(Session["FocusEntityIDSession"]);

                    ResultEntity<Plugin_FA_EntitiesEntity> Result = new ResultEntity<Plugin_FA_EntitiesEntity>();

                    Result = await Plugin_FA_EntitiesDomain.GetByID(FocusID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        hdnFocusEntityId.Value = Result.Entity.FocusEntityId.ToString();
                        lblHeadName1.Text = Result.Entity.Title;
                        lblHeadName2.Text = Result.Entity.Title;
                        ImagePage.ImageUrl = Result.Entity.Image;
                        newWinField.Value = Result.Entity.Image;
                        txtTitle.Text = Result.Entity.Title;
                        txtSummary.Text = Result.Entity.Summary;
                        lblMapID.Value = Result.Entity.MapEntity;

                        txtDescription.Text = Result.Entity.Description;
                        //txtLink.Text = Result.Entity.Link;
                        //ddlParentPage.SelectedValue = Result.Entity.Target;
                        //hdnFocusID.Value = Result.Entity.FocusID.ToString();
                        //hdnColor.Value = Result.Entity.Color;
                        txtorderr.Text = Result.Entity.Order.ToString();
                        CBIsPublished.Checked = Result.Entity.IsPublished;
                        ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                        int selectedLanguageid = Result.Entity.LanguageID;
                        FillFocus(selectedLanguageid);
                        ddlFocusID.SelectedValue = Result.Entity.FocusID.ToString();
                        txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        FillEntityByLanguage(selectedLanguageid);
                        ddlMappedNews1.SelectedValue = Result.Entity.MapEntity;

                        txtAddress.Text = Result.Entity.Address;
                        txtTelephone.Text = Result.Entity.Telephone;
                        txtFax.Text = Result.Entity.Fax;
                        txtEmail.Text = Result.Entity.Email;
                        txtWebsite.Text = Result.Entity.Website;
                        txtTitle1.Text = Result.Entity.Title1;
                        CBIsShowPage.Checked = Result.Entity.IsShowPage;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void FillEntityByLanguage(int LanguageId)
        {
            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
            Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                if (LanguageId == (int)EnumLanguage.Arabic)
                {
                    lblMapNews1.Text = "Map English Entity :";
                }
                else if (LanguageId == (int)EnumLanguage.English)
                {
                    lblMapNews1.Text = "Map Arabic Entity :";
                }

                ddlMappedNews1.Items.Clear();
                ddlMappedNews1.Items.Insert(0, new ListItem("Select Entity", "0"));

                foreach (Plugin_FA_EntitiesEntity item in Result.List.Where(s => s.IsPublished && s.IsDelete == false && s.LanguageID != LanguageId).ToList())
                {
                    ddlMappedNews1.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
                }
            }
        }
        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                FillFocus(LangID);
                FillEntityByLanguage(LangID);
                if (Convert.ToInt32(lblLanguageID.Value) == LangID)
                {
                    ddlFocusID.SelectedValue = lblFocusID.Value;
                    ddlMappedNews1.SelectedValue = lblMapID.Value;
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void FillFocus(int LangID)
        {
            ddlFocusID.Items.Clear();
            ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));

            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
            Result = Plugin_Focus_AreaDomain.GetAllNotAsync();

            Result.List = Result.List.Where(s => s.IsPublished == true && !s.IsDelete && s.LanguageID == LangID).OrderBy(s => s.FocusOrder).ToList();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_Focus_AreaEntity item in Result.List)
                {
                    ddlFocusID.Items.Add(new ListItem(item.Title.ToString(), item.FocusID.ToString()));
                }
            }
        }

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["FocusEntityIDSession"] != null)
                {
                    Plugin_FA_EntitiesEntity entity = new Plugin_FA_EntitiesEntity();

                    entity.FocusEntityId = Convert.ToInt64(hdnFocusEntityId.Value);
                    entity.Title = txtTitle.Text.Trim();
                    entity.Title1 = txtTitle1.Text;
                    entity.Summary = txtSummary.Text;
                    entity.FocusID = Convert.ToInt64(ddlFocusID.SelectedValue);
                    entity.Image = newWinField.Value;
                    entity.Description = txtDescription.Text;
                    entity.Order = Convert.ToInt32(txtorderr.Text);
                    entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.MapEntity = ddlMappedNews1.SelectedValue;

                    entity.Address = txtAddress.Text;
                    entity.Telephone = txtTelephone.Text;
                    entity.Fax = txtFax.Text;
                    entity.Email = txtEmail.Text;
                    entity.Website = txtWebsite.Text;
                    entity.IsShowPage = CBIsShowPage.Checked;

                    var Result = await Plugin_FA_EntitiesDomain.UpdateRecord(entity);

                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                else
                {
                    Response.Redirect("~/Plugins/FocusEntity/", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FocusEntity/ManageFocusEntities.aspx", false);
        }

    }
}