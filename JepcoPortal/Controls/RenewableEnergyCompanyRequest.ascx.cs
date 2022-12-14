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

public partial class Controls_RenewableEnergyCompanyRequest : System.Web.UI.UserControl
{
    int LangCount = 1;
    int SolarCount = 1;
    int callfirst;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                FillUserRequestData();
                fillUserDataDropdown();
                callfirst = 1;
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
            if (Session["RenwableEnergyIDSessionID"] != null)
            {
                long getUserRequestsID = Convert.ToInt64(Session["RenwableEnergyIDSessionID"]);
                ResultEntity<RenewableEnergyUserRequestsEntity> res = new ResultEntity<RenewableEnergyUserRequestsEntity>();
                res = RenewableEnergyUserRequestsDomain.GetByIDNotAsync(getUserRequestsID);
                if (res.Status == ErrorEnums.Success)
                {

                     hdnAcceptStatus.Value = Convert.ToInt32(res.Entity.CompanyAcceptedStatus).ToString();
                    //if (res.Entity.CompanyAcceptedStatus)
                    //{
                    //    rblRenwableEnergyType.Enabled = true;
                    //    txtEngDetial.Enabled = true;
                    //    txtTotalPower.Enabled = true;
                    //    txtACVal.Enabled = true;
                    //    txtDCVal.Enabled = true;

                    //}
                    //else
                    //{
                    //    rblRenwableEnergyType.Enabled = false;
                    //    txtEngDetial.Enabled = false;
                    //    txtTotalPower.Enabled = false;
                    //    txtACVal.Enabled = false;
                    //    txtDCVal.Enabled = false;
                    //}


                    FileNumber.Text = res.Entity.ReferenceNumber;
                        TypeRequst.Text = res.Entity.RenwableEnergyTypeID;

                        //rblRenwableRequest.SelectedItem.Value = res.Entity.RenwableEnergyTypeID;

                        rblRenwableRequest.SelectedValue = res.Entity.RenwableEnergyTypeID;

                        Counter.Text = res.Entity.MeterStatus;
                        rblMeterStatus.SelectedValue = res.Entity.MeterStatus;

                        if (res.Entity.MeterStatus == "1")
                        {
                            lblRefenceTitle.Text = "رقم الطلب ";
                        }
                        else if (res.Entity.MeterStatus == "2")
                        {
                            lblRefenceTitle.Text = "رقم العداد ";
                        }
                        else
                        {
                            lblRefenceTitle.Text = "";
                        }

                        ReferenceNo.Text = res.Entity.RefeenceType;
                        rbdRefeenceType.SelectedValue = res.Entity.RefeenceType;
                        long getUSerID = res.Entity.UserID;
                        ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                        ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(getUSerID);
                        {
                            hndFromUser.Value = ServiceUserEntity.Entity.ID.ToString();
                            txtFirstNAme.Text = ServiceUserEntity.Entity.FirstName;
                            txtSecondName.Text = ServiceUserEntity.Entity.SecondName;
                            txtThirdName.Text = ServiceUserEntity.Entity.ThirdName;
                            txtLastName.Text = ServiceUserEntity.Entity.FamilyName;
                            int cityId = ServiceUserEntity.Entity.City;
                            int area1id = ServiceUserEntity.Entity.Area1;
                            int Area2id = ServiceUserEntity.Entity.Area2;
                            ResultList<Lookup_CityEntity> CityEntity = new ResultList<Lookup_CityEntity>();
                            CityEntity = Lookup_CityDomain.GetLookupCityAllNotAsync();
                            //Result = Plugin_AboutCompanyDomain.GetAll();
                            if (CityEntity.Status == ErrorEnums.Success)
                            {
                                CityEntity.List = CityEntity.List.Where(s => s.CityID == cityId).ToList();
                                txtGovernal.Text = CityEntity.List[0].CityName;
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
                            txtStret.Text = ServiceUserEntity.Entity.Address;

                            if (res.Entity.RenwableEnergyTypeID == "3")
                            {
                                txtRequstName.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                                txtTelePhoneno.Text = ServiceUserEntity.Entity.MobileNumber;
                                txtEmailAdd.Text = ServiceUserEntity.Entity.Email;
                            }
                        }
                    
                   
                }                
            }



        }
        catch (Exception ex)
        {
        }
    }

    protected void fillUserDataDropdown()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
            RenwabaleEnergyCompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
            if (RenwabaleEnergyCompanyEntity.Status == ErrorEnums.Success)
            {
                ddlUSerType.Items.Insert(0, new ListItem("اختيار المفوض", "0"));
                //List<long> UserIDs = new List<long>();

                long companyId = RenwabaleEnergyCompanyEntity.Entity.RenwabaleEnergyCompanyID;

                ResultList<RenewableEnergyCompanyUserEntity> res = new ResultList<RenewableEnergyCompanyUserEntity>();
                res = RenewableEnergyCompanyUserDomain.GetAllNotAsync();
                if (res.Status == ErrorEnums.Success)
                {

                    var CompanyUSerList = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.CompanyID == companyId).OrderByDescending(s => s.RenewableEnergyCompanyUserID).ToList();

                    foreach (var item in CompanyUSerList)
                    {
                        ddlUSerType.Items.Add(new ListItem(item.FirstName.ToString() + " " + item.FatherName.ToString() + " " + item.FamilyName.ToString(), item.RenewableEnergyCompanyUserID.ToString()));
                        //ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                        //ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(item);
                        //if (ServiceUserEntity.Status == ErrorEnums.Success)
                        //{
                        //    ddlUSerType.Items.Add(new ListItem(ServiceUserEntity.Entity.FirstName.ToString() + " " + ServiceUserEntity.Entity.SecondName.ToString() + " " + ServiceUserEntity.Entity.FamilyName.ToString(), ServiceUserEntity.Entity.ID.ToString()));
                        //}
                    }

                }



                //ResultList<RenewableEnergyUserRequestsEntity> EnergyUserRequestsEntity = new ResultList<RenewableEnergyUserRequestsEntity>();
                //EnergyUserRequestsEntity = RenewableEnergyUserRequestsDomain.GetAllNotAsync();
                //if (EnergyUserRequestsEntity.Status == ErrorEnums.Success)
                //{ 
                //    foreach (RenewableEnergyUserRequestsEntity item in EnergyUserRequestsEntity.List.Where(s => s.CompanyID == companyId))
                //    {
                //        UserIDs.Add(item.UserID);
                //    }
                //}

                //foreach (var item in UserIDs)
                //{
                //    ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                //    ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(item);
                //    if (ServiceUserEntity.Status == ErrorEnums.Success)
                //    {
                //        ddlUSerType.Items.Add(new ListItem(ServiceUserEntity.Entity.FirstName.ToString() + " " + ServiceUserEntity.Entity.SecondName.ToString() + " " + ServiceUserEntity.Entity.FamilyName.ToString(), ServiceUserEntity.Entity.ID.ToString()));
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void ddlUSerType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            

            long USerTypeID = Convert.ToInt32(ddlUSerType.SelectedValue);


            ResultList<RenewableEnergyCompanyUserEntity> CompanyUserEntity = new ResultList<RenewableEnergyCompanyUserEntity>();
            CompanyUserEntity = RenewableEnergyCompanyUserDomain.GetAllNotAsync();
            if (CompanyUserEntity.Status == ErrorEnums.Success)
            {
                lstUSerData.DataSource = CompanyUserEntity.List.Where(s => s.RenewableEnergyCompanyUserID == USerTypeID).ToList();
                lstUSerData.DataBind();
            }



            //ResultList<Plugin_ServiceUserEntity> ServiceProviderEntity = new ResultList<Plugin_ServiceUserEntity>();
            //ServiceProviderEntity = Plugin_ServiceUserDomain.GetAllNotAsync();
            //if(ServiceProviderEntity.Status == ErrorEnums.Success)
            //{

            //    lstUSerData.DataSource = null;

            //    lstUSerData.DataSource = ServiceProviderEntity.List.Where(s => s.ID == USerTypeID).ToList();
            //    lstUSerData.DataBind();
            //}

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void lstUSerData_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                Image imgProfileimge = (Image)e.Item.FindControl("imgProfileimge");


                if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");

                if (!string.IsNullOrEmpty(imgProfileimge.ImageUrl)) { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgProfileimge.ImageUrl.Replace("~/", "~/Siteware/"); }
                else { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + "/Siteware/Siteware_File/image/JEPCO//Profile_pic.png"; }

            }
        }
        catch (Exception ex)
        {
        }
    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        try
        {


            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            //    //---******* (For Local) ******-------------------------
            string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

            //    //---------------******* (For Live) ******-------------------------
            //string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

            string guid = Guid.NewGuid().ToString().Substring(0, 6);

            RenewableEnergyUserRequestsDetailsEntity Entity = new RenewableEnergyUserRequestsDetailsEntity();
            //Entity.DetailsID = 
            Entity.UserRequestID = Convert.ToInt64(Session["RenwableEnergyIDSessionID"]);
            Page.Response.Write("<script>console.log(' User Requ : " + Entity.UserRequestID + "' );</script>");
            Entity.EnergyType = Convert.ToInt32(rblRenwableEnergyType.SelectedItem.Value);
            if (Convert.ToInt32(rblRenwableEnergyType.SelectedItem.Value) == 3)
            {
                Entity.EnergyTypeOther = txtEngDetial.Text;
            }
            else
            {
                Entity.EnergyTypeOther = "";
            }


            Entity.PowerType = Convert.ToInt32(rblRenwablePowerType.SelectedItem.Value);
            Entity.CompanyUserID = Convert.ToInt64(ddlUSerType.SelectedValue);
            Entity.ACPower = txtACVal.Text;
            Entity.DCPower = txtDCVal.Text;


            Entity.IsAgree = true;
            Entity.Order = 0;
            Entity.LanguageID = 2;
            Entity.PublishDate = DateTime.Now;
            Entity.IsPublished = true;
            Entity.IsDeleted = false;
            Entity.AddDate = DateTime.Now;
            Entity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
            Entity.EditDate = DateTime.Now;
            Entity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files1 = Request.Files["fileuploadfield_1"];
                if (files1 != null)
                {

                    if (files1.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files1.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files1.SaveAs(dir + files1.FileName);

                    }
                    else
                    {
                        Entity.Attachment1 = string.Empty;

                    }
                }
                else
                {
                    Entity.Attachment1 = string.Empty;

                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfield_1 :" + exp.Message + "');</script>");
                Page.Response.Write("<script>console.log('fileuploadfield_1  " + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files2 = Request.Files["fileuploadfield_2"];
                if (files2 != null)
                {

                    if (files2.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.Attachment2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files2.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files2.SaveAs(dir + files2.FileName);

                    }
                    else
                    {
                        Entity.Attachment2 = string.Empty;

                    }
                }
                else
                {
                    Entity.Attachment2 = string.Empty;

                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfield_2 :" + exp.Message + "');</script>");
                Page.Response.Write("<script>console.log('fileuploadfield_2  " + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files3 = Request.Files["fileuploadfield_3"];
                if (files3 != null)
                {

                    if (files3.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.Attachment3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files3.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files3.SaveAs(dir + files3.FileName);

                    }
                    else
                    {
                        Entity.Attachment3 = string.Empty;

                    }
                }
                else
                {
                    Entity.Attachment3 = string.Empty;

                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfield_3 :" + exp.Message + "');</script>");
                Page.Response.Write("<script>console.log('fileuploadfield_3  " + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files4 = Request.Files["fileuploadfield_4"];
                if (files4 != null)
                {

                    if (files4.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.Attachment4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files4.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files4.SaveAs(dir + files4.FileName);

                    }
                    else
                    {
                        Entity.Attachment4 = string.Empty;
                            
                    }
                }
                else
                {
                    Entity.Attachment4 = string.Empty;

                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                Page.Response.Write("<script>console.log('fileuploadfield_4  " + exp.Message + "');</script>");
            }

            var Result = RenewableEnergyUserRequestsDetailsDomain.InsertRecordNotAsync(Entity);

            //string abcd = Result.Details;
            //string abcd2 = abcd.Replace("'", "");
            //string abcd3 = abcd2.Replace('"',' ');

            //Page.Response.Write("<script>console.log(' Result  1:  " + abcd3 + " ');</script>");
            //Page.Response.Write("<script>console.log(' Result  2:  " + Result.Status + " ');</script>");



            if (Result.Status == ErrorEnums.Success)
            {

                Page.Response.Write("<script>console.log(' Details Succusee ID : " + Result.Entity.DetailsID + "');</script>");
                //Console.Write("<script>console.log('Details Succusee ID :" + Result.Entity.DetailsID + "');</script>");

                


                #region When rblRenwableRequest == 3

                if (rblRenwableRequest.SelectedValue == "3")
                {

                    #region  Details
                    //DateTime a = DateTime.Now;

                    RenwableEnergyType3Phase1DetailsEntity Type3Phase1DetailsEntity = new RenwableEnergyType3Phase1DetailsEntity();

                    
                    Type3Phase1DetailsEntity.DetailsID = Result.Entity.DetailsID;
                    Type3Phase1DetailsEntity.IsApproved = false;
                    //Type3Phase1DetailsEntity.ApprovedDate = DateTime.Now;
                    Type3Phase1DetailsEntity.TotalPower = txtTotalPower.Text;
                    Type3Phase1DetailsEntity.AddDate = DateTime.Now;
                    Type3Phase1DetailsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                    Type3Phase1DetailsEntity.EditDate = DateTime.Now;
                    Type3Phase1DetailsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();
                    var DetailsInsert = RenwableEnergyType3Phase1DetailsDomain.InsertRecordNotAsync(Type3Phase1DetailsEntity);
                    if (DetailsInsert.Status == ErrorEnums.Success)
                    { }

                    #endregion


                    #region Location 

                    //hdnLocationCoun==============


                    string LocationNameST = string.Empty;
                    string GovernateST = string.Empty;
                    string Area1ST = string.Empty;
                    string Area2ST = string.Empty;
                    string Area3ST = string.Empty;
                    string AreaNumberST = string.Empty;
                    string LongitudeST = string.Empty;
                    string LatitudeST = string.Empty;

                    if (!string.IsNullOrEmpty(hdnLocationCount.Value))
                    {
                        LangCount = Convert.ToInt32(hdnLocationCount.Value);
                    }
                    if (LangCount >= 2)
                    {

                        for (int i = 0; i < LangCount; i++)
                        {
                            try
                            {
                                if (i == 0)
                                {
                                }
                                else if (i == 1)
                                {

                                    LocationNameST = Request.Form.Get("txtLocationName_" + i);
                                    GovernateST = Request.Form.Get("txtGovernate_" + i);
                                    Area1ST = Request.Form.Get("txtArea1_" + i);
                                    Area2ST = Request.Form.Get("txtArea2_" + i);
                                    Area3ST = Request.Form.Get("txtArea3_" + i);
                                    AreaNumberST = Request.Form.Get("txtAreaNumber_" + i);
                                    LongitudeST = Request.Form.Get("txtLongitude_" + i);
                                    LatitudeST = Request.Form.Get("txtLatitude_" + i);

                                    RenwableEnergyType3Phase1LocationsEntity Type3Phase1LocationsEntity = new RenwableEnergyType3Phase1LocationsEntity();
                                    //LocationsEntity.Type3Phase1LocationsID;
                                    Type3Phase1LocationsEntity.DetailsID = Result.Entity.DetailsID;
                                    Type3Phase1LocationsEntity.LocationName = LocationNameST;
                                    Type3Phase1LocationsEntity.Governate = GovernateST;
                                    Type3Phase1LocationsEntity.Area1 = Area1ST;
                                    Type3Phase1LocationsEntity.Area2 = Area2ST;
                                    Type3Phase1LocationsEntity.Area3 = Area3ST;
                                    Type3Phase1LocationsEntity.AreaNumber = AreaNumberST;
                                    Type3Phase1LocationsEntity.Longitude = LongitudeST;
                                    Type3Phase1LocationsEntity.Latitude = LatitudeST;
                                    Type3Phase1LocationsEntity.AddDate =  DateTime.Now;
                                    Type3Phase1LocationsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1LocationsEntity.EditDate =  DateTime.Now;
                                    Type3Phase1LocationsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    try
                                    {
                                        //Here string ABCd is Entity of Table
                                        HttpPostedFile Thisfiles = Request.Files["fileuploadfieldLocation_" + i];
                                        if (Thisfiles != null)
                                        {
                                            if (Thisfiles.FileName != "") // If file is Selected File
                                            {
                                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                                //Entity.ChildPassport = dir + files1.FileName;

                                                Type3Phase1LocationsEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;

                                                if (!Directory.Exists(dir))
                                                {
                                                    Directory.CreateDirectory(dir);
                                                }
                                                Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                            }
                                            else
                                            {
                                                Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                                            }
                                        }
                                        else
                                        {
                                            Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                                        }
                                    }
                                    catch (Exception exp)
                                    {
                                        Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                                    }


                                    var LocationsInsert = RenwableEnergyType3Phase1LocationsDomain.InsertRecordNotAsync(Type3Phase1LocationsEntity);
                                    if (LocationsInsert.Status == ErrorEnums.Success)
                                    { }


                                }
                                else
                                {


                                    RenwableEnergyType3Phase1LocationsEntity Type3Phase1LocationsEntity = new RenwableEnergyType3Phase1LocationsEntity();

                                    LocationNameST = Request.Form.Get("txtLocationName_" + i);
                                    GovernateST = Request.Form.Get("txtGovernate_" + i);
                                    Area1ST = Request.Form.Get("txtArea1_" + i);
                                    Area2ST = Request.Form.Get("txtArea2_" + i);
                                    Area3ST = Request.Form.Get("txtArea3_" + i);
                                    AreaNumberST = Request.Form.Get("txtAreaNumber_" + i);
                                    LongitudeST = Request.Form.Get("txtLongitude_" + i);
                                    LatitudeST = Request.Form.Get("txtLatitude_" + i);

                                    Type3Phase1LocationsEntity.DetailsID = Result.Entity.DetailsID;
                                    Type3Phase1LocationsEntity.LocationName = LocationNameST;
                                    Type3Phase1LocationsEntity.Governate = GovernateST;
                                    Type3Phase1LocationsEntity.Area1 = Area1ST;
                                    Type3Phase1LocationsEntity.Area2 = Area2ST;
                                    Type3Phase1LocationsEntity.Area3 = Area3ST;
                                    Type3Phase1LocationsEntity.AreaNumber = AreaNumberST;
                                    Type3Phase1LocationsEntity.Longitude = LongitudeST;
                                    Type3Phase1LocationsEntity.Latitude = LatitudeST;
                                    Type3Phase1LocationsEntity.AddDate = DateTime.Now;
                                    Type3Phase1LocationsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1LocationsEntity.EditDate = DateTime.Now;
                                    Type3Phase1LocationsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    try
                                    {
                                        //Here string ABCd is Entity of Table
                                        HttpPostedFile Thisfiles = Request.Files["fileuploadfieldLocation_" + i];
                                        if (Thisfiles != null)
                                        {
                                            if (Thisfiles.FileName != "") // If file is Selected File
                                            {
                                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                                //Entity.ChildPassport = dir + files1.FileName;

                                                Type3Phase1LocationsEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;

                                                if (!Directory.Exists(dir))
                                                {
                                                    Directory.CreateDirectory(dir);
                                                }
                                                Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                            }
                                            else
                                            {
                                                Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                                            }
                                        }
                                        else
                                        {
                                            Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                                        }
                                    }
                                    catch (Exception exp)
                                    {
                                        Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                                    }

                                    var LocationsInsert = RenwableEnergyType3Phase1LocationsDomain.InsertRecordNotAsync(Type3Phase1LocationsEntity);
                                    if (LocationsInsert.Status == ErrorEnums.Success)
                                    { }

                                }

                            }
                            catch { }



                        }
                    }
                    else
                    {

                        RenwableEnergyType3Phase1LocationsEntity Type3Phase1LocationsEntity = new RenwableEnergyType3Phase1LocationsEntity();

                        LocationNameST = Request.Form.Get("txtLocationName_1");
                        GovernateST = Request.Form.Get("txtGovernate_1");
                        Area1ST = Request.Form.Get("txtArea1_1");
                        Area2ST = Request.Form.Get("txtArea2_1");
                        Area3ST = Request.Form.Get("txtArea3_1");
                        AreaNumberST = Request.Form.Get("txtAreaNumber_1");
                        LongitudeST = Request.Form.Get("txtLongitude_1");
                        LatitudeST = Request.Form.Get("txtLatitude_1");


                        //DetailsDevicesEntity.ID 
                        Type3Phase1LocationsEntity.DetailsID = Result.Entity.DetailsID;
                        Type3Phase1LocationsEntity.LocationName = LocationNameST;
                        Type3Phase1LocationsEntity.Governate = GovernateST;
                        Type3Phase1LocationsEntity.Area1 = Area1ST;
                        Type3Phase1LocationsEntity.Area2 = Area2ST;
                        Type3Phase1LocationsEntity.Area3 = Area3ST;
                        Type3Phase1LocationsEntity.AreaNumber = AreaNumberST;
                        Type3Phase1LocationsEntity.Longitude = LongitudeST;
                        Type3Phase1LocationsEntity.Latitude = LatitudeST;
                        Type3Phase1LocationsEntity.AddDate = DateTime.Now;
                        Type3Phase1LocationsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                        Type3Phase1LocationsEntity.EditDate = DateTime.Now;
                        Type3Phase1LocationsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                        try
                        {
                            //Here string ABCd is Entity of Table
                            HttpPostedFile Thisfiles = Request.Files["fileuploadfieldLocation_1"];
                            if (Thisfiles != null)
                            {
                                if (Thisfiles.FileName != "") // If file is Selected File
                                {
                                    string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                    //Entity.ChildPassport = dir + files1.FileName;

                                    Type3Phase1LocationsEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;

                                    if (!Directory.Exists(dir))
                                    {
                                        Directory.CreateDirectory(dir);
                                    }
                                    Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                }
                                else
                                {
                                    Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                                }
                            }
                            else
                            {
                                Type3Phase1LocationsEntity.Attachment1 = string.Empty;
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                        }


                        var LocationsInsert = RenwableEnergyType3Phase1LocationsDomain.InsertRecordNotAsync(Type3Phase1LocationsEntity);
                        if (LocationsInsert.Status == ErrorEnums.Success)
                        { }

                    }


                    //=====================
                    #endregion

                    #region Meter 

                    
                    string NumberofConnectionST = string.Empty;
                    string NumberofConnectionNameST = string.Empty;
                    string MeterNumbeST = string.Empty;
                    string FileNumberST = string.Empty;
                    string MeterAddressST = string.Empty;

                    if (!string.IsNullOrEmpty(HdnMeterStatus.Value))
                    {
                        LangCount = Convert.ToInt32(HdnMeterStatus.Value);
                    }
                    if (LangCount >= 2)
                    {

                        for (int i = 0; i < LangCount; i++)
                        {
                            try
                            {
                                if (i == 0)
                                {
                                }
                                else if (i == 1)
                                {

                                    NumberofConnectionST = Request.Form.Get("txtNumberofConnection_1"); 
                                    //NumberofConnectionST = Request.Form.Get("txtNumberofConnection_" + i); 
                                    NumberofConnectionNameST = Request.Form.Get("txtNumberofConnectionName_" + i); 
                                    MeterNumbeST = Request.Form.Get("txtMeterNumber_" + i);
                                    FileNumberST = Request.Form.Get("txtFileNumber_" + i); 
                                    MeterAddressST = Request.Form.Get("txtMeterAddress_" + i);

                                    RenwableEnergyType3Phase1MetersDataEntity Type3Phase1MetersDataEntity = new RenwableEnergyType3Phase1MetersDataEntity();

                                    Type3Phase1MetersDataEntity.DetailsID = Result.Entity.DetailsID;
                                    Type3Phase1MetersDataEntity.NumberofConnection = NumberofConnectionST;
                                    Type3Phase1MetersDataEntity.Name = NumberofConnectionNameST;
                                    Type3Phase1MetersDataEntity.MeterNumber = MeterNumbeST;
                                    Type3Phase1MetersDataEntity.FileNumber = FileNumberST;
                                    Type3Phase1MetersDataEntity.MeterAddress = MeterAddressST;
                                    Type3Phase1MetersDataEntity.AddDate = DateTime.Now;
                                    Type3Phase1MetersDataEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1MetersDataEntity.EditDate = DateTime.Now;
                                    Type3Phase1MetersDataEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1MetersDataEntity.Attachment1 = string.Empty;

                                    try
                                    {
                                        //Here string ABCd is Entity of Table
                                        HttpPostedFile Thisfiles = Request.Files["fileuploadfieldMeter_" + i];
                                        if (Thisfiles != null)
                                        {                                            
                                            if (Thisfiles.FileName != "") // If file is Selected File
                                            {
                                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                                //Entity.ChildPassport = dir + files1.FileName;

                                                Type3Phase1MetersDataEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;
                                                
                                                if (!Directory.Exists(dir))
                                                {
                                                    Directory.CreateDirectory(dir);
                                                }
                                                Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                            }
                                            else
                                            {
                                                Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                                            }
                                        }
                                        else
                                        {
                                            Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                                        }
                                    }
                                    catch (Exception exp)
                                    {
                                        Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                                    }

                                    var MetersDataInsert = RenwableEnergyType3Phase1MetersDomain.InsertRecordNotAsync(Type3Phase1MetersDataEntity);
                                    if (MetersDataInsert.Status == ErrorEnums.Success)
                                    { }


                                }
                                else
                                {


                                    NumberofConnectionST = Request.Form.Get("txtNumberofConnection_1");
                                    NumberofConnectionNameST = Request.Form.Get("txtNumberofConnectionName_" + i);
                                    MeterNumbeST = Request.Form.Get("txtMeterNumber_" + i);
                                    FileNumberST = Request.Form.Get("txtFileNumber_" + i);
                                    MeterAddressST = Request.Form.Get("txtMeterAddress_" + i);

                                    RenwableEnergyType3Phase1MetersDataEntity Type3Phase1MetersDataEntity = new RenwableEnergyType3Phase1MetersDataEntity();

                                    Type3Phase1MetersDataEntity.DetailsID = Result.Entity.DetailsID;
                                    Type3Phase1MetersDataEntity.NumberofConnection = NumberofConnectionST;
                                    Type3Phase1MetersDataEntity.Name = NumberofConnectionNameST;
                                    Type3Phase1MetersDataEntity.MeterNumber = MeterNumbeST;
                                    Type3Phase1MetersDataEntity.FileNumber = FileNumberST;
                                    Type3Phase1MetersDataEntity.MeterAddress = MeterAddressST;
                                    Type3Phase1MetersDataEntity.AddDate = DateTime.Now;
                                    Type3Phase1MetersDataEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1MetersDataEntity.EditDate = DateTime.Now;
                                    Type3Phase1MetersDataEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();
                                    Type3Phase1MetersDataEntity.Attachment1 = string.Empty;

                                    try
                                    {
                                        //Here string ABCd is Entity of Table
                                        HttpPostedFile Thisfiles = Request.Files["fileuploadfieldMeter_" + i];
                                        if (Thisfiles != null)
                                        {
                                            if (Thisfiles.FileName != "") // If file is Selected File
                                            {
                                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                                //Entity.ChildPassport = dir + files1.FileName;

                                                Type3Phase1MetersDataEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;

                                                if (!Directory.Exists(dir))
                                                {
                                                    Directory.CreateDirectory(dir);
                                                }
                                                Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                            }
                                            else
                                            {
                                                Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                                            }
                                        }
                                        else
                                        {
                                            Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                                        }
                                    }
                                    catch (Exception exp)
                                    {
                                        Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                                    }

                                    var MetersDataInsert = RenwableEnergyType3Phase1MetersDomain.InsertRecordNotAsync(Type3Phase1MetersDataEntity);
                                    if (MetersDataInsert.Status == ErrorEnums.Success)
                                    { }

                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {

                        

                        NumberofConnectionST = Request.Form.Get("txtNumberofConnection_1");
                        NumberofConnectionNameST = Request.Form.Get("txtNumberofConnectionName_1");
                        MeterNumbeST = Request.Form.Get("txtMeterNumber_1");
                        FileNumberST = Request.Form.Get("txtFileNumber_1");
                        MeterAddressST = Request.Form.Get("txtMeterAddress_1");
                        RenwableEnergyType3Phase1MetersDataEntity Type3Phase1MetersDataEntity = new RenwableEnergyType3Phase1MetersDataEntity();

                        Type3Phase1MetersDataEntity.DetailsID = Result.Entity.DetailsID;
                        Type3Phase1MetersDataEntity.NumberofConnection = NumberofConnectionST;
                        Type3Phase1MetersDataEntity.Name = NumberofConnectionNameST;
                        Type3Phase1MetersDataEntity.MeterNumber = MeterNumbeST;
                        Type3Phase1MetersDataEntity.FileNumber = FileNumberST;
                        Type3Phase1MetersDataEntity.MeterAddress = MeterAddressST;
                        Type3Phase1MetersDataEntity.AddDate = DateTime.Now;
                        Type3Phase1MetersDataEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                        Type3Phase1MetersDataEntity.EditDate = DateTime.Now;
                        Type3Phase1MetersDataEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();
                        Type3Phase1MetersDataEntity.Attachment1 = string.Empty;

                        try
                        {
                            //Here string ABCd is Entity of Table
                            HttpPostedFile Thisfiles = Request.Files["fileuploadfieldMeter_1"];
                            if (Thisfiles != null)
                            {
                                if (Thisfiles.FileName != "") // If file is Selected File
                                {
                                    string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                    //Entity.ChildPassport = dir + files1.FileName;

                                    Type3Phase1MetersDataEntity.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + Thisfiles.FileName;

                                    if (!Directory.Exists(dir))
                                    {
                                        Directory.CreateDirectory(dir);
                                    }
                                    Thisfiles.SaveAs(dir + Thisfiles.FileName);
                                }
                                else
                                {
                                    Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                                }
                            }
                            else
                            {
                                Type3Phase1MetersDataEntity.Attachment1 = string.Empty;
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.Write("<script>console.log('fileuploadfield_4 :" + exp.Message + "');</script>");
                        }

                        var MetersDataInsert = RenwableEnergyType3Phase1MetersDomain.InsertRecordNotAsync(Type3Phase1MetersDataEntity);
                        if (MetersDataInsert.Status == ErrorEnums.Success)
                        { }

                    }

                    #endregion

                    #region Attechment 

                    RenwableEnergyType3Phase1AttachmentsEntity Type3Phase1AttachmentsEntity = new RenwableEnergyType3Phase1AttachmentsEntity();
                    //Type3Phase1AttachmentsEntity.Type3Phase1Attachments
                    Type3Phase1AttachmentsEntity.DetailsID = Result.Entity.DetailsID;


                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross1 = Request.Files["fileuploadCross_1"];
                        if (filesCross1 != null)
                        {

                            if (filesCross1.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross1.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross1.SaveAs(dir + filesCross1.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments1 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments1 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_1 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_1  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross2 = Request.Files["fileuploadCross_2"];
                        if (filesCross2 != null)
                        {

                            if (filesCross2.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross2.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross2.SaveAs(dir + filesCross2.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments2 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments2 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_2 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_2  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross3 = Request.Files["fileuploadCross_3"];
                        if (filesCross3 != null)
                        {

                            if (filesCross3.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross3.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross3.SaveAs(dir + filesCross3.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments3 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments3 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_3 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_3  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross4 = Request.Files["fileuploadCross_4"];
                        if (filesCross4 != null)
                        {

                            if (filesCross4.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross4.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross4.SaveAs(dir + filesCross4.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments4 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments4 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_1 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_1  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross5 = Request.Files["fileuploadCross_5"];
                        if (filesCross5 != null)
                        {

                            if (filesCross5.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments5 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross5.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross5.SaveAs(dir + filesCross5.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments5 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments5 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_1 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_1  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross6 = Request.Files["fileuploadCross_6"];
                        if (filesCross6 != null)
                        {

                            if (filesCross6.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments6 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross6.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross6.SaveAs(dir + filesCross6.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments6 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments6 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_6 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_6  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross7 = Request.Files["fileuploadCross_7"];
                        if (filesCross7 != null)
                        {

                            if (filesCross7.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments7 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross7.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross7.SaveAs(dir + filesCross7.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments7 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments7 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_7 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_7  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross8 = Request.Files["fileuploadCross_8"];
                        if (filesCross8 != null)
                        {

                            if (filesCross8.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments8 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross8.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross8.SaveAs(dir + filesCross8.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments8 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments8 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_8 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_8  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross9 = Request.Files["fileuploadCross_9"];
                        if (filesCross9 != null)
                        {

                            if (filesCross9.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments9 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross9.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross9.SaveAs(dir + filesCross9.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments9 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments9 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_9 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_9  " + exp.Message + "');</script>");
                    }

                    try
                    {
                        //Here string ABCd is Entity of Table

                        HttpPostedFile filesCross10 = Request.Files["fileuploadCross_10"];
                        if (filesCross10 != null)
                        {

                            if (filesCross10.FileName != "") // If file is Selected File
                            {

                                string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                                //Entity.ChildPassport = dir + files1.FileName;

                                Type3Phase1AttachmentsEntity.Attachments10 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + filesCross10.FileName;

                                //Insert ABCd to Entity
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                filesCross10.SaveAs(dir + filesCross10.FileName);

                            }
                            else
                            {
                                Type3Phase1AttachmentsEntity.Attachments10 = string.Empty;

                            }
                        }
                        else
                        {
                            Type3Phase1AttachmentsEntity.Attachments10 = string.Empty;

                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write("<script>console.log('fileuploadCross_10 :" + exp.Message + "');</script>");
                        Page.Response.Write("<script>console.log('fileuploadCross_10  " + exp.Message + "');</script>");
                    }

                    //Type3Phase1AttachmentsEntity.Attachments1 = 
                    //Type3Phase1AttachmentsEntity.Attachments2
                    //Type3Phase1AttachmentsEntity.Attachments3
                    //Type3Phase1AttachmentsEntity.Attachments4
                    //Type3Phase1AttachmentsEntity.Attachments5
                    //Type3Phase1AttachmentsEntity.Attachments6
                    //Type3Phase1AttachmentsEntity.Attachments7
                    //Type3Phase1AttachmentsEntity.Attachments8
                    //Type3Phase1AttachmentsEntity.Attachments9
                    //Type3Phase1AttachmentsEntity.Attachments10
                    Type3Phase1AttachmentsEntity.AddDate =  DateTime.Now;
                    Type3Phase1AttachmentsEntity.AddUser  = SessionManager.GetInstance.Users.ID.ToString();
                    Type3Phase1AttachmentsEntity.EditDate  = DateTime.Now;
                    Type3Phase1AttachmentsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                    var AttachmentsInsert = RenwableEnergyType3Phase1AttachmentsDomain.InsertRecordNotAsync(Type3Phase1AttachmentsEntity);
                    if(AttachmentsInsert.Status == ErrorEnums.Success)
                    {

                    }

                    #endregion

                    try {

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
                            string _toMail1 = ConfigurationManager.AppSettings["RenwableEnergyType3"].ToString();
                            //string _toMail2 = ConfigurationManager.AppSettings["ToMailSolarDeviceAdmin"].ToString();

                            bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                            string _ccMail = ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin1"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin2"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin3"].ToString();

                            //string bodyContent = SettingResult.List[0].RenewableDeviceUserMail;
                            //bodyContent = bodyContent.Replace("{Name}", "");
                            //bodyContent = bodyContent.Replace("{FormDetails}", "");
                            //string _Body = bodyContent;

                            string _Body = "You HAve a New Requset For RenebleRequestType 3";


                            //string _BodyForAdmin = "<h1>Company Device</h1>";

                            //string bodyContent2 = SettingResult.List[0].RenewableDeviceAdminMail;
                            //bodyContent2 = bodyContent2.Replace("{Name}", "");
                            //bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                            //string _Body2 = bodyContent2;

                            try
                            {

                                SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                                //SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                            }
                            catch { }

                        }
                        #endregion
                    }
                    catch
                    {

                    }

                    

                }
                else
                {
                    #region Device Detials

                    string diveceId = string.Empty;
                    string diveceNoOfUnit = string.Empty;
                    string divecePower = string.Empty;
                    string diveceName = string.Empty;
                    string documents = string.Empty;

                    if (!string.IsNullOrEmpty(hdnDeviceRowloopCount.Value))
                    {
                        LangCount = Convert.ToInt32(hdnDeviceRowloopCount.Value);
                    }
                    if (LangCount >= 2)
                    {

                        for (int i = 0; i < LangCount; i++)
                        {
                            try
                            {
                                if (i == 0)
                                {
                                }
                                else if (i == 1)
                                {
                                    //Response.Write("<script>console.log('Status:txtSiblingName_1')</script>");
                                    //langlevel = Request.Form.Get("ddlLevel_" + i);
                                    //Response.Write("<script>console.log('txtSiblingName_1:" + SiblingName.ToString() + "')</script>");

                                    //Response.Write("<script>console.log('Status:ddlsiblingYear_1')</script>");
                                    //languagenm = Request.Form["txLang_" + i];
                                    //Response.Write("<script>console.log('ddlsiblingYear_1:" + ddlsiblingYear.ToString() + "')</script>");

                                    //Response.Write("<script>console.log('Status:txtAge_1')</script>");
                                    // edsource = Request.Form.Get("txEduSource_" + i);
                                    //Response.Write("<script>console.log('txtAge_1:" + txtAge.ToString() + "')</script>");
                                    RenewableEnergyUserRequestsDetailsDevicesEntity DetailsDevicesEntity = new RenewableEnergyUserRequestsDetailsDevicesEntity();

                                    // diveceId = Request.Form.Get("ddlDivice_" + i);
                                    diveceId = Request.Form.Get("ddlDiviceModel_" + i);
                                    diveceNoOfUnit = Request.Form.Get("txtdeviceNoUnit_" + i);
                                    divecePower = Request.Form.Get("txtdevice_" + i);
                                    if (divecePower == null)
                                    {
                                        divecePower = "";
                                    }
                                    diveceName = Request.Form.Get("txtdeviceName_" + i);
                                    documents = Request.Form.Get("txtdeviceDocument_" + i);


                                    DetailsDevicesEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                                    DetailsDevicesEntity.DeviceID = Convert.ToInt64(diveceId);
                                    DetailsDevicesEntity.DeviceName = diveceName;
                                    DetailsDevicesEntity.DevicePower = divecePower;
                                    DetailsDevicesEntity.DeviceDocument = documents;
                                    DetailsDevicesEntity.NumberofUnits = diveceNoOfUnit;
                                    DetailsDevicesEntity.AddDate = DateTime.Now;
                                    DetailsDevicesEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    DetailsDevicesEntity.EditDate = DateTime.Now;
                                    DetailsDevicesEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    var DevicesResult = RenewableEnergyUserRequestsDetailsDevicesDomain.InsertRecordNotAsync(DetailsDevicesEntity);
                                    if (DevicesResult.Status == ErrorEnums.Success)
                                    { }


                                }
                                else
                                {
                                    //languagenm = Request.Form["txLang_" + i];
                                    //langlevel = Request.Form.Get("ddlLevel_" + i);
                                    //edsource = Request.Form.Get("txEduSource_" + i);

                                    //Plugin_PersonalLanguagesEntity PerLangEntity = new Plugin_PersonalLanguagesEntity();
                                    //PerLangEntity.PersonalID = Convert.ToInt32(PersonalID);

                                    //PerLangEntity.Language = languagenm;
                                    //PerLangEntity.LanguageLevel = langlevel;
                                    //PerLangEntity.EducationSource = edsource;
                                    //PerLangEntity.Order = 0;
                                    //PerLangEntity.LanguageID = 1;
                                    //PerLangEntity.PublishDate = DateTime.Now;
                                    //PerLangEntity.IsPublished = true;
                                    //PerLangEntity.IsDeleted = false;
                                    //PerLangEntity.AddDate = DateTime.Now;
                                    //PerLangEntity.AddUser = "9";
                                    //PerLangEntity.EditDate = DateTime.Now;
                                    //PerLangEntity.EditUser = "9";


                                    //var PerLangResult = Plugin_Personal_LanguagesDomain.InsertNotAsync(PerLangEntity);

                                    RenewableEnergyUserRequestsDetailsDevicesEntity DetailsDevicesEntity = new RenewableEnergyUserRequestsDetailsDevicesEntity();

                                    //diveceId = Request.Form.Get("ddlDivice_" + i);
                                    diveceId = Request.Form.Get("ddlDiviceModel_" + i);
                                    diveceNoOfUnit = Request.Form.Get("txtdeviceNoUnit_" + i);
                                    divecePower = Request.Form.Get("txtdevice_" + i);
                                    if (divecePower == null)
                                    {
                                        divecePower = "";
                                    }
                                    //if(!string.IsNullOrEmpty(divecePower))
                                    //{
                                    //    divecePower = "";
                                    //}

                                    diveceName = Request.Form.Get("txtdeviceName_" + i);
                                    documents = Request.Form.Get("txtdeviceDocument_" + i);


                                    DetailsDevicesEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                                    DetailsDevicesEntity.DeviceID = Convert.ToInt64(diveceId);
                                    DetailsDevicesEntity.DeviceName = diveceName;
                                    DetailsDevicesEntity.DevicePower = divecePower;
                                    DetailsDevicesEntity.DeviceDocument = documents;
                                    DetailsDevicesEntity.NumberofUnits = diveceNoOfUnit;
                                    DetailsDevicesEntity.AddDate = DateTime.Now;
                                    DetailsDevicesEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    DetailsDevicesEntity.EditDate = DateTime.Now;
                                    DetailsDevicesEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    var DevicesResult = RenewableEnergyUserRequestsDetailsDevicesDomain.InsertRecordNotAsync(DetailsDevicesEntity);
                                    if (DevicesResult.Status == ErrorEnums.Success)
                                    { }

                                }

                            }
                            catch { }



                        }
                    }
                    else
                    {

                        RenewableEnergyUserRequestsDetailsDevicesEntity DetailsDevicesEntity = new RenewableEnergyUserRequestsDetailsDevicesEntity();

                        //diveceId = Request.Form.Get("ddlDivice_1");
                        diveceId = Request.Form.Get("ddlDiviceModel_1");
                        diveceNoOfUnit = Request.Form.Get("txtdeviceNoUnit_1");
                        divecePower = Request.Form.Get("txtdevice_1");
                        if (divecePower == null)
                        {
                            divecePower = "";
                        }
                        diveceName = Request.Form.Get("txtdeviceName_1");
                        documents = Request.Form.Get("txtdeviceDocument_1");


                        //DetailsDevicesEntity.ID 
                        DetailsDevicesEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                        DetailsDevicesEntity.DeviceID = Convert.ToInt64(diveceId);
                        DetailsDevicesEntity.DeviceName = diveceName;
                        DetailsDevicesEntity.DevicePower = divecePower;
                        DetailsDevicesEntity.DeviceDocument = documents;
                        DetailsDevicesEntity.NumberofUnits = diveceNoOfUnit;
                        DetailsDevicesEntity.AddDate = DateTime.Now;
                        DetailsDevicesEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                        DetailsDevicesEntity.EditDate = DateTime.Now;
                        DetailsDevicesEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();


                        var DevicesResult = RenewableEnergyUserRequestsDetailsDevicesDomain.InsertRecordNotAsync(DetailsDevicesEntity);
                        if (DevicesResult.Status == ErrorEnums.Success)
                        { }

                    }


                    #endregion


                    #region Solar Detials

                    string SolarId = string.Empty;
                    string SolarNoOfUnit = string.Empty;
                    string SolarPower = string.Empty;
                    string SolarName = string.Empty;
                    string Solardocuments = string.Empty;

                    if (!string.IsNullOrEmpty(hdnSollerRowloopCount.Value))
                    {
                        SolarCount = Convert.ToInt32(hdnSollerRowloopCount.Value);
                    }
                    if (SolarCount >= 2)
                    {

                        for (int i = 0; i < SolarCount; i++)
                        {
                            try
                            {
                                if (i == 0)
                                {
                                }
                                else if (i == 1)
                                {

                                    RenewableEnergyUserRequestsDetailsSollarsEntity DetailsSollarsEntity = new RenewableEnergyUserRequestsDetailsSollarsEntity();

                                    //SolarId = Request.Form.Get("ddlSolarcell_" + i);
                                    SolarId = Request.Form.Get("ddlSollerCellModel_" + i);
                                    diveceNoOfUnit = Request.Form.Get("txtSellNoUnit_" + i);
                                    SolarPower = Request.Form.Get("txtSollerCell_" + i);
                                    if (SolarPower == null)
                                    {
                                        SolarPower = "";
                                    }
                                    SolarName = Request.Form.Get("txtSolarcellName_" + i);
                                    Solardocuments = Request.Form.Get("txtSolarcellDocument_" + i);
                                    if (string.IsNullOrEmpty(Solardocuments))
                                    {
                                        Solardocuments = string.Empty;
                                    }

                                    DetailsSollarsEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                                    DetailsSollarsEntity.SollarCellID = Convert.ToInt64(SolarId);
                                    DetailsSollarsEntity.SollarCellName = SolarName;
                                    DetailsSollarsEntity.SollarCellPower = SolarPower;
                                    DetailsSollarsEntity.SollarCellDocument = Solardocuments;
                                    DetailsSollarsEntity.NumberofUnits = diveceNoOfUnit;
                                    DetailsSollarsEntity.AddDate = DateTime.Now;
                                    DetailsSollarsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    DetailsSollarsEntity.EditDate = DateTime.Now;
                                    DetailsSollarsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    var DevicesResult = RenewableEnergyUserRequestsDetailsSollarsDomain.InsertRecordNotAsync(DetailsSollarsEntity);
                                    if (DevicesResult.Status == ErrorEnums.Success)
                                    { }


                                }
                                else
                                {
                                    RenewableEnergyUserRequestsDetailsSollarsEntity DetailsSollarsEntity = new RenewableEnergyUserRequestsDetailsSollarsEntity();

                                    //SolarId = Request.Form.Get("ddlSolarcell_" + i);
                                    SolarId = Request.Form.Get("ddlSollerCellModel_" + i);
                                    diveceNoOfUnit = Request.Form.Get("txtSellNoUnit_" + i);
                                    SolarPower = Request.Form.Get("txtSollerCell_" + i);
                                    if (SolarPower == null)
                                    {
                                        SolarPower = "";
                                    }

                                    SolarName = Request.Form.Get("txtSolarcellName_" + i);
                                    Solardocuments = Request.Form.Get("txtSolarcellDocument_" + i);
                                    if (string.IsNullOrEmpty(Solardocuments))
                                    {
                                        Solardocuments = string.Empty;
                                    }

                                    DetailsSollarsEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                                    DetailsSollarsEntity.SollarCellID = Convert.ToInt64(SolarId);
                                    DetailsSollarsEntity.SollarCellName = SolarName;
                                    DetailsSollarsEntity.SollarCellPower = SolarPower;
                                    DetailsSollarsEntity.SollarCellDocument = Solardocuments;
                                    DetailsSollarsEntity.NumberofUnits = diveceNoOfUnit;
                                    DetailsSollarsEntity.AddDate = DateTime.Now;
                                    DetailsSollarsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                                    DetailsSollarsEntity.EditDate = DateTime.Now;
                                    DetailsSollarsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                                    var DevicesResult = RenewableEnergyUserRequestsDetailsSollarsDomain.InsertRecordNotAsync(DetailsSollarsEntity);
                                    if (DevicesResult.Status == ErrorEnums.Success)
                                    { }

                                }

                            }
                            catch { }



                        }
                    }
                    else
                    {

                        RenewableEnergyUserRequestsDetailsSollarsEntity DetailsSollarsEntity = new RenewableEnergyUserRequestsDetailsSollarsEntity();

                        //SolarId = Request.Form.Get("ddlSolarcell_1");
                        SolarId = Request.Form.Get("ddlSollerCellModel_1");
                        diveceNoOfUnit = Request.Form.Get("txtSellNoUnit_1");
                        SolarPower = Request.Form.Get("txtSollerCell_1");
                        if (SolarPower == null)
                        {
                            SolarPower = "";
                        }

                        SolarName = Request.Form.Get("txtSolarcellName_1");
                        Solardocuments = Request.Form.Get("txtSolarcellDocument_1");
                        if (string.IsNullOrEmpty(Solardocuments))
                        {
                            Solardocuments = string.Empty;
                        }

                        //DetailsDevicesEntity.ID 
                        DetailsSollarsEntity.RenewableEnergyUserRequestsDetailsID = Result.Entity.DetailsID;
                        DetailsSollarsEntity.SollarCellID = Convert.ToInt64(SolarId);
                        DetailsSollarsEntity.SollarCellName = SolarName;
                        DetailsSollarsEntity.SollarCellPower = SolarPower;
                        DetailsSollarsEntity.SollarCellDocument = Solardocuments;
                        DetailsSollarsEntity.NumberofUnits = diveceNoOfUnit;
                        DetailsSollarsEntity.AddDate = DateTime.Now;
                        DetailsSollarsEntity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                        DetailsSollarsEntity.EditDate = DateTime.Now;
                        DetailsSollarsEntity.EditUser = SessionManager.GetInstance.Users.ID.ToString();


                        var DevicesResult = RenewableEnergyUserRequestsDetailsSollarsDomain.InsertRecordNotAsync(DetailsSollarsEntity);
                        if (DevicesResult.Status == ErrorEnums.Success)
                        { }

                    }




                    #endregion
                }

                #endregion


                #region Update


                try
                {

                    RenewableEnergyUserRequestsEntity UserRequestsEntity = new RenewableEnergyUserRequestsEntity();
                    UserRequestsEntity.RenwableEnergyID = Convert.ToInt64(Session["RenwableEnergyIDSessionID"]);
                    UserRequestsEntity.CompanyAcceptedStatus = true;
                    UserRequestsEntity.AcceptStatusDate = DateTime.Now;
                    UserRequestsEntity.AcceptStatusUser = SessionManager.GetInstance.Users.FirstName.ToString();

                    var UserRequestsEntityResult = RenewableEnergyUserRequestsDomain.UpdateAfterCompanyRequestNotAsync(UserRequestsEntity);
                    //if (Result.Status == ErrorEnums.Success)
                    //{

                    //}
                    Page.Response.Write("<script>console.log('Enetgy Update Succusee ID :  " + UserRequestsEntityResult.Entity.RenwableEnergyID + "');</script>");
                    Console.Write("<script>console.log('Enetgy Update Succusee ID :" + UserRequestsEntityResult.Entity.RenwableEnergyID + "');</script>");
                }
                catch { }



                #endregion

                ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntity = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();
                TokenEntity = RenewableEnergyUserRequestsDetails_TokenDomain.GetByLastRecordNotAsync();

                string CurrentToken = "";
                string MonthCurrent = DateTime.Now.Month.ToString();

                DateTime date = DateTime.Now;

                string ancd = date.ToString("yy");


                string YearCurrent = ancd; // DateTime.Now.Year.ToString("yy");
                long NewToken = 0;
                if (TokenEntity.Status == ErrorEnums.Success)
                {
                    if (TokenEntity.Entity.AddMonth == MonthCurrent && TokenEntity.Entity.AddYear == YearCurrent)
                    {
                        CurrentToken = TokenEntity.Entity.TokenNo;
                    }
                    else
                    {
                        CurrentToken = YearCurrent + MonthCurrent + "001";
                    }
                    if (CurrentToken != "")
                    {
                        NewToken = Convert.ToInt64(CurrentToken) + 1;
                    }
                }
                else
                {
                    NewToken = Convert.ToInt64(YearCurrent + MonthCurrent + "001");
                }

                RenewableEnergyUserRequestsDetails_TokenEntity TokenEntityInsert = new RenewableEnergyUserRequestsDetails_TokenEntity();
                TokenEntityInsert.DetailsID = Result.Entity.DetailsID;
                TokenEntityInsert.TokenNo = NewToken.ToString();
                TokenEntityInsert.AddDate = DateTime.Now;
                TokenEntityInsert.AddYear = YearCurrent;
                TokenEntityInsert.AddMonth = MonthCurrent;
                var ResulttokelInsert = RenewableEnergyUserRequestsDetails_TokenDomain.InsertRecordNotAsync(TokenEntityInsert);

                //lblInquiryMessage.Text = "تم ارسال الطلب بنجاح. سيتم الرد عليكم حال  تدقيق الطلبالرقم المرجعي لطلبكم " + NewToken;


                #region Inasert Into Serveces and Steps 


                ServicesStepsEntity StepsEntity = new ServicesStepsEntity();

                //StepsEntity.StepID
                StepsEntity.ServiceID = Result.Entity.DetailsID.ToString();
                StepsEntity.StepNumber = "";
                StepsEntity.FromUser = hndFromUser.Value;
                StepsEntity.ToUser = ServiceUserID.ToString();
                StepsEntity.StepName = "";
                StepsEntity.SendSMS = false;
                StepsEntity.SMSContent = "";
                StepsEntity.SendMail = false;
                StepsEntity.MailContent = "";
                StepsEntity.Filed1 = "";
                StepsEntity.Filed2 = "";
                StepsEntity.Filed3 = "";
                StepsEntity.Filed4 = "";

                ResultEntity<ServicesStepsEntity> ServicesStepsEntity = new ResultEntity<ServicesStepsEntity>();
                ServicesStepsEntity = ServicesStepsDomain.InsertRecordNotAsync(StepsEntity);
                if (ServicesStepsEntity.Status == ErrorEnums.Success)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        ServicesStepsValuesEntity ValuesEntity = new ServicesStepsValuesEntity();

                        //ValuesEntity.ID              
                        ValuesEntity.StepID = ServicesStepsEntity.Entity.StepID;
                        ValuesEntity.ServiceID = Result.Entity.DetailsID.ToString();
                        ValuesEntity.Value1 = "";
                        ValuesEntity.Value2 = "";
                        ValuesEntity.Value3 = "";
                        ValuesEntity.Value4 = "";
                        ValuesEntity.Notes = "";
                        ValuesEntity.IsDone = false;
                        ValuesEntity.ReceivedDateTime = DateTime.Now;
                        //ValuesEntity.DoneDateTime = null;
                        ValuesEntity.AddDate = DateTime.Now;
                        ValuesEntity.AddUser = ServiceUserID.ToString();
                        ValuesEntity.EditDate = DateTime.Now;
                        ValuesEntity.EditUser = ServiceUserID.ToString();

                        ResultEntity<ServicesStepsValuesEntity> StepsValuesEntity = new ResultEntity<ServicesStepsValuesEntity>();
                        StepsValuesEntity = ServicesStepsValuesDomain.InsertNotAsync(ValuesEntity);



                    }


                }


                #endregion


                lblInquiryMessage.Text = " تم ارسال الطلب بنجاح";
                lblInquiryMessage2.Text = "سيتم الرد عليكم حال تدقيق الطلب";
                lblInquiryMessage3.Text = "الرقم المرجعي لطلبكم هو" + NewToken;


                mpeInquiry123.Show();

            }
            else
            {

                Page.Response.Write("<script>console.log(' Details Fail 1: " + Result.Details + "');</script>");
                Page.Response.Write("<script>console.log(' Details Fail 2:  " + Result.Status + " ');</script>");
                Page.Response.Write("<script>console.log(' Details Fail ');</script>");
            }


        }
        catch(Exception ex1) {
        throw ex1;
        }



    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyRequestsList", false);
    }

   
    protected void btn_device_Save_Click(object sender, EventArgs e)
    {

        HttpPostedFile files123 = Request.Files["fileuploadfieldDevice_1"];
        if (files123 != null)
        { }

        //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);

        //AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);


        if (fuImgPath.HasFile)
        {
            string asasd = "";
            //string extension = System.IO.Path.GetExtension(fuImgPath.FileName);

            //if (extension.ToUpper() != ".JPG" && extension.ToUpper() != ".GIF" && extension.ToUpper() != ".PNG" && extension.ToUpper() != ".JPEG" && extension.ToUpper() != ".BMP")

            //{

            //    lblMsg.Text = "Upload JPG/PNG/JPEG images only.";

            //    lblMsg.ForeColor = System.Drawing.Color.Red;

            //    return;

            //}

            //strFilePath = DateTime.Now.ToString("yyyyMMddHHmmss") + fuImgPath.PostedFile.FileName;

            //fuImgPath.PostedFile.SaveAs(Server.MapPath(@"~/Application/FileUploads/" + strFilePath.Trim()));

            //strFilePath = @"~/Application/Masters/FileUploads/Employee/" + strFilePath.Trim();

        }



        try
        {

           
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            //    //---******* (For Local) ******-------------------------
           //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

            //    //---------------******* (For Live) ******-------------------------
            string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

            string guid = Guid.NewGuid().ToString().Substring(0, 6);


            RenewableEnergyCompanyDeviceEntity Entity = new RenewableEnergyCompanyDeviceEntity();


            //===================================

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            string EmailSender = "";

            CompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
            if (CompanyEntity.Status == ErrorEnums.Success)
            {

                long CompanyId = CompanyEntity.Entity.RenwabaleEnergyCompanyID;
                Entity.CompanyID = CompanyId;
                // hdnemailId.Value = CompanyEntity.Entity.EmailAddress;
                EmailSender = CompanyEntity.Entity.EmailAddress;
            }

            //===================================


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files1 = Request.Files["fileuploadfieldDevice_1"];
                if (files1 != null)
                {

                    if (files1.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                       // string dir = uploadPath1 + guid + txtCompanyName.Value + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                         Entity.DeviceDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files1.FileName;
                       // Entity.DeviceDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Value + "//" + files1.FileName;
                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files1.SaveAs(dir + files1.FileName);

                    }
                    else
                    {
                        Entity.DeviceDocument = string.Empty;
                    }
                }
                else
                {
                    Entity.DeviceDocument = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfieldDevice_1 :" + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files2 = Request.Files["fileuploadfieldDevice_2"];
                if (files2 != null)
                {

                    if (files2.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                        //string dir = uploadPath1 + guid + txtCompanyName.Value + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.DeviceDocument2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files2.FileName;
                        //Entity.DeviceDocument2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Value + "//" + files2.FileName;
                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files2.SaveAs(dir + files2.FileName);

                    }
                    else
                    {
                        Entity.DeviceDocument2 = string.Empty;
                    }
                }
                else
                {
                    Entity.DeviceDocument2 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfieldDevice_2 :" + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files3 = Request.Files["fileuploadfieldDevice_3"];
                if (files3 != null)
                {

                    if (files3.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                        //string dir = uploadPath1 + guid + txtCompanyName.Value + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.DeviceDocument3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files3.FileName;
                        //Entity.DeviceDocument3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Value + "//" + files3.FileName;
                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files3.SaveAs(dir + files3.FileName);

                    }
                    else
                    {
                        Entity.DeviceDocument3 = string.Empty;
                    }
                }
                else
                {
                    Entity.DeviceDocument3 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfieldDevice_3 :" + exp.Message + "');</script>");
            }


            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files4 = Request.Files["fileuploadfieldDevice_4"];
                if (files4 != null)
                {

                    if (files4.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtCompanyName.Text + "//";
                       // string dir = uploadPath1 + guid + txtCompanyName.Value + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        Entity.DeviceDocument4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Text + "//" + files4.FileName;
                        //Entity.DeviceDocument4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtCompanyName.Value + "//" + files4.FileName;
                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files4.SaveAs(dir + files4.FileName);

                    }
                    else
                    {
                        Entity.DeviceDocument4 = string.Empty;
                    }
                }
                else
                {
                    Entity.DeviceDocument4 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Console.Write("<script>console.log('fileuploadfieldDevice_4 :" + exp.Message + "');</script>");
            }

            //Entity.RenewbleCompnyDevice =
            Entity.CompanyName = txtCompanyName.Text;
            //Entity.CompanyName = txtCompanyName.Value;
            Entity.ModelNo = txtModelNo.Text;
            Entity.DevicePower = txtDevicePower.Text;
            Entity.CountryOfOrigin = txtCountryOrigin.Text;
            Entity.Order = 0;
            Entity.LanguageID = 2;
            Entity.PublishDate = DateTime.Now;
            Entity.IsPublished = true;
            Entity.IsDeleted = false;
            Entity.AddDate = DateTime.Now;
            Entity.AddUser = ServiceUserID.ToString();
            Entity.EditDate = DateTime.Now;
            Entity.EditUser = ServiceUserID.ToString();
            Entity.Status = "2";
            Entity.IsApproved = true;


            //Entity.CompanyID = Convert.ToInt64(hdnCompanyId.Value);



            var Result = RenewableEnergyCompanyDeviceDomain.InsertRecordNotAsync(Entity);
            if (Result.Status == ErrorEnums.Success)
            {
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
                    string _subject = "Company Device Add Mail";
                    //string _toMail1 = hdnemailId.Value;
                    string _toMail1 = EmailSender;
                    string _toMail2 = ConfigurationManager.AppSettings["ToMailSolarDeviceAdmin"].ToString();

                    bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                    string _ccMail = ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin1"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin2"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarDeviceAdmin3"].ToString();

                    string bodyContent = SettingResult.List[0].RenewableDeviceUserMail;
                    bodyContent = bodyContent.Replace("{Name}", "");
                    bodyContent = bodyContent.Replace("{FormDetails}", "");
                    string _Body = bodyContent;


                    string _BodyForAdmin = "<h1>Company Device</h1>";

                    string bodyContent2 = SettingResult.List[0].RenewableDeviceAdminMail;
                    bodyContent2 = bodyContent2.Replace("{Name}", "");
                    bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                    string _Body2 = bodyContent2;

                    try
                    {

                        SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                        SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                    }
                    catch { }

                }
                #endregion
            }

            ModalPopupExtender1.Hide();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "setProgressBar(4);", "", true);
            hdnstep4.Value = "1";

            lnkSecondNav.Attributes["onClick"] = "chageStep3('4')";


        }
        catch { }
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

    protected void button_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SendClickDevice", "SendClickDevice();", true);
    }

    protected void btn_Soler_Save_Click(object sender, EventArgs e)
    {
        long ServiceUserID = SessionManager.GetInstance.Users.ID;

        //    //---******* (For Local) ******-------------------------
        //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

        //    //---------------******* (For Live) ******-------------------------
        string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

        string guid = Guid.NewGuid().ToString().Substring(0, 6);


        RenewableEnergyCompanySolarCellEntity Entity = new RenewableEnergyCompanySolarCellEntity();



        ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

        string EmailSender = "";

        CompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
        if (CompanyEntity.Status == ErrorEnums.Success)
        {

            long CompanyId = CompanyEntity.Entity.RenwabaleEnergyCompanyID;
            Entity.CompanyID = CompanyId;
            // hdnemailId.Value = CompanyEntity.Entity.EmailAddress;
            EmailSender = CompanyEntity.Entity.EmailAddress;
        }



        try
        {
            //Here string ABCd is Entity of Table

            HttpPostedFile files1 = Request.Files["fileuploadfieldSoller_1"];
            if (files1 != null)
            {

                if (files1.FileName != "") // If file is Selected File
                {

                    string dir = uploadPath1 + guid + txtSollerCompanyNAme.Text + "//";
                    //Entity.ChildPassport = dir + files1.FileName;

                    Entity.SolarCellDocument = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtSollerCompanyNAme.Text + "//" + files1.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files1.SaveAs(dir + files1.FileName);

                }
                else
                {
                    Entity.SolarCellDocument = string.Empty;
                }
            }
            else
            {
                Entity.SolarCellDocument = string.Empty;
            }
        }
        catch (Exception exp)
        {
            Console.Write("<script>console.log('fileuploadfieldSoller_1 :" + exp.Message + "');</script>");
        }



        try
        {
            //Here string ABCd is Entity of Table

            HttpPostedFile files2 = Request.Files["fileuploadfieldSoller_2"];
            if (files2 != null)
            {

                if (files2.FileName != "") // If file is Selected File
                {

                    string dir = uploadPath1 + guid + txtSollerCompanyNAme.Text + "//";
                    //Entity.ChildPassport = dir + files1.FileName;

                    Entity.SolarCellDocument2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtSollerCompanyNAme.Text + "//" + files2.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files2.SaveAs(dir + files2.FileName);

                }
                else
                {
                    Entity.SolarCellDocument2 = string.Empty;
                }
            }
            else
            {
                Entity.SolarCellDocument2 = string.Empty;
            }
        }
        catch (Exception exp)
        {
            Console.Write("<script>console.log('fileuploadfieldSoller_1 :" + exp.Message + "');</script>");
        }

        Entity.CompanyName = txtSollerCompanyNAme.Text;
        Entity.ModelNo = txtSollerModelNo.Text;
        Entity.DevicePower = txtSollerDevicePower.Text;
        Entity.CountryOfOrigin = txtSollerCountryOrigin.Text;
        Entity.Order = 0;
        Entity.LanguageID = 2;
        Entity.PublishDate = DateTime.Now;
        Entity.IsPublished = true;
        Entity.IsDeleted = false;
        Entity.AddDate = DateTime.Now;
        Entity.AddUser = ServiceUserID.ToString();
        Entity.EditDate = DateTime.Now;
        Entity.EditUser = ServiceUserID.ToString();
        Entity.Status = "2";
        Entity.IsApproved = true;
        //Entity.CompanyID = Convert.ToInt64(hdnCompanyId.Value);

        var Result = RenewableEnergyCompanySolarCellDomain.InsertRecordNotAsync(Entity);
        if (Result.Status == ErrorEnums.Success)
        {

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
                string _subject = "Company Device Add Mail";
                string _toMail1 = EmailSender;
                string _toMail2 = ConfigurationManager.AppSettings["ToMailSolarCellAdmin"].ToString();

                bool _EnableSSL = SettingResult.List[0].IsEnableSSL;
                string _ccMail = ConfigurationManager.AppSettings["CCMailSolarCellAdmin1"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarCellAdmin2"].ToString() + "," + ConfigurationManager.AppSettings["CCMailSolarCellAdmin3"].ToString();

                string bodyContent = SettingResult.List[0].RenewableDeviceUserMail;
                bodyContent = bodyContent.Replace("{Name}", "");
                bodyContent = bodyContent.Replace("{FormDetails}", "");
                string _Body = bodyContent;


                string _BodyForAdmin = "<h1>Company Device</h1>";

                string bodyContent2 = SettingResult.List[0].RenewableDeviceAdminMail;
                bodyContent2 = bodyContent2.Replace("{Name}", "");
                bodyContent2 = bodyContent2.Replace("{FormDetails}", _BodyForAdmin);
                string _Body2 = bodyContent2;

                try
                {

                    SendMail2(UserName, _toMail1, _fromMail, _ccMail, _Body, _subject, _Password, _HOST, _Port, _EnableSSL);
                    SendMail2(UserName, _toMail2, _fromMail, _ccMail, _Body2, _subject, _Password, _HOST, _Port, _EnableSSL);


                }
                catch { }

            }
            #endregion


            ModalPopupExtender2.Hide();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "setProgressBar(4);", "", true);
            hdnstep4.Value = "1";

            lnkSecondNav.Attributes["onClick"] = "chageStep3('4')";


        }

       
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Update();
        ModalPopupExtender1.Show();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       //string asd = txt1company.Text;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string strFilePath = string.Empty;

        if (fuImgPath.HasFile)
        {
            string asasd = "";
            //string extension = System.IO.Path.GetExtension(fuImgPath.FileName);

            //if (extension.ToUpper() != ".JPG" && extension.ToUpper() != ".GIF" && extension.ToUpper() != ".PNG" && extension.ToUpper() != ".JPEG" && extension.ToUpper() != ".BMP")

            //{

            //    lblMsg.Text = "Upload JPG/PNG/JPEG images only.";

            //    lblMsg.ForeColor = System.Drawing.Color.Red;

            //    return;

            //}

            //strFilePath = DateTime.Now.ToString("yyyyMMddHHmmss") + fuImgPath.PostedFile.FileName;

            //fuImgPath.PostedFile.SaveAs(Server.MapPath(@"~/Application/FileUploads/" + strFilePath.Trim()));

            //strFilePath = @"~/Application/Masters/FileUploads/Employee/" + strFilePath.Trim();

        }

    }

    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
        //AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
    }

    protected void FileUploadComplete(object sender, EventArgs e)
    {
       // string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
        //AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
    }
}