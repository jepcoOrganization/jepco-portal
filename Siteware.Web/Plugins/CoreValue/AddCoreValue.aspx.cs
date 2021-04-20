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


namespace Siteware.Web.Plugins.CoreValue
{
    public partial class AddCoreValue : System.Web.UI.Page
    {
        string PageName = "Core Value";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!FunctionSecurity.TestUserPermissionPage(SessionManager.GetInstance.Users.UserID, PageName))
                //{
                //    Response.Redirect("~/DashBoard.aspx", false);
                //}
                if (!IsPostBack)
                {
                    if (SessionManager.GetInstance.Users != null)
                    {
                        FillNavigation();
                        FillLanguages();
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
                Session["IDSelectPage"] = "~/Plugins/CoreValue/ManageCoreValue.aspx";

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

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            Plugin_Core_ValueEntity entity = new Plugin_Core_ValueEntity();
            entity.Title = txtTitle.Text.Trim();
            entity.Summary = txtSummary.Text;
            entity.Link = string.Empty;
            entity.Icon = newWinField.Value;
            entity.Target = string.Empty;
            entity.Description = txtDescription.Text;
            entity.Order = Convert.ToInt64(txtorderr.Text);
            entity.MappedCoreID1 = ddlMappedCore1.SelectedValue;
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDelete = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await Plugin_Core_ValueDomain.InsertRecord(entity);

            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/CoreValue/ManageCoreValue.aspx", false);
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                if (LanguageID > 0)
                {
                    FillCoreByLanguage(LanguageID);
                }
                else
                {
                    FillCoreByLanguage(LanguageID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected async void FillCoreByLanguage(int LanguageId)
        {
            ResultList<Plugin_Core_ValueEntity> Result = new ResultList<Plugin_Core_ValueEntity>();
            Result = await Plugin_Core_ValueDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                //if (LanguageId == (int)EnumLanguage.Arabic)
                //{
                //    lblMapCore1.Text = "Map English News :";

                //}
                //else if (LanguageId == (int)EnumLanguage.English)
                //{
                //    lblMapNews1.Text = "Map Arabic News :";
                //    lblMapNews2.Text = "Map Espaniol News :";
                //}
                //else if (LanguageId == (int)EnumLanguage.Espaniol)
                //{
                //    lblMapNews1.Text = "Map Arabic News :";
                //    lblMapNews2.Text = "Map English News :";
                //}

                ddlMappedCore1.Items.Clear();                
                ddlMappedCore1.Items.Insert(0, new ListItem("Select News", "0"));
              

                foreach (Plugin_Core_ValueEntity item in Result.List)
                {
                    if (item.LanguageID != LanguageId)
                    {
                        if (LanguageId == (int)EnumLanguage.Arabic)
                        {
                            if (item.LanguageID == (int)EnumLanguage.English)
                            {
                                ddlMappedCore1.Items.Add(new ListItem(item.Title.ToString(), item.CoreID.ToString()));
                            }
                            
                        }
                        if (LanguageId == (int)EnumLanguage.English)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddlMappedCore1.Items.Add(new ListItem(item.Title.ToString(), item.CoreID.ToString()));
                            }
                            
                        }
                        if (LanguageId == (int)EnumLanguage.Espaniol)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddlMappedCore1.Items.Add(new ListItem(item.Title.ToString(), item.CoreID.ToString()));
                            }
                           
                        }
                    }
                }
            }
        }


    }
}