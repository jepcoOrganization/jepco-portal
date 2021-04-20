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
using System.Web.Services;

namespace Siteware.Web.Plugins.Announcement
{
    public partial class EditAnnouncement : System.Web.UI.Page
    {
        string PageName = "Announcement";

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
                Session["IDSelectPage"] = "~/Plugins/Announcement/ManageAnnouncement.aspx";

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
            if (Session["AnnouncementIDSession"] != null)
            {
                int AnnouncementID = Convert.ToInt32(Session["AnnouncementIDSession"]);

                ResultEntity<PluginAnnouncementEntity> Result = new ResultEntity<PluginAnnouncementEntity>();

                Result = await PluginAnnouncementDomain.GetPagesByAnnouncementID(AnnouncementID);
                if (Result.Status == ErrorEnums.Success)
                {
                    //if (Result.Entity.MediaType == 1)
                    //{
                    //    ImagePage.ImageUrl = Result.Entity.Image;
                    //    newWinField.Value = Result.Entity.Image;
                    //    LiImage.Style["display"] = "block";
                    //}
                    //else
                    //{
                    //    newWinField2.Value = Result.Entity.Image;
                    //    VideoID.Src = Result.Entity.Image;
                    //    LiVideo.Style["display"] = "block";
                    //    ddchoisLink.SelectedValue = Result.Entity.VideoType.ToString();
                    //}
                    txtTitle.Text = Result.Entity.Title;
                    lblAnnouncement1.Text = Result.Entity.Title;
                    lblAnnouncement2.Text = Result.Entity.Title;
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtDescription.Text = Result.Entity.Description;
                    //txtLink.Text = Result.Entity.Link;
                    //ddlTarget.SelectedValue = Result.Entity.Target;
                    txtorderr.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtAnnounceDate.Value = Result.Entity.AnnouncementDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //ddlType.SelectedValue = Result.Entity.MediaType.ToString();
                    ddchoisLink.SelectedValue = Result.Entity.VideoType.ToString();
                    if(ddchoisLink.SelectedValue == "1")
                    {
                        DivFileUpload.Style["display"] = "block";
                    }
                    else
                    {
                        DivLink.Style["display"] = "block";
                        txtlnkURL.Text = Result.Entity.Image;
                    }
                }
            }

        }


        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            HeadlineImage.Attributes.Add("class", "ui-tabs-active ui-state-active");
        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            PluginAnnouncementEntity entity = new PluginAnnouncementEntity();
            if (Session["AnnouncementIDSession"] != null)
            {
                entity.AnnouncementID = Convert.ToInt32(Session["AnnouncementIDSession"]);
                //if (ddlType.SelectedValue == "1")
                //{
                //    entity.Image = newWinField.Value;
                //    entity.VideoType = 0;
                //}
                //else
                //{
                //    if (ddchoisLink.SelectedValue == "1")
                //    {
                //        entity.Image = newWinField2.Value;
                //    }
                //    else
                //    {
                //        entity.Image = txtlnkURL.Text;
                //    }
                //}
                entity.Image = string.Empty; // newWinField.Value;
                entity.VideoType = 0;
               
                entity.Title = txtTitle.Text;
                entity.MediaType = 0; // Convert.ToInt32(ddlType.SelectedValue);
                entity.Summary = string.Empty;
                entity.Description = txtDescription.Text;
                entity.Link = string.Empty; //txtLink.Text;
                entity.Target = string.Empty;// ddlTarget.SelectedValue;                
                var time = DateTime.Now.ToString("h:mm:ss tt");
                string datetime = txtPublishDate.Value + " " + time;
                entity.AnnouncementDate = DateTime.ParseExact(txtAnnounceDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.Order = float.Parse(txtorderr.Text);
                entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.MapAnnouncementId1 = string.Empty;
                entity.MapAnnouncementId2 = string.Empty;

                var Result = await PluginAnnouncementDomain.UpdateAnnouncement(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Announcement/ManageAnnouncement.aspx", false);
        }

    }
}