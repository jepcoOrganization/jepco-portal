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

public partial class Controls_RenewableEnergyRequestsList : System.Web.UI.UserControl
{
    DataPager pager1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {
                //Response.Redirect("~/Default.aspx", false);
                FillUserRequst();
            }
            else
            {
                FillCompanyRequst();
            }




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

                int Complaincout = lstUserRequstdevice.Items.Count();
                lblTotalCount.Text = Complaincout.ToString();


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
        Label lblTokenNo = (Label)e.Item.FindControl("lblTokenNo");
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label lblDevice = (Label)e.Item.FindControl("lblDevice");
                if (lblDevice.Text == "" || lblDevice.Text == string.Empty)
                {
                    lblDevice.Text = "غير متوفر";

                }

                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                //Label lblCompany = (Label)e.Item.FindControl("lblCompany");
                //Label lblTelePhone = (Label)e.Item.FindControl("lblTelePhone");


                Label lblAddUser = (Label)e.Item.FindControl("lblAddUser");

                ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(Convert.ToInt64(lblAddUser.Text));
                if (ServiceUserEntity.Status == ErrorEnums.Success)
                {
                    lblAddUser.Text = ServiceUserEntity.Entity.FirstName + " " + ServiceUserEntity.Entity.SecondName + " " + ServiceUserEntity.Entity.FamilyName;
                    //lblTelePhone.Text = ServiceUserEntity.Entity.MobileNumber;
                }

                HiddenField hdnRenwableID = (HiddenField)e.Item.FindControl("hdnRenwableID");
                HiddenField hdnDetailsID = (HiddenField)e.Item.FindControl("hdnDetailsID");

                HiddenField hdnRenwableEnergyTypeID = (HiddenField)e.Item.FindControl("hdnRenwableEnergyTypeID");

                //========================
                 Label ReqType = (Label)e.Item.FindControl("ReqType");
                if (hdnRenwableEnergyTypeID.Value == "1") { ReqType.Text = "صغير صافي قياس"; }
                else if (hdnRenwableEnergyTypeID.Value == "2") { ReqType.Text = "كبير صافي قياس"; }
                else { ReqType.Text = "تصريح عبور أولي"; }
                //========================

                LinkButton lnkDetilsAfterdata = (LinkButton)e.Item.FindControl("lnkDetilsAfterdata");
                LinkButton lnkEdit = (LinkButton)e.Item.FindControl("lnkEdit");
                LinkButton lnkPhase2 = (LinkButton)e.Item.FindControl("lnkPhase2");

