using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;

namespace Siteware.Web.Plugins.JobApplication
{
    public partial class EditJobApplication : System.Web.UI.Page
    {
        DateTime currentDate = DateTime.Now;
        string PageName = "JobApplication";
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
                        FillJobType();
                        FillJobName();
                        FillMaritalStatus();
                        FillYearoflicense();
                        FillYear();
                        FillLicenseType();
                        FillQualification();
                        FillProvenance();
                        FillArea();

                        FillData();

                        // rblSex.Enabled = false;                      
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Redirect("~/Login.aspx");
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
        protected void FillJobName()
        {
            try
            {

                ddlJobName.Items.Insert(0, new ListItem("Select Job Name", "0"));

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
        protected void FillMaritalStatus()
        {
            try
            {

                ddlMaritalStatus.Items.Insert(0, new ListItem("Select MaritalStatus", "0"));

                ResultList<MartialStatusEntity> Result = new ResultList<MartialStatusEntity>();
                Result = MartialStatusDomain.GetMartialStatusNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (MartialStatusEntity item in Result.List)
                    {
                        ddlMaritalStatus.Items.Add(new ListItem(item.Name.ToString(), item.MaritalStatusID.ToString()));
                    }
                }
            }
            catch { }

        }
        protected void FillJobType()
        {

            try
            {
                ddlJobType.Items.Insert(0, new ListItem("Select Job Type", "0"));

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
        protected void FillYearoflicense()
        {

            try
            {
                ddlYearoflicense.Items.Insert(0, new ListItem("Select Year of license", "0"));

                ResultList<Lookup_LicenceYearEntity> Result = new ResultList<Lookup_LicenceYearEntity>();
                Result = Lookup_LicenceYear_Domain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_LicenceYearEntity item in Result.List)
                    {
                        ddlYearoflicense.Items.Add(new ListItem(item.LicenceYearName.ToString(), item.LicenceYearID.ToString()));
                    }
                }

            }
            catch { }

        }
        protected void FillLicenseType()
        {

            try
            {
                ddllicenseType.Items.Insert(0, new ListItem("Select License Type", "0"));

                ResultList<Lookup_LicenceTypeEntity> Result = new ResultList<Lookup_LicenceTypeEntity>();
                Result = Lookup_LicenceTypeDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_LicenceTypeEntity item in Result.List)
                    {
                        ddllicenseType.Items.Add(new ListItem(item.LicenceTypeName.ToString(), item.LicenceTypeID.ToString()));
                    }
                }
            }
            catch { }

        }
        protected void FillQualification()
        {

            try
            {
                ddlQualification.Items.Insert(0, new ListItem("Select Qualification", "0"));

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
        protected void FillYear()
        {

            try
            {
                //ddlYear.Items.Insert(0, new ListItem("Select Year", "0"));

                //int GetYear = currentDate.Year;

                //for (int i = 1900; i <= GetYear; i++)
                //{
                //    //ddlYearoflicense.Items.Add(new ListItem(i.ToString(), i.ToString()));
                //    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                //}
            }
            catch { }

        }
        protected void FillProvenance()
        {

            try
            {
                ddlProvenance.Items.Insert(0, new ListItem("Select Provenance", "0"));

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
                ddlArea.Items.Insert(0, new ListItem("Select Area", "0"));
                ddlArea2.Items.Insert(0, new ListItem("Select Area2", "0"));

                ResultList<Lookup_AreaOneEntity> Result = new ResultList<Lookup_AreaOneEntity>();
                Result = Lookup_AreaOneDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_AreaOneEntity item in Result.List)
                    {
                        ddlArea.Items.Add(new ListItem(item.AreaOneName.ToString(), item.AreaOneID.ToString()));
                    }
                }

                ResultList<Lookup_AreaTwoEntity> Result1 = new ResultList<Lookup_AreaTwoEntity>();
                Result1 = Lookup_AreaTwoDomain.GetAllNotAsync();

                if (Result1.Status == ErrorEnums.Success)
                {
                    foreach (Lookup_AreaTwoEntity item in Result1.List)
                    {
                        ddlArea2.Items.Add(new ListItem(item.AreaTwoName.ToString(), item.AreaTwoID.ToString()));
                    }
                }
            }
            catch { }

        }


