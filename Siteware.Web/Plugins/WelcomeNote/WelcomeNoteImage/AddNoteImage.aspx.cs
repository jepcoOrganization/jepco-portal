using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
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
    public partial class AddNoteImage : System.Web.UI.Page
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
                        if (Session["WelcomeNoteIDSession"] != null)
                        {
                            FillNavigation();
                        }
                        else
                        {
                            Response.Redirect("~/Plugins/WelcomeNote/ManageWelcomeNote.aspx", false);
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
        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Session["WelcomeNoteIDSession"] != null)
            {
                WelcomeNote_ImageEntity entity = new WelcomeNote_ImageEntity();
                entity.WelcomeNoteID = Convert.ToInt32(Session["WelcomeNoteIDSession"].ToString());
                entity.Title = txtPageName.Text;
                entity.Image = newWinField.Value.ToString();
                entity.Link = txtLink.Text.Trim();
                entity.Target = ddlTargetID.SelectedValue;
                entity.ImageOrder = Convert.ToInt32(txtorder.Text);
                entity.IsDeleted = false;                
                entity.IsPublished = CBIsPublished.Checked;
                entity.Publisheddate= DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = await WelcomeNote_ImageDomain.InsertImage(entity);
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