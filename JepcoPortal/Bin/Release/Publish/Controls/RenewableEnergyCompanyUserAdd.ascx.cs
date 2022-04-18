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

public partial class Controls_RenewableEnergyCompanyUserAdd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

                Result = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
                if (Result.Status == ErrorEnums.Success)
                {

                    long CompanyId = Result.Entity.RenwabaleEnergyCompanyID;
                    hdnCompanyId.Value = CompanyId.ToString();
                }
            }

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {



        long ServiceUserID = SessionManager.GetInstance.Users.ID;

        //    //---******* (For Local) ******-------------------------
        //string uploadPath1 = ConfigurationManager.AppSettings["UploadPath"].ToString();

        //    //---------------******* (For Live) ******-------------------------
        string uploadPath1 = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());

        string guid = Guid.NewGuid().ToString().Substring(0, 6);


        RenewableEnergyCompanyUserEntity Entity = new RenewableEnergyCompanyUserEntity();

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

                    Entity.DocumentUpload = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files1.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files1.SaveAs(dir + files1.FileName);

                }
                else
                {
                    Entity.DocumentUpload = string.Empty;
                }
            }
            else
            {
                Entity.DocumentUpload = string.Empty;
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

                    string dir = uploadPath1 + guid + txtFirstNAme.Text + "//";
                    //Entity.ChildPassport = dir + files2.FileName;

                    Entity.DocumentUploadPhoto = "/Siteware/Siteware_File/image/JEPCO/JobApplicationFiles/" + guid + txtFirstNAme.Text + "//" + files2.FileName;
                    //Insert ABCd to Entity
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    files2.SaveAs(dir + files2.FileName);

                }
                else
                {
                    Entity.DocumentUploadPhoto = string.Empty;
                }
            }
            else
            {
                Entity.DocumentUploadPhoto = string.Empty;
            }
        }
        catch (Exception exp)
        {
            Console.Write("<script>console.log('fileuploadfield_2 :" + exp.Message + "');</script>");
        }

        //Entity.RenewbleCompnyDevice =
        //Entity.CompanyName = txtCompanyName.Text;
        //Entity.ModelNo = txtModelNo.Text;
        //Entity.DevicePower = txtDevicePower.Text;
        //Entity.CountryOfOrigin = txtCountryOrigin.Text;



        Entity.FirstName = txtFirstNAme.Text;
        Entity.FatherName = txtFatherNAme.Text;
        Entity.Grandfathername = txtGFatherNAme.Text;
        Entity.FamilyName = txtFamilyNAme.Text;
        Entity.DocumentType = txtDocumentType.Text;
        Entity.DocumnetNo = txtDocumentNo.Text;
        Entity.MobileNo = txtMobileNo.Text;
        Entity.EmailID = txtEmail.Text;
        Entity.RegisterDate = DateTime.ParseExact(txtStartDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        Entity.ExpireDate = DateTime.ParseExact(txtEndDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        
        Entity.Order = 0;
        Entity.LanguageID = 2;
        Entity.PublishDate = DateTime.Now;
        Entity.IsPublished = true;
        Entity.IsDeleted = false;
        Entity.AddDate = DateTime.Now;
        Entity.AddUser = ServiceUserID.ToString();
        Entity.EditDate = DateTime.Now;
        Entity.EditUser = ServiceUserID.ToString();

        Entity.CompanyID = Convert.ToInt64(hdnCompanyId.Value);
        Entity.IsActive = true;

        //mpeInquiry.Show();
        var Result = RenewableEnergyCompanyUserDomain.InsertRecordNotAsync(Entity);
        if (Result.Status == ErrorEnums.Success)
        {
            mpeInquiry.Show();

        }

    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ar/Home/RenewableEnergyCompanyUserList", false);
    }
}