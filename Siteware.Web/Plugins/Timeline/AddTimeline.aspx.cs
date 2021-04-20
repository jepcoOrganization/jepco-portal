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

namespace Siteware.Web.Plugins.Timeline
{
    public partial class AddTimeline : System.Web.UI.Page
    {
        string PageName = "Timeline";
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
                        FillLanguages();
                        ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));
                       
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

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LangID = Convert.ToInt32(ddlLanguages.SelectedValue);
                FillFocus(LangID);
                
            }
            catch (Exception ex)
            {
            }
        }

        protected async void FillFocus(int LangID)
        {
            ddlFocusID.Items.Clear();
            ddlFocusID.Items.Insert(0, new ListItem("Select Focus", "0"));

            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
            Result = await Plugin_Focus_AreaDomain.GetAll();

            Result.List = Result.List.Where(s => s.IsPublished == true && !s.IsDelete && s.LanguageID == LangID).OrderBy(s => s.FocusOrder).ToList();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_Focus_AreaEntity item in Result.List)
                {
                    ddlFocusID.Items.Add(new ListItem(item.Title.ToString(), item.FocusID.ToString()));
                }
            }
        }

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            Plugin_TimelineEntity entity = new Plugin_TimelineEntity();
            entity.Title = txtTitle.Text.Trim();
            entity.Summary = txtSummary.Text;          
            entity.FocusID = Convert.ToInt32(ddlFocusID.SelectedValue);
            entity.Description = txtDescription.Text;
            entity.Year = txtYear.Text;
            entity.Order = Convert.ToInt32(txtorderr.Text);
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDelete = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
           

            var Result = await Plugin_TimelineDomain.InsertRecord(entity);

            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Timeline/ManageTimeline.aspx", false);
        }
    }
}