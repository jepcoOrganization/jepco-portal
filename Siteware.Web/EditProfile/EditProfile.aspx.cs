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
using System.Globalization;

namespace Siteware.Web.EditProfile
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    lblUsername.Text = SessionManager.GetInstance.Users.FirstName + " " + SessionManager.GetInstance.Users.LastName;
                    FillDetails();
                    FillGender();
                    FillCountry();
                    FillMartial();
                    FillDepartment();
                    FillSection();
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx");
                }
            }

        }
        protected async void FillDetails()
        {
            int UserID = Convert.ToInt32(SessionManager.GetInstance.Users.UserID);

            ResultEntity<UserEntity> Result = new ResultEntity<UserEntity>();

            Result = await UsersDomain.GetUserData(UserID);
            if (Result.Status == ErrorEnums.Success)
            {
                txtusername.Text = Result.Entity.LoginID;
                txtEmail.Text = Result.Entity.Email;
                CbStatus.Checked = Result.Entity.Status;
                CbIsDeleted.Checked = Result.Entity.IsDeleted;
                txtFirstName.Text = Result.Entity.FirstName.ToString();
                txtSecondName.Text = Result.Entity.SecondName.ToString();
                txtLastName.Text = Result.Entity.LastName.ToString();
                datepicker.Value = Result.Entity.BirthDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                ddlMartialStatus.SelectedValue = Result.Entity.MaritalStatusID.ToString();
                ddlGender.SelectedValue = Result.Entity.GenderID.ToString();
                ddlCountry.SelectedValue = Result.Entity.CountryID.ToString();
                txtTelephone.Text = Result.Entity.Telephone.ToString();
                txtEXT.Text = Result.Entity.Ext.ToString();
                txtMobile.Text = Result.Entity.Mobile.ToString();
                txtaddress.Text = Result.Entity.Address.ToString();
                txtaddress.Text = Result.Entity.Address.ToString();
                ddlDepartment.SelectedValue = Result.Entity.DepartmentID.ToString();
                ddlSection.SelectedValue = Result.Entity.SectionID.ToString();
                txtTitle.Text = Result.Entity.Title.ToString();
                datepicker2.Value = Result.Entity.HireDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                if (Result.Entity.Image != null && Result.Entity.Image != "")
                {
                    ImageUser.ImageUrl = Result.Entity.Image.ToString();
                }
                else
                {
                    ImageUser.ImageUrl = "/AppTheme/images/profilethumb.png";
                }
            }

            //

            //var Data = UsersRepository.SelectByUserID(UserID);
            //if (Data != null)
            //{
            //    


            //}
        }


        protected async void btnUpdate_Clicks(object sender, EventArgs e)
        {

            UserEntity entity = new UserEntity();

            if (txtOldPassword.Text.Length > 0 && txtNewPassword.Text.Length > 0 && txtConfirmPassword.Text.Length > 0)
            {

                int UserID = Convert.ToInt32(SessionManager.GetInstance.Users.UserID);

                lblOldPassValidation.Visible = false;

                ResultEntity<UserEntity> GetData = new ResultEntity<UserEntity>();

                GetData = await UsersDomain.GetUserData(UserID);
                if (GetData.Status == ErrorEnums.Success)
                {
                    string OldPassword = GetData.Entity.Passwordd;
                    string PasswordDec = Encrypt.Encrypted(txtOldPassword.Text);

                    if (OldPassword != PasswordDec)
                    {
                        lblOldPassValidation.Visible = true;
                        return;
                    }
                    else
                    {
                        entity.UserID = Convert.ToInt32(SessionManager.GetInstance.Users.UserID);
                        entity.Passwordd = Encrypt.Encrypted(txtNewPassword.Text.ToString());

                        var Result1 = UsersDomain.UpdateUserPassword(entity);
                    }
                }
            }

            entity.UserID = Convert.ToInt32(SessionManager.GetInstance.Users.UserID);
            entity.LoginID = txtusername.Text.ToString();

            entity.CountryID = Convert.ToByte(ddlCountry.SelectedValue.ToString());
            entity.Image = ImageUser.ImageUrl.ToString();
            entity.FirstName = txtFirstName.Text.ToString();
            entity.SecondName = txtSecondName.Text.ToString();
            entity.LastName = txtLastName.Text.ToString();
            entity.Email = txtEmail.Text.ToString();
            entity.BirthDate = DateTime.ParseExact(datepicker.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //entity.BirthDate = DateTime.ParseExact(datepicker.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            // entity.BirthDate = Convert.ToDateTime(datepicker.Value.ToString());
            entity.MaritalStatusID = Convert.ToByte(ddlMartialStatus.SelectedValue.ToString());
            entity.GenderID = Convert.ToByte(ddlGender.SelectedValue.ToString());
            entity.DepartmentID = Convert.ToByte(ddlDepartment.SelectedValue.ToString());
            entity.SectionID = Convert.ToByte(ddlSection.SelectedValue.ToString());
            entity.Title = txtTitle.Text.ToString();
            entity.Telephone = txtTelephone.Text.ToString();
            entity.Ext = txtEXT.Text.ToString();
            entity.Mobile = txtMobile.Text.ToString();
            entity.HireDate = DateTime.ParseExact(datepicker2.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            // entity.HireDate = Convert.ToDateTime(datepicker2.Value.ToString());
            entity.Status = CbStatus.Checked;
            entity.IsDeleted = CbIsDeleted.Checked;
            entity.Address = txtaddress.Text.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await UsersDomain.UpdateUserData(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditProfile/EditProfile.aspx", false);
        }
        protected void FillUploadImage()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Siteware_File/");
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                Guid Image = Guid.NewGuid();
                FileUpload1.PostedFile.SaveAs(path + Image + FileUpload1.FileName);
                ImageUser.ImageUrl = "~/Siteware_File/" + Image + FileUpload1.FileName.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied02", "alert('Cannot accept files of this type')", true);
            }
        }
        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            FillUploadImage();

        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillSection();
        }

        protected void FillGender()
        {
            ddlGender.Items.Insert(0, new ListItem("Select Gender", "0"));
            try
            {
                ResultList<GenderLanguageEntity> Result = new ResultList<GenderLanguageEntity>();
                Result = GenderLanguageDomain.GetGenderNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (GenderLanguageEntity item in Result.List)
                    {
                        ddlGender.Items.Add(new ListItem(item.Name.ToString(), item.GenderID.ToString()));
                    }
                }

            }
            catch (Exception ex) { }
        }

        protected void FillCountry()
        {
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
            try
            {
                ResultList<CountryLanguageEntity> Result = new ResultList<CountryLanguageEntity>();
                Result = CountryLanguageDomain.GetCountryNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (CountryLanguageEntity item in Result.List)
                    {
                        ddlCountry.Items.Add(new ListItem(item.Name.ToString(), item.CountryID.ToString()));
                    }
                }

            }
            catch (Exception ex) { }
        }

        protected void FillMartial()
        {
            ddlMartialStatus.Items.Insert(0, new ListItem("Select Martial", "0"));
            try
            {
                ResultList<MartialStatusEntity> Result = new ResultList<MartialStatusEntity>();
                Result = MartialStatusDomain.GetMartialStatusNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (MartialStatusEntity item in Result.List)
                    {
                        ddlMartialStatus.Items.Add(new ListItem(item.Name.ToString(), item.MaritalStatusID.ToString()));
                    }
                }

            }
            catch (Exception ex) { }
        }

        protected void FillDepartment()
        {
            ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));

            try
            {
                ResultList<DepartmentLanguageEntity> Result = new ResultList<DepartmentLanguageEntity>();
                Result = DepartmentLanguageDomain.GetDepartmentNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (DepartmentLanguageEntity item in Result.List)
                    {
                        ddlDepartment.Items.Add(new ListItem(item.Name.ToString(), item.DepartmentID.ToString()));
                    }
                }
            }
            catch (Exception exp)
            {

            }

        }

        protected void FillSection()
        {
            ddlSection.Items.Insert(0, new ListItem("Select Section", "0"));
            try
            {
                ResultList<SectionLanguageEntity> Result = new ResultList<SectionLanguageEntity>();
                Result = SectionLanguageDomain.GetSectionNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (SectionLanguageEntity item in Result.List)
                    {
                        ddlSection.Items.Add(new ListItem(item.Name.ToString(), item.SectionID.ToString()));
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }

    }
}