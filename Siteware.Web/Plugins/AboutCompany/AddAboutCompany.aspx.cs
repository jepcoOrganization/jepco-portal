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
    public partial class AddAboutCompany : System.Web.UI.Page
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
                
                Session["IDSelectPage"] = " ~/Plugins/AboutCompany/ManageAboutCompany.aspx";

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

        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            Plugin_AboutCompanyEntity entity = new Plugin_AboutCompanyEntity();
            entity.Title = txtTitle.Text;
            entity.Title2 = txtTitle2.Text;
            entity.Title3 = txttitle3.Text;

            entity.Link = txtLink.Text; // string.Empty;
            entity.Icon = newWinField.Value;
            entity.Target = ddlParentPage.SelectedValue;
            entity.Summery = txtSummary.Text;
           
            entity.Order = Convert.ToInt64(txtorderr.Text);
           
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishedDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.IsDelete = false;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await Plugin_AboutCompanyDomain.InsertRecord(entity);

            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }

        protected void btnOk_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/AboutCompany/ManageAboutCompany.aspx", false);

        }

        
    }
}