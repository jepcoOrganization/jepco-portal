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
    public partial class AddVideos : System.Web.UI.Page
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

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
                Plugin_VideoEntity entity = new Plugin_VideoEntity();
                entity.Title = txtTitle.Text;

            //if (ddchoisLink.SelectedValue == "1")
            //{
            //    entity.Link = newWinField2.Value.ToString();
            //}
            //else { entity.Link = txtlnkURL.Text.ToString(); }
            entity.Link = txtLink.Text;
                entity.CoverImage = newWinField.Value.ToString();
                entity.Order = Convert.ToInt32(txtorderr.Text);
                entity.IsDeleted = false;
                entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                entity.IsPublished = CBIsPublished.Checked;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            //entity.Target = ddchoisLink.SelectedValue.ToString();
            entity.Target = ddlParentPage.SelectedValue;
                var Result = await Plugin_VideoDomain.Insert(entity);
                if (Result.Status == ErrorEnums.Success)
                {

                    mpeSuccess.Show();
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