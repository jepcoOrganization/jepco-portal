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

namespace Siteware.Web.Plugins.WelcomeNote.WelcomeNoteImage
{
    public partial class EditNoteImage : System.Web.UI.Page
    {
        string PageName = "Welcome Note";
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
                        if (Session["ImageIDSession"] != null)
                        {
                            FillNavigation();
                            FillDetail();
                        }
                        else
                        {
                            Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/ManageNoteImage.aspx", false);
                        }

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
                //HtmlGenericControl liMedia = (HtmlGenericControl)masterPage.FindControl("liMedia");
                //HtmlGenericControl ulMedia = (HtmlGenericControl)masterPage.FindControl("ulMedia");

                //liDashboard.Attributes.Add("class", "");
                //liMedia.Attributes.Add("class", "active dropdown");
                //ulMedia.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/WelcomeNote/ManageWelcomeNote.aspx";

            }
        }
        protected async void FillDetail()
        {
            try
            {
                ResultEntity<WelcomeNote_ImageEntity> Result = new ResultEntity<WelcomeNote_ImageEntity>();
                if (Session["ImageIDSession"] != null)
                {
                    long ID = Convert.ToInt64(Session["ImageIDSession"].ToString());
                    Result = await WelcomeNote_ImageDomain.GetByID(ID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lblNoteID.Value = Result.Entity.WelcomeNoteID.ToString();
                        txtPageName.Text = Result.Entity.Title.Trim();
                        txtLink.Text = Result.Entity.Link;
                        ddlTargetID.SelectedValue = Result.Entity.Target;
                        txtorder.Text = Result.Entity.ImageOrder.ToString();
                        CBIsPublished.Checked = Result.Entity.IsPublished;
                        txtPublishDate.Value = Result.Entity.Publisheddate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        ImagePage.ImageUrl = Result.Entity.Image.ToString();
                        newWinField.Value = Result.Entity.Image.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Session["ImageIDSession"] != null)
            {
                WelcomeNote_ImageEntity entity = new WelcomeNote_ImageEntity();
                entity.ImageID = Convert.ToInt64(Session["ImageIDSession"].ToString());
                entity.WelcomeNoteID = Convert.ToInt32(lblNoteID.Value);
                entity.Title = txtPageName.Text;
                entity.Image = newWinField.Value.ToString();
                entity.Link = txtLink.Text.Trim();
                entity.Target = ddlTargetID.SelectedValue;
                entity.ImageOrder = Convert.ToInt32(txtorder.Text);
                entity.IsPublished = CBIsPublished.Checked;
                entity.Publisheddate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);              
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await WelcomeNote_ImageDomain.UpdateImage(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/WelcomeNote/WelcomeNoteImage/ManageNoteImage.aspx", false);
        }
    }
}