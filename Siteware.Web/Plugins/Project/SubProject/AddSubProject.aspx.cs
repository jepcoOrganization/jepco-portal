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

namespace Siteware.Web.Plugins.Project.SubProject
{
    public partial class AddSubProject : System.Web.UI.Page
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

                Session["IDSelectPage"] = "~/Plugins/Project/SubProject/ManageSubProject.aspx";

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
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            if(Session["ProjectIDSession"] !=null)
            {
                Plugin_ProjectEntities entity = new Plugin_ProjectEntities();

                entity.Title = txtLinkTitle.Text;
                entity.Summary = txtSummary.Text;
                entity.ImageUrl = newWinField.Value;
                entity.URL = txtLink.Text;
                entity.ParentID = Convert.ToInt64(Session["ProjectIDSession"].ToString());
                entity.TargetID = Convert.ToByte(ddlTargetID.SelectedValue);
                entity.Order = Convert.ToInt32(txtorder.Text);
                entity.LanguageID = Convert.ToByte(ddLanguages.SelectedValue);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.AddDate = Convert.ToDateTime(DateTime.Now);
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                var Result = Plugin_Project_Domain.InsertNotAsync(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
           
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Project/SubProject/ManageSubProject.aspx", false);
        }
    }
}