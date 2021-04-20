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

namespace Siteware.Web.Plugins.Facility
{
    public partial class EditFacility : System.Web.UI.Page
    {
        string PageName = "What We Do";
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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liNav");
                ////HtmlGenericControl liNavigation = (HtmlGenericControl)masterPage.FindControl("liNavigation");
                //HtmlGenericControl ulNav = (HtmlGenericControl)masterPage.FindControl("ulNav");
                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active dropdown");
                ////liNavigation.Attributes.Add("class", "active");
                //ulNav.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/Facility/ManageFacility.aspx";

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
                if (Session["FacilityIDSession"] != null)
                {
                    long ID = Convert.ToInt64(Session["FacilityIDSession"].ToString());
                    ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();
                    result = Plugin_Facility_Domain.GetFacilityByIDNotAsync(ID);
                    txtFacilityName.Text = result.Entity.Title;
                    txtFacilitySummary.Text = result.Entity.Summary;                   
                    txtPublishDate.Value = result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = result.Entity.IsPublished;
                    ddLanguages.SelectedValue = result.Entity.LanguageID.ToString();
                    txtFacilityOrder.Text = result.Entity.Order.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["FacilityIDSession"] != null)
                {
                    Plugin_Facility_Entity entity = new Plugin_Facility_Entity();
                    entity.ID = Convert.ToInt64(Session["FacilityIDSession"].ToString());
                    entity.Title = txtFacilityName.Text;
                    entity.Summary = txtFacilitySummary.Text;
                    entity.ImageUrl = string.Empty;
                    entity.URL = string.Empty;
                    entity.TargetID = 0;
                    entity.ParentID = 0;
                    entity.Order = Convert.ToInt32(txtFacilityOrder.Text);
                    entity.LanguageID = Convert.ToByte(ddLanguages.SelectedValue);
                    entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.IsDeleted = false;
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

                    var Result = Plugin_Facility_Domain.UpdateFacilityNotAsync(entity);
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
            Response.Redirect("~/Plugins/Facility/ManageFacility.aspx", false);
        }
    }
}