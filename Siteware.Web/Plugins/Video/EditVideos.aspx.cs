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

namespace Siteware.Web.Plugins.Video
{
    public partial class EditVideos : System.Web.UI.Page
    {
        string PageName = "Videos";
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
                        // divpageurl.Visible = false;
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

                Session["IDSelectPage"] = "~/Plugins/Video/ManageVideos.aspx";

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
            if (Session["VideopIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["VideopIDSession"]);

                ResultEntity<Plugin_VideoEntity> Result = new ResultEntity<Plugin_VideoEntity>();

                Result = await Plugin_VideoDomain.GetByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    txtorderr.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    if (Result.Entity.CoverImage != null && Result.Entity.CoverImage != "")
                    {
                        ImagePage.ImageUrl = Result.Entity.CoverImage.ToString();
                        newWinField.Value = Result.Entity.CoverImage.ToString();
                    }
                    ddlParentPage.SelectedValue = Result.Entity.Target;
                    txtLink.Text = Result.Entity.Link;
                    //ddchoisLink.SelectedValue = Result.Entity.Target;
                    //if (Result.Entity.Target == "1")
                    //{
                    //    newWinField2.Value = Result.Entity.Link;
                    //}
                    //else
                    //{
                    //    txtlnkURL.Text = Result.Entity.Link;
                    //}
                    // DivFileUpload.Visible = false; DivLink.Visible = true; 
                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            Plugin_VideoEntity entity = new Plugin_VideoEntity();
            if (Session["VideopIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["VideopIDSession"]);
                entity.Title = txtTitle.Text;


                //if (ddchoisLink.SelectedValue == "1")
                //{
                //    entity.Link = newWinField2.Value.ToString();
                //}
                //else { entity.Link = txtlnkURL.Text.ToString(); }


                entity.CoverImage = newWinField.Value.ToString();
                entity.Order = Convert.ToInt32(txtorderr.Text);
                entity.IsDeleted = false;
                entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //entity.AddDate = Convert.ToDateTime(DateTime.Now);
                //entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                //entity.Target = ddchoisLink.SelectedValue.ToString();
                entity.Target = ddlParentPage.SelectedValue;
                entity.Link = txtLink.Text;

                var Result = await Plugin_VideoDomain.Update(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Video/ManageVideos.aspx", false);
        }
        //protected void ddchoisLink_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddchoisLink.SelectedValue == "1")
        //    { DivFileUpload.Visible = true; DivLink.Visible = false; }
        //    else if (ddchoisLink.SelectedValue == "2")
        //    { DivFileUpload.Visible = false; DivLink.Visible = true; }
        //}

    }
}