        protected async void FillData()
        {
            try
            {
                if (Session["JobApplicationIDSession"] != null)
                {
                    long JobApplicationID = Convert.ToInt32(Session["JobApplicationIDSession"]);

                    ResultEntity<Plugin_JobApplicationEntity> Result = new ResultEntity<Plugin_JobApplicationEntity>();

                    Result = await Plugin_JobApplicationDomain.GetByID(JobApplicationID);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lblNewsname2.Text = Result.Entity.FirstName.ToString();
                        ddlJobName.SelectedValue = Result.Entity.JobName.ToString();
                        ddlJobType.SelectedValue = Result.Entity.JobType.ToString();
                        txtFirstName.Text = Result.Entity.FirstName.ToString();
                        txtSecondname.Text = Result.Entity.SecondName.ToString();
                        txtthirdName.Text = Result.Entity.ThirdName.ToString();
                        txtlastName.Text = Result.Entity.LastName.ToString();
                        txtNationalID.Text = Result.Entity.Nationalid.ToString();
                        txtBirthdate.Value = Result.Entity.BirthDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        ddlMaritalStatus.SelectedValue = Result.Entity.MaritalState.ToString();
                        txtChildNumber.Text = Result.Entity.NoofChild.ToString();
                        rbllicense.Items.FindByText(Result.Entity.HaveLicence.ToString()).Selected = true;
                        //rbllicense.SelectedItem.Text = Result.Entity.HaveLicence.ToString();
                        ddlYearoflicense.SelectedValue = Result.Entity.YearOfLicence.ToString();
                        ddllicenseType.SelectedValue = Result.Entity.LicenceType.ToString();
                        if (rbllicense.SelectedValue == "True")
                        {
                            divLicenseDetail.Visible = true;
                        }

                        ddlQualification.SelectedValue = Result.Entity.Qualification.ToString();

                        #region Plugin_Qualification

                        ResultList<Plugin_QualificationEntity> QualificationIDResult = new ResultList<Plugin_QualificationEntity>();
                        QualificationIDResult = await Plugin_QualificationDomain.GetByAdmissionID(JobApplicationID);

                        if (QualificationIDResult.Status == ErrorEnums.Success)
                        {
                            var ItemPerent = QualificationIDResult.List.Take(1).ToList();
                            long PerentID = ItemPerent[0].QualificationID;

                            ResultEntity<Plugin_QualificationEntity> QualificationInformationResult = new ResultEntity<Plugin_QualificationEntity>();

                            QualificationInformationResult = await Plugin_QualificationDomain.GetByID(PerentID);
                            if (QualificationInformationResult.Status == ErrorEnums.Success)
                            {
                                txtUniName.Text = QualificationInformationResult.Entity.UniName.ToString();
                                txtname.Text = QualificationInformationResult.Entity.Name.ToString();
                                //ddlYear.SelectedValue = QualificationInformationResult.Entity.Year.ToString();
                                txtYear.Text = QualificationInformationResult.Entity.Year.ToString();
                                txtMajor.Text = QualificationInformationResult.Entity.Major.ToString();
                                txtMajor2.Text = QualificationInformationResult.Entity.Major_Two.ToString();
                                txtMajorFrom.Text = QualificationInformationResult.Entity.Major_From.ToString();
                                txtAvg.Text = QualificationInformationResult.Entity.AVG.ToString();
                                txtOverallEval.Text = QualificationInformationResult.Entity.OverAllEval.ToString();
                               
                            }
                        }

                        divyear.Visible = true;
                        divmajor.Visible = true;
                        if (!string.IsNullOrEmpty(Result.Entity.Qualification.ToString()))
                        {
                            if (Result.Entity.Qualification.ToString() == "1")
                            {
                                divuniname.Visible = true;
                                divavg.Visible = true;
                                divOverallEval.Visible = true;
                            }
                            else if (Result.Entity.Qualification.ToString() == "2")
                            {
                                divname.Visible = true;
                                divavg.Visible = true;
                            }
                            else if (Result.Entity.Qualification.ToString() == "3")
                            {
                                divavg.Visible = true;
                            }
                            else if (Result.Entity.Qualification.ToString() == "4")
                            {
                                divmajor2.Visible = true;
                                divmajorfrom.Visible = true;
                            }
                            else
                            {
                                divQualification.Visible = false;
                                divyear.Visible = false;
                                divmajor.Visible = false;
                            }
                        }
                        else
                        {
                            divQualification.Visible = false;
                            divyear.Visible = false;
                            divmajor.Visible = false;
                        }

                        #endregion


                        #region Previous Experiance

                        ResultList<Plugin_PreviuesExperianceEntity> PreviousExperianceIDResult = new ResultList<Plugin_PreviuesExperianceEntity>();
                        PreviousExperianceIDResult = await Plugin_PreviuesExperianceDomain.GetByAdmissionID(JobApplicationID);
                        fildsetPreviousExperiance.Visible = false;
                        if (PreviousExperianceIDResult.Status == ErrorEnums.Success)
                        {
                            if (PreviousExperianceIDResult.List.Count > 0)
                            {
                                fildsetPreviousExperiance.Visible = true;
                                lstPreviousExperiance.DataSource = PreviousExperianceIDResult.List.ToList();
                                lstPreviousExperiance.DataBind();
                            }
                        }

                        #endregion

                        #region Training Cources

                        ResultList<Plugin_CVTrainingEntity> TrainingCourcesIDResult = new ResultList<Plugin_CVTrainingEntity>();
                        TrainingCourcesIDResult = await Plugin_CVTrainingDomain.GetByAdmissionID(JobApplicationID);
                        fildsetTrainingCources.Visible = false;
                        if (TrainingCourcesIDResult.Status == ErrorEnums.Success)
                        {
                            if (TrainingCourcesIDResult.List.Count > 0)
                            {
                                fildsetTrainingCources.Visible = true;
                                lstTrainingCources.DataSource = TrainingCourcesIDResult.List.ToList();
                                lstTrainingCources.DataBind();
                            }
                        }

                        #endregion

                        #region Contact Detail

                        ResultList<Plugin_CVContactEntity> ContactDetailIDResult = new ResultList<Plugin_CVContactEntity>();
                        ContactDetailIDResult = await Plugin_CVContactDomain.GetByAdmissionID(JobApplicationID);
                        
                        if (ContactDetailIDResult.Status == ErrorEnums.Success)
                        {
                            var ItemPerent = ContactDetailIDResult.List.Take(1).ToList();
                            long PerentID = ItemPerent[0].ContactID;

                            ResultEntity<Plugin_CVContactEntity> ContactInformationResult = new ResultEntity<Plugin_CVContactEntity>();

                            ContactInformationResult = await Plugin_CVContactDomain.GetByID(PerentID);
                            if (ContactInformationResult.Status == ErrorEnums.Success)
                            {
                                ddlProvenance.SelectedValue = ContactInformationResult.Entity.Provenance.ToString();
                                ddlArea.SelectedValue = ContactInformationResult.Entity.AreaOne.ToString();
                                ddlArea2.SelectedValue = ContactInformationResult.Entity.AreaTwo.ToString();
                                txtStreet.Text = ContactInformationResult.Entity.Street.ToString();
                                txtBuildingNumber.Text = ContactInformationResult.Entity.BuildingNumber.ToString();
                                txtTel1.Text = ContactInformationResult.Entity.TeliphoneOne.ToString();
                                txtTel2.Text = ContactInformationResult.Entity.TeliphoneTwo.ToString();
                                txtEmail.Text = ContactInformationResult.Entity.Email.ToString();

                                //Uploaded File
                                lnkUploadFile.NavigateUrl = ContactInformationResult.Entity.Resume;

                                if (ContactInformationResult.Entity.Resume != string.Empty)
                                {
                                    string abcd = ContactInformationResult.Entity.Resume.ToString();
                                    string Cutted = abcd.Split('/').Last();

                                    lnkUploadFile.NavigateUrl = ContactInformationResult.Entity.Resume;
                                    lnkUploadFile.Text = Cutted;
                                }
                            }
                        }

                        #endregion

                    }
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void lstLanguageAbility_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

            }
        }
    }
}