                ResultList<RenewableEnergyUserRequestsDetailsEntity> DetailsEntity = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();
                DetailsEntity = RenewableEnergyUserRequestsDetailsDomain.GetAllNotAsync();
                if (DetailsEntity.Status == ErrorEnums.Success)
                {
                    //var DetailsEntityLast = DetailsEntity.List.Where(s => s.IsDeleted == false && s.UserRequestID == Convert.ToInt64(hdnRenwableID.Value)).OrderByDescending(s => s.DetailsID);
                    DetailsEntity.List = DetailsEntity.List.Where(s => s.IsDeleted == false && s.UserRequestID == Convert.ToInt64(hdnRenwableID.Value)).OrderByDescending(s => s.DetailsID).ToList();
                    long ThisDatailID = DetailsEntity.List[0].DetailsID;
                    hdnDetailsID.Value = ThisDatailID.ToString();
                    lnkDetilsAfterdata.CommandArgument = ThisDatailID.ToString();
                    ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> TokenEntity = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();
                    TokenEntity = RenewableEnergyUserRequestsDetails_TokenDomain.GetAllNotAsync();
                    if (TokenEntity.Status == ErrorEnums.Success)
                    {
                        TokenEntity.List = TokenEntity.List.Where(s => s.DetailsID == ThisDatailID).ToList();
                        lblTokenNo.Text = TokenEntity.List[0].TokenNo;
                        lnkDetilsAfterdata.Attributes.Add("style", "display:block");
                        lnkEdit.Attributes.Add("style", "display:none");
                        lnkPhase2.Attributes.Add("style", "display:none");

                        //========================================= When Phase 2

                        if (hdnRenwableEnergyTypeID.Value == "3")
                        {
                            ResultList<RenwableEnergyType3Phase1DetailsEntity> Type3Phase1DetailsList = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();
                            Type3Phase1DetailsList = RenwableEnergyType3Phase1DetailsDomain.GetAllNotAsync();
                            if (Type3Phase1DetailsList.Status == ErrorEnums.Success)
                            {
                                Type3Phase1DetailsList.List = Type3Phase1DetailsList.List.Where(s => s.DetailsID == ThisDatailID).ToList();
                                if (Type3Phase1DetailsList.List.Count >= 1)
                                {
                                    if (Type3Phase1DetailsList.List[0].IsApproved == true)
                                    {
                                        lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                                        lnkEdit.Attributes.Add("style", "display:none");
                                        lnkPhase2.Attributes.Add("style", "display:block");
                                        lnkPhase2.CommandArgument = ThisDatailID.ToString();
                                    }
                                    else
                                    {
                                        lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                                        lnkEdit.Attributes.Add("style", "display:block");
                                        lnkPhase2.Attributes.Add("style", "display:none");
                                    }
                                }
                                else
                                {
                                    lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                                    lnkEdit.Attributes.Add("style", "display:block");
                                    lnkPhase2.Attributes.Add("style", "display:none");
                                }
                            }
                            else
                            {
                                lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                                lnkEdit.Attributes.Add("style", "display:block");
                                lnkPhase2.Attributes.Add("style", "display:none");
                            }                            
                        }
                        else
                        {
                            //03-12-2020 - Ajay = Start
                            //lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                            //lnkEdit.Attributes.Add("style", "display:block");
                            //lnkPhase2.Attributes.Add("style", "display:none");
                            //lblTokenNo.Text = "غير متوفر";

                            lblTokenNo.Text = TokenEntity.List[0].TokenNo;
                            lnkDetilsAfterdata.Attributes.Add("style", "display:block");
                            lnkEdit.Attributes.Add("style", "display:none");
                            lnkPhase2.Attributes.Add("style", "display:none");





                            //03-12-2020 - Ajay = End

                        }
                        //=========================================== 
                    }
                    else
                    {
                        lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                        lnkEdit.Attributes.Add("style", "display:block");
                        lnkPhase2.Attributes.Add("style", "display:none");
                        lblTokenNo.Text = "غير متوفر";
                    }
                }
                else
                {
                    lnkDetilsAfterdata.Attributes.Add("style", "display:none");
                    lnkEdit.Attributes.Add("style", "display:block");
                    lnkPhase2.Attributes.Add("style", "display:none");
                }

               

         }
        }
        catch (Exception ex)
        {
            lblTokenNo.Text = "غير متوفر";
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
            Response.Redirect("/ar/Home/RenewableEnergyRequestsList/RenewableEnergyCompanyRequest", false);
        }

        if (e.CommandName == "ViewDetailsAfterData")
        {
            long ID = Convert.ToInt64(e.CommandArgument);

            Session["DetailsIDSessionID"] = ID;

            //Response.Redirect("", false);
            //Response.Redirect("/ar/Home/RenewableEnergyCompanyRequest", false);
            Response.Redirect("/ar/Home/RenewableEnergyRequestsList/EnergyRequestDetails", false);
        }

        if (e.CommandName == "ViewPhase2")
        {
            long ID = Convert.ToInt64(e.CommandArgument);

            Session["DetailsIDSessionID"] = ID;

            //Response.Redirect("", false);
            //Response.Redirect("/ar/Home/RenewableEnergyCompanyRequest", false);
            //Response.Redirect("/ar/Home/RenewableEnergyCompanyRequestPhase2", false);
            Response.Redirect("/ar/Home/RenewableEnergyCompanyRequestPhase2", false);

            
        }

    }

    protected void FillCompanyRequst()
    {

        try
        {

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


                    var allResultCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.CompanyID == CompanyID).ToList();
                    int Complaincout = allResultCount.Count();
                    lblTotalCount.Text = Complaincout.ToString();


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