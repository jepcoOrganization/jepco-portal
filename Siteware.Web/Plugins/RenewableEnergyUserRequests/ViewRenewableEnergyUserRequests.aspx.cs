using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.RenewableEnergyUserRequests
{
    public partial class ViewRenewableEnergyUserRequests : System.Web.UI.Page
    {
        string PageName = "RenewableEnergyUserRequests";
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
                        FillstepstatusDropdown();
                        fillCompnay();
                        FillSendToDropdown();
                        FillHistory();
                        FillUserRequest();
                        FillRequestSteps();
                        FillStepsValueHistory();
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
        protected async void FillUserRequest()
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> ResultEntity = new ResultEntity<RenewableEnergyUserRequestsEntity>();


            if (Session["RenewableEnergyUserRequestsIDSession"] != null)
            {
                long UserReqID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                ResultEntity = await RenewableEnergyUserRequestsDomain.GetByID(UserReqID);
                if (ResultEntity.Status == ErrorEnums.Success)
                {
                    // rblRenwableEnergyType.SelectedItem = Entity.Entity.RenwableEnergyTypeID;
                    rblRenwableEnergyType.SelectedValue = ResultEntity.Entity.RenwableEnergyTypeID;


                    if (ResultEntity.Entity.RenwableEnergyTypeID == "3")
                    {
                        ResultList<RenewableEnergyUserRequestsDetailsEntity> DetailsEntity = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                        DetailsEntity = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                        if (DetailsEntity.Status == ErrorEnums.Success)
                        {
                            DetailsEntity.List = DetailsEntity.List.Where(s => s.IsDeleted == false && s.UserRequestID == Convert.ToInt64(ResultEntity.Entity.RenwableEnergyID)).OrderByDescending(s => s.DetailsID).ToList();
                            long ThisDatailID = DetailsEntity.List[0].DetailsID;
                           
                            ResultList<RenwableEnergyType3Phase1DetailsEntity> Type3Phase1DetailsList = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();
                            Type3Phase1DetailsList = RenwableEnergyType3Phase1DetailsDomain.GetAllNotAsync();
                            if (Type3Phase1DetailsList.Status == ErrorEnums.Success)
                            {
                                Type3Phase1DetailsList.List = Type3Phase1DetailsList.List.Where(s => s.DetailsID == ThisDatailID).ToList();
                                if (Type3Phase1DetailsList.List.Count >= 1)
                                {
                                    RequestType3IsAccepted.Checked = Type3Phase1DetailsList.List[0].IsApproved;
                                    Type3Phase1DetailsID.Value = Type3Phase1DetailsList.List[0].Type3Phase1DetailsID.ToString();
                                    divUpdatebtn.Visible = true;
                                    Type3AcceptDiv.Visible = true;

                                    ResultList<RenwableEnergyType3Phase1AttachmentsEntity> Type3Phase1AttachmentsEntityList = new ResultList<RenwableEnergyType3Phase1AttachmentsEntity>();
                                    Type3Phase1AttachmentsEntityList = RenwableEnergyType3Phase1AttachmentsDomain.GetAllNotAsync();
                                    if (Type3Phase1AttachmentsEntityList.Status == ErrorEnums.Success)
                                    {
                                        Type3Phase1AttachmentsEntityList.List = Type3Phase1AttachmentsEntityList.List.Where(s => s.DetailsID == ThisDatailID).ToList();

                                        li4.Visible = true;
                                        Phase1AttechmentDiv.Visible = true;
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments1 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments1.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt1.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments1;
                                            Phase1Attachemnt1.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments2 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments2.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt2.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments2;
                                            Phase1Attachemnt2.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments3 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments3.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt3.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments3;
                                            Phase1Attachemnt3.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments4 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments4.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt4.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments4;
                                            Phase1Attachemnt4.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments5 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments5.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt5.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments5;
                                            Phase1Attachemnt5.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments6 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments6.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt6.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments6;
                                            Phase1Attachemnt6.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments7 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments7.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt7.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments7;
                                            Phase1Attachemnt7.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments8 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments8.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt8.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments8;
                                            Phase1Attachemnt8.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments9 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments9.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt9.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments9;
                                            Phase1Attachemnt9.Text = Cutted;
                                        }
                                        if (Type3Phase1AttachmentsEntityList.List[0].Attachments10 != string.Empty)
                                        {
                                            string abcd = Type3Phase1AttachmentsEntityList.List[0].Attachments10.ToString();
                                            string Cutted = abcd.Split('/').Last();
                                            Phase1Attachemnt10.NavigateUrl = Type3Phase1AttachmentsEntityList.List[0].Attachments10;
                                            Phase1Attachemnt10.Text = Cutted;
                                        }


                                        if (Type3Phase1DetailsList.List[0].IsApproved == true)
                                        {
                                            ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> Type3Phase2AttachmentsEntityList = new ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>();
                                            Type3Phase2AttachmentsEntityList = RenwableEnergyType3Phase2DetailsAttechmentDomain.GetAllNotAsync();
                                            if (Type3Phase2AttachmentsEntityList.Status == ErrorEnums.Success)
                                            {
                                                Type3Phase2AttachmentsEntityList.List = Type3Phase2AttachmentsEntityList.List.Where(s => s.DetailsID == ThisDatailID).ToList();
                                                if (Type3Phase2AttachmentsEntityList.List.Count >= 1)
                                                {
                                                    li5.Visible = true;
                                                    Phase2AttechmentDiv.Visible = true;
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment1 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment1.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt1.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment1;
                                                        Phase2Attachemnt1.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment2 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment2.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt2.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment2;
                                                        Phase2Attachemnt2.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment3 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment3.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt3.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment3;
                                                        Phase2Attachemnt3.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment4 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment4.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt4.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment4;
                                                        Phase2Attachemnt4.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment5 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment5.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt5.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment5;
                                                        Phase2Attachemnt5.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment6 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment6.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt6.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment6;
                                                        Phase2Attachemnt6.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment7 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment7.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt7.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment7;
                                                        Phase2Attachemnt7.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment8 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment8.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt8.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment8;
                                                        Phase2Attachemnt8.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment9 != string.Empty)
                                                    {

                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment9.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt9.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment9;
                                                        Phase2Attachemnt9.Text = CuttedPhase2;
                                                    }
                                                    if (Type3Phase2AttachmentsEntityList.List[0].Attechment10 != string.Empty)
                                                    {
                                                        string abcd = Type3Phase2AttachmentsEntityList.List[0].Attechment10.ToString();
                                                        string CuttedPhase2 = abcd.Split('/').Last();
                                                        Phase2Attachemnt10.NavigateUrl = Type3Phase2AttachmentsEntityList.List[0].Attechment10;
                                                        Phase2Attachemnt10.Text = CuttedPhase2;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                            }


                        }
                    }
                    else
                    {
                        divUpdatebtn.Visible = false;
                        Type3AcceptDiv.Visible = false;
                    }

                    #region Add By Kiran || 11-05-2021
                    try
                    {
                        ResultList<RenewableEnergyUserRequestsDetailsEntity> DetailsEntity = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                        DetailsEntity = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                        if (DetailsEntity.Status == ErrorEnums.Success)
                        {
                            DetailsEntity.List = DetailsEntity.List.Where(s => s.IsDeleted == false && s.UserRequestID == Convert.ToInt64(ResultEntity.Entity.RenwableEnergyID)).OrderByDescending(s => s.DetailsID).ToList();

                            txtACVal.Text = DetailsEntity.List[0].ACPower;
                            txtDCVal.Text = DetailsEntity.List[0].DCPower;
                            if (DetailsEntity.List[0].Attachment1 != string.Empty)
                            {
                                string abcd = DetailsEntity.List[0].Attachment1.ToString();
                                string Cutted = abcd.Split('/').Last();

                                inkDetail1.NavigateUrl = DetailsEntity.List[0].Attachment1;
                                inkDetail1.Text = Cutted;

                            }
                            if (DetailsEntity.List[0].Attachment2 != string.Empty)
                            {
                                string abcd = DetailsEntity.List[0].Attachment2.ToString();
                                string Cutted = abcd.Split('/').Last();

                                inkDetail2.NavigateUrl = DetailsEntity.List[0].Attachment2;
                                inkDetail2.Text = Cutted;

                            }
                            if (DetailsEntity.List[0].Attachment3 != string.Empty)
                            {
                                string abcd = DetailsEntity.List[0].Attachment3.ToString();
                                string Cutted = abcd.Split('/').Last();

                                inkDetail3.NavigateUrl = DetailsEntity.List[0].Attachment3;
                                inkDetail3.Text = Cutted;

                            }
                            if (DetailsEntity.List[0].Attachment4 != string.Empty)
                            {
                                string abcd = DetailsEntity.List[0].Attachment4.ToString();
                                string Cutted = abcd.Split('/').Last();

                                inkDetail4.NavigateUrl = DetailsEntity.List[0].Attachment4;
                                inkDetail4.Text = Cutted;

                            }
                            var DevicesResult = RenewableEnergyUserRequestsDetailsDevicesDomain.GetByUserRequestsDetailsIDNotAsync(DetailsEntity.List[0].DetailsID);
                            if (DevicesResult.Status == ErrorEnums.Success)
                            {
                                lstdevice_information.DataSource = DevicesResult.List.ToList();
                                lstdevice_information.DataBind();
                            }

                            var SollerDevicesResult = RenewableEnergyUserRequestsDetailsSollarsDomain.GetAllByUserRequestsDetailsIDNotAsync(DetailsEntity.List[0].DetailsID);
                            if (SollerDevicesResult.Status == ErrorEnums.Success)
                            {
                                lstSollerDevice.DataSource = SollerDevicesResult.List.ToList();
                                lstSollerDevice.DataBind();
                            }

                            fillUserDataDropdown(ResultEntity.Entity.CompanyID);
                            ddlUSerType.SelectedValue = Convert.ToString(DetailsEntity.List[0].CompanyUserID);
                            UserTypeDetailByUserType(DetailsEntity.List[0].CompanyUserID);
                        }

                    }
                    catch
                    { }
                    #endregion

                    rblMeterStatus.SelectedValue = ResultEntity.Entity.MeterStatus;
                    if (rblMeterStatus.SelectedValue == "1")
                    {
                        txtCounter_refNo.Text = ResultEntity.Entity.ReferenceNumber;


                    }
                    else if (rblMeterStatus.SelectedValue == "2")
                    {
                        if (ResultEntity.Entity.Attachemnt4 != string.Empty)
                        {
                            string abcd = ResultEntity.Entity.Attachemnt4.ToString();
                            string Cutted = abcd.Split('/').Last();

                            lnkA4.NavigateUrl = ResultEntity.Entity.Attachemnt4;
                            lnkA4.Text = Cutted;

                        }

                    }
                    else
                    {
                        txtCounter_refNo.Visible = false;
                        if (ResultEntity.Entity.Attachemnt5 != string.Empty)
                        {
                            string abcd = ResultEntity.Entity.Attachemnt5.ToString();
                            string Cutted = abcd.Split('/').Last();

                            lnkA5.NavigateUrl = ResultEntity.Entity.Attachemnt5;
                            lnkA5.Text = Cutted;

                        }
                    }
                    if (ResultEntity.Entity.Attachemnt1 != string.Empty)
                    {
                        string abcd = ResultEntity.Entity.Attachemnt1.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnkA1.NavigateUrl = ResultEntity.Entity.Attachemnt1;
                        lnkA1.Text = Cutted;

                    }
                    if (ResultEntity.Entity.Attachemnt2 != string.Empty)
                    {
                        string abcd = ResultEntity.Entity.Attachemnt2.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnkA2.NavigateUrl = ResultEntity.Entity.Attachemnt2;
                        lnkA2.Text = Cutted;

                    }
                    if (ResultEntity.Entity.Attachemnt3 != string.Empty)
                    {
                        string abcd = ResultEntity.Entity.Attachemnt3.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnkA3.NavigateUrl = ResultEntity.Entity.Attachemnt3;
                        lnkA3.Text = Cutted;

                    }
                    lblguid.Text = ResultEntity.Entity.GUID;
                    txtStatusDate.Value = ResultEntity.Entity.AcceptStatusDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    chkStatus.Checked = ResultEntity.Entity.CompanyAcceptedStatus;
                    ddlCompanyName.SelectedValue = ResultEntity.Entity.CompanyID.ToString();
                    FillCompanyData(ResultEntity.Entity.CompanyID);                    
                    #region UserDetails 

                    ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                    ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(ResultEntity.Entity.UserID);
                    {
                        txtFirstName.Text = ServiceUserEntity.Entity.FirstName;
                        txtSecondName.Text = ServiceUserEntity.Entity.SecondName;
                        txtThirdName.Text = ServiceUserEntity.Entity.ThirdName;
                        txtFamilyName.Text = ServiceUserEntity.Entity.FamilyName;
                        txtUserTelephone.Text = ServiceUserEntity.Entity.TelephoneNumber;
                        txtUserEmail.Text = ServiceUserEntity.Entity.Email;
                        hdnUSerEmailId.Value = ServiceUserEntity.Entity.Email;
                        int cityId = ServiceUserEntity.Entity.City;
                        int area1id = ServiceUserEntity.Entity.Area1;
                        int Area2id = ServiceUserEntity.Entity.Area2;
                        ResultList<Lookup_CityEntity> CityEntity = new ResultList<Lookup_CityEntity>();
                        CityEntity = Lookup_CityDomain.GetLookupCityAllNotAsync();
                        //Result = Plugin_AboutCompanyDomain.GetAll();
                        if (CityEntity.Status == ErrorEnums.Success)
                        {
                            CityEntity.List = CityEntity.List.Where(s => s.CityID == cityId).ToList();
                            txtCity.Text = CityEntity.List[0].CityName;
                        }
                        ResultList<Lookup_AreaOneEntity> AreaOneEntity = new ResultList<Lookup_AreaOneEntity>();
                        AreaOneEntity = Lookup_AreaOneDomain.GetAllNotAsync();
                        if (AreaOneEntity.Status == ErrorEnums.Success)
                        {
                            AreaOneEntity.List = AreaOneEntity.List.Where(s => s.AreaOneID == area1id).ToList();
                            txtArea1.Text = AreaOneEntity.List[0].AreaOneName;
                        }
                        ResultList<Lookup_AreaTwoEntity> AreaTwoEntity = new ResultList<Lookup_AreaTwoEntity>();
                        AreaTwoEntity = Lookup_AreaTwoDomain.GetAllNotAsync();
                        if (AreaTwoEntity.Status == ErrorEnums.Success)
                        {
                            AreaTwoEntity.List = AreaTwoEntity.List.Where(s => s.AreaTwoID == Area2id).ToList();
                            txtArea2.Text = AreaOneEntity.List[0].AreaOneName;
                        }
                        txtAddress.Text = ServiceUserEntity.Entity.Address;



                    }
                    #endregion





                    //  HiddenField RenwableEnergyID
                    //  hidden UserID
                    // rdoibutn RenwableEnergyTypeID


                    //rdoibutn MeterStatus
                    // txt  ReferenceNumber
                    //ddl  CompanyID
                    // checkbox CompanyAcceptedStatu
                    // datetime AcceptStatusDate
                    // txt AcceptStatusUser
                    // link Attachemnt1
                    // link Attachemnt2
                    // link Attachemnt3
                    // link Attachemnt4
                    // not show Order
                    // not show LanguageID
                    //  not show PublishDate
                    //  not show IsPublished
                    //  not show IsDeleted
                    // not show AddDate
                    //  not show AddUser
                    //  not show EditDate
                    // not show  EditUser
                    // not show LanguageName
                    //  not show RefeenceType
                    //  link    Attachemnt5
                    //   txt/Label   GUID
                }
            }
        }

        protected void fillCompnay()
        {
            try
            {
                ddlCompanyName.Items.Insert(0, new ListItem("اختر اسم الشركة التي ترغب بتفويضها لتركيب النظام", "0"));

                ResultList<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();
                Result = Plugin_RenwabaleEnergyCompanyDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (Plugin_RenwabaleEnergyCompanyEntity item in Result.List.Where(s => s.IsPublished == true))
                    {
                        ddlCompanyName.Items.Add(new ListItem(item.CompanyName.ToString(), item.RenwabaleEnergyCompanyID.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        #region WorkFlow Tab Details | Tejas | 11022021
        protected async void FillSendToDropdown()
        {
            try
            {
                if (SessionManager.GetInstance.Users != null)
                {

                    DDLWorkflowUser.Items.Insert(0, new ListItem("Select User", "0"));

                    //ResultList<Plugin_CMS_WorkFlow_Users_Entity> Result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
                    //Result = Plugin_CMS_WorkFlow_Users_Domain.GetAllNotAsyncIdentity();

                    //if (Result.Status == ErrorEnums.Success)
                    //{
                    //    foreach (Plugin_CMS_WorkFlow_Users_Entity item in Result.List.Where(s => s.IsDelete == false && s.FromUserID == SessionManager.GetInstance.Users.UserID))
                    //    {
                    //        DDLWorkflowUser.Items.Add(new ListItem(item.ToUserID.ToString(), item.ToUserID.ToString()));
                    //    }
                    //}

                    ResultList<UserEntity> userlist = new ResultList<UserEntity>();
                    userlist = await UsersDomain.GetUserAll();

                    userlist.List = userlist.List.Where(x => x.IsDeleted == false).ToList();
                    ResultList<Plugin_CMS_WorkFlow_Users_Entity> Result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
                    Result = Plugin_CMS_WorkFlow_Users_Domain.GetAllNotAsyncIdentity();
                    var Result1 = Result.List.Where(x => x.FromUserID == SessionManager.GetInstance.Users.UserID).ToList();

                    if (Result.Status == ErrorEnums.Success)
                    {
                        foreach (var itemUser in Result1)
                        {
                            foreach (var itemUser1 in userlist.List)
                            {
                                //if (itemUser.ToUserID == itemUser1.UserID) {
                                //    // following condtion will check if ToUser in Plugin_CMS_WorkFlow_Users_Entity ( To fill SendTo Dropdown) is Current logged in user then will skip that entry in dropdown 
                                //    if (itemUser.ToUserID == SessionManager.GetInstance.Users.UserID) {
                                //        // do nothing
                                //    }
                                //    else
                                //    {
                                //        DDLWorkflowUser.Items.Add(new ListItem(itemUser1.FirstName.ToString() + " " + itemUser1.LastName.ToString(), itemUser.ToUserID.ToString()));
                                //    }
                                //}
                                if (itemUser.ToUserID == itemUser1.UserID)
                                {
                                    DDLWorkflowUser.Items.Add(new ListItem(itemUser1.FirstName.ToString() + " " + itemUser1.LastName.ToString(), itemUser.ToUserID.ToString()));
                                }
                            }

                        }
                    }
                    //Security_Users
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ResultList<Plugin_CMS_WorkFlow_Entity> checkforflagResult = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                checkforflagResult = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();

                Plugin_CMS_WorkFlow_Entity entity = new Plugin_CMS_WorkFlow_Entity();
                Plugin_CMS_WorkFlow_Entity entity1 = new Plugin_CMS_WorkFlow_Entity();


                string fileuplaod = newWinField.Value.ToString();
                string fileuplaod2 = newWinField2.Value.ToString();
                string fileuplaod3 = newWinField3.Value.ToString();

                if (checkforflagResult.List.Count > 0)
                {
                    foreach (var itemx in checkforflagResult.List)
                    {
                        if (itemx.ID > 0)
                        {
                            if (itemx.To_User == Convert.ToString(SessionManager.GetInstance.Users.UserID)
                                                        && itemx.RequestID.ToString() == Session["RenewableEnergyUserRequestsIDSession"].ToString())
                            {
                                entity.ID = itemx.ID;
                                entity.WF_ID = itemx.WF_ID;
                                entity.RequestID = itemx.RequestID;
                                entity.From_User = itemx.From_User;
                                entity.To_User = itemx.To_User;
                                entity.Send_Date = itemx.Send_Date;
                                entity.ProcessName = string.Empty;
                                entity.ShowToUser = itemx.ShowToUser;
                                entity.Notes = itemx.Notes;
                                entity.IsDelete = itemx.IsDelete;
                                entity.AddDate = itemx.AddDate;
                                entity.EditDate = DateTime.Now;
                                entity.ReqBackFlag = true;
                                entity.InsertMultiFlag = true;

                                var Result1 = Plugin_CMS_WorkFlow_Domain.UpdateNotAsync(entity);
                                if (Result1.Status == ErrorEnums.Success)
                                {
                                    //DDLWorkflowUser.Attributes.Add("disabled", "disabled");
                                    //divNotes.Style.Add("display", "none");
                                    //FillHistory();

                                    entity1.WF_ID = 1;
                                    entity1.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                                    entity1.From_User = SessionManager.GetInstance.Users.UserID.ToString();
                                    entity1.To_User = DDLWorkflowUser.SelectedValue.ToString();
                                    entity1.Send_Date = DateTime.Now;
                                    entity1.ProcessName = string.Empty;
                                    entity1.ShowToUser = false;
                                    entity1.Notes = txtNotes.Text;
                                    entity1.IsDelete = false;
                                    entity1.AddDate = DateTime.Now;
                                    entity1.EditDate = DateTime.Now;
                                    entity1.ReqBackFlag = false;
                                    entity1.InsertMultiFlag = false;
                                    entity1.Attachment = fileuplaod;
                                    entity1.Attachment2 = fileuplaod2;
                                    entity1.Attachment3 = fileuplaod3;

                                    var Result = Plugin_CMS_WorkFlow_Domain.InsertNotAsync(entity1);
                                    if (Result.Status == ErrorEnums.Success)
                                    {
                                        //DDLWorkflowUser.SelectedValue = "0";
                                        //DDLWorkflowUser.Enabled = false;
                                        DDLWorkflowUser.Attributes.Add("disabled", "disabled");
                                        divNotes.Style.Add("display", "none");
                                        FillHistory();
                                    }
                                }

                                break;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(txtNotes.Text))
                                {
                                    entity.WF_ID = 1;
                                    entity.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                                    entity.From_User = SessionManager.GetInstance.Users.UserID.ToString();
                                    entity.To_User = DDLWorkflowUser.SelectedValue.ToString();
                                    entity.Send_Date = DateTime.Now;
                                    entity.ProcessName = string.Empty;
                                    entity.ShowToUser = false;
                                    entity.Notes = txtNotes.Text;
                                    entity.IsDelete = false;
                                    entity.AddDate = DateTime.Now;
                                    entity.EditDate = DateTime.Now;
                                    entity.ReqBackFlag = false;
                                    entity.InsertMultiFlag = false;
                                    entity.Attachment = fileuplaod;
                                    entity.Attachment2 = fileuplaod2;
                                    entity.Attachment3 = fileuplaod3;

                                    var Result = Plugin_CMS_WorkFlow_Domain.InsertNotAsync(entity);
                                    if (Result.Status == ErrorEnums.Success)
                                    {
                                        //DDLWorkflowUser.SelectedValue = "0";
                                        //DDLWorkflowUser.Enabled = false;
                                        DDLWorkflowUser.Attributes.Add("disabled", "disabled");
                                        divNotes.Style.Add("display", "none");
                                        FillHistory();
                                    }
                                    break;
                                }
                            }

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(txtNotes.Text))
                            {
                                entity.WF_ID = 1;
                                entity.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                                entity.From_User = SessionManager.GetInstance.Users.UserID.ToString();
                                entity.To_User = DDLWorkflowUser.SelectedValue.ToString();
                                entity.Send_Date = DateTime.Now;
                                entity.ProcessName = string.Empty;
                                entity.ShowToUser = false;
                                entity.Notes = txtNotes.Text;
                                entity.IsDelete = false;
                                entity.AddDate = DateTime.Now;
                                entity.EditDate = DateTime.Now;
                                entity.ReqBackFlag = false;
                                entity.InsertMultiFlag = false;
                                entity.Attachment = fileuplaod;
                                entity.Attachment2 = fileuplaod2;
                                entity.Attachment3 = fileuplaod3;

                                var Result = Plugin_CMS_WorkFlow_Domain.InsertNotAsync(entity);
                                if (Result.Status == ErrorEnums.Success)
                                {
                                    //DDLWorkflowUser.SelectedValue = "0";
                                    //DDLWorkflowUser.Enabled = false;
                                    DDLWorkflowUser.Attributes.Add("disabled", "disabled");
                                    divNotes.Style.Add("display", "none");
                                    FillHistory();
                                }
                                break;
                            }
                        }

                    }

                }
                else
                {

                    if (!string.IsNullOrEmpty(txtNotes.Text))
                    {
                        entity.WF_ID = 1;
                        entity.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                        entity.From_User = SessionManager.GetInstance.Users.UserID.ToString();
                        entity.To_User = DDLWorkflowUser.SelectedValue.ToString();
                        entity.Send_Date = DateTime.Now;
                        entity.ProcessName = string.Empty;
                        entity.ShowToUser = false;
                        entity.Notes = txtNotes.Text;
                        entity.IsDelete = false;
                        entity.AddDate = DateTime.Now;
                        entity.EditDate = DateTime.Now;
                        entity.ReqBackFlag = false;
                        entity.InsertMultiFlag = false;
                        entity.Attachment = fileuplaod;
                        entity.Attachment2 = fileuplaod2;
                        entity.Attachment3 = fileuplaod3;

                        var Result = Plugin_CMS_WorkFlow_Domain.InsertNotAsync(entity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            //DDLWorkflowUser.SelectedValue = "0";
                            //DDLWorkflowUser.Enabled = false;
                            DDLWorkflowUser.Attributes.Add("disabled", "disabled");
                            divNotes.Style.Add("display", "none");
                            FillHistory();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void DDLWorkflowUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLWorkflowUser.SelectedValue == "0")
            {
                divNotes.Style.Add("display", "none");
            }
            else
            {
                ResultList<Plugin_CMS_WorkFlow_Entity> resultList = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                resultList = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();
                resultList.List = resultList.List.Where(x => x.To_User == DDLWorkflowUser.SelectedValue.ToString() && x.From_User == SessionManager.GetInstance.Users.UserID.ToString()).ToList();
                if (resultList.List.Count > 0)
                {
                    //divNotes.Style.Add("display", "none");
                    divNotes.Style.Add("display", "block");
                }
                else
                {
                    divNotes.Style.Add("display", "block");
                }
                //divNotes.Style.Add("display", "none");
            }

        }

        protected void FillHistory()
        {
            try
            {


                if (!string.IsNullOrEmpty(Session["RenewableEnergyUserRequestsIDSession"].ToString()))
                {
                    long requestid = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);
                    ResultList<Plugin_CMS_WorkFlow_Entity> resultList = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                    //resultList = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();
                    resultList = Plugin_CMS_WorkFlow_Domain.GetAllRequestIDNotAsync(requestid);
                    if (resultList.Status == ErrorEnums.Success)
                    {
                        var all_req = resultList.List.Where(x => x.To_User == Convert.ToString(SessionManager.GetInstance.Users.UserID) || x.From_User == Convert.ToString(SessionManager.GetInstance.Users.UserID)).ToList();


                        var req = resultList.List.Where(x => x.RequestID.ToString() == Session["RenewableEnergyUserRequestsIDSession"].ToString()).OrderByDescending(y => y.ID).FirstOrDefault();
                        if (req != null)
                        {
                            if (Convert.ToString(SessionManager.GetInstance.Users.UserID) == req.From_User)
                            {
                                DDLWorkflowUser.Enabled = false;
                            }
                            else
                            {
                                //var isRequestExists = resultList.List.Where(x => x.From_User.ToString() == Convert.ToString(SessionManager.GetInstance.Users.UserID)).OrderByDescending(y => y.ID).FirstOrDefault();
                                //if (isRequestExists != null)
                                //{
                                //    DDLWorkflowUser.Enabled = false;
                                //}
                                //else
                                //{

                                //    DDLWorkflowUser.Enabled = true;

                                //}

                                if (Convert.ToString(SessionManager.GetInstance.Users.UserID) != req.To_User)
                                {

                                    DDLWorkflowUser.Enabled = false;
                                }
                                else
                                {
                                    DDLWorkflowUser.Enabled = true;
                                }

                            }
                        }

                        //var req = resultList.List.Where(x => x.RequestID.ToString() == Session["RenewableEnergyUserRequestsIDSession"].ToString()).OrderByDescending(y => y.ID).ToList();
                        //if (req.Count > 0)
                        //{
                        //    foreach (var item in req)
                        //    {
                        //        if (Convert.ToString(SessionManager.GetInstance.Users.UserID) == item.From_User)
                        //        {
                        //            DDLWorkflowUser.Enabled = false;
                        //        }
                        //        else
                        //        {
                        //            DDLWorkflowUser.Enabled = true;

                        //        }
                        //    }
                        //}

                        //var resultListToSend = resultList.List.Where(x => x.To_User == Convert.ToString(SessionManager.GetInstance.Users.UserID)).ToList();

                        //resultList.List = resultList.List.Where(x => x.From_User == Convert.ToString(SessionManager.GetInstance.Users.UserID)).ToList();
                        //if (resultList.List.Count > 0)
                        //{

                        //    foreach(var item in resultList.List)
                        //    {

                        //        if (Session["RenewableEnergyUserRequestsIDSession"].ToString() == item.RequestID.ToString())
                        //        {
                        //            DDLWorkflowUser.Enabled = false;
                        //        }

                        //    }

                        //    foreach (var item1 in resultListToSend)
                        //    {
                        //        if (Session["RenewableEnergyUserRequestsIDSession"].ToString() == item1.RequestID.ToString())
                        //        {
                        //            DDLWorkflowUser.Enabled = true;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    DDLWorkflowUser.Enabled = true;
                        //}
                        if (all_req.Count > 0)
                        {
                            lstWorkflowHistory.DataSource = all_req;
                            lstWorkflowHistory.DataBind();

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        protected void FillCompanyData(long CompanyId)
        {
            try
            {
                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompany = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

                //ResultList <Lookup_JobNameEntity> Result = new ResultList<Lookup_JobNameEntity>();
                RenwabaleEnergyCompany = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(CompanyId);

                if (RenwabaleEnergyCompany.Status == ErrorEnums.Success)
                {
                    txtMobileNo.Text = RenwabaleEnergyCompany.Entity.MobileNumber;
                    txtNationalNo.Text = RenwabaleEnergyCompany.Entity.CompanyNationalID;
                    txtEmail.Text = RenwabaleEnergyCompany.Entity.EmailAddress;
                    
                }
                
            }
            catch { }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                long Phase1DatilsID = Convert.ToInt64(Type3Phase1DetailsID.Value);

                RenwableEnergyType3Phase1DetailsEntity Type3Phase1DetailsEntity = new RenwableEnergyType3Phase1DetailsEntity();
                Type3Phase1DetailsEntity.Type3Phase1DetailsID = Phase1DatilsID;
                Type3Phase1DetailsEntity.IsApproved = RequestType3IsAccepted.Checked;
                Type3Phase1DetailsEntity.ApprovedDate = DateTime.Now;


                var DetailsInsert = RenwableEnergyType3Phase1DetailsDomain.UpdateIsAcceptedNotAsync(Type3Phase1DetailsEntity);
                if (DetailsInsert.Status == ErrorEnums.Success)
                {

                    #region  mail Send To Admin
                    ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
                    SettingResult = SettingDomain.GetSettingAllWithoutAsync();

                    if (SettingResult.Status == ErrorEnums.Success)
                    {
                        string UserName = SettingResult.List[0].Email;
                        string _fromMail = SettingResult.List[0].FromMail;
                        string _Password = SettingResult.List[0].PasswordEmail;
                        string _HOST = SettingResult.List[0].SMTPServer;
                        int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
                        string _subject = "RenwableEnergyType3 Request Send";


                        string _toMail1 = txtEmail.Text.ToString(); //ConfigurationManager.AppSettings["RenwableEnergyType3"].ToString();
                        //string _toMail1 = ConfigurationManager.AppSettings["RenwableEnergyType3"].ToString();
                        //string _toMail2 = ConfigurationManager.AppSettings["ToMailSolarDeviceAdmin"].ToString();

                        bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                        //string _ccMail = ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin1"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin2"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin3"].ToString();

                        //string bodyContent = SettingResult.List[0].RenewableDeviceUserMail;
                        //bodyContent = bodyContent.Replace("{Name}", "");
                        //bodyContent = bodyContent.Replace("{FormDetails}", "");
                        //string _Body = bodyContent;

                        string _Body = "Your Request Has Been Accepted.";


                        //string _BodyForAdmin = "<h1>Company Device</h1>";

                        //string bodyContent2 = SettingResult.List[0].RenewableDeviceAdminMail;
                        //bodyContent2 = bodyContent2.Replace("{Name}", "");
                        //bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                        //string _Body2 = bodyContent2;

                        try
                        {

                            SendMail2(UserName, _toMail1, _fromMail, "", _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                            //SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                        }
                        catch { }

                    }
                    #endregion



                }

                if (DetailsInsert.Status == ErrorEnums.Success)
                {
                    mpeSuccess.Show();
                }



            }
            catch (Exception exp) { }


        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/RenewableEnergyUserRequests/ManageRenewableEnergyUserRequests.aspx", false);
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

                //foreach (string sCC in ccmail.Split(",".ToCharArray()))
                //    mailMessage.CC.Add(sCC);

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

        protected async void lstWorkflowHistory_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ResultList<UserEntity> userlist = new ResultList<UserEntity>();

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblUserFrom = (Label)e.Item.FindControl("lblFromUser");
                Label lblToUser = (Label)e.Item.FindControl("lblToUser");

                HyperLink Attachment = (HyperLink)e.Item.FindControl("Attachment");
                HyperLink Attachment2 = (HyperLink)e.Item.FindControl("Attachment2");
                HyperLink Attachment3 = (HyperLink)e.Item.FindControl("Attachment3");

                if (!string.IsNullOrEmpty(Attachment.NavigateUrl))
                {
                    string abcd = Attachment.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment.Text = Cutted;
                }
                if (!string.IsNullOrEmpty(Attachment2.NavigateUrl))
                {
                    string abcd = Attachment2.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment2.Text = Cutted;
                }
                if (!string.IsNullOrEmpty(Attachment3.NavigateUrl))
                {
                    string abcd = Attachment3.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment3.Text = Cutted;
                }

                userlist = await UsersDomain.GetUserAll();
                if (userlist.List.Count > 0)
                {
                    var fromUser = userlist.List.Where(x => x.UserID.ToString() == Convert.ToString(lblUserFrom.Text)).ToList();
                    if (fromUser.Count > 0)
                    {
                        lblUserFrom.Text = fromUser[0].FirstName + " " + fromUser[0].LastName;
                    }

                    var toUser = userlist.List.Where(x => x.UserID.ToString() == Convert.ToString(lblToUser.Text)).ToList();
                    if (toUser.Count > 0)
                    {
                        lblToUser.Text = toUser[0].FirstName + " " + toUser[0].LastName;
                    }
                }
            }
        }

        public void FillRequestSteps()
        {
            try
            {

                ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> resultList = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();
                resultList = Plugin_CMS_WorkFlow_Users_Reuests_StepsDomain.GetAllNotAsync();
                if (resultList.Status == ErrorEnums.Success)
                {
                    //var itemList = new List<ListItem>();
                    foreach (var item in resultList.List.Where(x => x.WF_ID == 1).OrderBy(y => y.Order))
                    {
                        ListItem li = new ListItem();
                        li.Text = item.StepName;
                        li.Value = item.ID.ToString();

                        RbtnUserReqSteps.Items.Add(li);
                        RbtnUserReqSteps1.Items.Add(li);

                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void BtnStepSave_Click(object sender, EventArgs e)
        {
            bool stepTrue = false;
            foreach (ListItem litem in RbtnUserReqSteps.Items)
            {
                if (litem.Selected)
                {
                    txtStepsNote.Style.Add("border", "none");
                    stepTrue = true;
                    break;
                }
                else
                {
                    txtStepsNote.Style.Add("border", "1px solid red");
                }
            }
            if (stepTrue)
            {
                //save data
                if (!string.IsNullOrEmpty(txtStepsNote.Text))
                {
                    try
                    {
                        string fileuplaod4 = newWinField4.Value.ToString();
                        string fileuplaod5 = newWinField5.Value.ToString();
                        string fileuplaod6 = newWinField6.Value.ToString();

                        Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity valueEntity = new Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity();
                        valueEntity.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"].ToString());
                        valueEntity.RequestUserStepID = Convert.ToInt64(RbtnUserReqSteps.SelectedItem.Value.ToString());
                        valueEntity.StepName = RbtnUserReqSteps.SelectedItem.Text.ToString();
                        valueEntity.StepNotes = txtStepsNote.Text.ToString().Trim();
                        valueEntity.IsDelete = false;
                        valueEntity.Adddate = Convert.ToDateTime(DateTime.Now);
                        valueEntity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                        valueEntity.EditDate = Convert.ToDateTime(DateTime.Now);
                        valueEntity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                        valueEntity.StepStatus = ddlstepstatus.SelectedItem.Text.ToString();
                        valueEntity.Attachment = fileuplaod4;
                        valueEntity.Attachment2 = fileuplaod5;
                        valueEntity.Attachment3 = fileuplaod6;
                        if (ddlstepstatus1.SelectedItem.Text.ToString() == "Done")
                        {
                            valueEntity.CompletedDate = Convert.ToDateTime(DateTime.Now);
                        }

                        var result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.InsertNotAsync(valueEntity);
                        if (result.Status == ErrorEnums.Success)
                        {
                            #region Save History table

                            try
                            {
                                Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity historyEntity = new Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity();
                                historyEntity.RequestStepValuesID = valueEntity.ID;
                                historyEntity.RequestID = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"].ToString()); ;
                                historyEntity.RequestUserStepID = Convert.ToInt64(RbtnUserReqSteps.SelectedItem.Value.ToString());
                                historyEntity.StepName = RbtnUserReqSteps.SelectedItem.Text.ToString();
                                historyEntity.StepNotes = txtStepsNote.Text.ToString().Trim();
                                historyEntity.IsDelete = false;
                                historyEntity.Adddate = Convert.ToDateTime(DateTime.Now);
                                historyEntity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                                historyEntity.EditDate = Convert.ToDateTime(DateTime.Now);
                                historyEntity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                                historyEntity.StepStatus = ddlstepstatus1.SelectedItem.Text;
                                historyEntity.Attachment = fileuplaod4;
                                historyEntity.Attachment2 = fileuplaod5;
                                historyEntity.Attachment3 = fileuplaod6;
                                if (ddlstepstatus1.SelectedItem.Text.ToString() == "Done")
                                {
                                    historyEntity.CompletedDate = Convert.ToDateTime(DateTime.Now);
                                }

                                var DetailsInsert = Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryDomain.InsertNotAsync(historyEntity);

                                if (DetailsInsert.Status == ErrorEnums.Success)
                                {

                                }

                            }
                            catch (Exception ex)
                            {

                            }

                            #endregion

                            mpeSuccess1.Show();
                            FillStepsValueHistory();
                            txtStepsNote.Text = string.Empty;
                            RbtnUserReqSteps.ClearSelection();
                        }

                    }
                    catch (Exception ex1)
                    {

                    }
                }
                else
                {
                    txtStepsNote.Style.Add("border", "1px solid red");
                }


            }
        }

        protected void btnOk1_Click(object sender, EventArgs e)
        {
            mpeSuccess1.Hide();
        }

        public void FillStepsValueHistory()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["RenewableEnergyUserRequestsIDSession"].ToString()))
                {
                    long requestid = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);

                    ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> stepsValueResult = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
                    stepsValueResult = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.GetAllByRequestIDNotAsync(requestid);
                    if (stepsValueResult.Status == ErrorEnums.Success)
                    {
                        lstStepsValue.DataSource = stepsValueResult.List.Where(x => x.IsDelete == false).OrderBy(y => y.ID).ToList();
                        lstStepsValue.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void lstStepsValue_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink Attachment = (HyperLink)e.Item.FindControl("Attachment");
                HyperLink Attachment2 = (HyperLink)e.Item.FindControl("Attachment2");
                HyperLink Attachment3 = (HyperLink)e.Item.FindControl("Attachment3");

                if (!string.IsNullOrEmpty(Attachment.NavigateUrl))
                {
                    string abcd = Attachment.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment.Text = Cutted;
                }
                if (!string.IsNullOrEmpty(Attachment2.NavigateUrl))
                {
                    string abcd = Attachment2.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment2.Text = Cutted;
                }
                if (!string.IsNullOrEmpty(Attachment3.NavigateUrl))
                {
                    string abcd = Attachment3.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment3.Text = Cutted;
                }

                Label lblStepStatus = e.Item.FindControl("lblStepStatus") as Label;
                //lblAddDate.Text = Convert.ToDateTime(lblAddDate.Text).ToString("dd-MM-yyyy");
                HiddenField UserID = e.Item.FindControl("hndadduser") as HiddenField;
                LinkButton btneditStep = e.Item.FindControl("btneditStep") as LinkButton;
                if ((SessionManager.GetInstance.Users.UserID.ToString() == UserID.Value.ToString()) && lblStepStatus.Text != "Done")
                {
                    btneditStep.Enabled = true;
                }


            }
        }

        protected async void FillstepstatusDropdown()
        {
            try
            {
                ddlstepstatus.Items.Insert(0, new ListItem("Select Step Status", "0"));
                ddlstepstatus.Items.Insert(1, new ListItem("Done", "Done"));
                ddlstepstatus.Items.Insert(2, new ListItem("Pending", "Pending"));

                ddlstepstatus1.Items.Insert(0, new ListItem("Select Step Status", "0"));
                ddlstepstatus1.Items.Insert(1, new ListItem("Done", "Done"));
                ddlstepstatus1.Items.Insert(2, new ListItem("Pending", "Pending"));
            }
            catch (Exception ex)
            {
            }
        }

        protected void lstStepsValue_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["WorkFlowUsersReuestsStepsValueIDSession"] = ID;

                try
                {
                    if (!string.IsNullOrEmpty(Session["RenewableEnergyUserRequestsIDSession"].ToString()))
                    {
                        long requestid = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);

                        ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> stepsValueResult = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
                        stepsValueResult = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.GetAllByRequestIDNotAsync(requestid);
                        if (stepsValueResult.Status == ErrorEnums.Success)
                        {
                            var data = stepsValueResult.List.Where(x => x.IsDelete == false && x.ID == ID).OrderBy(y => y.ID).FirstOrDefault();
                            if (data != null)
                            {
                                txtStepsNote1.Text = Convert.ToString(data.StepNotes);
                                if (!string.IsNullOrEmpty(data.StepStatus))
                                {
                                    ddlstepstatus1.SelectedValue = Convert.ToString(data.StepStatus);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                }

                mpeStepedit.Show();

                //Response.Redirect("~/Plugins/RenewableEnergyUserRequests/ViewRenewableEnergyUserRequests.aspx", false);
            }
        }

        protected void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["WorkFlowUsersReuestsStepsValueIDSession"].ToString()))
            {
                if (!string.IsNullOrEmpty(txtStepsNote1.Text))
                {
                    try
                    {
                        Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity valueEntity = new Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity();
                        valueEntity.ID = Convert.ToInt64(Session["WorkFlowUsersReuestsStepsValueIDSession"].ToString());
                        //valueEntity.StepName = RbtnUserReqSteps.SelectedItem.Text.ToString();
                        valueEntity.StepNotes = txtStepsNote1.Text.ToString().Trim();
                        valueEntity.EditDate = Convert.ToDateTime(DateTime.Now);
                        valueEntity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                        valueEntity.StepStatus = ddlstepstatus1.SelectedItem.Text.ToString();
                        if (ddlstepstatus1.SelectedItem.Text.ToString() == "Done")
                        {
                            valueEntity.CompletedDate = Convert.ToDateTime(DateTime.Now);
                        }

                        var result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.UpdateStatusNotAsync(valueEntity);
                        if (result.Status == ErrorEnums.Success)
                        {
                            Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity historyEntity = new Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity();

                            #region Save History table

                            try
                            {
                                if (!string.IsNullOrEmpty(Session["RenewableEnergyUserRequestsIDSession"].ToString()))
                                {
                                    long requestid = Convert.ToInt64(Session["RenewableEnergyUserRequestsIDSession"]);

                                    ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> stepsValueResult = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
                                    stepsValueResult = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.GetAllByRequestIDNotAsync(requestid);
                                    if (stepsValueResult.Status == ErrorEnums.Success)
                                    {
                                        var data = stepsValueResult.List.Where(x => x.IsDelete == false && x.ID == valueEntity.ID).OrderBy(y => y.ID).FirstOrDefault();
                                        if (data != null)
                                        {
                                            historyEntity.RequestStepValuesID = valueEntity.ID;
                                            historyEntity.RequestID = data.RequestID;
                                            historyEntity.RequestUserStepID = data.RequestID;
                                            historyEntity.StepName = data.StepName;
                                            historyEntity.StepNotes = data.StepNotes;
                                            historyEntity.IsDelete = false;
                                            historyEntity.Adddate = Convert.ToDateTime(DateTime.Now);
                                            historyEntity.AddUser = SessionManager.GetInstance.Users.UserID.ToString();
                                            historyEntity.EditDate = Convert.ToDateTime(DateTime.Now);
                                            historyEntity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                                            historyEntity.StepStatus = ddlstepstatus1.SelectedItem.Text;
                                            historyEntity.Attachment = data.Attachment;
                                            historyEntity.Attachment2 = data.Attachment2;
                                            historyEntity.Attachment3 = data.Attachment3;
                                            if (ddlstepstatus1.SelectedItem.Text.ToString() == "Done")
                                            {
                                                historyEntity.CompletedDate = Convert.ToDateTime(DateTime.Now);
                                            }
                                            var DetailsInsert = Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryDomain.InsertNotAsync(historyEntity);

                                            if (DetailsInsert.Status == ErrorEnums.Success)
                                            {

                                            }
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {

                            }

                            #endregion

                            mpeSuccess1.Show();
                            FillStepsValueHistory();
                            txtStepsNote.Style.Add("border", "none");
                        }

                    }
                    catch (Exception ex1)
                    {

                    }
                }
                else
                {
                    txtStepsNote.Style.Add("border", "1px solid red");
                }
            }
        }

        protected void lstUSerData_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                    //Image imgProfileimge = (Image)e.Item.FindControl("imgProfileimge");


                    //if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    //    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");

                    if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    {
                        string abcd = lnkSecondNav.NavigateUrl;
                        string Cutted = abcd.Split('/').Last();

                        lnkSecondNav.Text = Cutted;
                    }                    

                    //if (!string.IsNullOrEmpty(imgProfileimge.ImageUrl)) { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgProfileimge.ImageUrl.Replace("~/", "~/Siteware/"); }
                    //else { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + "/Siteware/Siteware_File/image/JEPCO//Profile_pic.png"; }

                }
            }
            catch (Exception ex)
            {
            }
        }

        public void UserTypeDetailByUserType(long UserTypeID)
        {
            try
            {
                long USerTypeID = UserTypeID;


                ResultList<RenewableEnergyCompanyUserEntity> CompanyUserEntity = new ResultList<RenewableEnergyCompanyUserEntity>();
                CompanyUserEntity = RenewableEnergyCompanyUserDomain.GetAllNotAsync();
                if (CompanyUserEntity.Status == ErrorEnums.Success)
                {
                    lstUSerData.DataSource = CompanyUserEntity.List.Where(s => s.RenewableEnergyCompanyUserID == USerTypeID).ToList();
                    lstUSerData.DataBind();
                }
            }
            catch
            { }
        }
        protected void fillUserDataDropdown(long CompanyId)
        {
            try
            {

                ddlUSerType.Items.Insert(0, new ListItem("اختيار المفوض", "0"));


                long companyId = CompanyId;

                ResultList<RenewableEnergyCompanyUserEntity> res = new ResultList<RenewableEnergyCompanyUserEntity>();
                res = RenewableEnergyCompanyUserDomain.GetAllNotAsync();
                if (res.Status == ErrorEnums.Success)
                {

                    var CompanyUSerList = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.CompanyID == companyId).OrderByDescending(s => s.RenewableEnergyCompanyUserID).ToList();

                    foreach (var item in CompanyUSerList)
                    {
                        ddlUSerType.Items.Add(new ListItem(item.FirstName.ToString() + " " + item.FatherName.ToString() + " " + item.FamilyName.ToString(), item.RenewableEnergyCompanyUserID.ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void lstdevice_information_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkDeviceDocument");                   

                    if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    {
                        string abcd = lnkSecondNav.NavigateUrl;
                        string Cutted = abcd.Split('/').Last();

                        lnkSecondNav.Text = Cutted;
                    }
                    //if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    //    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");                  

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lstSollerDevice_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkDeviceDocument");

                    if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    {
                        string abcd = lnkSecondNav.NavigateUrl;
                        string Cutted = abcd.Split('/').Last();

                        lnkSecondNav.Text = Cutted;
                    }

                    //if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    //    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}