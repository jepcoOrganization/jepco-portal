using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiteWare.DataAccess.Repositories;
using HtmlAgilityPack;
using System.Web.Services;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class LoginPage_Registration : SiteBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // FillIDType();
            FillNAtionality();
            FillUserType();
            FillCountry();
            FillCity();
            FillArea();
            FillAllUserIDs();
            ddlCity.Items.Insert(0, new ListItem("اختر مدينة", "0"));
            ddlArea1.Items.Insert(0, new ListItem("حدد المنطقة 1", "0"));
            //ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));
            FillAllUserMobiles();
            FillClassification();



        }
    }

    protected async void FillUserType()
    {
        ddlUSerType.Items.Insert(0, new ListItem("حدد نوع المستخدم", "0"));

        ResultList<Lookup_ServiceUserTypeEntity> Result = new ResultList<Lookup_ServiceUserTypeEntity>();
        Result = await Lookup_ServiceUserTypeDomain.GetAll();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Lookup_ServiceUserTypeEntity item in Result.List)
            {
                ddlUSerType.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));

            }
        }

    }


    protected async void FillNAtionality()
    {
        ddlNAtionality.Items.Insert(0, new ListItem("الجنسية", "0"));
       // ddlNAtionalityUser2.Items.Insert(0, new ListItem("الجنسية", "0"));
        ResultList<Lookup_NationalityEntity> Result = new ResultList<Lookup_NationalityEntity>();
        Result = await Lookup_NationalityDomain.GetAll();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Lookup_NationalityEntity item in Result.List)
            {
                ddlNAtionality.Items.Add(new ListItem(item.Name.ToString(), item.NationalityID.ToString()));
              //  ddlNAtionalityUser2.Items.Add(new ListItem(item.Name.ToString(), item.NationalityID.ToString()));
            }
        }

    }

    protected async void FillClassification()
    {
        ddlCompanyClassification.Items.Insert(0, new ListItem("الرجاء اختيار تصنيف الشركة", "0"));

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


    protected async void FillIDType()
    {
        //ddlIDType.Items.Insert(0, new ListItem("حدد نوع الهوية", "0"));
        //ResultList<Lookup_IdentityTypeEntity> Result = new ResultList<Lookup_IdentityTypeEntity>();
        //Result = await Lookup_IdentityTypeDomain.GetAllIdentity();

        //if (Result.Status == ErrorEnums.Success)
        //{
        //    foreach (Lookup_IdentityTypeEntity item in Result.List)
        //    {
        //        ddlIDType.Items.Add(new ListItem(item.IDType.ToString(), item.ID.ToString()));

        //    }
        //}



        if (ddlNAtionality.SelectedValue.ToString() == "1")
        {
            ddlIDType.Items.Clear();
            ddlIDType.Items.Insert(0, new ListItem("حدد نوع الوثيقة", "0"));
            ResultList<Lookup_IdentityTypeEntity> Result = new ResultList<Lookup_IdentityTypeEntity>();
            Result = Lookup_IdentityTypeDomain.GetAllNotAsyncIdentity();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_IdentityTypeEntity item in Result.List)
                {
                    ddlIDType.Items.Add(new ListItem(item.IDType.ToString(), item.ID.ToString()));
                }
            }
        }
        else
        {
            ddlIDType.Items.Clear();
            ddlIDType.Items.Insert(0, new ListItem("حدد نوع الهوية", "0"));
            ResultList<Lookup_IdentityTypeEntity> Result = new ResultList<Lookup_IdentityTypeEntity>();
            Result = Lookup_IdentityTypeDomain.GetAllNotAsyncIdentity();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_IdentityTypeEntity item in Result.List)
                {
                    ddlIDType.Items.Add(new ListItem(item.IDType.ToString(), item.ID.ToString()));
                }
                //ddlTypeDocument.Items.RemoveAt()

                ddlIDType.Items.FindByValue("1").Enabled = false;
            }
        }


    }

    protected async void FillCountry()
    {
        ddlCountry.Items.Insert(0, new ListItem("حدد الدولة", "0"));

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
        //ddlCity.Items.Insert(0, new ListItem("اختر مدينة", "0"));

        //ResultList<Lookup_CityEntity> Result = new ResultList<Lookup_CityEntity>();
        //Result = await Lookup_CityDomain.GetLookupCityAll();

        //if (Result.Status == ErrorEnums.Success)
        //{
        //    foreach (Lookup_CityEntity item in Result.List)
        //    {
        //        ddlCity.Items.Add(new ListItem(item.CityName.ToString(), item.CityID.ToString()));
        //    }
        //}

    }

    protected async void FillArea()
    {
        //ddlArea1.Items.Insert(0, new ListItem("حدد المنطقة 1", "0"));
        //ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));

        //ResultList<Lookup_AreaEntity> Result = new ResultList<Lookup_AreaEntity>();
        //Result = await Lookup_AreaDomain.GetLookupAreaAll();

        //if (Result.Status == ErrorEnums.Success)
        //{
        //    foreach (Lookup_AreaEntity item in Result.List)
        //    {
        //        ddlArea1.Items.Add(new ListItem(item.AreaName.ToString(), item.AreaID.ToString()));
        //        ddlArea2.Items.Add(new ListItem(item.AreaName.ToString(), item.AreaID.ToString()));

        //    }
        //}

    }





    protected async void btnSubmit_Click(object sender, EventArgs e)
    {

        //    //---******* (For Local) ******-------------------------
        //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

        //    //---------------******* (For Live) ******-------------------------
        string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());




        string guid = Guid.NewGuid().ToString().Substring(0, 6);


        if (ddlUSerType.SelectedValue == "1")
        {
            Plugin_ServiceUserEntity entity = new Plugin_ServiceUserEntity();
            entity.FirstName = txtFirstName.Text;
            entity.SecondName = txtSecondName.Text;
            entity.ThirdName = txtThirdName.Text;
            entity.FamilyName = txtFamilyName.Text;
            entity.UserID = string.Empty; //txtUserId.Text;
            entity.UserType = ddlUSerType.SelectedValue;
            entity.IDType = Convert.ToInt32(ddlIDType.SelectedValue);
            entity.IDNumber = txtIDNumber.Text;
            entity.MobileNumber = "+962" + txtMobileNo.Text;
            entity.TelephoneNumber = txtTelePhoneNo.Text;
            entity.Email = txtEmail.Text;
            string pass = txtPassword.Text;
            string pass2 = txtConformPass.Text;
            entity.Password = txtPassword.Text;
            entity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            entity.City = Convert.ToInt32(ddlCity.SelectedValue);
            entity.Area1 = Convert.ToInt32(ddlArea1.SelectedValue);
            //entity.Area2 = Convert.ToInt32(ddlArea2.SelectedValue);
            entity.Address = txtAddress.Text;
            entity.Latitude = string.Empty; //txtLatitude.Text;
            entity.Longitude = string.Empty; //txtLongitude.Text;
            entity.IsDeleted = false;
            entity.Order = 0;
            entity.IsPublished = true;
            entity.PublishDate = DateTime.Now;
            entity.LanguageID = 2;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = "9";
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = "9";
            entity.NationalityID = Convert.ToInt32(ddlNAtionality.SelectedValue);

            var Result = await Plugin_ServiceUserDomain.Insert(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                string dyna_otp = Generatenumber();
                MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();
                MemberOTPEntity.ServiceUserID = Result.Entity.ID;
                MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                MemberOTPEntity.OTP = dyna_otp;
                MemberOTPEntity.IsVerify = false;
                MemberOTPEntity.AddDate = DateTime.Now;
                MemberOTPEntity.VerifyDate = DateTime.Now;
                var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                mpeInquiry.Show();
            }

        }
        else
        {
            Plugin_ServiceUserEntity entity = new Plugin_ServiceUserEntity();
            entity.FirstName = txtCompanyName.Text;
            entity.SecondName = "";
            entity.ThirdName = "";
            entity.FamilyName = "";
            entity.UserID = string.Empty; //txtUserId.Text;
            entity.UserType = ddlUSerType.SelectedValue;
            entity.IDType = 0;// Convert.ToInt32(ddlIDType.SelectedValue);
            entity.IDNumber = string.Empty; // txtIDNumber.Text;
            entity.MobileNumber = "+962" + txtMobileUser2.Text;
            entity.TelephoneNumber = txtTelePhoneUser2.Text;
            entity.Email = txtEmailUSer2.Text;
            string pass = txtPasswordUser2.Text;
            string pass2 = txtConformPassUser2.Text;
            entity.Password = txtPasswordUser2.Text;
            entity.Country = 0; //Convert.ToInt32(ddlCountry.SelectedValue);
            entity.City = 0; // Convert.ToInt32(ddlCity.SelectedValue);
            entity.Area1 = 0; // Convert.ToInt32(ddlArea1.SelectedValue);
            //entity.Area2 = Convert.ToInt32(ddlArea2.SelectedValue);
            entity.Address = string.Empty;// txtAddress.Text;
            entity.Latitude = string.Empty; //txtLatitude.Text;
            entity.Longitude = string.Empty; //txtLongitude.Text;
            entity.IsDeleted = false;
            entity.Order = 0;
            entity.IsPublished = true;
            entity.PublishDate = DateTime.Now;
            entity.LanguageID = 2;
            entity.AddDate = Convert.ToDateTime(DateTime.Now);
            entity.AddUser = "9";
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = "9";
            entity.NationalityID = 0; //Convert.ToInt32(ddlNAtionality.SelectedValue);

            var Result =  Plugin_ServiceUserDomain.InsertNotAsync(entity);
            if (Result.Status == ErrorEnums.Success)
            {

                Plugin_RenwabaleEnergyCompanyEntity RenwabaleEnergyCompany = new Plugin_RenwabaleEnergyCompanyEntity();
                
                RenwabaleEnergyCompany.ServiceUserID = Result.Entity.ID;
                RenwabaleEnergyCompany.CompanyName = txtCompanyName.Text;
                RenwabaleEnergyCompany.CompanyNationalID = txtNAtionalityUser2.Text; // Convert.ToInt32(ddlNAtionalityUser2.SelectedValue);
                RenwabaleEnergyCompany.CompanyClassificationID = Convert.ToInt32(ddlCompanyClassification.SelectedValue);
                RenwabaleEnergyCompany.Password = txtPasswordUser2.Text;
                RenwabaleEnergyCompany.MobileNumber = txtMobileUser2.Text;
                RenwabaleEnergyCompany.TelephoneNumber = txtTelePhoneUser2.Text;
                RenwabaleEnergyCompany.FaxNumber = txtFaxUSer2.Text;
                RenwabaleEnergyCompany.EmailAddress = txtEmailUSer2.Text;
                RenwabaleEnergyCompany.Website = txtWebsiteUser2.Text;
                RenwabaleEnergyCompany.Governate = Convert.ToInt32(Request.Form["ddlGeove"]);
                RenwabaleEnergyCompany.Area = Convert.ToInt32(Request.Form["ddlAreas"]);
                RenwabaleEnergyCompany.Area2 = Convert.ToInt32(Request.Form["ddlAreas2"]);
                RenwabaleEnergyCompany.StreetID = Convert.ToInt32(Request.Form["ddlsteet"]);
                RenwabaleEnergyCompany.Address = txtAdressUSer2.Text;



                RenwabaleEnergyCompany.Order = 1;
                RenwabaleEnergyCompany.LanguageID = 2;
                RenwabaleEnergyCompany.QualificationExpiryDate = DateTime.ParseExact(txtQualificationDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                RenwabaleEnergyCompany.IsMobileVerfied = false;
                RenwabaleEnergyCompany.ISEmailVerfied = false;
                RenwabaleEnergyCompany.PublishDate = DateTime.Now;
                RenwabaleEnergyCompany.IsPublished = false;
                RenwabaleEnergyCompany.IsDeleted = false;
                RenwabaleEnergyCompany.AddDate = DateTime.Now;
                RenwabaleEnergyCompany.AddUser = "9";
                RenwabaleEnergyCompany.EditDate = DateTime.Now;
                RenwabaleEnergyCompany.EditUser = "9";

                try
                {
                    //Here string ABCd is Entity of Table

                    HttpPostedFile files1 = Request.Files["fileuploadfield_1"];
                    if (files1 != null)
                    {

                        if (files1.FileName != "") // If file is Selected File
                        {

                            string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                            //Entity.ChildPassport = dir + files1.FileName;
                            
                            RenwabaleEnergyCompany.CompanyRegistrationDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files1.FileName;
                            //Insert ABCd to Entity
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }

                            files1.SaveAs(dir + files1.FileName);

                        }
                        else
                        {
                            RenwabaleEnergyCompany.CompanyRegistrationDocument = string.Empty;
                        }
                    }
                    else
                    {
                        RenwabaleEnergyCompany.CompanyRegistrationDocument = string.Empty;
                    }
                }
                catch (Exception exp)
                {
                    Console.Write("<script>console.log('fileuploadfield_1 :" + exp.Message + "');</script>");
                }

                try
                {
                    //Here string ABCd is Entity of Table

                    HttpPostedFile files2 = Request.Files["fileuploadfield_2"];
                    if (files2 != null)
                    {
                        if (files2.FileName != "") // If file is Selected File
                        {
                            string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                            RenwabaleEnergyCompany.QualificationDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files2.FileName;
                            //Insert ABCd to Entity
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }
                            files2.SaveAs(dir + files2.FileName);
                        }
                        else
                        {
                            RenwabaleEnergyCompany.QualificationDocument = string.Empty;
                        }
                    }
                    else
                    {
                        RenwabaleEnergyCompany.QualificationDocument = string.Empty;
                    }
                }
                catch (Exception exp)
                {
                    Console.Write("<script>console.log('fileuploadfield_2 :" + exp.Message + "');</script>");
                }

                var RenwabaleEnergyResult  = await Plugin_RenwabaleEnergyCompanyDomain.InsertRecord(RenwabaleEnergyCompany);


                string dyna_otp = Generatenumber();
                MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();
                MemberOTPEntity.ServiceUserID = Result.Entity.ID;
                MemberOTPEntity.MobileNumber = Result.Entity.MobileNumber;
                MemberOTPEntity.OTP = dyna_otp;
                MemberOTPEntity.IsVerify = false;
                MemberOTPEntity.AddDate = DateTime.Now;
                MemberOTPEntity.VerifyDate = DateTime.Now;
                var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);



                #region admission mail
                ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
                SettingResult = SettingDomain.GetSettingAllWithoutAsync();

                if (SettingResult.Status == ErrorEnums.Success)
                {
                    string UserName = SettingResult.List[0].Email;
                    string _fromMail = SettingResult.List[0].FromMail;
                    string _Password = SettingResult.List[0].PasswordEmail;
                    string _HOST = SettingResult.List[0].SMTPServer;
                    int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
                    string _subject = "New Registration";
                    string _toMail1 = ConfigurationManager.AppSettings["ToMailCompanyApprovals"].ToString();
                    string _toMail2 = txtEmailUSer2.Text;
                    
                    bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                    string _ccMail = ConfigurationManager.AppSettings["CCMAilCompanyApprovals1"].ToString();

                    string bodyContent = SettingResult.List[0].RenewableRegistrationAdminMail;
                    bodyContent = bodyContent.Replace("{Name}", txtCompanyName.Text);
                    bodyContent = bodyContent.Replace("{FormDetails}", "");
                    string _Body = bodyContent;

                    //string _BodyForAdmin = "<h1>New Admission Details</h1>" +
                    //              "<p>Student Name : " + txtName.Text + "</p>" +
                    //               "<p>Father Name : " + txtFFirstName.Text + "</p>" +
                    //               "<p>Mother Name : " + txtMFirstName.Text + "</p>" +
                    //              "<p>Date : " + txtDate.Value.ToString() + "</p>";

                    string bodyContent2 = SettingResult.List[0].RenewableRegistrationUserMail;
                    bodyContent2 = bodyContent2.Replace("{Name}", txtCompanyName.Text);
                    bodyContent2 = bodyContent2.Replace("{FormDetails}", "");
                    string _Body2 = bodyContent2;

                    try
                    {

                        SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                        SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);

                    }
                    catch { }

                }
                #endregion




                lblInquiryMessage.Text = "تم تسجيل معلومات شركتكم بنجاح. سيقوم فريقنا بمراجعة البيانات واعلامكم في أقرب وقت.";
                mpeInquiry.Show();
            }


        }

    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/LoginPage/Login.aspx", false);
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/LoginPage/Login.aspx", false);
    }

    protected async void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        int counrtyid = Convert.ToInt32(ddlCountry.SelectedValue);
        ddlCity.Items.Clear();
        ddlArea1.Items.Clear();
        //ddlArea2.Items.Clear();
        ddlCity.Items.Insert(0, new ListItem("اختر مدينة", "0"));
        ddlArea1.Items.Insert(0, new ListItem("حدد المنطقة 1", "0"));
        //ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));


        ResultList<Lookup_CityEntity> Result = new ResultList<Lookup_CityEntity>();
        Result = await Lookup_CityDomain.GetLookupCityAll();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Lookup_CityEntity item in Result.List.Where(s => s.CountryID == counrtyid))
            {
                ddlCity.Items.Add(new ListItem(item.CityName.ToString(), item.CityID.ToString()));
            }
        }
    }

    protected async void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CityID = Convert.ToInt32(ddlCity.SelectedValue);
        ddlArea1.Items.Clear();
        //ddlArea2.Items.Clear();
        ddlArea1.Items.Insert(0, new ListItem("حدد المنطقة 1", "0"));
        //ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));

        //ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));

        ResultList<Lookup_AreaOneEntity> Result = new ResultList<Lookup_AreaOneEntity>();
        Result = await Lookup_AreaOneDomain.GetAll();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Lookup_AreaOneEntity item in Result.List.Where(s => s.CityId == CityID))
            {
                ddlArea1.Items.Add(new ListItem(item.AreaOneName.ToString(), item.AreaOneID.ToString()));


            }
        }
    }

    protected async void ddlArea1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AreaID = Convert.ToInt32(ddlArea1.SelectedValue);
        // ddlArea2.Items.Clear();
        // ddlArea2.Items.Insert(0, new ListItem("حدد المنطقة 2", "0"));

        ResultList<Lookup_AreaTwoEntity> Result = new ResultList<Lookup_AreaTwoEntity>();
        Result = await Lookup_AreaTwoDomain.GetAll();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Lookup_AreaTwoEntity item in Result.List.Where(s => s.AreaOneId == AreaID))
            {
                // ddlArea2.Items.Add(new ListItem(item.AreaTwoName.ToString(), item.AreaTwoID.ToString()));


            }
        }

    }

    protected void FillAllUserIDs()
    {
        List<string> tempString = new List<string>();
        //tempString.Add("Hello");
        //tempString.Add("World");


        ResultList<Plugin_ServiceUserEntity> Result = new ResultList<Plugin_ServiceUserEntity>();
        Result = Plugin_ServiceUserDomain.GetAllNotAsync();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Plugin_ServiceUserEntity item in Result.List)
            {
                var thisid = item.Email;
                tempString.Add(thisid);
            }
        }




        StringBuilder sb = new StringBuilder();

        sb.Append("<script>");
        sb.Append("var testArray = new Array;");
        foreach (string str in tempString)
        {
            sb.Append("testArray.push('" + str + "');");
        }
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
    }




    protected void ddlNAtionality_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillIDType();
    }



    public static string Generatenumber()
    {
        var chars = "0123456789";
        var stringChars = new char[6];
        var random = new Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        var finalString = new String(stringChars);
        return finalString;
    }

    protected void FillAllUserMobiles()
    {
        List<string> tempString = new List<string>();
        //tempString.Add("Hello");
        //tempString.Add("World");


        ResultList<Plugin_ServiceUserEntity> Result = new ResultList<Plugin_ServiceUserEntity>();
        Result = Plugin_ServiceUserDomain.GetAllNotAsync();

        if (Result.Status == ErrorEnums.Success)
        {
            foreach (Plugin_ServiceUserEntity item in Result.List)
            {
                var thisid = item.MobileNumber;
                tempString.Add(thisid);
            }
        }




        StringBuilder sb = new StringBuilder();

        sb.Append("<script>");
        sb.Append("var testArrayMobiles = new Array;");
        foreach (string str in tempString)
        {
            sb.Append("testArrayMobiles.push('" + str + "');");
        }
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "testArrayMobilesScript", sb.ToString());
    }

    public void SendMail2(string UserName, string toMail, string fromMail, string ccmail, string Body, string Subject, string Password, string HOST, int Port, bool ssl)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            if (HOST == "")
            {
                HOST = "smtp.office365.com";
            }
            if (string.IsNullOrEmpty(fromMail))
            {
                fromMail = "info3@aura-techs.com";
            }


            SmtpClient SmtpServer = new SmtpClient(HOST);
            mailMessage.From = new MailAddress(fromMail);



            if (toMail == "")
            {
                mailMessage.To.Add("info3@aura-techs.com");
            }
            else
            {
                mailMessage.To.Add(toMail);
            }

            foreach (string sCC in ccmail.Split(",".ToCharArray()))
                mailMessage.CC.Add(sCC);

            if (Subject == "")
            {
                mailMessage.Subject = "testc";
            }
            else
            {
                mailMessage.Subject = Subject;
            }
            if (Body == "")
            {
                mailMessage.Body = "test";
            }
            else
            {
                mailMessage.Body = Body;
            }

            mailMessage.IsBodyHtml = true;


            SmtpServer.Port = Port;
            SmtpServer.EnableSsl = ssl;
            SmtpServer.UseDefaultCredentials = false;

            SmtpServer.Credentials = new System.Net.NetworkCredential(UserName, Password);

            try
            {
                SmtpServer.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}