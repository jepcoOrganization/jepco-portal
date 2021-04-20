using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_RenewableEnergyUserRequestsList : System.Web.UI.UserControl
{
    DataPager pager1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                string ServeceUserType = SessionManager.GetInstance.Users.UserType;
                if (ServeceUserType != "2")
                {
                    FillUserRequst();
                    
                }
                else
                {

                    //FillCompanyRequst();

                    Response.Redirect("~/Default.aspx", false);
                }

            }

            //For Pagination 
            pager1 = lstUserRequstdevice.FindControl("DataPager1") as DataPager;

            if (pager1 != null)
            {
                pager1.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }

        }
        catch
        {
        }
    }

    protected void FillUserRequst()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultList<RenewableEnergyUserRequestsEntity> res = new ResultList<RenewableEnergyUserRequestsEntity>();
            res = RenewableEnergyUserRequestsDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstUserRequstdevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString()).OrderByDescending(s => s.RenwableEnergyID).ToList();
                lstUserRequstdevice.DataBind();

                //int Complaincout = lstUserRequstdevice.Items.Count();
                //lblTotalCount.Text = Complaincout.ToString();


                var AppoverCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString()).ToList();
                int Appover = AppoverCount.Count();
                lblAppoverCount.Text = Appover.ToString();

                var ReversingCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString() && s.CompanyAcceptedStatus == true).ToList();
                int Reversing = ReversingCount.Count();
                lblReversingCount.Text = Reversing.ToString();


                

            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void lstUserRequstdevice_itemdatabound(object sender, ListViewItemEventArgs e)
    {
        Label lblTokanNo = (Label)e.Item.FindControl("lblTokanNo");
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HiddenField hdnRenwableEnergyTypeID = (HiddenField)e.Item.FindControl("hdnRenwableEnergyTypeID");
                //========================
                Label ReqType = (Label)e.Item.FindControl("ReqType");
                if (hdnRenwableEnergyTypeID.Value == "1") { ReqType.Text = "صغير صافي قياس"; }
                else if (hdnRenwableEnergyTypeID.Value == "2") { ReqType.Text = "كبير صافي قياس"; }
                else { ReqType.Text = "تصريح عبور اولي"; }
                //========================

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
                HiddenField hdnID = (HiddenField)e.Item.FindControl("hdnID");
                
                Label lblCompany = (Label)e.Item.FindControl("lblCompany");
                Label lblTelePhone = (Label)e.Item.FindControl("lblTelePhone");
               
                

                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                RenwabaleEnergyCompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(Convert.ToInt32(lblCompany.Text));
                if (RenwabaleEnergyCompanyEntity.Status == ErrorEnums.Success)
                {
                    lblCompany.Text = RenwabaleEnergyCompanyEntity.Entity.CompanyName;
                    lblTelePhone.Text = RenwabaleEnergyCompanyEntity.Entity.MobileNumber;
                }

                ResultList<RenewableEnergyUserRequestsDetailsEntity> DetialList = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                DetialList = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                if (DetialList.Status == ErrorEnums.Success)
                {
                    DetialList.List = DetialList.List.Where(s => s.UserRequestID == Convert.ToInt64(hdnID.Value)).OrderByDescending(s => s.DetailsID).ToList();

                    long detailid = DetialList.List[0].DetailsID;

                    ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntityList = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();
                    TokenEntityList = RenewableEnergyUserRequestsDetails_TokenDomain.GetAllNotAsync();

                    if (TokenEntityList.Status == ErrorEnums.Success)
                    {
                        TokenEntityList.List = TokenEntityList.List.Where(s => s.DetailsID == detailid).ToList();
                        lblTokanNo.Text = TokenEntityList.List[0].TokenNo;
                    }
                    else {
                        lblTokanNo.Text = "غير محدد";


                    }

                }
                else
                {
                    lblTokanNo.Text = "غير محدد";
                }


                

            }
        }
        catch (Exception ex)
        {
            lblTokanNo.Text = "غير محدد";
        }
    }

    protected void lstnewsrow_pagepropertieschanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try 
        {
            DataPager pager1;
            pager1 = lstUserRequstdevice.FindControl("DataPager1") as DataPager;
            (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {
                this.FillUserRequst();
            }
            else
            {
                this.FillCompanyRequst();
            }



            //this.FillUserRequst();
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void lstUserRequstdevice_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            long ID = Convert.ToInt64(e.CommandArgument);

            Session["RenwableEnergyIDSessionID"] = ID;
            
            //Response.Redirect("", false);
            //Response.Redirect("/ar/Home/RenewableEnergyCompanyRequest", false);
            Response.Redirect("/ar/Home/EnergyRequestUserDetails", false);
            
        }
       
    }

    protected void FillCompanyRequst() {

        try {

            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
            RenwabaleEnergyCompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
            if (RenwabaleEnergyCompanyEntity.Status == ErrorEnums.Success)
            {
                long CompanyID = RenwabaleEnergyCompanyEntity.Entity.RenwabaleEnergyCompanyID;

                //============== *** =======================

                ResultList<RenewableEnergyUserRequestsEntity> res = new ResultList<RenewableEnergyUserRequestsEntity>();
                res = RenewableEnergyUserRequestsDomain.GetAllNotAsync();
                if (res.Status == ErrorEnums.Success)
                {

                    lstUserRequstdevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.CompanyID == CompanyID).OrderByDescending(s => s.RenwableEnergyID).ToList();
                    lstUserRequstdevice.DataBind();

                    //int Complaincout = lstUserRequstdevice.Items.Count();
                    //lblTotalCount.Text = Complaincout.ToString();


                    var AppoverCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.CompanyID == CompanyID).ToList();
                    int Appover = AppoverCount.Count();
                    lblAppoverCount.Text = Appover.ToString();

                    var ReversingCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.CompanyID == CompanyID && s.CompanyAcceptedStatus == true).ToList();
                    int Reversing = ReversingCount.Count();
                    lblReversingCount.Text = Reversing.ToString();

                }


                //============== *** =======================



            }


        }
        catch { }

       

    }

   
}