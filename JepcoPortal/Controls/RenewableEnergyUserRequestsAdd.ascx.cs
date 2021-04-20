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

public partial class Controls_RenewableEnergyUserRequestsAdd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fillUserDetails();
                fillCompnay();

            }


        }
        catch
        {
        }
    }

    protected void fillUserDetails()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultEntity<Plugin_ServiceUserEntity> Result = new ResultEntity<Plugin_ServiceUserEntity>();

            Result = Plugin_ServiceUserDomain.GetByIDNotAsync(ServiceUserID);
            if (Result.Status == ErrorEnums.Success)
            {

                txtFirstNAme.Text = Result.Entity.FirstName;
                txtsecondNAme.Text = Result.Entity.SecondName;
                txtThirdName.Text = Result.Entity.ThirdName;
                txtLastName.Text = Result.Entity.FamilyName;


                int cityId = Result.Entity.City;
                int area1id = Result.Entity.Area1;
                int Area2id = Result.Entity.Area2;

                ResultList<Lookup_CityEntity> CityEntity = new ResultList<Lookup_CityEntity>();
                CityEntity =  Lookup_CityDomain.GetLookupCityAllNotAsync();
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

                txtStret.Text = Result.Entity.Address;



            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void fillCompnay()
    {
        try
        {
            ddlCompnay.Items.Insert(0, new ListItem("اختر اسم الشركة التي ترغب بتفويضها لتركيب النظام", "0"));

            ResultList<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();
            Result = Plugin_RenwabaleEnergyCompanyDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (Plugin_RenwabaleEnergyCompanyEntity item in Result.List.Where(s => s.IsPublished == true))
                {
                    ddlCompnay.Items.Add(new ListItem(item.CompanyName.ToString(), item.RenwabaleEnergyCompanyID.ToString()));
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlCompnay_SelectedIndexChanged(object sender, EventArgs e)
    {
        long CompanyId = Convert.ToInt32(ddlCompnay.SelectedValue);

        FillCompanyData(CompanyId);
    }

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


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try {

            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            #region 15-10-2020

            //    //---******* (For Local) ******-------------------------
            // string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();
            //string uploadPath1 = ConfigurationManager.AppSettings["UploadPathRenewableEnergyRequest"].ToString();

            //    //---------------******* (For Live) ******-------------------------
            //string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());
            string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPathRenewableEnergyRequest"].ToString());

            string guid = Guid.NewGuid().ToString().Substring(0, 6);


            RenewableEnergyUserRequestsEntity Entity = new RenewableEnergyUserRequestsEntity();
            MessagesAndNotificationsEntity MassageNotification = new MessagesAndNotificationsEntity();

            // Entity.RenwableEnergyID
            Entity.UserID = ServiceUserID;
            // Entity.RenwableEnergyTypeID = rblRenwableEnergyType.SelectedItem.Text;
            Entity.RenwableEnergyTypeID = rblRenwableEnergyType.SelectedItem.Value;
            Entity.MeterStatus = rblMeterStatus.SelectedItem.Value;
            if (rblMeterStatus.SelectedItem.Value == "3")
            {
                Entity.RefeenceType = "";
                Entity.ReferenceNumber = "";
            }
            else
            {
                Entity.RefeenceType = rblMeterStatus.SelectedItem.Value;
                Entity.ReferenceNumber = txtRefernceNumber.Text;
            }

            //Entity.ReferenceNumber = txtRefernceNumber.Text;
            Entity.CompanyID = Convert.ToInt64(ddlCompnay.SelectedValue);
            Entity.CompanyAcceptedStatus = false;
            Entity.AcceptStatusDate = DateTime.Now;
            Entity.AcceptStatusUser = ""; //SessionManager.GetInstance.Users.FirstName;

            Entity.Order = 0;
            Entity.LanguageID = 2;
            Entity.PublishDate = DateTime.Now;
            Entity.IsPublished = true;
            Entity.IsDeleted = false;
            Entity.AddDate = DateTime.Now;
            Entity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
            Entity.EditDate = DateTime.Now;
            Entity.EditUser = SessionManager.GetInstance.Users.ID.ToString();


            //Entity.RefeenceType = rbdRefeenceType.SelectedItem.Text;
            // Entity.RefeenceType = rbdRefeenceType.SelectedItem.Value;

            string userFullName = txtFirstNAme.Text + " " + txtsecondNAme.Text + " " + txtLastName.Text;

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

                        //Entity.Attachemnt1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files1.FileName;
                        //MassageNotification.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files1.FileName;

                        Entity.Attachemnt1 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files1.FileName;
                        MassageNotification.Attachment1 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files1.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files1.SaveAs(dir + files1.FileName);

                    }
                    else
                    {
                        Entity.Attachemnt1 = string.Empty;
                        MassageNotification.Attachment1 = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Erroe in uploading');", true);

                    }
                }
                else
                {
                    Entity.Attachemnt1 = string.Empty;
                    MassageNotification.Attachment1 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Entity.Attachemnt1 = string.Empty;
                MassageNotification.Attachment1 = string.Empty;
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

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        //Entity.Attachemnt2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files2.FileName;
                        //MassageNotification.Attachment2 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files2.FileName;

                        Entity.Attachemnt2 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files2.FileName;
                        MassageNotification.Attachment2 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files2.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files2.SaveAs(dir + files2.FileName);

                    }
                    else
                    {
                        Entity.Attachemnt2 = string.Empty;
                        MassageNotification.Attachment2 = string.Empty;
                    }
                }
                else
                {
                    Entity.Attachemnt2 = string.Empty;
                    MassageNotification.Attachment2 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Entity.Attachemnt2 = string.Empty;
                MassageNotification.Attachment2 = string.Empty;
                Console.Write("<script>console.log('fileuploadfield_2 :" + exp.Message + "');</script>");
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

                        //Entity.Attachemnt3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files3.FileName;
                        //MassageNotification.Attachment3 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files3.FileName;


                        Entity.Attachemnt3 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files3.FileName;
                        MassageNotification.Attachment3 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files3.FileName;


                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files3.SaveAs(dir + files3.FileName);

                    }
                    else
                    {
                        Entity.Attachemnt3 = string.Empty;
                        MassageNotification.Attachment3 = string.Empty;
                    }
                }
                else
                {
                    Entity.Attachemnt3 = string.Empty;
                    MassageNotification.Attachment3 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Entity.Attachemnt3 = string.Empty;
                MassageNotification.Attachment3 = string.Empty;
                Console.Write("<script>console.log('fileuploadfield_3 :" + exp.Message + "');</script>");
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

                        //Entity.Attachemnt4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files4.FileName;
                        //MassageNotification.Attachment4 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files4.FileName;

                        Entity.Attachemnt4 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files4.FileName;
                        MassageNotification.Attachment4 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files4.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files4.SaveAs(dir + files4.FileName);

                    }
                    else
                    {
                        Entity.Attachemnt4 = string.Empty;
                        MassageNotification.Attachment4 = string.Empty;
                    }
                }
                else
                {
                    Entity.Attachemnt4 = string.Empty;
                    MassageNotification.Attachment4 = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Entity.Attachemnt4 = string.Empty;
                MassageNotification.Attachment4 = string.Empty;
                Console.Write("<script>console.log('fileuploadfield_3 :" + exp.Message + "');</script>");
            }

            try
            {
                //Here string ABCd is Entity of Table

                HttpPostedFile files5 = Request.Files["fileuploadfield_5"];
                if (files5 != null)
                {

                    if (files5.FileName != "") // If file is Selected File
                    {

                        string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                        //Entity.ChildPassport = dir + files1.FileName;

                        // Entity.Attachemnt5 = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files5.FileName;
                        Entity.Attachemnt5 = "/Siteware/Siteware_File/image/JEPCO/RenewableEnergyRequest/" + guid + txtFirstNAme.Text + "//" + files5.FileName;

                        //Insert ABCd to Entity
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        files5.SaveAs(dir + files5.FileName);

                    }
                    else
                    {
                        Entity.Attachemnt5 = string.Empty;

                    }
                }
                else
                {
                    Entity.Attachemnt4 = string.Empty;

                }
            }
            catch (Exception exp)
            {
                Entity.Attachemnt4 = string.Empty;
                Console.Write("<script>console.log('fileuploadfield_5 :" + exp.Message + "');</script>");
            }

            Entity.GUID = guid + txtFirstNAme.Text;

            var Result = RenewableEnergyUserRequestsDomain.InsertRecordNotAsync(Entity);
            if (Result.Status == ErrorEnums.Success)
            {

                //MassageNotification.NotificationID = 
                MassageNotification.MsgFromUserID = SessionManager.GetInstance.Users.ID;
                MassageNotification.FromUserType = "1";
                MassageNotification.MsgToUserID = Convert.ToInt64(ddlCompnay.SelectedValue);
                MassageNotification.ToUserType = "2";
                MassageNotification.Subject = " طلب طافة متجددة من " + SessionManager.GetInstance.Users.FirstName + " " + SessionManager.GetInstance.Users.SecondName + " " + SessionManager.GetInstance.Users.FamilyName;
                MassageNotification.Description = "  الرجاء متابعة قائمة طلبات الطاقة المتجدد" + txtFirstNAme.Text + "تم استلام طلب طاقة متجددة جديد من  ";
                MassageNotification.IsRead = false;
                MassageNotification.RequestID = Result.Entity.RenwableEnergyID.ToString();
                MassageNotification.RequestType = "1";
                MassageNotification.Order = 0;
                MassageNotification.LanguageID = 2;
                MassageNotification.PublishDate = DateTime.Now;
                MassageNotification.IsPublished = true;
                MassageNotification.IsDeleted = false;
                MassageNotification.AddDate = DateTime.Now;
                MassageNotification.AddUser = SessionManager.GetInstance.Users.ID.ToString();
                MassageNotification.EditDate = DateTime.Now;
                MassageNotification.EditUser = SessionManager.GetInstance.Users.ID.ToString();

                var MSGResult = MessagesAndNotificationsDomain.InsertRecord(MassageNotification);

                lvlCompanyNAme.Text = ddlCompnay.SelectedItem.Text.ToString();
                mpeInquiry.Show();




            }

            else
            {

                string errerrre = Result.Status.ToString(); 
                Console.Write("<script>console.log('Insert Eroor :" + errerrre + "');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Erroe in Insert "+ errerrre  + " ');", true);

            }



            #endregion

        }
        catch (Exception exp)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Expection gerret');", true);
        }

        


    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyUserRequestsList", false);
    }



    protected void btncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyUserRequestsList", false);
    }
}