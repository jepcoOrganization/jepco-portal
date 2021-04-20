using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;
using System.Globalization;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;

namespace Siteware.Web.Plugins.Project
{
    public partial class EditProject : System.Web.UI.Page
    {
        string PageName = "Project";
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
                        // FillParentMenu();
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

                Session["IDSelectPage"] = "~/Plugins/Project/ManageProject.aspx";

            }
        }

        protected void FillLanguages()
        {
            ddLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = LanguageDomain.GetLanguagesAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }

        }
        protected void FillDetails()
        {
            try
            {
                if (Session["ProjectIDSession"] != null)
                {
                    long ID = Convert.ToInt64(Session["ProjectIDSession"].ToString());
                    ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();
                    result = Plugin_Project_Domain.GetProjectByIDNotAsync(ID);
                    txtTitle.Text = result.Entity.Title;
                    txtSummary.Text = result.Entity.Summary;
                    txtPublishDate.Value = result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = result.Entity.IsPublished;
                    ddLanguages.SelectedValue = result.Entity.LanguageID.ToString();
                    txtorder.Text = result.Entity.Order.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ProjectIDSession"] != null)
                {
                    Plugin_ProjectEntities entity = new Plugin_ProjectEntities();
                    entity.ID = Convert.ToInt64(Session["ProjectIDSession"].ToString());
                    entity.Title = txtTitle.Text;
                    entity.Summary = txtSummary.Text;
                    entity.ImageUrl = string.Empty;
                    entity.ParentID = 0;
                    entity.URL = string.Empty;
                    entity.TargetID = 0;
                    entity.Order = Convert.ToInt32(txtorder.Text);
                    entity.LanguageID = Convert.ToByte(ddLanguages.SelectedValue);
                    entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.IsDeleted = false;
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = await Plugin_Project_Domain.UpdateProject(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Project/ManageProject.aspx", false);
        }
    }
}