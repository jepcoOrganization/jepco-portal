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

namespace Siteware.Web.Plugins.RenwabaleEnergyCompany
{
    
    public partial class EditRenwabaleEnergyCompany : System.Web.UI.Page
    {
        string PageName = "RenwabaleEnergyCompany";
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
                        FillClassification();
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
                Session["IDSelectPage"] = "~/Plugins/RenwabaleEnergyCompany/ManageRenwabaleEnergyCompany.aspx";

            }
        }

        protected async void FillDetails()
        {
            if (Session["RenwabaleEnergyCompanyIDSession"] != null)
            {
                int ID = Convert.ToInt32(Session["RenwabaleEnergyCompanyIDSession"]);

                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

                Result = await Plugin_RenwabaleEnergyCompanyDomain.GetByID(ID);
                if (Result.Status == ErrorEnums.Success)
                {
                    
                   
                    
                    hdnServiceUserID.Value = Result.Entity.ServiceUserID.ToString();
                    hdnGovernate.Value = Result.Entity.Governate.ToString();
                    hdnArea.Value = Result.Entity.Area.ToString();
                    hdnArea2.Value = Result.Entity.Area2.ToString();
                    hdnStreetID.Value = Result.Entity.StreetID.ToString();
                    txtCompanyName.Text = Result.Entity.CompanyName;
                    txtNAtionalID.Text = Result.Entity.CompanyNationalID;
                    ddlCompanyClassification.SelectedValue = Result.Entity.CompanyNationalID.ToString();
                    txtMobile.Text = Result.Entity.MobileNumber;
                    txtTelephone.Text = Result.Entity.TelephoneNumber;
                    txtFaxNo.Text = Result.Entity.FaxNumber;
                    txtEmail.Text = Result.Entity.EmailAddress;
                    txtwebsite.Text = Result.Entity.Website;
                    txtQualificationExpiry.Value = Result.Entity.QualificationExpiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    txtAddress.Text = Result.Entity.Address;
                    hdnRegistrationDocument.Value = Result.Entity.CompanyRegistrationDocument;
                    if (Result.Entity.CompanyRegistrationDocument != string.Empty)
                    {
                        string abcd = Result.Entity.CompanyRegistrationDocument.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnkRegistrationDocument.NavigateUrl = Result.Entity.CompanyRegistrationDocument;
                        lnkRegistrationDocument.Text = Cutted;

                    }
                    hdnQualificationDocument.Value = Result.Entity.QualificationDocument;
                    if (Result.Entity.QualificationDocument != string.Empty)
                    {
                        string abcd = Result.Entity.QualificationDocument.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnkQualificationDocument.NavigateUrl = Result.Entity.QualificationDocument;
                        lnkQualificationDocument.Text = Cutted;

                    }

                    chkMobilevrify.Checked = Result.Entity.IsMobileVerfied;
                    chkEmailVerify.Checked = Result.Entity.ISEmailVerfied;
                    //lnkRegistrationDocument
                    //    lnkQualificationDocument

                    txtorderr.Text = Result.Entity.Order.ToString();
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                }
            }
        }
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            Plugin_RenwabaleEnergyCompanyEntity entity = new Plugin_RenwabaleEnergyCompanyEntity();
            if (Session["RenwabaleEnergyCompanyIDSession"] != null)
            {

                //              [RenwabaleEnergyCompanyID]
                //,[ServiceUserID]
                //,[CompanyName]
                //,[CompanyNationalID]
                //,[CompanyClassificationID]
                //,[Password]
                //,[MobileNumber]
                //,[TelephoneNumber]
                //,[FaxNumber]
                //,[EmailAddress]
                //,[Website]
                //,[Governate]
                //,[Area]
                //,[Area2]
                //,[StreetID]
                //,[Address]
                //,[CompanyRegistrationDocument]
                //,[QualificationDocument]
                //,[QualificationExpiryDate]
                //,[IsMobileVerfied]
                //,[ISEmailVerfied]
                //,[Order]
                //,[LanguageID]
                //,[PublishDate]
                //,[IsPublished]
                //,[IsDeleted]
                //,[AddDate]
                //,[AddUser]
                //,[EditDate]
                //,[EditUser]

                entity.RenwabaleEnergyCompanyID = Convert.ToInt64(Session["RenwabaleEnergyCompanyIDSession"]);
                entity.ServiceUserID = Convert.ToInt64(hdnServiceUserID.Value);
                entity.CompanyName = txtCompanyName.Text; 
                entity.CompanyNationalID = txtNAtionalID.Text;
                entity.CompanyClassificationID = Convert.ToInt32(ddlCompanyClassification.SelectedValue);
                entity.Password = txtPassword.Text;
                entity.MobileNumber = txtMobile.Text;
                entity.TelephoneNumber = txtTelephone.Text;
                entity.FaxNumber = txtFaxNo.Text;
                entity.EmailAddress = txtEmail.Text;
                entity.Website = txtwebsite.Text;
                entity.Governate = Convert.ToInt32(hdnGovernate.Value);
                entity.Area = Convert.ToInt32(hdnArea.Value);
                entity.Area2 = Convert.ToInt32(hdnArea2.Value);
                entity.StreetID = Convert.ToInt32(hdnStreetID.Value);
                entity.Address = txtAddress.Text;
                entity.CompanyRegistrationDocument = hdnQualificationDocument.Value;
                entity.QualificationDocument = hdnRegistrationDocument.Value;
                entity.QualificationExpiryDate = DateTime.ParseExact(txtQualificationExpiry.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsMobileVerfied = chkMobilevrify.Checked;
                entity.ISEmailVerfied = chkEmailVerify.Checked;
                entity.Order = 0;
                entity.LanguageID = 2;
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.AddDate = DateTime.Now;
                entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EditDate = DateTime.Now;
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.IsDeleted = false;

                var Result = await Plugin_RenwabaleEnergyCompanyDomain.UpdateRecord(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }
            }
        }
        protected async void FillLanguages()
        {
            //ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            //ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            //Result = await LanguageDomain.GetLanguagesAll();

            //if (Result.Status == ErrorEnums.Success)
            //{
            //    foreach (LanguageEntity item in Result.List)
            //    {
            //        ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
            //    }
            //}

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ServiceNote/ManageServiceNote.aspx", false);
        }

        protected async void FillClassification()
        {
            ddlCompanyClassification.Items.Insert(0, new ListItem("الجنسية", "0"));

            ResultList<Lookup_CompamyClassificationEntity> Result = new ResultList<Lookup_CompamyClassificationEntity>();
            Result = await Lookup_CompamyClassificationDomain.GetAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_CompamyClassificationEntity item in Result.List)
                {
                    ddlCompanyClassification.Items.Add(new ListItem(item.CompanyClassificationName.ToString(), item.CompanyClassificationID.ToString()));

                }
            }

        }
    }
}