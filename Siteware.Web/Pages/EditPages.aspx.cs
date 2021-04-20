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
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Configuration;

namespace Siteware.Web.Pages
{
    public partial class EditPages : System.Web.UI.Page
    {
        string PageName = "Pages";

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
                        FillParentPages();
                        FillNavigation();
                        FillLanguages();
                        FillDetails();
                        //FillListPages();
                        //FillListPagesAnother();
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
                //liPages.Attributes.Add("class", "active");
                Session["IDSelectPage"] = "~/Pages/ManagePages.aspx";

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
        protected async void FillDetails()
        {
            if (Session["PageIDSession"] != null)
            {
                int PageID = Convert.ToInt32(Session["PageIDSession"]);

                ResultEntity<PagesEntity> Result = new ResultEntity<PagesEntity>();

                Result = await PagesDomain.GetPagesByPageID(PageID);
                if (Result.Status == ErrorEnums.Success)
                {
                    lblPagename1.Text = Result.Entity.Name;
                    lblPagename2.Text = Result.Entity.Name;
                    txtPageName.Text = Result.Entity.Name;

                    ddlParentPage.SelectedValue = Result.Entity.ParentID.ToString();                    
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();

                    lblAliasPath.Text = Result.Entity.AliasPath;
                    String[] substrings1 = lblAliasPath.Text.Split('/');
                    txtAliasPath.Text = substrings1[substrings1.Length - 1];

                    lblNamePath.Text = Result.Entity.NamePath;
                    String[] substrings2 = lblNamePath.Text.Split('/');
                    txtNamePath.Text = substrings2[substrings2.Length - 1];

                    lblLivePath.Text = Result.Entity.LivePath;
                    lnklblLivePath.NavigateUrl = Result.Entity.LivePath;
                    txtpageDescription.Text = Result.Entity.Description;
                    txtContentHTML.Text = Result.Entity.ContentHTML;
                    txtContentHTML1.Text = Result.Entity.ContentHTML1;
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    lblPageCount.Text = Result.Entity.ViewCount.ToString();
                    txtSEOAttribute.Text = Result.Entity.SEOAttribute;
                    txtMetaTitle.Text = Result.Entity.MetaTitle;
                    txtMetaDescription.Text = Result.Entity.MetaDescription;
                    lblPageLanguageId.Text = Result.Entity.LanguageID.ToString();

                    checkIsList.Checked = Result.Entity.IsList;
                    newWinField2.Value = Result.Entity.ListLink;

                    txtPageURL1.Text = Result.Entity.MappedPage1;
                    txtPageURL2.Text = Result.Entity.MappedPage2;
                    //Add | Jigar Patel | 20-12-2017
                    int LanguageId = Convert.ToInt32(Result.Entity.LanguageID);
                    FillListPagesLanguage(LanguageId);
                    //------------------------------------------

                    //ddListPages1.SelectedValue = Result.Entity.MappedPage1 == "" ? "#" : Result.Entity.MappedPage1;
                    //ddListPages2.SelectedValue = Result.Entity.MappedPage2 == "" ? "#" : Result.Entity.MappedPage2;

                    ResultList<PagesKeywordEntity> ResultKeyword = new ResultList<PagesKeywordEntity>();
                    ResultKeyword = await PagesKeywordDomain.GetKeywordByPageID(PageID);
                    if (ResultKeyword.Status == ErrorEnums.Success)
                    {
                        string index = "";
                        foreach (var item in ResultKeyword.List)
                        {
                            txtKeyWords.Value = "," + item.Keyword;
                            index = index + txtKeyWords.Value;
                        }
                        txtKeyWords.Value = index;
                    }

                    if (Result.Entity.Image != null && Result.Entity.Image != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.Image.ToString();
                        newWinField.Value = Result.Entity.Image.ToString();
                    }
                    if (!string.IsNullOrEmpty(Result.Entity.MobileBanner))
                    {
                        MobileImage.ImageUrl = Result.Entity.MobileBanner.ToString();
                        newWinField1.Value = Result.Entity.MobileBanner.ToString();
                    }
                }
            }


        }
        protected async void FillParentPages()
        {
            ddlParentPage.Items.Clear();
            ddlParentPage.Items.Insert(0, new ListItem("Home", "0"));
            int PageID = Convert.ToInt32(Session["PageIDSession"]);

            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (PagesEntity item in Result.List)
                {
                    if (PageID != item.PageID)
                    {
                        ddlParentPage.Items.Add(new ListItem(item.Name.ToString(), item.PageID.ToString()));
                    }

                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            PagesEntity entity = new PagesEntity();
            if (Session["PageIDSession"] != null)
            {
                string lang = string.Empty;
                if (Convert.ToInt32(EnumLanguage.Arabic) == Convert.ToInt32(ddlLanguages.SelectedValue))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                entity.PageID = Convert.ToInt32(Session["PageIDSession"]);
                entity.Name = txtPageName.Text.TrimEnd();
                entity.ParentID = Convert.ToInt32(ddlParentPage.SelectedValue);
                entity.IsList = checkIsList.Checked;
                entity.ListLink = newWinField2.Value.ToString();
                if (entity.ParentID == 0)
                {
                    entity.AliasPath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + txtAliasPath.Text.TrimEnd();
                    entity.NamePath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + txtNamePath.Text.TrimEnd();
                    entity.LivePath = entity.AliasPath;
                }
                else
                {
                    var ResultParent = await PagesDomain.GetPagesByPageID(entity.ParentID);
                    if (ResultParent.Status == ErrorEnums.Success)
                    {
                        if (ResultParent.Entity.ParentID == 0)
                        {
                            entity.AliasPath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + ddlParentPage.SelectedItem.Text + "/" + txtAliasPath.Text.TrimEnd();
                            entity.NamePath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + ddlParentPage.SelectedItem.Text + "/" + txtNamePath.Text.TrimEnd();
                            entity.LivePath = entity.AliasPath;
                        }
                        else
                        {
                            var ResultParent2 = await PagesDomain.GetPagesByPageID(ResultParent.Entity.ParentID);
                            if (ResultParent2.Status == ErrorEnums.Success)
                            {
                                if (ResultParent2.Entity.ParentID == 0)
                                {
                                    entity.AliasPath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + ResultParent2.Entity.Name + "/" + ddlParentPage.SelectedItem.Text + "/" + txtAliasPath.Text.TrimEnd();
                                    entity.NamePath = lang + ConfigurationManager.AppSettings["RoutePath"].ToString() + ResultParent2.Entity.Name + "/" + ddlParentPage.SelectedItem.Text + "/" + txtNamePath.Text.TrimEnd();
                                    entity.LivePath = entity.AliasPath;
                                }
                            }
                        }

                    }
                }
                //entity.AliasPath = txtAliasPath.Text;
                //entity.NamePath = txtNamePath.Text;
                //entity.LivePath = entity.AliasPath;

                entity.Description = txtpageDescription.Text;
                entity.ContentHTML = txtContentHTML.Text;
                entity.ContentHTML1 = txtContentHTML1.Text;
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                entity.IsDeleted = false;
                entity.SEOAttribute = txtSEOAttribute.Text;
                entity.MetaTitle = txtMetaTitle.Text;
                entity.MetaDescription = txtMetaDescription.Text;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.Image = newWinField.Value.ToString();
                entity.MobileBanner = newWinField1.Value.ToString();
                entity.MappedPage1 = txtPageURL1.Text;
                entity.MappedPage2 = txtPageURL2.Text;

                var Result = await PagesDomain.UpdatePages(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    var DeleteKeyword = await PagesKeywordDomain.DeleteKeywordByPageID(entity.PageID);
                    if (DeleteKeyword.Status == ErrorEnums.Success)
                    {
                        if (txtKeyWords.Value != "")
                        {
                            PagesKeywordEntity entityKeyword = new PagesKeywordEntity();
                            var key = txtKeyWords.Value.Split(',');
                            int index = 0;
                            foreach (var item in key)
                            {
                                if (key[index] != "")
                                {
                                    entityKeyword.Keyword = key[index];
                                    entityKeyword.PageID = entity.PageID;
                                    entityKeyword.AddDate = DateTime.Now;
                                    entityKeyword.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                                    entityKeyword.EditDate = DateTime.Now;
                                    entityKeyword.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                                    var ResultKeyword = await PagesKeywordDomain.InsertKeyword(entityKeyword);
                                    if (ResultKeyword.Status == ErrorEnums.Success)
                                    {

                                    }
                                }
                                index += 1;
                            }
                        }
                    }
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ManagePages.aspx", false);
        }

        protected async void FillListPages()
        {
            ddListPages1.Items.Insert(0, new ListItem("-- Please Select --", "#"));
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (PagesEntity item in Result.List)
                {
                    ddListPages1.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                }
            }
        }

        protected void butOkPages1_Click(object sender, EventArgs e)
        {
            if (ddListPages1.SelectedValue != "#")
            { txtPageURL1.Text = ddListPages1.SelectedValue; }
        }

        protected void FillListPagesLanguage(int LanguageId)
        {
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result =  PagesDomain.GetPagesAllNotAsync(SessionManager.GetInstance.Users.UserID);
            if (Result.Status == ErrorEnums.Success)
            {
                if (LanguageId == (int)EnumLanguage.Arabic)
                {
                    lblMapPageURL1.Text = "English Page URL :";
                    lblMapPageURL2.Text = "Espaniol Page URL :";
                }
                else if (LanguageId == (int)EnumLanguage.English)
                {
                    lblMapPageURL1.Text = "Arabic Page URL :";
                    lblMapPageURL2.Text = "Espaniol Page URL :";
                }
                else if (LanguageId == (int)EnumLanguage.Espaniol)
                {
                    lblMapPageURL1.Text = "Arabic Page URL :";
                    lblMapPageURL2.Text = "English Page URL :";
                }

                ddListPages1.Items.Clear();
                ddListPages2.Items.Clear();
                ddListPages1.Items.Insert(0, new ListItem("-- Please Select --", "#"));
                ddListPages2.Items.Insert(0, new ListItem("-- Please Select --", "#"));
                foreach (PagesEntity item in Result.List)
                {
                    if (LanguageId != item.LanguageID)
                    {
                        if (LanguageId == (int)EnumLanguage.Arabic)
                        {
                            if (item.LanguageID == (int)EnumLanguage.English)
                            {
                                ddListPages1.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                            else
                            {
                                ddListPages2.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                        }
                        if (LanguageId == (int)EnumLanguage.English)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddListPages1.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                            else
                            {
                                ddListPages2.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                        }
                        if (LanguageId == (int)EnumLanguage.Espaniol)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddListPages1.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                            else
                            {
                                ddListPages2.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                            }
                        }
                    }
                    
                }
            }
        }

        protected async void FillListPagesAnother()
        {
            
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (PagesEntity item in Result.List)
                {
                    ddListPages2.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                }
            }
        }

        protected void butOkPages2_Click(object sender, EventArgs e)
        {
            if (ddListPages2.SelectedValue != "#")
            { txtPageURL2.Text = ddListPages2.SelectedValue; }
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int langId = Convert.ToInt32(lblPageLanguageId.Text);
                int LanguageId = Convert.ToInt32(ddlLanguages.SelectedValue);
                if (LanguageId > 0)
                {
                    if (langId != LanguageId)
                    {
                        txtPageURL1.Text = "";
                        txtPageURL2.Text = "";
                        FillListPagesLanguage(LanguageId);
                    }
                    else
                    {
                        FillDetails();
                    }
                    
                }
                else
                {
                    FillListPagesLanguage(LanguageId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}