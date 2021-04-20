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
    public partial class AddFocusEntities : System.Web.UI.Page
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
                        FillLanguages();
                        ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));
                        ddlMappedNews1.Items.Insert(0, new ListItem("Select Entity", "0"));
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

        protected async void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }
        }

        protected async void FillFocus(int LangID)
        {
            ddlFocusID.Items.Clear();
            ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));

            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
            Result = await Plugin_Focus_AreaDomain.GetAll();

            Result.List = Result.List.Where(s => s.IsPublished == true && !s.IsDelete && s.LanguageID == LangID).OrderBy(s => s.FocusOrder).ToList();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_Focus_AreaEntity item in Result.List)
                {
                    ddlFocusID.Items.Add(new ListItem(item.Title.ToString(), item.FocusID.ToString()));
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
            }
            catch (Exception ex)
            {
            }
        }

        protected async void FillEntityByLanguage(int LanguageId)
        {
            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
            Result = await Plugin_FA_EntitiesDomain.GetAll();

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

                foreach (Plugin_FA_EntitiesEntity item in Result.List.Where(s => s.IsPublished && s.IsDelete == false).ToList())
                {
                    if (item.LanguageID != LanguageId)
                    {
                        ddlMappedNews1.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
                    }
                }
            }
        }

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            Plugin_FA_EntitiesEntity entity = new Plugin_FA_EntitiesEntity();
            entity.Title = txtTitle.Text.Trim();
            entity.Summary = txtSummary.Text;
            entity.Image = newWinField.Value;
            entity.FocusID = Convert.ToInt32(ddlFocusID.SelectedValue);
            entity.Description = txtDescription.Text;
            entity.Order = Convert.ToInt32(txtorderr.Text);
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.IsPublished = CBIsPublished.Checked;
            entity.Address = txtAddress.Text;
            entity.Telephone = txtTelephone.Text;
            entity.Fax = txtFax.Text;
            entity.Email = txtEmail.Text;
            entity.Website = txtWebsite.Text;
            entity.Title1 = txtTitle1.Text;
            entity.IsShowPage = CBIsShowPage.Checked;
            entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDelete = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.MapEntity = ddlMappedNews1.SelectedValue;

            var Result = await Plugin_FA_EntitiesDomain.InsertRecord(entity);

            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FocusEntity/ManageFocusEntities.aspx", false);
        }
    }
}