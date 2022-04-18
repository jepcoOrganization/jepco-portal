using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Configuration;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using System.IO;
//using System.Data.SQLite.dll;
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

public partial class Controls_JobApplication : System.Web.UI.UserControl
{
    DateTime currentDate = DateTime.Now;
    DataPager pager1;
    string lang = string.Empty;
    int newsCount = 1;
    int Certificatecount = 1;
    int addmoreCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //CaptchaErrorLabel.text = "incorrect captcha code!";
            //CaptchaErrorLabel.visible = false;

            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }
            FillJobType();
           // FillJobName();
            FillQualifacation();
            FillMAritStatus();
            FillLicenceType();
            FillYearofLicence();
            FillProvenance();
            FillArea();
            FillTwoArea();
            FillCapctha();

        }
    }

    protected void FillJobType()
    {
        try
        {

            ddlJobType.Items.Insert(0, new ListItem("الرجاء اختيار نوع الوظيفة", "0"));

            ResultList<Lookup_JobTypeEntity> Result = new ResultList<Lookup_JobTypeEntity>();
            Result = Lookup_JobTypeDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_JobTypeEntity item in Result.List)
                {
                    ddlJobType.Items.Add(new ListItem(item.JobTypeName.ToString(), item.JobTypeID.ToString()));
                }
            }
        }
        catch { }

    }

    protected void FillJobName()
    {
        try
        {

            ddlJobName.Items.Insert(0, new ListItem("الرجاء اختيار اسم الوظيفة", "0"));

            ResultList<Lookup_JobNameEntity> Result = new ResultList<Lookup_JobNameEntity>();
            Result = Lookup_JobNameDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_JobNameEntity item in Result.List)
                {
                    ddlJobName.Items.Add(new ListItem(item.JobName.ToString(), item.JobNameID.ToString()));
                }
            }
        }
        catch { }

    }
    protected void FillQualifacation()
    {
        try
        {

            ddlQualification.Items.Insert(0, new ListItem(" الرجاء اختيار المؤهل العلمي ", "0"));

            ResultList<Lookup_QualificationEntity> Result = new ResultList<Lookup_QualificationEntity>();
            Result = Lookup_QualificationDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_QualificationEntity item in Result.List)
                {
                    ddlQualification.Items.Add(new ListItem(item.QualificationName.ToString(), item.QualificationID.ToString()));
                }
            }
        }
        catch { }

    }
    protected void FillMAritStatus()
    {
        //try
        //{

        //    ddlMaritalStatus.Items.Insert(0, new ListItem("Select Qualification", "0"));

        //    ResultList<Lookup_Mari> Result = new ResultList<Lookup_QualificationEntity>();
        //    Result = Lookup_QualificationDomain.GetAllNotAsync();

        //    if (Result.Status == ErrorEnums.Success)
        //    {
        //        foreach (Lookup_QualificationEntity item in Result.List)
        //        {
        //            ddlMaritalStatus.Items.Add(new ListItem(item.QualificationName.ToString(), item.QualificationID.ToString()));
        //        }
        //    }
        //}
        //catch { }

    }

    protected void FillLicenceType()
    {
        try
        {

            ddlLisenceType.Items.Insert(0, new ListItem("الرجاء اختيار فئة الرخصة", "0"));

            ResultList<Lookup_LicenceTypeEntity> Result = new ResultList<Lookup_LicenceTypeEntity>();
            Result = Lookup_LicenceTypeDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_LicenceTypeEntity item in Result.List)
                {
                    ddlLisenceType.Items.Add(new ListItem(item.LicenceTypeName.ToString(), item.LicenceTypeID.ToString()));
                }
            }
        }
        catch { }

    }
    protected void FillYearofLicence()
    {
        //try
        //{

        //    ddlYearofLisence.Items.Insert(0, new ListItem("الرجاء اختيار فئة الرخصة", "0"));

        //    ResultList<Lookup_LicenceYearEntity> Result = new ResultList<Lookup_LicenceYearEntity>();
        //    Result = Lookup_LicenceYear_Domain.GetAllNotAsync();

        //    if (Result.Status == ErrorEnums.Success)
        //    {
        //        foreach (Lookup_LicenceYearEntity item in Result.List)
        //        {
        //            ddlYearofLisence.Items.Add(new ListItem(item.LicenceYearName.ToString(), item.LicenceYearID.ToString()));
        //        }
        //    }
        //}
        //catch { }

    }

    protected void FillProvenance()
    {
        try
        {

            ddlProvenance.Items.Insert(0, new ListItem("الرجاء اختيار المحافظة", "0"));

            ResultList<Lookup_ProvenanceEntity> Result = new ResultList<Lookup_ProvenanceEntity>();
            Result = Lookup_ProvenanceDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_ProvenanceEntity item in Result.List)
                {
                    ddlProvenance.Items.Add(new ListItem(item.ProvenanceName.ToString(), item.ProvenanceID.ToString()));
                }
            }
        }
        catch { }

    }

    protected void FillArea()
    {
        try
        {

            ddlArea.Items.Insert(0, new ListItem("الرجاء اختيار المنطقة ", "0"));

            ResultList<Lookup_AreaOneEntity> Result = new ResultList<Lookup_AreaOneEntity>();
            Result = Lookup_AreaOneDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_AreaOneEntity item in Result.List)
                {
                    ddlArea.Items.Add(new ListItem(item.AreaOneName.ToString(), item.AreaOneID.ToString()));
                }
            }
        }
        catch { }

    }

    protected void FillTwoArea()
    {
        try
        {

            ddlArea2.Items.Insert(0, new ListItem("الرجاء اختيار الحي", "0"));

            ResultList<Lookup_AreaTwoEntity> Result = new ResultList<Lookup_AreaTwoEntity>();
            Result = Lookup_AreaTwoDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_AreaTwoEntity item in Result.List)
                {
                    ddlArea2.Items.Add(new ListItem(item.AreaTwoName.ToString(), item.AreaTwoID.ToString()));
                }
            }
        }
        catch { }

    }

    void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();

            CaptchCodeSession.Value = captcha.ToString();

            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        //    //---******* (For Local) ******-------------------------
       // string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

        //    //---------------******* (For Live) ******-------------------------
        string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

        if (Session["captcha"].ToString() != txtCaptcha.Text)
        {
            CaptchaErrorLabel.Text = "Invalid Captcha Code";

            CaptchaErrorLabel.Visible = true;
            FillCapctha();
        }
        else
        {
            #region Insert All
            string guid = Guid.NewGuid().ToString().Substring(0, 6);
            #region Insert JobApplication


            Plugin_JobApplicationEntity Entity = new Plugin_JobApplicationEntity();

            Entity.JobType = Convert.ToByte(ddlJobType.SelectedValue);
            Entity.JobName = Convert.ToByte(ddlJobName.SelectedValue);
            Entity.FirstName = txtfirstName.Text;
            Entity.SecondName = txtSecondName.Text;
            Entity.ThirdName = txtThirdName.Text;
            Entity.LastName = txtLastName.Text;
            Entity.Nationalid = txtNationalID.Text;
           
            Entity.BirthDate = DateTime.ParseExact(txtDateOfBirth.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Entity.MaritalState = Convert.ToByte(ddlMaritalStatus.SelectedValue);
            Entity.NoofChild = txtNumberofChild.Text;
            Entity.HaveLicence = rblLisence.SelectedItem.Text;
            Entity.LicenceType = Convert.ToByte(ddlLisenceType.SelectedValue);
            if (rblLisence.SelectedValue == "True")
            {
                DateTime dateofLicence = DateTime.ParseExact(txtLicenceYear.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                int Licenceyear = dateofLicence.Year;
                Entity.YearOfLicence = Licenceyear; //Convert.ToByte(ddlYearofLisence.SelectedValue);
            }
            else
            {
                Entity.YearOfLicence = 0;
            }
            
            Entity.Qualification = Convert.ToByte(ddlQualification.SelectedValue);
            Entity.Order = 0;
            Entity.LanguageID = 2;
            Entity.PublishDate = DateTime.Now;
            Entity.IsPublished = true;
            Entity.IsDeleted = false;
            Entity.AddDate = DateTime.Now;
            Entity.AddUser = "9";
            Entity.EditDate = DateTime.Now;
            Entity.EditUser = "9";
            //Entity.JobApplicationID


            var Result = Plugin_JobApplicationDomain.InsertNotAsync(Entity);
            if (Result.Status == ErrorEnums.Success)
            {
                long JobApplicationID = Result.Entity.JobApplicationID;

                #region Insert Qualification
                int QuliType = Convert.ToByte(ddlQualification.SelectedValue);
                Plugin_QualificationEntity QualificationEntity = new Plugin_QualificationEntity();
                if (QuliType == 7)
                {

                    QualificationEntity.JobApplicationID = JobApplicationID;
                    QualificationEntity.UniName = string.Empty;
                    QualificationEntity.Name = string.Empty;
                    QualificationEntity.Year = txtYear4.Text;
                    QualificationEntity.Major = txtMajor4.Text;
                    QualificationEntity.Major_Two = txtMajor24.Text;
                    QualificationEntity.Major_From = txtMajorFrom.Text;
                    QualificationEntity.AVG = string.Empty;
                    QualificationEntity.OverAllEval = string.Empty;
                    QualificationEntity.Order = 0;
                    QualificationEntity.LanguageID = 2;
                    QualificationEntity.PublishDate = DateTime.Now;
                    QualificationEntity.IsPublished = true;
                    QualificationEntity.IsDeleted = false;
                    QualificationEntity.AddDate = DateTime.Now;
                    QualificationEntity.AddUser = "9";
                    QualificationEntity.EditDate = DateTime.Now;
                    QualificationEntity.EditUser = "9";

                    //QualificationEntity.QualificationID = 
                }
                else if (QuliType == 4)
                {
                    //Plugin_QualificationEntity QualificationEntity = new Plugin_QualificationEntity();
                    QualificationEntity.JobApplicationID = JobApplicationID;
                    QualificationEntity.UniName = string.Empty;
                    QualificationEntity.Name = txtUniName2.Text;
                    QualificationEntity.Year = DateTime.ParseExact(ddlYear2.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).Year.ToString(); 
                    QualificationEntity.Major = txtMajor2.Text;
                    QualificationEntity.Major_Two = string.Empty;
                    QualificationEntity.Major_From = string.Empty;
                    QualificationEntity.AVG = txtAverage2.Text;
                    QualificationEntity.OverAllEval = string.Empty;
                    QualificationEntity.Order = 0;
                    QualificationEntity.LanguageID = 2;
                    QualificationEntity.PublishDate = DateTime.Now;
                    QualificationEntity.IsPublished = true;
                    QualificationEntity.IsDeleted = false;
                    QualificationEntity.AddDate = DateTime.Now;
                    QualificationEntity.AddUser = "9";
                    QualificationEntity.EditDate = DateTime.Now;
                    QualificationEntity.EditUser = "9";
                }
                else if (QuliType == 5)
                {
                    //Plugin_QualificationEntity QualificationEntity = new Plugin_QualificationEntity();
                    QualificationEntity.JobApplicationID = JobApplicationID;
                    QualificationEntity.UniName = string.Empty;
                    QualificationEntity.Name = string.Empty;
                    QualificationEntity.Year = txtYear3.Text;
                    QualificationEntity.Major = txtMajor3.Text;
                    QualificationEntity.Major_Two = string.Empty;
                    QualificationEntity.Major_From = string.Empty;
                    QualificationEntity.AVG = txtAverage3.Text;
                    QualificationEntity.OverAllEval = string.Empty;
                    QualificationEntity.Order = 0;
                    QualificationEntity.LanguageID = 2;
                    QualificationEntity.PublishDate = DateTime.Now;
                    QualificationEntity.IsPublished = true;
                    QualificationEntity.IsDeleted = false;
                    QualificationEntity.AddDate = DateTime.Now;
                    QualificationEntity.AddUser = "9";
                    QualificationEntity.EditDate = DateTime.Now;
                    QualificationEntity.EditUser = "9";
                }
                else
                {

                    //Plugin_QualificationEntity QualificationEntity = new Plugin_QualificationEntity();
                    QualificationEntity.JobApplicationID = JobApplicationID;
                    QualificationEntity.UniName = txtUniName.Text;
                    QualificationEntity.Name = string.Empty;
                    
                    QualificationEntity.Year = DateTime.ParseExact(ddlPassingYear.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).Year.ToString(); 
                    QualificationEntity.Major = txtMajor.Text;
                    QualificationEntity.Major_Two = string.Empty;
                    QualificationEntity.Major_From = string.Empty;
                    QualificationEntity.AVG = txtAverage.Text;
                    QualificationEntity.OverAllEval = txtOverallEval.Text;
                    QualificationEntity.Order = 0;
                    QualificationEntity.LanguageID = 2;
                    QualificationEntity.PublishDate = DateTime.Now;
                    QualificationEntity.IsPublished = true;
                    QualificationEntity.IsDeleted = false;
                    QualificationEntity.AddDate = DateTime.Now;
                    QualificationEntity.AddUser = "9";
                    QualificationEntity.AddUser = "9";
                    QualificationEntity.EditDate = DateTime.Now;
                    QualificationEntity.EditUser = "9";
                }

                var QualificationResult = Plugin_QualificationDomain.InsertNotAsync(QualificationEntity);
                if (QualificationResult.Status == ErrorEnums.Success)
                { }
                #endregion

                #region Insert PreviuesExperiance 



                string EntityNameName = "";
                string ExperianceType = "";
                string NumberOfYear = "";

                if (!string.IsNullOrEmpty(hdWorkExpCount.Value))
                {
                    Certificatecount = Convert.ToInt32(hdWorkExpCount.Value);
                }
                if (Certificatecount >= 2)
                {

                    for (int i = 0; i < Certificatecount; i++)
                    {
                        try
                        {
                            if (i == 0)
                            {
                            }
                            else if (i == 1)
                            {
                                //Response.Write("<script>console.log('Status:txtSiblingName_1')</script>");
                                EntityNameName = Request.Form.Get("txtEntityName_" + i);
                                //Response.Write("<script>console.log('txtSiblingName_1:" + SiblingName.ToString() + "')</script>");

                                //Response.Write("<script>console.log('Status:ddlsiblingYear_1')</script>");
                                ExperianceType = Request.Form.Get("txtExperienceType_" + i);
                                //Response.Write("<script>console.log('ddlsiblingYear_1:" + ddlsiblingYear.ToString() + "')</script>");

                                //Response.Write("<script>console.log('Status:txtAge_1')</script>");
                                NumberOfYear = Request.Form.Get("txtNumberofYears_" + i);
                                //Response.Write("<script>console.log('txtAge_1:" + txtAge.ToString() + "')</script>");

                                Plugin_PreviuesExperianceEntity PreviuesExperianceEntity = new Plugin_PreviuesExperianceEntity();
                                PreviuesExperianceEntity.JobApplicationID = JobApplicationID;
                                PreviuesExperianceEntity.EntityName = EntityNameName;
                                PreviuesExperianceEntity.ExperianceType = ExperianceType;
                                PreviuesExperianceEntity.NumberOfYear = NumberOfYear;
                                PreviuesExperianceEntity.Order = 0;
                                PreviuesExperianceEntity.LanguageID = 2;
                                PreviuesExperianceEntity.PublishDate = DateTime.Now;
                                PreviuesExperianceEntity.IsPublished = true;
                                PreviuesExperianceEntity.IsDeleted = false;
                                PreviuesExperianceEntity.AddDate = DateTime.Now;
                                PreviuesExperianceEntity.AddUser = "9";
                                PreviuesExperianceEntity.EditDate = DateTime.Now;
                                PreviuesExperianceEntity.EditUser = "9";
                                var ExperianceEntity1Result = Plugin_PreviuesExperianceDomain.InsertNotAsync(PreviuesExperianceEntity);

                            }
                            else
                            {
                                EntityNameName = Request.Form.Get("txtEntityName_" + i);
                                ExperianceType = Request.Form.Get("txtExperienceType_" + i);
                                NumberOfYear = Request.Form.Get("txtNumberofYears_" + i);

                                Plugin_PreviuesExperianceEntity PreviuesExperianceEntity = new Plugin_PreviuesExperianceEntity();
                                PreviuesExperianceEntity.JobApplicationID = JobApplicationID;
                                PreviuesExperianceEntity.EntityName = EntityNameName;
                                PreviuesExperianceEntity.ExperianceType = ExperianceType;
                                PreviuesExperianceEntity.NumberOfYear = NumberOfYear;
                                PreviuesExperianceEntity.Order = 0;
                                PreviuesExperianceEntity.LanguageID = 2;
                                PreviuesExperianceEntity.PublishDate = DateTime.Now;
                                PreviuesExperianceEntity.IsPublished = true;
                                PreviuesExperianceEntity.IsDeleted = false;
                                PreviuesExperianceEntity.AddDate = DateTime.Now;
                                PreviuesExperianceEntity.AddUser = "9";
                                PreviuesExperianceEntity.EditDate = DateTime.Now;
                                PreviuesExperianceEntity.EditUser = "9";
                                var ExperianceEntity1Result = Plugin_PreviuesExperianceDomain.InsertNotAsync(PreviuesExperianceEntity);

                            }

                        }
                        catch { }



                    }
                }
                else
                {

                    EntityNameName = Request.Form.Get("txtEntityName_1");
                    ExperianceType = Request.Form.Get("txtExperienceType_1");
                    NumberOfYear = Request.Form.Get("txtNumberofYears_1");

                    Plugin_PreviuesExperianceEntity PreviuesExperianceEntity = new Plugin_PreviuesExperianceEntity();
                    PreviuesExperianceEntity.JobApplicationID = JobApplicationID;
                    PreviuesExperianceEntity.EntityName = EntityNameName;
                    PreviuesExperianceEntity.ExperianceType = ExperianceType;
                    PreviuesExperianceEntity.NumberOfYear = NumberOfYear;
                    PreviuesExperianceEntity.Order = 0;
                    PreviuesExperianceEntity.LanguageID = 2;
                    PreviuesExperianceEntity.PublishDate = DateTime.Now;
                    PreviuesExperianceEntity.IsPublished = true;
                    PreviuesExperianceEntity.IsDeleted = false;
                    PreviuesExperianceEntity.AddDate = DateTime.Now;
                    PreviuesExperianceEntity.AddUser = "9";
                    PreviuesExperianceEntity.EditDate = DateTime.Now;
                    PreviuesExperianceEntity.EditUser = "9";
                    var ExperianceEntity1Result = Plugin_PreviuesExperianceDomain.InsertNotAsync(PreviuesExperianceEntity);


                }

                #endregion

                #region Insert Training

                string CourceTypeST = "";
                string CourceNameST = "";
                string CourceDurationST = "";

                if (!string.IsNullOrEmpty(hdntrainigCourse.Value))
                {
                    Certificatecount = Convert.ToInt32(hdntrainigCourse.Value);
                }
                if (Certificatecount >= 2)
                {

                    for (int i = 0; i < Certificatecount; i++)
                    {
                        try
                        {
                            if (i == 0)
                            {
                            }
                            else if (i == 1)
                            {
                                //Response.Write("<script>console.log('Status:txtSiblingName_1')</script>");
                                CourceTypeST = Request.Form.Get("txtCourseType_" + i);
                                //Response.Write("<script>console.log('txtSiblingName_1:" + SiblingName.ToString() + "')</script>");

                                //Response.Write("<script>console.log('Status:ddlsiblingYear_1')</script>");
                                CourceNameST = Request.Form.Get("txtCourseName_" + i);
                                //Response.Write("<script>console.log('ddlsiblingYear_1:" + ddlsiblingYear.ToString() + "')</script>");

                                //Response.Write("<script>console.log('Status:txtAge_1')</script>");
                                CourceDurationST = Request.Form.Get("txtCourseDuration_" + i);
                                //Response.Write("<script>console.log('txtAge_1:" + txtAge.ToString() + "')</script>");
                                Plugin_CVTrainingEntity CVTrainingEntity = new Plugin_CVTrainingEntity();

                                CVTrainingEntity.JobApplicationID = JobApplicationID;
                                CVTrainingEntity.CourceType = CourceTypeST;
                                CVTrainingEntity.CourceName = CourceNameST;
                                CVTrainingEntity.CourceDuration = CourceDurationST;
                                CVTrainingEntity.Order = 0;
                                CVTrainingEntity.LanguageID = 2;
                                CVTrainingEntity.PublishDate = DateTime.Now;
                                CVTrainingEntity.IsPublished = true;
                                CVTrainingEntity.IsDeleted = false;
                                CVTrainingEntity.AddDate = DateTime.Now;
                                CVTrainingEntity.AddUser = "9";
                                CVTrainingEntity.EditDate = DateTime.Now;
                                CVTrainingEntity.EditUser = "9";
                                var ExperianceEntity1Result = Plugin_CVTrainingDomain.InsertNotAsync(CVTrainingEntity);
                            }
                            else
                            {
                                CourceTypeST = Request.Form.Get("txtCourseType_" + i);
                                CourceNameST = Request.Form.Get("txtCourseName_" + i);
                                CourceDurationST = Request.Form.Get("txtCourseDuration_" + i);

                                Plugin_CVTrainingEntity CVTrainingEntity = new Plugin_CVTrainingEntity();

                                CVTrainingEntity.JobApplicationID = JobApplicationID;
                                CVTrainingEntity.CourceType = CourceTypeST;
                                CVTrainingEntity.CourceName = CourceNameST;
                                CVTrainingEntity.CourceDuration = CourceDurationST;
                                CVTrainingEntity.Order = 0;
                                CVTrainingEntity.LanguageID = 2;
                                CVTrainingEntity.PublishDate = DateTime.Now;
                                CVTrainingEntity.IsPublished = true;
                                CVTrainingEntity.IsDeleted = false;
                                CVTrainingEntity.AddDate = DateTime.Now;
                                CVTrainingEntity.AddUser = "9";
                                CVTrainingEntity.EditDate = DateTime.Now;
                                CVTrainingEntity.EditUser = "9";
                                var ExperianceEntity1Result = Plugin_CVTrainingDomain.InsertNotAsync(CVTrainingEntity);
                            }

                        }
                        catch { }



                    }
                }
                else
                {
                    CourceTypeST = Request.Form.Get("txtCourseType_1");
                    CourceNameST = Request.Form.Get("txtCourseName_1");
                    CourceDurationST = Request.Form.Get("txtCourseDuration_1");


                    Plugin_CVTrainingEntity CVTrainingEntity = new Plugin_CVTrainingEntity();

                    CVTrainingEntity.JobApplicationID = JobApplicationID;
                    CVTrainingEntity.CourceType = CourceTypeST;
                    CVTrainingEntity.CourceName = CourceNameST;
                    CVTrainingEntity.CourceDuration = CourceDurationST;
                    CVTrainingEntity.Order = 0;
                    CVTrainingEntity.LanguageID = 2;
                    CVTrainingEntity.PublishDate = DateTime.Now;
                    CVTrainingEntity.IsPublished = true;
                    CVTrainingEntity.IsDeleted = false;
                    CVTrainingEntity.AddDate = DateTime.Now;
                    CVTrainingEntity.AddUser = "9";
                    CVTrainingEntity.EditDate = DateTime.Now;
                    CVTrainingEntity.EditUser = "9";
                    var ExperianceEntity1Result = Plugin_CVTrainingDomain.InsertNotAsync(CVTrainingEntity);


                }

                #endregion

                #region Insert Contact 
                Plugin_CVContactEntity ContactEntity = new Plugin_CVContactEntity();
                ContactEntity.JobApplicationID = JobApplicationID;
                ContactEntity.Provenance = Convert.ToByte(ddlProvenance.SelectedValue);
                ContactEntity.AreaOne = Convert.ToByte(ddlArea.SelectedValue);
                ContactEntity.AreaTwo = Convert.ToByte(ddlArea2.SelectedValue);
                ContactEntity.Street = txtStreet.Text;
                ContactEntity.Building = string.Empty;
                ContactEntity.BuildingNumber = txtBuildingNo.Text;
                ContactEntity.TeliphoneOne = txtTel1.Text;
                ContactEntity.TeliphoneTwo = txtTel2.Text;
                ContactEntity.Email = txtEmail.Text;
                // ContactEntity.Resume =
                ContactEntity.Order = 0;
                ContactEntity.LanguageID = 2;
                ContactEntity.PublishDate = DateTime.Now;
                ContactEntity.IsPublished = true;
                ContactEntity.IsDeleted = false;
                ContactEntity.AddDate = DateTime.Now;
                ContactEntity.AddUser = "9";
                ContactEntity.EditDate = DateTime.Now;
                ContactEntity.EditUser = "9";
                

                try
                {

                    HttpPostedFile files1 = Request.Files["fileuploadfield_1"];

                    if (files1 != null)
                    {

                        if (files1.FileName != "") // If file is Selected File
                        {

                            string dir = uploadPath1 + guid + txtfirstName.Text + "//";
                            //Entity.ChildPassport = dir + files1.FileName;
                            ContactEntity.Resume = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtfirstName.Text + "//" + files1.FileName;
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }

                            files1.SaveAs(dir + files1.FileName);

                        }
                        else
                        {
                            ContactEntity.Resume = string.Empty;
                        }
                    }
                    else
                    {
                        ContactEntity.Resume = string.Empty;
                    }

                }
                catch (Exception exp)
                {
                    Console.Write("<script>console.log('Child Details :" + exp.Message + "');</script>");
                }

                var ContactResult = Plugin_CVContactDomain.InsertNotAsync(ContactEntity);

                #endregion


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
                    string _subject = "Jepco Job Application";
                    string _toMail1 = txtEmail.Text;
                   // string _toMail2 = txtMEmail.Text;
                    string _toMail3 = ConfigurationManager.AppSettings["ToMail"].ToString();
                    bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                    string _ccMail = ConfigurationManager.AppSettings["CCMail1"].ToString() + "," + ConfigurationManager.AppSettings["CCMail2"].ToString() + "," + ConfigurationManager.AppSettings["CCMail3"].ToString();

                    string bodyContent = SettingResult.List[0].UserMailContent;
                    bodyContent = bodyContent.Replace("{Name}", txtfirstName.Text);
                    bodyContent = bodyContent.Replace("{FormDetails}", "");
                    string _Body = bodyContent;


                    string _BodyForAdmin = "<h1>New Job Details</h1>" +
                                  "<p>Candidate Name : " + txtfirstName.Text + "</p>";

                    string bodyContent2 = SettingResult.List[0].MailContent;
                    bodyContent2 = bodyContent2.Replace("{Name}", txtfirstName.Text);
                    bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                    string _Body2 = bodyContent2;

                    try
                    {

                        SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                        //SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                        SendMail2(UserName, _toMail3, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                    }
                    catch { }

                }
                #endregion

                mpeInquiry.Show();

            }


            #endregion


            #endregion



        }
    }

    //protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int idx = Convert.ToInt32(ddlQualification.SelectedValue.ToString());
    //    if (idx == 1)
    //    {
    //        firstop.Visible = true;
    //        secondop.Visible = false;
    //        thirdop.Visible = false;
    //        fourthop.Visible = false;
    //    }
    //    else if (idx == 2)
    //    {
    //        secondop.Visible = true;
    //        firstop.Visible = false;
    //        thirdop.Visible = false;
    //        fourthop.Visible = false;
    //    }
    //    else if (idx == 3)
    //    {
    //        secondop.Visible = false;
    //        firstop.Visible = false;
    //        thirdop.Visible = true;
    //        fourthop.Visible = false;

    //    }
    //    else if (idx == 4)
    //    {
    //        secondop.Visible = false;
    //        firstop.Visible = false;
    //        thirdop.Visible = false;
    //        fourthop.Visible = true;
    //    }
    //}

    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int JobtypeId = Convert.ToInt32(ddlJobType.SelectedValue);

        FillJobName2(JobtypeId);
    }

    protected void FillJobName2(int JobtypeId)
    {
        try
        {
            ddlJobName.Items.Clear();
            ddlJobName.Items.Insert(0, new ListItem("الرجاء اختيار اسم الوظيفة", "0"));

            ResultList<Lookup_JobNameEntity> Result = new ResultList<Lookup_JobNameEntity>();
            Result = Lookup_JobNameDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Lookup_JobNameEntity item in Result.List.Where(s => s.JobTypeID == JobtypeId))
                {
                    ddlJobName.Items.Add(new ListItem(item.JobName.ToString(), item.JobNameID.ToString()));
                }
            }
        }
        catch { }

    }


    #region 
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
                mailMessage.To.Add("laluram54@gmail.com");
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
    #endregion
}