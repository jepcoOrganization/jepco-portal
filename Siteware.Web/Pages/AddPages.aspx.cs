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
    public partial class AddPages : System.Web.UI.Page
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
                        FillNavigation();
                        FillParentPages();
                        FillLanguages();
                        FillListPages();
                        FillListPagesAnother();
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

        protected async void FillParentPages()
        {
            ddlParentPage.Items.Insert(0, new ListItem("Home", "0"));

            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (PagesEntity item in Result.List)
                {
                    ddlParentPage.Items.Add(new ListItem(item.Name.ToString(), item.PageID.ToString()));
                }
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

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            PagesEntity entity = new PagesEntity();
            entity.Name = txtPageName.Text.TrimEnd();
            entity.ParentID = Convert.ToInt32(ddlParentPage.SelectedValue);

            entity.IsList = checkIsList.Checked;
            entity.ListLink = newWinField2.Value.ToString();
            //entity.AliasPath = txtAliasPath.Text;
            //entity.NamePath = txtNamePath.Text;
            //entity.LivePath = entity.AliasPath;

            string lang = string.Empty;
            if (Convert.ToInt32(EnumLanguage.Arabic) == Convert.ToInt32(ddlLanguages.SelectedValue))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }

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
            entity.Image = newWinField.Value.ToString();
            entity.MobileBanner = newWinField1.Value.ToString();
            entity.Description = txtpageDescription.Text;
            entity.ContentHTML = txtContentHTML.Text;
            entity.ContentHTML1 = txtContentHTML1.Text;
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
            entity.IsDeleted = false;
            entity.ViewCount = 0;
            entity.SEOAttribute = txtSEOAttribute.Text;
            entity.MetaTitle = txtMetaTitle.Text;
            entity.MetaDescription = txtMetaDescription.Text;
            entity.MappedPage1 = txtPageURL1.Text;
            entity.MappedPage2 = txtPageURL2.Text;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await PagesDomain.InsertPages(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                var DeleteKeyword = await PagesKeywordDomain.DeleteKeywordByPageID(Result.Entity.PageID);
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
                                entityKeyword.PageID = Result.Entity.PageID;
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ManagePages.aspx", false);
        }
        //protected void FillUploadImage()
        //{
        //    Boolean fileOK = false;
        //    String path = Server.MapPath("~/Siteware_File/");
        //    if (FileUpload1.HasFile)
        //    {
        //        String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        //        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
        //        for (int i = 0; i < allowedExtensions.Length; i++)
        //        {
        //            if (fileExtension == allowedExtensions[i])
        //            {
        //                fileOK = true;
        //            }
        //        }
        //    }

        //    if (fileOK)
        //    {
        //        Guid Image = Guid.NewGuid();
        //        FileUpload1.PostedFile.SaveAs(path + Image + FileUpload1.FileName);
        //        ImagePage.ImageUrl = "~/Siteware_File/" + Image + FileUpload1.FileName.ToString();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied02", "alert('Cannot accept files of this type')", true);
        //    }
        //}

        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            // FillUploadImage();

        }

        protected void CheckList_CheckedChanged(object sender, EventArgs e)
        {
            //if (CheckList.Checked)
            //{
            //DivUpladFile.Visible=true;
            //}
            //else
            //{
            //    DivUpladFile.Visible = false;
            //}
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

        protected async void FillListPagesAnother()
        {
            ddListPages2.Items.Insert(0, new ListItem("-- Please Select --", "#"));
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
        #region-->FillPages By Language
        protected async void FillListPagesByLanguage(int LanguageId)
        {  
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                ddListPages1.Items.Clear();
                ddListPages1.Items.Insert(0, new ListItem("-- Please Select --", "#"));
                foreach (PagesEntity item in Result.List)
                {
                    if (item.LanguageID == LanguageId)
                    {
                        ddListPages1.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                    }           
                }
            }
        }
        protected async void FillListPagesAnotherLanguage(int LanguageId)
        {
            
            ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
            Result = await PagesDomain.GetPagesAll(SessionManager.GetInstance.Users.UserID);

            if (Result.Status == ErrorEnums.Success)
            {
                ddListPages2.Items.Clear();
                ddListPages2.Items.Insert(0, new ListItem("-- Please Select --", "#"));
                foreach (PagesEntity item in Result.List)
                {
                    if (item.LanguageID == LanguageId)
                    {
                        ddListPages2.Items.Add(new ListItem(item.Name.ToString(), item.AliasPath.ToString()));
                    }
                }
            }
        }
        #endregion

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LanguageId = Convert.ToInt32(ddlLanguages.SelectedValue);
                int LangId1 = 0;
                int LangId2 = 0;
                if (LanguageId > 0)
                {
                    if (LanguageId == (int)EnumLanguage.Arabic)
                    {
                        LangId1 = (int)EnumLanguage.English;
                        LangId2 = (int)EnumLanguage.Espaniol;
                        lblMapPageURL1.Text = "English Page URL :";
                        lblMapPageURL2.Text = "Espaniol Page URL :";

                        FillListPagesByLanguage(LangId1);
                        FillListPagesAnotherLanguage(LangId2);
                    }
                    else if (LanguageId == (int)EnumLanguage.English)
                    {
                        LangId1 = (int)EnumLanguage.Arabic;
                        LangId2 = (int)EnumLanguage.Espaniol;
                        lblMapPageURL1.Text = "Arabic Page URL :";
                        lblMapPageURL2.Text = "Espaniol Page URL :";

                        FillListPagesByLanguage(LangId1);
                        FillListPagesAnotherLanguage(LangId2);
                    }
                    else if (LanguageId == (int)EnumLanguage.Espaniol)
                    {
                        LangId1 = (int)EnumLanguage.Arabic;
                        LangId2 = (int)EnumLanguage.English;
                        lblMapPageURL1.Text = "Arabic Page URL :";
                        lblMapPageURL2.Text = "English Page URL :";

                        FillListPagesByLanguage(LangId1);
                        FillListPagesAnotherLanguage(LangId2);
                    }
                }
                else
                {
                    FillListPagesByLanguage(LangId1);
                    FillListPagesAnotherLanguage(LangId2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}