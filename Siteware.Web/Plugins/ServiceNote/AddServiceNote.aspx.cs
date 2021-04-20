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
using SiteWare.DataAccess.Common;
using System.Text.RegularExpressions;

namespace Siteware.Web.Plugins.ServiceNote
{
    public partial class AddServiceNote : System.Web.UI.Page
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
                
                Session["IDSelectPage"] = "~/Plugins/ServiceNote/ManageServiceNote.aspx";

            }
        }

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            Plugin_ServiceNoteEntity entity = new Plugin_ServiceNoteEntity();
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
            entity.AddDate = DateTime.Now;
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = DateTime.Now;
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.IsDelete = false;

            var Result = await Plugin_ServiceNoteDomain.InsertServiceNote(entity);

            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
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