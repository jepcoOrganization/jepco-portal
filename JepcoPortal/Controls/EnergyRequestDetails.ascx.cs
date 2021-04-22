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

public partial class Controls_EnergyRequestDetails : System.Web.UI.UserControl
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
            long ServiceUserID = SessionManager.GetInstance.Users.ID;
            if (Session["DetailsIDSessionID"] != null)
            {
                ResultEntity<RenewableEnergyUserRequestsDetailsEntity> DetailsEntity = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();
                DetailsEntity = RenewableEnergyUserRequestsDetailsDomain.GetByIDNotAsync(Convert.ToInt64(Session["DetailsIDSessionID"]));
                if(DetailsEntity.Status == ErrorEnums.Success)
                {
                    lbldate.Text = DetailsEntity.Entity.AddDate.ToString();
                    txtACPower.Text = DetailsEntity.Entity.ACPower;
                    txtDCPower.Text = DetailsEntity.Entity.DCPower;
                    //lblDate2.Text = DetailsEntity.Entity.AddDate.ToString();
                    lblDate2.Text = DetailsEntity.Entity.PublishDate.ToString("dd-MM-yyyy");
                    long CompanyUser = Convert.ToInt64(DetailsEntity.Entity.AddUser);                   
                    ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                    CompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(CompanyUser);
                    if(CompanyEntity.Status == ErrorEnums.Success)
                    {
                        //lblName.Text = CompanyEntity.Entity.CompanyName;
                        lblUSerName.Text = CompanyEntity.Entity.CompanyName;
                    }
                    //AddUser
                    ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> DetailsDevicesList = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();
                    DetailsDevicesList = RenewableEnergyUserRequestsDetailsDevicesDomain.GetAllNotAsync();
                    if (DetailsDevicesList.Status == ErrorEnums.Success)
                    {
                       
                        lstCompanyDevice.DataSource = DetailsDevicesList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == DetailsEntity.Entity.DetailsID).ToList();
                        lstCompanyDevice.DataBind();
                    }
                    ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> DetailsSollerList = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();
                    DetailsSollerList = RenewableEnergyUserRequestsDetailsSollarsDomain.GetAllNotAsync();
                    if (DetailsDevicesList.Status == ErrorEnums.Success)
                    {

                        lstCompanySoller.DataSource = DetailsSollerList.List.Where(s => s.RenewableEnergyUserRequestsDetailsID == DetailsEntity.Entity.DetailsID).ToList();
                        lstCompanySoller.DataBind();
                    }
                    ResultEntity<RenewableEnergyUserRequestsEntity> UserRequestsEntity = new ResultEntity<RenewableEnergyUserRequestsEntity>();
                    UserRequestsEntity = RenewableEnergyUserRequestsDomain.GetByIDNotAsync(DetailsEntity.Entity.UserRequestID);
                    if(UserRequestsEntity.Status == ErrorEnums.Success)
                    {
                        
                        long userRequst = UserRequestsEntity.Entity.UserID;

                        lblRefenceNo.Text = UserRequestsEntity.Entity.ReferenceNumber;
                        //lblName.Text = UserRequestsEntity.Entity.ReferenceNumber;
                        // lblName2.Text = UserRequestsEntity.Entity.ReferenceNumber;
                        if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "1")
                        {
                            lblENGType.Text = " صغير صافي قياس";
                            lblENGType2.Text = " صغير صافي قياس";
                        }
                        else if (UserRequestsEntity.Entity.RenwableEnergyTypeID == "2") {
                            lblENGType.Text = " كبير صافي قياس";
                            lblENGType2.Text = " كبير صافي قياس";
                        }
                        else {
                            lblENGType.Text = "عبور";
                            lblENGType2.Text = "عبور";
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



                        //lblENGType.Text = UserRequestsEntity.Entity.RenwableEnergyTypeID.ToString();
                        ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                        ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(userRequst);
                        {
                            txtFirstNAme.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                            txtMobileNo.Text = ServiceUserEntity.Entity.MobileNumber;
                            txtemail.Text = ServiceUserEntity.Entity.Email;
                            //lblUSerName.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                        }
                    }

                    #region Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value

                    try
                    {
                        ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> stepsValueResult = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
                        stepsValueResult = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain.GetAllByRequestIDNotAsync(DetailsEntity.Entity.UserRequestID);
                        if (stepsValueResult.Status == ErrorEnums.Success)
                        {
                            lstStepsValue.DataSource = stepsValueResult.List.Where(x => x.IsDelete == false).OrderBy(y => y.ID).ToList();
                            lstStepsValue.DataBind();
                        }
                    }
                    catch { }

                    #endregion
                }
                //ResultEntity<ServicesStepsEntity> StepsEntity = new ResultEntity<ServicesStepsEntity>();
                //StepsEntity = ServicesStepsDomain.GetByServiceIDNotAsync(Session["DetailsIDSessionID"].ToString());
                //if(StepsEntity.Status == ErrorEnums.Success)
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

                long DetailID = Convert.ToInt64(Session["DetailsIDSessionID"]);
                ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntity = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();
                TokenEntity = RenewableEnergyUserRequestsDetails_TokenDomain.GetAllNotAsync();
                if (TokenEntity.Status == ErrorEnums.Success)
                {
                    TokenEntity.List = TokenEntity.List.Where(q => q.DetailsID == DetailID).ToList();
                    lblName.Text = TokenEntity.List[0].TokenNo;
                    lblName2.Text = TokenEntity.List[0].TokenNo;
                }


            }
        }
        catch (Exception ex)
        {
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



    protected void lstStepsValue_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            try
            {
                string ImageUrl = ConfigurationManager.AppSettings["ImagePath"];
                HyperLink Attachment = (HyperLink)e.Item.FindControl("Attachment");
                HyperLink Attachment2 = (HyperLink)e.Item.FindControl("Attachment2");
                HyperLink Attachment3 = (HyperLink)e.Item.FindControl("Attachment3");               

                if (!string.IsNullOrEmpty(Attachment.NavigateUrl))
                {
                    Attachment.NavigateUrl = ImageUrl + Attachment.NavigateUrl;
                    string abcd = Attachment.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment.Text = "مرفق 1";
                }
                if (!string.IsNullOrEmpty(Attachment2.NavigateUrl))
                {
                    Attachment2.NavigateUrl = ImageUrl + Attachment2.NavigateUrl;
                    string abcd = Attachment2.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment2.Text = "مرفق 2";
                }
                if (!string.IsNullOrEmpty(Attachment3.NavigateUrl))
                {
                    Attachment3.NavigateUrl = ImageUrl + Attachment3.NavigateUrl;
                    string abcd = Attachment3.NavigateUrl;
                    string Cutted = abcd.Split('/').Last();

                    Attachment3.Text = "مرفق 3";
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyRequestsList", false);
    }
}