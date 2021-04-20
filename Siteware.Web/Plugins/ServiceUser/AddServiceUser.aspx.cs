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

namespace Siteware.Web.Plugins.ServiceUser
{
    public partial class AddServiceUser : System.Web.UI.Page
    {
        string PageName = "ServiceUser";
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
                        FillCountry();
                        FillArea();
                        FillCity();
                        FillIDType();
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
                Session["IDSelectPage"] = "~/Plugins/ServiceUser/ManageServiceUser.aspx";

               
            }
        }

        protected async void BtnAdd_Click(object sender, EventArgs e)
        {
            Plugin_ServiceUserEntity entity = new Plugin_ServiceUserEntity();

            entity.FirstName = txtFirstName.Text;
            entity.SecondName = txtSecondName.Text;
            entity.ThirdName = txtThirdName.Text;
            entity.FamilyName = txtFirstName.Text;
            entity.UserID = txtUserID.Text;
            entity.UserType = txtUserType.Text;
            entity.IDType = Convert.ToInt32(ddlIDType.SelectedValue);
            entity.IDNumber = txtIDNumber.Text;
            entity.MobileNumber = txtMobileNumber.Text;
            entity.TelephoneNumber = txtTelephoneNumber.Text;
            entity.Email = txtEmail.Text;
            entity.Password = txtPassword.Text;
            entity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            entity.City = Convert.ToInt32(ddlCity.SelectedValue);
            entity.Area1 = Convert.ToInt32(ddlArea1.SelectedValue);
            entity.Area2 = Convert.ToInt32(ddlArea2.SelectedValue);
            entity.Address = txtAddress.Text;
            entity.Latitude = txtLatitude.Text;
            entity.Longitude = txtLongitude.Text;

            entity.IsDeleted = false;
            entity.Order = Convert.ToInt32(txtorderr.Text);
            entity.IsPublished = CBIsPublished.Checked;
            entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
            
            var Result = await Plugin_ServiceUserDomain.Insert(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/ServiceUser/ManageServiceUser.aspx", false);
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
        protected async void FillCountry()
        {
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

            ResultList<Lookup_CountryEntity> Result = new ResultList<Lookup_CountryEntity>();
            Result = await Lookup_countryDomain.GetAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_CountryEntity item in Result.List)
                {
                    ddlCountry.Items.Add(new ListItem(item.CountryName.ToString(), item.CountryID.ToString()));
                }
            }

        }

        protected async void FillCity()
        {
            ddlCity.Items.Insert(0, new ListItem("Select City", "0"));

            ResultList<Lookup_CityEntity> Result = new ResultList<Lookup_CityEntity>();
            Result = await Lookup_CityDomain.GetLookupCityAll();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_CityEntity item in Result.List)
                {
                    ddlCity.Items.Add(new ListItem(item.CityName.ToString(), item.CityID.ToString()));
                }
            }

        }

        protected async void FillArea()
        {
            ddlArea1.Items.Insert(0, new ListItem("Select Area 1", "0"));
            ddlArea2.Items.Insert(0, new ListItem("Select Area 2", "0"));

            ResultList<Lookup_AreaEntity> Result = new ResultList<Lookup_AreaEntity>();
            Result = await Lookup_AreaDomain.GetLookupAreaAll();
          
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_AreaEntity item in Result.List)
                {
                    ddlArea1.Items.Add(new ListItem(item.AreaName.ToString(), item.AreaID.ToString()));
                    ddlArea2.Items.Add(new ListItem(item.AreaName.ToString(), item.AreaID.ToString()));

                }
            }

        }
         protected async void FillIDType()
        {
            ddlIDType.Items.Insert(0, new ListItem("Select ID Type", "0"));
           
            ResultList<Lookup_ServiceUserTypeEntity> Result = new ResultList<Lookup_ServiceUserTypeEntity>();
            Result = await Lookup_ServiceUserTypeDomain.GetAll();
          
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_ServiceUserTypeEntity item in Result.List)
                {
                    ddlIDType.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                   
                }
            }

        }

    }
}