using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_EnergyRequestUserDetails : System.Web.UI.UserControl
{
    int LangCount = 1;
    int SolarCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //string ServeceUserType = SessionManager.GetInstance.Users.UserType;
                //if (ServeceUserType != "2")
                //{
                //    FillUserRequst();

                //}
                //else
                //{

                //    FillCompanyRequst();

                //    //Response.Redirect("~/Default.aspx", false);
                //}
                //Session["DetailsIDSessionID"] = "7";
                FillUserRequestData();




            }
        }
        catch
        {
        }
    }

    protected void FillUserRequestData()
    {
        try
        {


            // Get From RenewableEnergyUserRequestsList

            long ServiceUserID = SessionManager.GetInstance.Users.ID;
            if (Session["RenwableEnergyIDSessionID"] != null)
            {

                long DetailsID = 0;
                ResultEntity<RenewableEnergyUserRequestsEntity> UserRequestsEntity = new ResultEntity<RenewableEnergyUserRequestsEntity>();
                UserRequestsEntity = RenewableEnergyUserRequestsDomain.GetByIDNotAsync(Convert.ToInt64(Session["RenwableEnergyIDSessionID"]));
                if (UserRequestsEntity.Status == ErrorEnums.Success)
                {
                    long RequuestId = UserRequestsEntity.Entity.RenwableEnergyID;
                    long CompanyID = UserRequestsEntity.Entity.CompanyID;
                    

                    lbldate.Text = UserRequestsEntity.Entity.AddDate.ToString();
                    lblMeterStus.Text = UserRequestsEntity.Entity.ReferenceNumber;
                    lblRefenceNo.Text = UserRequestsEntity.Entity.ReferenceNumber;
                    if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "1")
                    {
                        lblENGType.Text = " صغير صافي قياس";
                        lblENGType2.Text = " صغير صافي قياس";
                    }
                    else if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "2")
                    {
                        lblENGType.Text = " كبير صافي قياس";
                        lblENGType2.Text = " كبير صافي قياس";
                    }
                    else
                    {
                        lblENGType.Text = "تصريح عبور اولي";
                        lblENGType2.Text = "تصريح عبور اولي";
                    }


                    if (UserRequestsEntity.Entity.MeterStatus == "1")
                    {
                        lblMeterStus.Text = "عداد عامل";
                        
                    }
                    else if (UserRequestsEntity.Entity.MeterStatus == "2")
                    {
                        lblMeterStus.Text = "عداد جديد";
                       
                    }
                    else
                    {
                        lblMeterStus.Text = "مبنى قيد الانشاء";
                        lblRefenceNo.Text = "غير متوفر";
                    }

                    if (lblENGType.Text == "تصريح عبور اولي")
                    {
                        liMeterStatus.Style.Add("display", "none");
                    }
                    else
                    {
                        liMeterStatus.Style.Add("display", "inline-block");
                    }


                    //Get Company Data 
                    ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                    CompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(CompanyID);
                    if (CompanyEntity.Status == ErrorEnums.Success)
                    {
                        txtFirstNAme.Text = CompanyEntity.Entity.CompanyName;
                        txtNatinalNo.Text = CompanyEntity.Entity.CompanyNationalID;
                        txtMobileNo.Text = CompanyEntity.Entity.MobileNumber;
                        txtemail.Text = CompanyEntity.Entity.EmailAddress;


                    }


                    ResultList<RenewableEnergyUserRequestsDetailsEntity> DetialList = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                    DetialList = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                    if (DetialList.Status == ErrorEnums.Success)
                    {
                        DetialList.List = DetialList.List.Where(s => s.UserRequestID == RequuestId).OrderByDescending(s => s.DetailsID).ToList();

                        long detailid = DetialList.List[0].DetailsID;

                        txtACPower.Text = DetialList.List[0].ACPower;
                        txtDCPower.Text = DetialList.List[0].DCPower;

                        ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntityList = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();
                        TokenEntityList = RenewableEnergyUserRequestsDetails_TokenDomain.GetAllNotAsync();

                        if (TokenEntityList.Status == ErrorEnums.Success)
                        {
                            TokenEntityList.List = TokenEntityList.List.Where(s => s.DetailsID == detailid).ToList();
                            lblName.Text = TokenEntityList.List[0].TokenNo;

                        }
                        else
                        {
                            lblName.Text = "غير محدد";
                        }

                        ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> DetailsDevicesList = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();
                        DetailsDevicesList = RenewableEnergyUserRequestsDetailsDevicesDomain.GetAllNotAsync();
                        if (DetailsDevicesList.Status == ErrorEnums.Success)
                        {

                            lstCompanyDevice.DataSource = DetailsDevicesList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == detailid).ToList();
                            lstCompanyDevice.DataBind();
                        }
                        ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> DetailsSollerList = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();
                        DetailsSollerList = RenewableEnergyUserRequestsDetailsSollarsDomain.GetAllNotAsync();
                        if (DetailsDevicesList.Status == ErrorEnums.Success)
                        {

                            lstCompanySoller.DataSource = DetailsSollerList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == detailid).ToList();
                            lstCompanySoller.DataBind();
                        }

                    }
                    else
                    {
                        lblName.Text = "غير محدد";
                    }




                    //ResultList<RenewableEnergyUserRequestsDetailsEntity> DetailsList = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                    //DetailsList = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                    //if(DetailsList.Status == ErrorEnums.Success)
                    //{
                    //    DetailsList.List = DetailsList.List.Where(s => s.UserRequestID == UserRequestsEntity.Entity.RenwableEnergyID).OrderByDescending(s => s.DetailsID).ToList();
                    //   // long CompanyID = DetailsList.List[0].CompanyUserID;
                    //    DetailsID = DetailsList.List[0].DetailsID;

                    //}
                }
                else
                {
                    lblName.Text = "غير محدد";
                }


                //ResultEntity<RenewableEnergyUserRequestsDetailsEntity> DetailsEntity = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();
                //DetailsEntity = RenewableEnergyUserRequestsDetailsDomain.GetByIDNotAsync(Convert.ToInt64(Session["DetailsIDSessionID"]));
                //if (DetailsEntity.Status == ErrorEnums.Success)
                //{
                //    lbldate.Text = DetailsEntity.Entity.AddDate.ToString();
                //    txtACPower.Text = DetailsEntity.Entity.ACPower;
                //    txtDCPower.Text = DetailsEntity.Entity.DCPower;
                //    lblDate2.Text = DetailsEntity.Entity.AddDate.ToString();
                //    long CompanyUser = Convert.ToInt64(DetailsEntity.Entity.AddUser);
                //    ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                //    CompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(CompanyUser);
                //    if (CompanyEntity.Status == ErrorEnums.Success)
                //    {
                //        //lblName.Text = CompanyEntity.Entity.CompanyName;
                //    }
                //    //AddUser
                //    ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> DetailsDevicesList = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();
                //    DetailsDevicesList = RenewableEnergyUserRequestsDetailsDevicesDomain.GetAllNotAsync();
                //    if (DetailsDevicesList.Status == ErrorEnums.Success)
                //    {

                //        lstCompanyDevice.DataSource = DetailsDevicesList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == DetailsEntity.Entity.DetailsID).ToList();
                //        lstCompanyDevice.DataBind();
                //    }
                //    ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> DetailsSollerList = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();
                //    DetailsSollerList = RenewableEnergyUserRequestsDetailsSollarsDomain.GetAllNotAsync();
                //    if (DetailsDevicesList.Status == ErrorEnums.Success)
                //    {

                //        lstCompanySoller.DataSource = DetailsSollerList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == DetailsEntity.Entity.DetailsID).ToList();
                //        lstCompanySoller.DataBind();
                //    }
                //    ResultEntity<RenewableEnergyUserRequestsEntity> UserRequestsEntity = new ResultEntity<RenewableEnergyUserRequestsEntity>();
                //    UserRequestsEntity = RenewableEnergyUserRequestsDomain.GetByIDNotAsync(DetailsEntity.Entity.UserRequestID);
                //    if (UserRequestsEntity.Status == ErrorEnums.Success)
                //    {

                //        long userRequst = UserRequestsEntity.Entity.UserID;
                //        //lblName.Text = UserRequestsEntity.Entity.ReferenceNumber;
                //        // lblName2.Text = UserRequestsEntity.Entity.ReferenceNumber;
                //        if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "1")
                //        {
                //            lblENGType.Text = " صغير صافي قياس";
                //            lblENGType2.Text = " صغير صافي قياس";
                //        }
                //        else if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "2")
                //        {
                //            lblENGType.Text = " كبير صافي قياس";
                //            lblENGType2.Text = " كبير صافي قياس";
                //        }
                //        else
                //        {
                //            lblENGType.Text = "عبور";
                //            lblENGType2.Text = "عبور";
                //        }
                //        //lblENGType.Text = UserRequestsEntity.Entity.RenwableEnergyTypeID.ToString();
                //        ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                //        ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(userRequst);
                //        {
                //            txtFirstNAme.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                //            txtMobileNo.Text = ServiceUserEntity.Entity.MobileNumber;
                //            txtemail.Text = ServiceUserEntity.Entity.Email;
                //            lblUSerName.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                //        }
                //    }
                //}
                //ResultEntity<ServicesStepsEntity> StepsEntity = new ResultEntity<ServicesStepsEntity>();
                //StepsEntity = ServicesStepsDomain.GetByServiceIDNotAsync(Session["DetailsIDSessionID"].ToString());
                //if (StepsEntity.Status == ErrorEnums.Success)
                //{
                //    long Stepid = StepsEntity.Entity.StepID;

                //    ResultList<ServicesStepsValuesEntity> StepsValuesEntity = new ResultList<ServicesStepsValuesEntity>();
                //    StepsValuesEntity = ServicesStepsValuesDomain.GetAllNotAsync();
                //    if (StepsValuesEntity.Status == ErrorEnums.Success)
                //    {
                //        StpeValueUnDone.DataSource = StepsValuesEntity.List.Where(s => s.StepID == Stepid && s.IsDone == false).ToList();
                //        StpeValueUnDone.DataBind();
                //        StpeValueDone.DataSource = StepsValuesEntity.List.Where(s => s.StepID == Stepid && s.IsDone == true).ToList();
                //        StpeValueDone.DataBind();
                //    }
                //}

                //long DetailID = Convert.ToInt64(Session["DetailsIDSessionID"]);
                //ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntity = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();
                //TokenEntity = RenewableEnergyUserRequestsDetails_TokenDomain.GetAllNotAsync();
                //if (TokenEntity.Status == ErrorEnums.Success)
                //{
                //    TokenEntity.List = TokenEntity.List.Where(q => q.DetailsID == DetailID).ToList();
                //    lblName.Text = TokenEntity.List[0].TokenNo;
                //    lblName2.Text = TokenEntity.List[0].TokenNo;
                //}


            }
        }
        catch (Exception ex)
        {
            lblName.Text = "غير محدد";
        }
    }

    protected void lstCompanyDevice_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lstCompanySoller_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");
            }
        }
        catch (Exception ex)
        {
        }
    }
}