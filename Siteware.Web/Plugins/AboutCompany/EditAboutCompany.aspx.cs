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

namespace Siteware.Web.Plugins.AboutCompany
{
    public partial class EditAboutCompany : System.Web.UI.Page
    {
        string PageName = "AboutCompany";
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
               
                Session["IDSelectPage"] = "~/Plugins/AboutCompany/ManageAboutCompany.aspx";

            }
        }
        protected void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = LanguageDomain.GetLanguagesAllNotAsync();

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
            try
            {
                if (Session["CompanyIDSession"] != null)
                {
                    long CompanyID = Convert.ToInt64(Session["CompanyIDSession"]);

                    ResultEntity<Plugin_AboutCompanyEntity> Result = new ResultEntity<Plugin_AboutCompanyEntity>();

                    Result = await Plugin_AboutCompanyDomain.GetByID(CompanyID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lblHeadName1.Text = Result.Entity.Title;
                        lblHeadName2.Text = Result.Entity.Title;
                        ImagePage.ImageUrl = Result.Entity.Icon;
                        newWinField.Value = Result.Entity.Icon;
                        txtTitle.Text = Result.Entity.Title;
                        txtTitle2.Text = Result.Entity.Title2;
                        txttitle3.Text = Result.Entity.Title3;
                        txtSummary.Text = Result.Entity.Summery;
                        txtLink.Text = Result.Entity.Link;
                        ddlParentPage.SelectedValue = Result.Entity.Target;
                       
                        hdnCompanyID.Value = Result.Entity.CompanyID.ToString();
                        txtorderr.Text = Result.Entity.Order.ToString();
                        CBIsPublished.Checked = Result.Entity.IsPublished;
                        ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                        
                       
                        txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CompanyIDSession"] != null)
                {
                    Plugin_AboutCompanyEntity entity = new Plugin_AboutCompanyEntity();
                    entity.CompanyID = Convert.ToInt64(hdnCompanyID.Value);
                    entity.Title = txtTitle.Text;
                    entity.Title2 = txtTitle2.Text;
                    entity.Title3 = txttitle3.Text;
                    entity.Summery = txtSummary.Text;
                    entity.Link = txtLink.Text.Trim();
                    entity.Icon = newWinField.Value;
                    entity.Target = ddlParentPage.SelectedValue;
                   
                    entity.Order = Convert.ToInt64(txtorderr.Text);
                    entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
                    entity.IsPublished = CBIsPublished.Checked;
                    entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    entity.EditDate = Convert.ToDateTime(DateTime.Now);
                    entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                    entity.AddDate = Convert.ToDateTime(DateTime.Now);
                    entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                    var Result = await Plugin_AboutCompanyDomain.UpdateRecord(entity);

                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                else
                {
                    Response.Redirect("~/Plugins/AboutCompany/ManageAboutCompany.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/AboutCompany/ManageAboutCompany.aspx", false);
        }

       

        
    }
}