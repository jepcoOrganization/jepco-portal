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
    public partial class AddNews : System.Web.UI.Page
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
                        FillNews();
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
                Session["IDSelectPage"] = "~/Plugins/News/ManageNews.aspx";

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

        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            HeadlineImage.Attributes.Add("class", "ui-tabs-active ui-state-active");
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            NewsEntity entity = new NewsEntity();

            entity.NewsImage = newWinField.Value.ToString();
            entity.Headline = txtHeadLine.Text;
            entity.Summary = txtSummary.Text;
            entity.Description = txtDescription.Text;
            entity.NewsDate = DateTime.ParseExact(txtNewDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.ViewCount = 0;
            entity.NewsOrder = float.Parse(txtorderr.Text);
            entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDeleted = false;
            entity.ShowInMarquee = CBShowInMarquee.Checked;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.MappedNewsID1 = ddlMappedNews1.SelectedValue;
            entity.MappedNewsID2 = ddlMappedNews2.SelectedValue;
            entity.IsNotification = CBIsNotification.Checked;

            var Result = await NewsDomain.InsertNews(entity);
            bool isNotified = false;
            //if (entity.IsNotification)
            //{
            //    var getlatestnews = await NewsDomain.GetNewsAll();
            //    var lastnews = getlatestnews.List.Where(q => q.IsDeleted == false && q.IsPublished == true && q.LanguageID == Convert.ToByte(ddlLanguages.SelectedValue)).OrderByDescending(q => q.NewsID).FirstOrDefault();

            //    var ResultIoS = string.Empty;
            //    var ResultAndroid = string.Empty;
            //    SendNotificationEntity sendNotification = new SendNotificationEntity();
            //    sendNotification.NotificationType = "News";
            //    sendNotification.NotificationID = lastnews.NewsID;
            //    sendNotification.Notification = entity.Headline;
            //    sendNotification.IoSnotificationResult = ResultIoS;
            //    sendNotification.AndroidnotificationResult = ResultAndroid;
            //    sendNotification.DateGenerated = DateTime.Now;

            //    var SaveNotification = await SendNotificationDomain.InsertNotification(sendNotification);
            //    if (SaveNotification.Status == ErrorEnums.Success)
            //    {
            //        isNotified = true;
            //    }
            //}
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/News/ManageNews.aspx", false);
        }

        protected void FillNews()
        {
            ddlMappedNews1.Items.Insert(0, new ListItem("Select News", "0"));
            ddlMappedNews2.Items.Insert(0, new ListItem("Select News", "0"));
        }
        protected async void FillNewsByLanguage(int LanguageId)
        {
            ResultList<NewsEntity> Result = new ResultList<NewsEntity>();
            Result = await NewsDomain.GetNewsAll();

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

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                if (LanguageID > 0)
                {
                    FillNewsByLanguage(LanguageID);
                }
                else
                {
                    FillNewsByLanguage(LanguageID);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}