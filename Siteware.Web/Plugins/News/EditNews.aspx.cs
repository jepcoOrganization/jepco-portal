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
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;

namespace Siteware.Web.Plugins.News
{
    public partial class EditNews : System.Web.UI.Page
    {
        string PageName = "News";

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
                        //FillNews();
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
                Session["IDSelectPage"] = "~/Plugins/News/ManageNews.aspx";

                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
            }
        }

        protected async void FillDetails()
        {
            if (Session["NewsIDSession"] != null)
            {
                int NewsID = Convert.ToInt32(Session["NewsIDSession"]);

                ResultEntity<NewsEntity> Result = new ResultEntity<NewsEntity>();

                Result = await NewsDomain.GetPagesByNewsID(NewsID);
                if (Result.Status == ErrorEnums.Success)
                {
                    ImagePage.ImageUrl = Result.Entity.NewsImage;
                    newWinField.Value = Result.Entity.NewsImage;
                    txtHeadLine.Text = Result.Entity.Headline;
                    lblNewsname1.Text = Result.Entity.Headline;
                    txtSummary.Text = Result.Entity.Summary;
                    txtDescription.Text = Result.Entity.Description;
                    txtNewDate.Value = Result.Entity.NewsDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    lblViewCount.Text = Result.Entity.ViewCount.ToString();
                    txtorderr.Text = Result.Entity.NewsOrder.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    lblNewsLanguageId.Text = Result.Entity.LanguageID.ToString();
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBShowInMarquee.Checked = Result.Entity.ShowInMarquee;
                    ddNewsLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    CBIsNotification.Checked = Result.Entity.IsNotification;
                    int languageId = Convert.ToInt32(Result.Entity.LanguageID);
                    FillNews(languageId);
                    ddlMappedNews1.SelectedValue = Result.Entity.MappedNewsID1.ToString();
                    ddlMappedNews2.SelectedValue = Result.Entity.MappedNewsID2.ToString();
                }
            }
        }

        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            HeadlineImage.Attributes.Add("class", "ui-tabs-active ui-state-active");
        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            NewsEntity entity = new NewsEntity();
            if (Session["NewsIDSession"] != null)
            {
                entity.NewsID = Convert.ToInt32(Session["NewsIDSession"]);
                entity.NewsImage = newWinField.Value.ToString();
                entity.Headline = txtHeadLine.Text;
                entity.Summary = txtSummary.Text;
                entity.Description = txtDescription.Text;
                entity.NewsDate = DateTime.ParseExact(txtNewDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.NewsOrder = float.Parse(txtorderr.Text);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsDeleted = false;
                entity.ShowInMarquee = CBShowInMarquee.Checked;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.LanguageID = Convert.ToByte(ddNewsLanguages.SelectedValue);
                entity.MappedNewsID1 = ddlMappedNews1.SelectedValue;
                entity.MappedNewsID2 = ddlMappedNews2.SelectedValue;
                entity.IsNotification = CBIsNotification.Checked;

                var Result = await NewsDomain.UpdateNews(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/News/ManageNews.aspx", false);
        }

        protected async void FillLanguages()
        {
            ddNewsLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = await LanguageDomain.GetLanguagesAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddNewsLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }
        }

        protected void FillNews(int LanguageId)
        {
            ResultList<NewsEntity> Result = new ResultList<NewsEntity>();
            Result = NewsDomain.GetNewsAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                if (LanguageId == (int)EnumLanguage.Arabic)
                {
                    lblMapNews1.Text = "Map English News :";
                    lblMapNews2.Text = "Map Espaniol News :";
                }
                else if (LanguageId == (int)EnumLanguage.English)
                {
                    lblMapNews1.Text = "Map Arabic News :";
                    lblMapNews2.Text = "Map Espaniol News :";
                }
                else if (LanguageId == (int)EnumLanguage.Espaniol)
                {
                    lblMapNews1.Text = "Map Arabic News :";
                    lblMapNews2.Text = "Map English News :";
                }

                ddlMappedNews1.Items.Clear();
                ddlMappedNews2.Items.Clear();

                ddlMappedNews1.Items.Insert(0, new ListItem("Select News", "0"));
                ddlMappedNews2.Items.Insert(0, new ListItem("Select News", "0"));

                foreach (NewsEntity item in Result.List)
                {
                    if (item.LanguageID != LanguageId)
                    {
                        if (LanguageId == (int)EnumLanguage.Arabic)
                        {
                            if (item.LanguageID == (int)EnumLanguage.English)
                            {
                                ddlMappedNews1.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                            else
                            {
                                ddlMappedNews2.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                        }
                        if (LanguageId == (int)EnumLanguage.English)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddlMappedNews1.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                            else
                            {
                                ddlMappedNews2.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                        }
                        if (LanguageId == (int)EnumLanguage.Espaniol)
                        {
                            if (item.LanguageID == (int)EnumLanguage.Arabic)
                            {
                                ddlMappedNews1.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                            else
                            {
                                ddlMappedNews2.Items.Add(new ListItem(item.Headline.ToString(), item.NewsID.ToString()));
                            }
                        }
                    }
                }
            }
        }

        protected void ddNewsLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int langId = Convert.ToInt32(lblNewsLanguageId.Text);
                int LanguageId = Convert.ToInt32(ddNewsLanguages.SelectedValue);
                if (LanguageId > 0)
                {
                    if (langId != LanguageId)
                        FillNews(LanguageId);
                    else
                        FillDetails();
                }
                else
                {
                    FillNews(LanguageId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}