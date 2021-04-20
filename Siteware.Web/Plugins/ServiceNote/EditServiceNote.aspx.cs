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

namespace Siteware.Web.Plugins.ServiceNote
{
    public partial class EditServiceNote : System.Web.UI.Page
    {
        string PageName = "ServiceNote";
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
                Session["IDSelectPage"] = "~/Plugins/ServiceNote/ManageServiceNote.aspx";

            }
        }

        protected async void FillDetails()
        {
            if (Session["ServiceNoteIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["ServiceNoteIDSession"]);

                ResultEntity<Plugin_ServiceNoteEntity> Result = new ResultEntity<Plugin_ServiceNoteEntity>();

                Result = await Plugin_ServiceNoteDomain.GetByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtTitle.Text = Result.Entity.Title;
                    txtTitle2.Text = Result.Entity.Title2;
                    txtSummary.Text = Result.Entity.Summary;
                    txtContactDetail.Text = Result.Entity.ContactDetail;
                    txtLink.Text = Result.Entity.Link;
                    ddlParentPage.SelectedValue = Result.Entity.Target;
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    txtorderr.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            Plugin_ServiceNoteEntity entity = new Plugin_ServiceNoteEntity();
            if (Session["ServiceNoteIDSession"] != null)
            {
                entity.ServiceNoteID = Convert.ToInt64(Session["ServiceNoteIDSession"]);
                entity.Title = txtTitle.Text;
                entity.Title2 = txtTitle2.Text;
                entity.Summary = txtSummary.Text;
                entity.ContactDetail = txtContactDetail.Text;
                entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                entity.Link = txtLink.Text;
                entity.Order = Convert.ToInt64(txtorderr.Text);
                entity.Target = ddlParentPage.SelectedValue.ToString();
                entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.EditDate = DateTime.Now;
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.IsDelete = false;

                var Result = await Plugin_ServiceNoteDomain.UpdateServiceNote(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
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
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ServiceNote/ManageServiceNote.aspx", false);
        }

    }
}