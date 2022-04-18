using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiteWare.DataAccess.Repositories;
using HtmlAgilityPack;
using System.Web.Services;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using Newtonsoft.Json.Linq;
using System.Text;



using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;


using System.Xml;
using System.Xml.Serialization;

using System.Xml.Linq;

public partial class _Default : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 0;
    string lang = string.Empty;
    private byte CurrLangID;


    protected void Page_Load(object sender, EventArgs e)
    {
        CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
        if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
        {
            LangID = 1;
            lang = "/en";

            //lblLangID.Value = "2";
            // lnkLanguage.Text = "عربى";
        }
        else
        {
            LangID = 2;
            lang = "/ar";
            // lblLangID.Value = "1";
            // lnkLanguage.Text = "English";
        }

        

        if (!IsPostBack)
        {


            var date = currentDate;
            var month = date.ToString("MMM", new CultureInfo("ar-AE"));
            var Date = date.ToString("dd", new CultureInfo("ar-AE"));
            var Year = date.ToString("yyyy", new CultureInfo("ar-AE"));
            var DayName = date.ToString("dddd", new CultureInfo("ar-AE"));
            

            lbldate.Text = Date.ToString();
            lblMonth.Text = month.ToString();
            lblYear.Text = Year.ToString();
            lblDayName.Text = DayName.ToString();

            if (SessionManager.GetInstance.Users != null)
            {

                if (RouteData.Values["language"] == null)
                {
                    Response.Redirect("ar/Home");
                }
                ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
                Result = SettingDomain.GetSettingAllWithoutAsync();
                if (Result.Status == ErrorEnums.Success)
                {
                    Page.Title = Result.List[0].PageName; 
                    imgLogo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].Logo;
                    //imgMobileLogo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].FooterLogo;
                    lblCopyright.Text = FetchLinksFromSource(Result.List[0].CopyRights);
                }
                FillSecondNavigation();
                FillSocialMedia();
               
                //FillNavigation();
                FillServiceUser();
                FillBanner();
                FillDailyAdvise();
               
                FillNews();
                FillCompalinData();
              
                FillCapctha();

                FillUnReadMSG();

            }
            else
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/LoginPage/Login.aspx");
            }


        }
        else
        { }



        //System.Threading.Thread.Sleep(100);
        //// string currenttime = DateTime.Now.ToLongTimeString();
        //string currenttime = DateTime.Now.ToString("hh:mm tt");
        //lblcurrenttime.Text = currenttime;

    }


    #region FillServiceUser

    protected async void FillServiceUser()
    {
        try
        {
            long UserId = SessionManager.GetInstance.Users.ID;

            

            ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();

            ServiceUserEntity = await Plugin_ServiceUserDomain.GetByID(UserId);
            if (ServiceUserEntity.Status == ErrorEnums.Success)
            {

                ResultEntity<MobileRegistationEntity> MobileRegistrationResult = new ResultEntity<MobileRegistationEntity>();
                MobileRegistrationResult = MobileRegistationDomain.GetByIDNotAsync(UserId);

                if (MobileRegistrationResult.Status == ErrorEnums.Success)
                {

                   // Boolean isRegisterd = GetMobileVerifyed[0].IsVerify;
                    Boolean isRegisterd = MobileRegistrationResult.Entity.IsVerify;

                    if (isRegisterd == true)
                    {
                        lblUserName.Text = ServiceUserEntity.Entity.FirstName;
                        lblUserLastName.Text = ServiceUserEntity.Entity.FamilyName;
                        lblUserAddress.Text = ServiceUserEntity.Entity.Address;
                        lblUSerEmail.Text = ServiceUserEntity.Entity.Email;
                        lblUSerMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                        hdnmobileno.Value = ServiceUserEntity.Entity.MobileNumber;
                        lblUSerRegiDate.Text = ServiceUserEntity.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        lblOTPMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                        ModalOTP.Show();
                    }



                }


                //ResultList<MobileRegistationEntity> MobileRegistrationResult = new ResultList<MobileRegistationEntity>();

                //MobileRegistrationResult = await MobileRegistationDomain.GetAll();
                //if (MobileRegistrationResult.Status == ErrorEnums.Success)
                //{
                //    var GetMobileVerifyed = MobileRegistrationResult.List.Where(s => s.MobileNumber == ServiceUserEntity.Entity.MobileNumber && s.ServiceUserID == UserId).OrderByDescending(a => a.AddDate).Take(1).ToList();

                //    if (GetMobileVerifyed.Count > 0)
                //    {
                //        Boolean isRegisterd = GetMobileVerifyed[0].IsVerify;

                //        if (isRegisterd == true)
                //        {
                //            lblUserName.Text = ServiceUserEntity.Entity.FirstName;
                //            lblUserLastName.Text = ServiceUserEntity.Entity.FamilyName;
                //            lblUserAddress.Text = ServiceUserEntity.Entity.Address;
                //            lblUSerEmail.Text = ServiceUserEntity.Entity.Email;
                //            lblUSerMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                //            hdnmobileno.Value = ServiceUserEntity.Entity.MobileNumber;
                //            lblUSerRegiDate.Text = ServiceUserEntity.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                //        }
                //        else
                //        {
                //            lblOTPMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                //            ModalOTP.Show();

                //        }
                //    }
                //    else
                //    {

                //        #region--> New API
                //        //*************************---New API Integration---------- ****************************************************

                //        //----------------------------------------- Latest Code --------------------------------------
                //        var getSMSCred = await GetAccessToken();
                //        Page.Response.Write("<script>console.log(' Call For OTP ');</script>");
                //        string smsException = string.Empty;

                //        string dyna_otp = Generatenumber();
                //        if (!string.IsNullOrEmpty(getSMSCred.SenderID) && !string.IsNullOrEmpty(getSMSCred.AccessToken))
                //        {
                //            List<string> MobileNumber = new List<string>();
                //            MobileNumber.Add("962" + ServiceUserEntity.Entity.MobileNumber);
                //            var Body = new
                //            {
                //                //service_type = "bulk_sms",
                //                //recipient_numbers_type = "single_numbers",
                //                //phone_numbers = MobileNumber.ToArray(),
                //                //content = "JepcoPortal Send : " + dyna_otp,
                //                //sender_id = "SENDER"

                //                service_type = "bulk_sms",
                //                recipient_numbers_type = "single_numbers",
                //                phone_numbers = MobileNumber.ToArray(),
                //                // content = "JepcoPortal Send : " + dyna_otp,
                //                content = "اهلا وسهلا بكم في البوابة الالكترونية لشركة الكهرباء رقم التعريف الخاص بك هو " + dyna_otp,
                //                sender_id = "JEPCO"

                //            };
                //            Page.Response.Write("<script>console.log('Mobile No : " + ServiceUserEntity.Entity.MobileNumber + "');</script>");
                //            string inputJson = (new JavaScriptSerializer()).Serialize(Body);
                //            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["SMSURL"].ToString()));
                //            httpRequest.ContentType = "application/json";
                //            httpRequest.Method = "POST";
                //            httpRequest.Headers.Add("integration_token", getSMSCred.AccessToken);

                //            byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                //            using (Stream stream = httpRequest.GetRequestStream())
                //            {
                //                stream.Write(bytes, 0, bytes.Length);
                //                stream.Close();
                //            }
                //            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                //            {
                //                using (Stream stream = httpResponse.GetResponseStream())
                //                {
                //                    var res = (new StreamReader(stream)).ReadToEnd();
                //                    var data = (JObject)JsonConvert.DeserializeObject(res);

                //                    string status = data["status"].Value<string>();
                //                    smsException = status;

                //                    Page.Response.Write("<script>console.log('OTP Suss');</script>");

                //                    try
                //                    {
                //                        MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                //                        MemberOTPEntity.ServiceUserID = UserId;
                //                        MemberOTPEntity.MobileNumber = "+962" + ServiceUserEntity.Entity.MobileNumber;
                //                        MemberOTPEntity.OTP = dyna_otp;
                //                        MemberOTPEntity.IsVerify = false;


                //                        var MemberOTPResult = await MobileRegistationDomain.Insert(MemberOTPEntity);
                //                    }
                //                    catch { }



                //                }
                //            }
                //        }
                //        //**************************************************************************************************************
                //        #endregion





                //        lblOTPMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                //        ModalOTP.Show();
                //    }
                   


                //}
                //else
                //{
                //    lblOTPMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                //    ModalOTP.Show();
                //}

            }


            try {

                ResultEntity<LastLoginTimeEntity> LastLoginEntity = new ResultEntity<LastLoginTimeEntity>();
                LastLoginEntity = await LastLoginTimeDomain.GetByServiceUserID(UserId);
                if (LastLoginEntity.Status == ErrorEnums.Success)
                {
                    lblLastLogin.Text = LastLoginEntity.Entity.LastLoginTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    hdhLastLoginId.Value = LastLoginEntity.Entity.LoginId.ToString();
                }
                else
                {
                    lblLastLogin.Text = "";
                    hdhLastLoginId.Value = "0";
                }

            }
            catch
            {

            }

            FillNavigationWithUserType(SessionManager.GetInstance.Users.UserType);

        }
        catch
        {

        }


    }

    #endregion

    #region--> FillSecondNavigation
    protected async void FillSecondNavigation()
    {
        try
        {
            //ResultList<SecondNavigationEntity> Result = new ResultList<SecondNavigationEntity>();
            ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
            Result = await FooterNavigationDomain.GetFooterAll();

            if (Result.Status == ErrorEnums.Success)
            {


                lstSecondNavFooter1.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate ).OrderBy(s => s.MenuOrder).Take(5).ToList();
                lstSecondNavFooter1.DataBind();

                lstSecondNavFooter2.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Skip(5).Take(3).ToList();
                lstSecondNavFooter2.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstSecondNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");

                //if (lnkSecondNav.Target == "1")
                //{
                //    lnkSecondNav.Target = "_blank";
                //}
                //else
                //{
                //    lnkSecondNav.Target = "_parent";
                //}
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region FillDailyAdvace
    protected async void FillDailyAdvise()
    {
        try
        {
            ResultList<Plugin_DailyAdviseEntity> Result = new ResultList<Plugin_DailyAdviseEntity>();

            Result = await Plugin_DailyAdviseDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstDailyAdv.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.Order).ToList();
                lstDailyAdv.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    //protected void lstDailyAdv_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    #endregion

    //#region--> FillContactUs
    //protected void FillContactUs()
    //{
    //    try
    //    {
    //        ResultList<PluginContactUsEntity> res = new ResultList<PluginContactUsEntity>();
    //        res = PluginContactUsDomain.GetPluginContactAllNotAsync();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstContactUs.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
    //            lstContactUs.DataBind();

    //            lstMobContactUs.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
    //            lstMobContactUs.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstContactUs_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgContactus = (Image)e.Item.FindControl("imgContactus");
    //            if (!string.IsNullOrEmpty(imgContactus.ImageUrl))
    //                imgContactus.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgContactus.ImageUrl.Replace("~/", "~/Siteware/");

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    #region--> FillNavigation
    protected void FillNavigation()
    {
        ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
        // ResultList<NavigationEntity> rootmenu = new ResultList<NavigationEntity>();

        Result = NavigationDomain.GetNavigationWebsiteAllNotAsync();
        // rootmenu = await NavigationDomain.GetNavigationByRootMenu();

        if (Result.Status == ErrorEnums.Success)
        {
            lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(8).ToList();
            lstNavigation.DataBind();

            //lstNavigation2.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
            //lstNavigation2.DataBind();

            lstMobileNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(8).ToList();
            lstMobileNavigation.DataBind();
        }
    }

    protected void FillNavigationWithUserType(string userType)
    {
        ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
        // ResultList<NavigationEntity> rootmenu = new ResultList<NavigationEntity>();

        Result = NavigationDomain.GetNavigationWebsiteAllNotAsync();
        // rootmenu = await NavigationDomain.GetNavigationByRootMenu();

        if (Result.Status == ErrorEnums.Success)
        {


            if(userType == "1")
            {
                lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowUser == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstNavigation.DataBind();

                //lstNavigation2.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
                //lstNavigation2.DataBind();

                lstMobileNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowUser == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstMobileNavigation.DataBind();
            }
            else if (userType == "2")
            {
                lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowCompany == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstNavigation.DataBind();

                //lstNavigation2.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
                //lstNavigation2.DataBind();

                lstMobileNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowCompany == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstMobileNavigation.DataBind();
            }
            else
            {
                lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowUser == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstNavigation.DataBind();

                //lstNavigation2.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
                //lstNavigation2.DataBind();

                lstMobileNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.ShowUser == true).OrderBy(q => q.MenuOrder).Take(8).ToList();
                lstMobileNavigation.DataBind();
            }



            
        }
    }



    protected void lstNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Image img = (Image)e.Item.FindControl("img");
        if (!string.IsNullOrEmpty(img.ImageUrl))
            img.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + img.ImageUrl.Replace("~/", "~/Siteware/");

        HyperLink lnk = (HyperLink)e.Item.FindControl("lnkNav");

        if (lnk.Target == "1")
        { lnk.Target = "_blank"; }
        else
        { lnk.Target = "_parent"; }

        HiddenField hdnid = (HiddenField)e.Item.FindControl("hdnid");
        Literal unReadMSgMenu = (Literal)e.Item.FindControl("unReadMSgMenu");
        

        if (hdnid.Value == "8") {
            try
            {
                long UserId = SessionManager.GetInstance.Users.ID;
                string ServeceUserType = SessionManager.GetInstance.Users.UserType;
                if (ServeceUserType != "2")
                {
                    unReadMSgMenu.Text = "";
                }
                else
                {
                    ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                    RenwabaleEnergyCompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(UserId);
                    if (RenwabaleEnergyCompanyEntity.Status == ErrorEnums.Success)
                    {
                        long CompanyId = RenwabaleEnergyCompanyEntity.Entity.RenwabaleEnergyCompanyID;
                        // UnRead MSG Count
                        ResultList<MessagesAndNotificationsEntity> Result = new ResultList<MessagesAndNotificationsEntity>();
                        Result = MessagesAndNotificationsDomain.GetAllNotAsync();
                        if (Result.Status == ErrorEnums.Success)
                        {
                            unReadMSgMenu.Text = "";
                            var Unreads = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.MsgToUserID == CompanyId && q.IsRead == false).ToList();
                            
                            unReadMSgMenu.Text = "<small class='msgno'> " + Unreads.Count.ToString() + "</small>";
                        }
                        else
                        {
                            unReadMSgMenu.Text = "";
                        }
                    }
                }

                
            }
            catch { }

        }
        else {
            unReadMSgMenu.Text = "";
        }
        

    }



    //int countmymenu = 1;
    //protected void lstNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {


    //        HiddenField ID = (HiddenField)e.Item.FindControl("MenuID");
    //        Result = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(ID.Value));

    //        if (Result.List.Count == 0)
    //        {
    //            //lstmenu.Attributes.Add("class", "")
    //            //if (string.IsNullOrEmpty(lnk.NavigateUrl) || lnk.NavigateUrl == "#")
    //            //{
    //            //    lnk.NavigateUrl = "javascript:void(0);";
    //            //}
    //            //  ulsubmenu.Visible = false;
    //        }
    //        else
    //        {
    //            HtmlGenericControl ddlmenu = (HtmlGenericControl)e.Item.FindControl("ddlmenu");
    //            ddlmenu.Attributes.Add("class", "nwdr dropdownmenu" + countmymenu);
    //            ListView lstSubNavgation = (ListView)e.Item.FindControl("lstSubNavgation");
    //            Image imgNav = (Image)e.Item.FindControl("imgNav");
    //            if (!string.IsNullOrEmpty(imgNav.ImageUrl))
    //                imgNav.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNav.ImageUrl.Replace("~/", "~/Siteware/");

    //            lstSubNavgation.DataSource = Result.List.Where(a => a.IsDeleted == false && a.IsPublished == true && a.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(a => a.MenuOrder);
    //            lstSubNavgation.DataBind();
    //        }

    //        countmymenu++;
    //    }
    //}

    //int menucount = 1;
    //protected void lstNavigation2_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {

    //        HtmlGenericControl lstmenu = (HtmlGenericControl)e.Item.FindControl("lstmenu");
    //        HiddenField ID = (HiddenField)e.Item.FindControl("MenuID");
    //        HyperLink lnk = (HyperLink)e.Item.FindControl("lnkMenu");
    //        HiddenField hiddnloop = (HiddenField)e.Item.FindControl("hiddnloop");
    //        hiddnloop.Value = menucount.ToString();
    //        Result = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(ID.Value));

    //        if (Result.List.Count == 0)
    //        {
    //            if (lnk.Target == "1")
    //            { lnk.Target = "_blank"; }
    //            else
    //            { lnk.Target = "_parent"; }
    //        }
    //        else
    //        {
    //            lnk.Target = "_parent";

    //            if (string.IsNullOrEmpty(lnk.NavigateUrl) || lnk.NavigateUrl == "#")
    //            {
    //                lnk.NavigateUrl = "javascript:void(0);";
    //            }

    //            // lstmenu.Attributes.Add("class", "active Mydropli dropli" + menucount);
    //            lstmenu.Attributes.Add("onclick", "return callsubmenu(" + menucount + ");");

    //        }
    //        //HtmlGenericControl ulsubmenu = (HtmlGenericControl)e.Item.FindControl("ulsubmenu");

    //        //if (ID.Value == "1")
    //        //{
    //        //    lstmenu.Attributes.Add("class", "active Mydropli dropli" + menucount);
    //        //    lstmenu.Attributes.Add("onclick", "return callsubmenu(" + menucount + ");");

    //        //}
    //        menucount++;
    //    }
    //}

    //protected void lstSubNavgation_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{

    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {
    //        HyperLink lnk = (HyperLink)e.Item.FindControl("lnkSubMenu");
    //        if (lnk.Target == "1")
    //        { lnk.Target = "_blank"; }
    //        else
    //        { lnk.Target = "_parent"; }
    //    }
    //}

    //protected void lstMobileNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {


    //        HiddenField ID = (HiddenField)e.Item.FindControl("MenuID");
    //        HtmlGenericControl lstmenu = (HtmlGenericControl)e.Item.FindControl("lstmenu");
    //        HyperLink lnk = (HyperLink)e.Item.FindControl("lnkMenu");
    //        Result = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(ID.Value));
    //        if (Result.List.Count == 0)
    //        {
    //            lstmenu.Attributes.Add("class", "");
    //        }
    //        else
    //        {
    //            lstmenu.Attributes.Add("class", "active mobdrop");
    //            Image imgNav = (Image)e.Item.FindControl("imgNav");
    //            if (!string.IsNullOrEmpty(imgNav.ImageUrl))
    //                imgNav.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNav.ImageUrl.Replace("~/", "~/Siteware/");
    //            ListView lstSubMobileNavigation = (ListView)e.Item.FindControl("lstSubMobileNavigation");
    //            lstSubMobileNavigation.DataSource = Result.List.Where(a => a.IsDeleted == false && a.IsPublished == true && a.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(a => a.MenuOrder);
    //            lstSubMobileNavigation.DataBind();

    //            if (string.IsNullOrEmpty(lnk.NavigateUrl) || lnk.NavigateUrl == "#")
    //            {
    //                lnk.NavigateUrl = "javascript:void(0);";
    //            }
    //        }





    //        if (lnk.Target == "1")
    //        { lnk.Target = "_blank"; }
    //        else
    //        { lnk.Target = "_parent"; }





    //        menucount++;
    //    }
    //}

    #endregion




    //#region--> FillSlider
    //protected async void FillSlider()
    //{
    //    try
    //    {
    //        ResultList<PluginSliderEntity> Result = new ResultList<PluginSliderEntity>();
    //        Result = await PluginSliderDomain.GetSliderAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstSlider.DataSource = Result.List.Where(q => q.IsDeleted == false && q.IsPublish == true && q.LanguageID == CurrLangID && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.Order).ToList();
    //            lstSlider.DataBind();

    //            lstSlideCount.DataSource = Result.List.Where(q => q.IsDeleted == false && q.IsPublish == true && q.LanguageID == CurrLangID && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.Order).ToList();
    //            lstSlideCount.DataBind();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw;
    //    }
    //}

    //int slidercnt = 0;
    //protected void lstSlider_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {
    //        //HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");

    //        Image img = (Image)e.Item.FindControl("img");
    //        if (!string.IsNullOrEmpty(img.ImageUrl))
    //            img.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + img.ImageUrl.Replace("~/", "~/Siteware/");


    //        HtmlGenericControl sliderDiv = (HtmlGenericControl)e.Item.FindControl("sliderDiv");
    //        HyperLink lnkSlider = (HyperLink)e.Item.FindControl("lnkSlider");

    //        if (slidercnt == 0)
    //        {
    //            sliderDiv.Attributes.Add("class", "item active");
    //        }
    //        else
    //        {
    //            sliderDiv.Attributes.Add("class", "item");
    //        }
    //        // string Image = ConfigurationManager.AppSettings["ImagePath"].ToString() + hdnImage.Value;

    //        //if (!string.IsNullOrEmpty(Image))
    //        //{
    //        //    sliderDiv.Style.Add("background-image", "url(" + Image + ");");
    //        //}

    //        slidercnt++;
    //    }
    //}
    //int dotCount = 0;
    //protected void lstSlideCount_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl liid = (HtmlGenericControl)e.Item.FindControl("liid");
    //            Literal txtliCount = (Literal)e.Item.FindControl("txtliCount");


    //            if (dotCount == 0)
    //            {
    //                liid.Attributes.Add("class", "active");
    //            }
    //            liid.Attributes.Add("data-slide-to", dotCount.ToString());

    //            dotCount++;
    //            txtliCount.Text = "0" + dotCount;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //#endregion

    //#region--> FillNotification
    //protected void FillNotification()
    //{
    //    try
    //    {
    //        ResultList<Plugin_NotificationEntity> res = new ResultList<Plugin_NotificationEntity>();
    //        res = Plugin_NOtificationDomain.GetAllNotAsync();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstNotification.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.DateFrom <= currentDate.Date && s.DateTo >= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
    //            lstNotification.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstNotification_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgbannerinfo = (Image)e.Item.FindControl("imgbannerinfo");
    //            if (!string.IsNullOrEmpty(imgbannerinfo.ImageUrl))
    //                imgbannerinfo.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgbannerinfo.ImageUrl.Replace("~/", "~/Siteware/");

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

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

            // CaptchCodeSession.Value = captcha.ToString();

            // imgCaptcha.ImageUrl = "~/Controls/GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }

    #region--> FillBanner
    protected async void FillBanner()
    {
        try
        {
            ResultList<PluginBannerEntity> res = new ResultList<PluginBannerEntity>();
            res = await PluginBannerDomain.GetPluginBannerAll();

            if (res.Status == ErrorEnums.Success)
            {

                lstBanner.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.CategoryID == 1 && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.BannerOrder).Take(4).ToList();
                lstBanner.DataBind();

                //lstFooterApp.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.CategoryID == 1 && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.BannerOrder).Take(2).ToList();
                //lstFooterApp.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }

    int CountBanner = 1;
    protected void lstBanner_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image img = (Image)e.Item.FindControl("img");
                if (!string.IsNullOrEmpty(img.ImageUrl))
                    img.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + img.ImageUrl.Replace("~/", "~/Siteware/");
                HtmlGenericControl Li = (HtmlGenericControl)e.Item.FindControl("li");
                if (CountBanner == 4)
                {
                    Li.Attributes.Add("class", "libg4");
                }
                else if (CountBanner == 2)
                {
                    Li.Attributes.Add("class", "libg2");
                }
                else if (CountBanner == 3)
                {
                    Li.Attributes.Add("class", "libg3");
                }
                else
                {
                    Li.Attributes.Add("class", "libg1");
                }
                CountBanner++;

            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    //#region--> FillDialyAdvice
    //protected async void FillDialyAdvice()
    //{
    //    try
    //    {
    //        ResultList<Plugin_DailyAdviseEntity> res = new ResultList<Plugin_DailyAdviseEntity>();
    //        res = await Plugin_DailyAdviseDomain.GetAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {
    //            lstDailyAdvice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.DateFrom <= currentDate.Date && s.DateTo >= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
    //            lstDailyAdvice.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //#endregion



    //#region--> FillCompnay
    //protected async void FillCompnay()
    //{
    //    try
    //    {
    //        ResultList<Plugin_AboutCompanyEntity> res = new ResultList<Plugin_AboutCompanyEntity>();
    //        res = await Plugin_AboutCompanyDomain.GetAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstCompany.DataSource = res.List.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
    //            lstCompany.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstCompany_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgCompany = (Image)e.Item.FindControl("imgCompany");
    //            if (!string.IsNullOrEmpty(imgCompany.ImageUrl))
    //                imgCompany.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgCompany.ImageUrl.Replace("~/", "~/Siteware/");

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion


    //#region--> FillserviceTab
    //protected async void FillserviceTab()
    //{
    //    try
    //    {
    //        ResultList<PluginServiceTabEntity> res = new ResultList<PluginServiceTabEntity>();
    //        res = await PluginServiceTabDomain.GetDataPointAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstTab.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
    //            lstTab.DataBind();

    //            lstTabServiceData.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
    //            lstTabServiceData.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //int looplstProjectTab = 0;
    //protected void lstTab_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {

    //            HyperLink lnkTab = (HyperLink)e.Item.FindControl("lnkTab");
    //            lnkTab.Attributes["href"] = "#lstTabServiceData_home_" + looplstProjectTab;
    //            lnkTab.Attributes.Add("aria-controls", "lstProject_lstSubProjects_0_irbid_" + looplstProjectTab);

    //            Image imgTab1 = (Image)e.Item.FindControl("imgTab1");
    //            if (!string.IsNullOrEmpty(imgTab1.ImageUrl))
    //                imgTab1.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgTab1.ImageUrl.Replace("~/", "~/Siteware/");

    //            Image imgTab2 = (Image)e.Item.FindControl("imgTab2");
    //            if (!string.IsNullOrEmpty(imgTab2.ImageUrl))
    //                imgTab2.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgTab2.ImageUrl.Replace("~/", "~/Siteware/");

    //            looplstProjectTab++;

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //int countTabloop = 0;
    //protected async void lstTabServiceData_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            ResultList<PluginServiceEntity> Result = new ResultList<PluginServiceEntity>();
    //            ListView lstServiceData = (ListView)e.Item.FindControl("lstServiceData");
    //            HiddenField ID = (HiddenField)e.Item.FindControl("hdnid");
    //            Result = await PluginServiceDomain.GetDataPointAll();

    //            if (Result.Status == ErrorEnums.Success)
    //            {
    //                lstServiceData.DataSource = Result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.ServiceTabID == Convert.ToInt32(ID.Value) && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).ToList();
    //                lstServiceData.DataBind();
    //            }
    //            HtmlGenericControl home = (HtmlGenericControl)e.Item.FindControl("home");
    //            if (countTabloop == 0)
    //            {
    //                home.Attributes.Add("class", "tab-pane active");
    //            }
    //            else
    //            {
    //                home.Attributes.Add("class", "tab-pane");
    //            }


    //        }
    //        countTabloop++;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void lstServiceData_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgTab1 = (Image)e.Item.FindControl("imgTab1");
    //            if (!string.IsNullOrEmpty(imgTab1.ImageUrl))
    //                imgTab1.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgTab1.ImageUrl.Replace("~/", "~/Siteware/");

    //            Image imgTab2 = (Image)e.Item.FindControl("imgTab2");
    //            if (!string.IsNullOrEmpty(imgTab2.ImageUrl))
    //                imgTab2.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgTab2.ImageUrl.Replace("~/", "~/Siteware/");


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //#endregion


    //#region--> FillServiceNote
    //protected async void FillServiceNote()
    //{
    //    try
    //    {
    //        ResultList<Plugin_ServiceNoteEntity> res = new ResultList<Plugin_ServiceNoteEntity>();
    //        res = await Plugin_ServiceNoteDomain.GetAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {
    //            lstServiceNote.DataSource = res.List.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date).OrderBy(s => s.Order).Take(1).ToList();
    //            lstServiceNote.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}



    //#endregion



    //#region--> FillPrice
    //protected async void FillPrice()
    //{
    //    try
    //    {
    //        ResultList<Plugin_PriceEntity> res = new ResultList<Plugin_PriceEntity>();
    //        res = await Plugin_PriceDomain.GetAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {
    //            lstPrice.DataSource = res.List.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(1).ToList();
    //            lstPrice.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //#endregion

    //#region--> FillDataPoint
    //protected async void FillDatapoint()
    //{
    //    try
    //    {
    //        ResultList<PluginDataPointEntity> res = new ResultList<PluginDataPointEntity>();
    //        res = await PluginDataPointDomain.GetDataPointAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstDatapoint.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
    //            lstDatapoint.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstDatapoint_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgData = (Image)e.Item.FindControl("imgData");
    //            if (!string.IsNullOrEmpty(imgData.ImageUrl))
    //                imgData.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgData.ImageUrl.Replace("~/", "~/Siteware/");
    //            //< strong class="timer count-title count-number" data-to="7256765" data-speed="20000"></strong>
    //            Literal lblPoint = (Literal)e.Item.FindControl("lblPoint");

    //            string dataremove = lblPoint.Text.Replace(",", "");// string newOdd = odd.Replace(',', ':');
    //            lblPoint.Text = "<strong class='timer count-title count-number' data-to=' " + dataremove + "' data-speed='20000'> " + lblPoint.Text + "</strong>";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    //#region--> FillAnnousment
    //protected async void FillAnnousment()
    //{
    //    try
    //    {
    //        ResultList<PluginAnnouncementEntity> res = new ResultList<PluginAnnouncementEntity>();
    //        res = await PluginAnnouncementDomain.GetAnnouncementAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstAnnousment.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).Take(3).ToList();
    //            lstAnnousment.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstAnnousment_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {

    //            HiddenField hdnid = (HiddenField)e.Item.FindControl("hdnid");
    //            Literal lblTitle = (Literal)e.Item.FindControl("lblTitle");
    //            HyperLink lnkAnousment = (HyperLink)e.Item.FindControl("lnkAnousment");
    //            Literal lblDate = (Literal)e.Item.FindControl("lblDate");
    //            string lang = string.Empty;
    //            if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }

    //            string title = Regex.Replace(lblTitle.Text, @"[\\:/*#.]+", string.Empty);
    //            int ID = Convert.ToInt32(hdnid.Value.ToString());
    //            lnkAnousment.NavigateUrl = lang + "/AnnoucePage/" + title.Trim() + "/" + ID.ToString();

    //            var date = Convert.ToDateTime(lblDate.Text);


    //            var m = date.ToString("MMM");
    //            var month = date.ToString("MM", new CultureInfo("en-US"));

    //            var Date = date.ToString("dd", new CultureInfo("en-US"));
    //            var year = date.ToString("yyyy", new CultureInfo("en-US"));
    //            lblDate.Text = " " + Date + "-" + month + "-" + year;

    //            //if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            //{
    //            //    //Get month and convert to arabic
    //            //    var m = date.ToString("MMM");
    //            //    var month = date.ToString("MMM", new CultureInfo("ar-AE"));

    //            //    var Date = date.ToString("dd", new CultureInfo("ar-AE"));
    //            //    var year = date.ToString("yyyy", new CultureInfo("ar-AE"));
    //            //    lblDate.Text = month + " " + Date + " " + year;
    //            //}
    //            //else
    //            //{
    //            //    //Convert NewsDate in given dateformat
    //            //    var m = date.ToString("MMM");
    //            //    var month = date.ToString("MMM", new CultureInfo("en-US"));

    //            //    var Date = date.ToString("dd", new CultureInfo("en-US"));
    //            //    var year = date.ToString("yyyy", new CultureInfo("en-US"));
    //            //    lblDate.Text = month + " " + Date + " " + year;
    //            //}
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion


    //#region--> FillFinance_Prefomance
    //protected async void FillFinanacePrt()
    //{
    //    try
    //    {
    //        ResultList<Plugin_FinancePerformanceEntity> res = new ResultList<Plugin_FinancePerformanceEntity>();
    //        res = await Plugin_FinancePerformanceDomain.GetAll();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstFinancePrt.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ParentID == 0).OrderBy(s => s.Order).Take(1).ToList();
    //            lstFinancePrt.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstFinancePrt_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {

    //            ListView lstFinanceChild = (ListView)e.Item.FindControl("lstFinanceChild");
    //            HiddenField hndid = (HiddenField)e.Item.FindControl("hndid");

    //            ResultList<Plugin_FinancePerformanceEntity> Result1 = new ResultList<Plugin_FinancePerformanceEntity>();

    //            Result1 = Plugin_FinancePerformanceDomain.GetAllWithoutAsync();
    //            int ParentID = Convert.ToInt32(hndid.Value);
    //            Result1.List = Result1.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ParentID == ParentID).ToList();
    //            if (Result1.Status == ErrorEnums.Success)
    //            {
    //                lstFinanceChild.DataSource = Result1.List.ToList();
    //                lstFinanceChild.DataBind();
    //            }





    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void lstFinanceChild_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgFin = (Image)e.Item.FindControl("imgFin");
    //            if (!string.IsNullOrEmpty(imgFin.ImageUrl))
    //                imgFin.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgFin.ImageUrl.Replace("~/", "~/Siteware/");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    #region FillNews 
    protected async void FillNews()
    {
        try
        {
            ResultList<NewsEntity> res = new ResultList<NewsEntity>();
            res = await NewsDomain.GetNewsAll();
            if (res.Status == ErrorEnums.Success)
            {

                lstNews.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderByDescending(s => s.NewsDate).ThenBy(s => s.NewsOrder).Take(2).ToList();
                lstNews.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void lstNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HiddenField hdnNewsID = (HiddenField)e.Item.FindControl("hdnNewsID");
                Literal lblTitle = (Literal)e.Item.FindControl("lblTitle");
                HyperLink lnkNews = (HyperLink)e.Item.FindControl("lnkNews");
                Literal lblDate = (Literal)e.Item.FindControl("lblDate");
                string lang = string.Empty;
                if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                string title = Regex.Replace(lblTitle.Text, @"[\\:/*#.]+", string.Empty);
                int ID = Convert.ToInt32(hdnNewsID.Value.ToString());
                lnkNews.NavigateUrl = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();

                var date = Convert.ToDateTime(lblDate.Text);


                var m = date.ToString("MMM");
                var month = date.ToString("MMM", new CultureInfo("ar-AE"));
                var Date = date.ToString("dd", new CultureInfo("ar-AE"));

                lblDate.Text = " <span> " + Date + "<small> " + month + " </small></span>";

                Image imgNews = (Image)e.Item.FindControl("imgNews");
                if (!string.IsNullOrEmpty(imgNews.ImageUrl))
                    imgNews.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNews.ImageUrl.Replace("~/", "~/Siteware/");



            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    //#region--> FillFooterNavigation
    //protected void FillFooterNavigation()
    //{
    //    try
    //    {
    //        ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
    //        Result = FooterNavigationDomain.GetFooterAllWithoutAsync();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            long _parentID = 0;

    //            Result.List = Result.List.Where(s => s.ParentID == _parentID && s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Take(4).ToList();

    //            lstFooterNav.DataSource = Result.List.ToList();
    //            lstFooterNav.DataBind();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //    }
    //}
    //protected void lstFooterNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HiddenField hdnID = (HiddenField)e.Item.FindControl("hdnID");
    //            ListView lstFooterNavSub = (ListView)e.Item.FindControl("lstFooterNavSub");
    //            ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
    //            Result = FooterNavigationDomain.GetFooterAllWithoutAsync();
    //            if (Result.Status == ErrorEnums.Success)
    //            {
    //                long _parentID = Convert.ToInt32(hdnID.Value);

    //                Result.List = Result.List.Where(s => s.ParentID == _parentID && s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Take(4).ToList();

    //                lstFooterNavSub.DataSource = Result.List.ToList();
    //                lstFooterNavSub.DataBind();
    //            }




    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}



    //protected void lstFooterNavSub_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {

    //            //HyperLink lnkFooterNav = (HyperLink)e.Item.FindControl("lnkFooterNav");

    //            //if (string.IsNullOrEmpty(lnkFooterNav.NavigateUrl) || lnkFooterNav.NavigateUrl == "#")
    //            //{
    //            //    lnkFooterNav.NavigateUrl = "javascript:void(0);";
    //            //}
    //            //if (lnkFooterNav.Target == "1")
    //            //{
    //            //    lnkFooterNav.Target = "_blank";
    //            //}
    //            //else
    //            //{
    //            //    lnkFooterNav.Target = "_parent";
    //            //}
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    //#region--> FillVideoAlbum

    //#endregion

    //#region--> FillService
    //protected async void FillServices()
    //{
    //    try
    //    {
    //        ResultList<PluginServiceEntity> Result = new ResultList<PluginServiceEntity>();

    //        Result = await PluginServiceDomain.GetDataPointAll();

    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstServices.DataSource = Result.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ShowonSlider == true).Take(4).ToList();
    //            lstServices.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstServices_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {


    //            Image imgSocial = (Image)e.Item.FindControl("imgSocial");
    //            if (!string.IsNullOrEmpty(imgSocial.ImageUrl))
    //                imgSocial.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgSocial.ImageUrl.Replace("~/", "~/Siteware/");
    //            HiddenField hdnclr = (HiddenField)e.Item.FindControl("hdnclr");
    //            HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");

    //            if (hdnclr.Value == "1") { lnkSecondNav.Attributes.Add("class", "yellowbg"); }
    //            else if (hdnclr.Value == "2") { lnkSecondNav.Attributes.Add("class", "blackbg"); }
    //            else if (hdnclr.Value == "3") { lnkSecondNav.Attributes.Add("class", "redbg"); }
    //            else { lnkSecondNav.Attributes.Add("class", "bluebg"); }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion


    //#region Insert in Plugin_News_Letter and votes

    protected void btnSubscribes_click(object sender, EventArgs e)
    {
        Page.Validate("grp1");
        if (Page.IsValid)
        {
            Plugin_News_LetterEntity entity = new Plugin_News_LetterEntity();
            entity.EmailNewsLetter = txtSubscribe.Text;
            entity.SubscribeNewsLetter = true;
            entity.AddDate = DateTime.Now;
            entity.AddUser = "web";
            entity.EditDate = DateTime.Now;
            entity.EditUser = "web";

            var Result = Plugin_News_LetterDomain.InsertPlugin_News_LetterNonasync(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                //btnSubscribe.Text = "";
                txtSubscribe.Text = "";
                if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.Arabic)
                {
                    lblMessage.Text = "Your email has been successfully registered";
                    //btnOk.Text = "Ok";
                }
                else
                {
                    lblMessage.Text = "Your email has been successfully registered";
                    //btnOk.Text = "Ok";
                }
                txtSubscribe.Attributes.Add("style", "");
                mpeSuccess.Show();
                //mpeSubscribe.Show();

            }
        }
        else
        {

            txtSubscribe.Attributes.Add("style", "border: 1px solid red");
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        mpeSuccess.Hide();
    }


    protected void btnVote_click(object sender, EventArgs e)
    {

        Plugin_VotingEntity entity = new Plugin_VotingEntity();
        entity.VotingResult = RadioButtonList2.SelectedItem.Value;
        entity.Order = 0;
        entity.PublishedDate = DateTime.Now;
        entity.IsPublished = true;
        entity.IsDeleted = false;
        entity.LanguageID = 2;
        entity.AddDate = DateTime.Now;
        entity.AddUser = SessionManager.GetInstance.Users.ID.ToString();
        entity.EditDate = DateTime.Now;
        entity.EditUser = SessionManager.GetInstance.Users.ID.ToString();

        var Result = Plugin_VotingDomain.InsertNotAsync(entity);

        if (Result.Status == ErrorEnums.Success)
        {
            mpeSuccess.Show();

        }

        //if (Result.Status == ErrorEnums.Success)
        //{
        //}

    }
    //#endregion

    #region--> FillSocialMedia
    protected async void FillSocialMedia()
    {
        try
        {
            ResultList<PluginSocialIconEntity> res = new ResultList<PluginSocialIconEntity>();
            res = await PluginSocialIconDomain.GetPluginSocialIconAll();
            if (res.Status == ErrorEnums.Success)
            {



                lstSocialFooter.DataSource = res.List.Where(s => !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.IconOrder).Take(4).ToList();
                lstSocialFooter.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void lstSocial_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgsocial = (Image)e.Item.FindControl("imgsocial");
                if (!string.IsNullOrEmpty(imgsocial.ImageUrl))
                    imgsocial.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgsocial.ImageUrl.Replace("~/", "~/Siteware/");

                //Image ImgSocialIcon = (Image)e.Item.FindControl("SocialIconImg");
                HiddenField imgURL = (HiddenField)e.Item.FindControl("imgURL");
                //if (!string.IsNullOrEmpty(ImgSocialIcon.ImageUrl))
                //    ImgSocialIcon.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + ImgSocialIcon.ImageUrl.Replace("~/", "~/Siteware/");
                if (imgURL != null)
                {
                    if (!string.IsNullOrEmpty(imgURL.Value))
                    {
                        string imageover = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgURL.Value.Replace("~/", "~/Siteware/");
                        imgsocial.Attributes.Add("onmouseover", "this.src='" + imageover + "'");
                        imgsocial.Attributes.Add("onmouseout", "this.src='" + imgsocial.ImageUrl + "'");
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion


    //#region--> FillVideos
    //protected async void FillVideos()
    //{
    //    try
    //    {
    //        ResultList<Plugin_VideoEntity> Result = new ResultList<Plugin_VideoEntity>();

    //        Result = await Plugin_VideoDomain.GetAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lnkVideo.DataSource = Result.List.Where(s => s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).Take(4).ToList();
    //            lnkVideo.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lnkVideo_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgCoverImage = (Image)e.Item.FindControl("imgCoverImage");
    //            if (!string.IsNullOrEmpty(imgCoverImage.ImageUrl))
    //                imgCoverImage.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgCoverImage.ImageUrl.Replace("~/", "~/Siteware/");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    public string FetchLinksFromSource(string htmlSource)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        if (doc.DocumentNode.SelectNodes("//img") != null)
        {
            foreach (var img in doc.DocumentNode.SelectNodes("//img"))
            {
                string orig = img.Attributes["src"].Value;
                string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                img.SetAttributeValue("src", newsrc);
            }
        }
        return doc.DocumentNode.OuterHtml;
    }

    protected void bnt_lngChange_Click(object sender, EventArgs e)
    {
        //lblTitle.Text = "Message";
        //lblMessage.Text = "English website is under construction";
        lblTitle.Text = "English Language";
        lblMessage.Text = "We are currently working on our english version, It will be launched soon";

        mpeSuccess.Show();


    }


    //#region--> FillSocialIcon
    //protected void FillSocialIcon()
    //{
    //    try
    //    {
    //        ResultList<PluginSocialIconEntity> Result = new ResultList<PluginSocialIconEntity>();
    //        Result = PluginSocialIconDomain.GetPluginSocialIconAllNotAsync();

    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstSocialIcon.DataSource = Result.List.Where(q => q.LanguageID == CurrLangID).OrderBy(c => c.ID);
    //            lstSocialIcon.DataBind();

    //            lstMobSocialIcon.DataSource = Result.List.Where(q => q.LanguageID == CurrLangID).OrderBy(c => c.ID);
    //            lstMobSocialIcon.DataBind();

    //            lstFooterSocial.DataSource = Result.List.Where(q => q.LanguageID == CurrLangID).OrderBy(c => c.ID);
    //            lstFooterSocial.DataBind();
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    //protected void lstSocialIcon_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {
    //        Image ImgSocialIcon = (Image)e.Item.FindControl("imgSocialIcon");
    //        if (!string.IsNullOrEmpty(ImgSocialIcon.ImageUrl))
    //            ImgSocialIcon.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + ImgSocialIcon.ImageUrl.Replace("~/", "~/Siteware/");
    //    }
    //}
    //#endregion






    //#region--> FillFocusArea
    //protected async void FillFocusArea()
    //{
    //    try
    //    {
    //        ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
    //        Result = await Plugin_Focus_AreaDomain.GetAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lblFocusCount.Value = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList().Count.ToString();

    //            lstFocusArea.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            lstFocusArea.DataBind();

    //            lstFocusTitle.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            lstFocusTitle.DataBind();

    //            //lstFocusArea1.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            //lstFocusArea1.DataBind();

    //            //FocusCount = 0;
    //            //lstFocusArea2.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            //lstFocusArea2.DataBind();

    //            //// FocusCount = 0;
    //            //lstMobFocusArea.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            //lstMobFocusArea.DataBind();

    //            lstFocusAreaEntity.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).Take(6).ToList();
    //            lstFocusAreaEntity.DataBind();


    //        }
    //    }
    //    catch
    //    {
    //    }
    //}


    //int loopFocusTitle = 0;
    //protected void lstFocusTitle_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
    //            if (loopFocusTitle == 0)
    //            {
    //                lnkTitle.Attributes.Add("class", "nav-link active");
    //                lnkTitle.Attributes.Add("aria-selected", "true");
    //            }
    //            else
    //            {
    //                lnkTitle.Attributes.Add("class", "nav-link");
    //                lnkTitle.Attributes.Add("aria-selected", "false");
    //            }
    //            //lnkTitle.Attributes["href"] = "#" + lnkTitle.Text;

    //            //lnkTitle.Attributes["href"] = "#lstFocusAreaEntity_" + lnkTitle.Text + "_" + loopFocusTitle;
    //            lnkTitle.Attributes["href"] = "#lstFocusAreaEntity_divtitleid_" + loopFocusTitle;

    //            lnkTitle.Attributes.Add("aria-controls", "lstFocusAreaEntity_divtitleid_" + loopFocusTitle);


    //            // lnkTitle.ID = lnkTitle.Text + "-tab";

    //            HiddenField hdnFocusID = (HiddenField)e.Item.FindControl("hdnFocusID");
    //            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();

    //            Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();
    //            if (Result.Status == ErrorEnums.Success)
    //            {
    //                //lstFocusEntity.DataSource = Result.List.Where(q => q.FocusID == (Convert.ToInt64(hdnFocusID.Value)) && q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.Order).ToList();
    //                //lstFocusEntity.DataBind();


    //            }

    //            loopFocusTitle++;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}

    //int loopFocusEntity = 0;
    //protected void lstFocusAreaEntity_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        HtmlGenericControl divtitleid = (HtmlGenericControl)e.Item.FindControl("divtitleid");
    //        HtmlGenericControl divcarouselitem = (HtmlGenericControl)e.Item.FindControl("divcarouselitem");
    //        HiddenField hdnTitle = (HiddenField)e.Item.FindControl("hdnTitle");
    //        HiddenField hdnFocusid = (HiddenField)e.Item.FindControl("hdnFocusid");
    //        HtmlGenericControl demo = (HtmlGenericControl)e.Item.FindControl("demo");
    //        HiddenField lblColor = (HiddenField)e.Item.FindControl("lblColor");

    //        hdnColor.Value = lblColor.Value;
    //        if (loopFocusEntity == 0)
    //        {
    //            divtitleid.Attributes.Add("class", "tab-pane fade show active");

    //        }
    //        else
    //        {
    //            divtitleid.Attributes.Add("class", "tab-pane fade");

    //        }
    //        divtitleid.Attributes.Add("aria-labelledby", "lstFocusAreaEntity_divtitleid_" + loopFocusEntity + "-tab");
    //        //divtitleid.ID = hdnTitle.Value;

    //        ListView lstEntitys = (ListView)e.Item.FindControl("lstEntitys");


    //        ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();

    //        Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstEntitys.DataSource = Result.List.Where(q => q.FocusID == (Convert.ToInt64(hdnFocusid.Value)) && q.IsDelete == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishedDate <= currentDate).OrderBy(s => s.Order).ToList();
    //            lstEntitys.DataBind();
    //            looplstEntity = 0;
    //        }

    //        HyperLink lnkPrev = (HyperLink)e.Item.FindControl("lnkPrev");
    //        lnkPrev.Attributes["href"] = "#lstFocusAreaEntity_demo_" + loopFocusEntity;


    //        HyperLink lnkNext = (HyperLink)e.Item.FindControl("lnkNext");
    //        lnkNext.Attributes["href"] = "#lstFocusAreaEntity_demo_" + loopFocusEntity;

    //        loopFocusEntity++;

    //    }
    //    catch (Exception exp)
    //    {
    //    }
    //}

    //int looplstEntity = 0;
    //protected void lstEntitys_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divcarouselitem = (HtmlGenericControl)e.Item.FindControl("divcarouselitem");
    //            if (looplstEntity == 0)
    //            {
    //                divcarouselitem.Attributes.Add("class", "carousel-item active");
    //            }
    //            else
    //            {
    //                divcarouselitem.Attributes.Add("class", "carousel-item");
    //            }


    //            Image imgEntity = (Image)e.Item.FindControl("imgEntity");
    //            if (!string.IsNullOrEmpty(imgEntity.ImageUrl))
    //                imgEntity.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgEntity.ImageUrl.Replace("~/", "~/Siteware/");

    //            HiddenField hdnEntityId = (HiddenField)e.Item.FindControl("hdnEntityId");

    //            ListView lstDataPoint = (ListView)e.Item.FindControl("lstDataPoint");

    //            Literal lblSummary = (Literal)e.Item.FindControl("lblSummary");
    //            if (lblSummary.Text.Length > 400)
    //            {
    //                lblSummary.Text = lblSummary.Text.Substring(0, 400) + "...";
    //            }


    //            ResultList<PluginDataPointEntity> Result = new ResultList<PluginDataPointEntity>();

    //            Result = PluginDataPointDomain.GetDataPointAllNotAsync();


    //            if (Result.Status == ErrorEnums.Success)
    //            {
    //                lstDataPoint.DataSource = Result.List.Where(q => q.FocusID == (Convert.ToInt64(hdnEntityId.Value)) && q.IsDeleted == false && q.IsPublished == true && q.LanguageID == CurrLangID && q.PublishDate <= currentDate).OrderBy(s => s.Order).ToList();
    //                lstDataPoint.DataBind();
    //            }

    //            HyperLink lnkDetailsEntity = (HyperLink)e.Item.FindControl("lnkDetailsEntity");
    //            Literal lblEntityTitle = (Literal)e.Item.FindControl("lblEntityTitle");

    //            int ID = Convert.ToInt32(hdnEntityId.Value.ToString());
    //            string title = Regex.Replace(lblEntityTitle.Text, @"[\\:/*#.]+", " ");
    //            lnkDetailsEntity.NavigateUrl = lang + "/EntityPage/" + title.Trim() + "/" + ID.ToString();

    //            HtmlGenericControl spnEntityTitle = (HtmlGenericControl)e.Item.FindControl("spnEntityTitle");
    //            spnEntityTitle.Style.Add("color", hdnColor.Value);

    //            looplstEntity++;

    //        }
    //    }
    //    catch
    //    {
    //    }
    //}

    //protected void lstFocusArea_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divFocusArea = (HtmlGenericControl)e.Item.FindControl("divFocusArea");
    //            HiddenField lblColor = (HiddenField)e.Item.FindControl("lblColor");
    //            HyperLink lnkFocusArea = (HyperLink)e.Item.FindControl("lnkFocusArea");
    //            Image imgFocusArea = (Image)e.Item.FindControl("imgFocusArea");

    //            divFocusArea.Style.Add("background-color", lblColor.Value);
    //            if (!string.IsNullOrEmpty(imgFocusArea.ImageUrl))
    //                imgFocusArea.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgFocusArea.ImageUrl;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}

    //protected void lstDataPoint_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgDataPoint = (Image)e.Item.FindControl("imgDataPoint");
    //            Literal lblTitle = (Literal)e.Item.FindControl("lblTitle");
    //            if (!string.IsNullOrEmpty(imgDataPoint.ImageUrl))
    //                imgDataPoint.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgDataPoint.ImageUrl.Replace("~/", "~/Siteware/");

    //            if (lblTitle.Text.Length > 22)
    //            {
    //                lblTitle.Text = lblTitle.Text.Substring(0, 22);
    //            }


    //        }
    //    }
    //    catch
    //    {
    //    }
    //}


    //#endregion

    //#region--> FillWelcomeNote
    //protected async void FillWelcomeNote()
    //{
    //    try
    //    {
    //        ResultList<StatisticNoteEntity> Result = new ResultList<StatisticNoteEntity>();
    //        Result = await StatisticNoteDomain.GetWelcomeNoteAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            var record = Result.List.Where(s => s.IsDeleted == false && s.IsPublished == true && s.PublishDate <= currentDate).FirstOrDefault();
    //            if (record != null)
    //            {
    //                lnkWelcome1.NavigateUrl = record.Link;
    //                lnkWelcome2.NavigateUrl = record.Link;
    //                lnkWelcome3.NavigateUrl = record.Link;
    //                if (record.TargetID == 1)
    //                {
    //                    lnkWelcome1.Target = "_blank";
    //                    lnkWelcome2.Target = "_blank";
    //                    lnkWelcome3.Target = "_blank";
    //                }
    //                else
    //                {
    //                    lnkWelcome1.Target = "_parent";
    //                    lnkWelcome2.Target = "_parent";
    //                    lnkWelcome3.Target = "_parent";
    //                }
    //                imgWelcomeNote.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + record.Image;
    //                lblWelTitle.Text = record.Title;
    //                lblSummary.Text = record.Description;
    //            }
    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
    //#endregion
    //#region--> FillNews
    //List<List<NewsEntity>> splitNewsList = new List<List<NewsEntity>>();
    //protected async void FillNews()
    //{
    //    try
    //    {
    //        ResultList<NewsEntity> Result = new ResultList<NewsEntity>();
    //        Result = await NewsDomain.GetNewsAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            Result.List = Result.List.Where(q => q.IsDeleted == false && q.LanguageID == (byte)CurrLangID && q.IsPublished == true && q.PublishDate.Date <= currentDate.Date).OrderBy(s => s.NewsOrder).ThenByDescending(q => q.NewsDate).ToList();
    //            splitNewsList = CommonFunction.SplitList(Result.List, 3);

    //            lstMobileNews.DataSource = Result.List;
    //            lstMobileNews.DataBind();

    //            lstNewsDots.DataSource = splitNewsList.ToList();
    //            lstNewsDots.DataBind();

    //            lstNewsMain.DataSource = splitNewsList.ToList();
    //            lstNewsMain.DataBind();
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //int newsDots = 0;
    //protected void lstNewsDots_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl liNews = (HtmlGenericControl)e.Item.FindControl("liNews");
    //            if (newsDots == 0)
    //            {
    //                liNews.Attributes.Add("class", "active");
    //            }
    //            liNews.Attributes.Add("data-slide-to", newsDots.ToString());
    //            newsDots++;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //int newsMain = 0;
    //protected void lstNewsMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divNewsMain = (HtmlGenericControl)e.Item.FindControl("divNewsMain");
    //            ListView lstNews = (ListView)e.Item.FindControl("lstNews");
    //            if (newsMain == 0)
    //            {
    //                divNewsMain.Attributes.Add("class", "carousel-item active");
    //            }
    //            if (lstNews != null)
    //            {
    //                lstNews.DataSource = splitNewsList[newsMain].ToList();
    //                lstNews.DataBind();
    //            }
    //            newsMain++;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //int newsCount = 0;
    //protected void lstNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HiddenField lblNewsID = (HiddenField)e.Item.FindControl("lblNewsID");
    //            Literal lblHeadline = (Literal)e.Item.FindControl("lblHeadline");
    //            Literal lblNewsDate = (Literal)e.Item.FindControl("lblNewsDate");
    //            Literal lblSummary = (Literal)e.Item.FindControl("lblSummary");
    //            HyperLink lnkReadmore = (HyperLink)e.Item.FindControl("lnkReadmore");
    //            HtmlGenericControl divNewMob = (HtmlGenericControl)e.Item.FindControl("divNewMob");

    //            Image imgNews = (Image)e.Item.FindControl("imgNews");
    //            imgNews.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgNews.ImageUrl.Replace("~/", "~/Siteware/");

    //            string lang = string.Empty;
    //            if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }

    //            string title = Regex.Replace(lblHeadline.Text, @"[\\:/*#.]+", string.Empty);
    //            int ID = Convert.ToInt32(lblNewsID.Value.ToString());
    //            lnkReadmore.NavigateUrl = lang + "/NewsPage/" + title.Trim() + "/" + ID.ToString();

    //            var date = Convert.ToDateTime(lblNewsDate.Text);

    //            if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                //Get month and convert to arabic
    //                var m = date.ToString("MMM");
    //                var month = date.ToString("MMM", new CultureInfo("ar-AE"));

    //                var Date = date.ToString("dd", new CultureInfo("ar-AE"));
    //                var year = date.ToString("yyyy", new CultureInfo("ar-AE"));
    //                lblNewsDate.Text = month + " " + Date + " " + year;
    //            }
    //            else
    //            {
    //                //Convert NewsDate in given dateformat
    //                var m = date.ToString("MMM");
    //                var month = date.ToString("MMM", new CultureInfo("en-US"));

    //                var Date = date.ToString("dd", new CultureInfo("en-US"));
    //                var year = date.ToString("yyyy", new CultureInfo("en-US"));
    //                lblNewsDate.Text = month + " " + Date + " " + year;
    //            }
    //            if (lblSummary.Text.Length > 200)
    //            {
    //                lblSummary.Text = lblSummary.Text.Substring(0, 200) + "...";
    //            }
    //            if (divNewMob != null)
    //            {
    //                if (newsCount == 0)
    //                {
    //                    divNewMob.Attributes.Add("class", "carousel-item active");
    //                }
    //            }
    //            newsCount++;

    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //#endregion
    //#region--> FillCoreValue
    //protected async void FillCoreValue()
    //{
    //    try
    //    {
    //        ResultList<Plugin_Core_ValueEntity> Result = new ResultList<Plugin_Core_ValueEntity>();
    //        Result = await Plugin_Core_ValueDomain.GetAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstCoreValue.DataSource = Result.List.Where(q => q.IsDelete == false && q.LanguageID == CurrLangID && q.IsPublished == true).OrderBy(s => s.Order).Take(5).ToList();
    //            lstCoreValue.DataBind();
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //protected void lstCoreValue_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkCoreValue = (HyperLink)e.Item.FindControl("lnkCoreValue");
    //            Image imgCoreValue = (Image)e.Item.FindControl("imgCoreValue");
    //            HiddenField lblCoreID = (HiddenField)e.Item.FindControl("lblCoreID");
    //            Literal lblCoreTitle = (Literal)e.Item.FindControl("lblCoreTitle");
    //            Literal lblCoreSummary = (Literal)e.Item.FindControl("lblCoreSummary");

    //            imgCoreValue.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgCoreValue.ImageUrl;

    //            string title = Regex.Replace(lblCoreTitle.Text, @"[\\:/*#.]+", string.Empty);
    //            int ID = Convert.ToInt32(lblCoreID.Value.ToString());
    //            lnkCoreValue.NavigateUrl = lang + "/CoreValuePage/" + title.Trim() + "/" + ID.ToString();

    //            if (lblCoreSummary.Text.Length > 130)
    //            {
    //                lblCoreSummary.Text = lblCoreSummary.Text.Substring(0, 130) + "...";
    //            }
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //#endregion
    //#region--> splitResult
    //List<List<PluginPartnerEntity>> splitResult = new List<List<PluginPartnerEntity>>();
    //protected async void FillPartner()
    //{
    //    try
    //    {
    //        ResultList<PluginPartnerEntity> Result = new ResultList<PluginPartnerEntity>();
    //        Result = await PluginPartnerDomain.GetPluginpartnerAll();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            Result.List = Result.List.Where(s => s.IsDeleted == false && s.IsPublished && s.LanguageID == CurrLangID && s.PublishDate <= currentDate).OrderBy(s => s.Order).ToList();
    //            if (Result.List.Count > 0)
    //            {
    //                splitResult = CommonFunction.SplitList(Result.List, 4);
    //                lstPartnerDots.DataSource = splitResult.ToList();
    //                lstPartnerDots.DataBind();

    //                lstPartnerMain.DataSource = splitResult.ToList();
    //                lstPartnerMain.DataBind();
    //            }
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //int dotPartner = 0;
    //protected void lstPartnerDots_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl liPartner = (HtmlGenericControl)e.Item.FindControl("liPartner");
    //            if (dotPartner == 0)
    //            {
    //                liPartner.Attributes.Add("class", "active");
    //            }
    //            liPartner.Attributes.Add("data-slide-to", dotPartner.ToString());
    //            dotPartner++;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //int mainPartner = 0;
    //protected void lstPartnerMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divPartner = (HtmlGenericControl)e.Item.FindControl("divPartner");
    //            ListView lstPartner = (ListView)e.Item.FindControl("lstPartner");
    //            if (mainPartner == 0)
    //            {
    //                divPartner.Attributes.Add("class", "carousel-item active");
    //            }
    //            if (lstPartner != null)
    //            {
    //                lstPartner.DataSource = splitResult[mainPartner].ToList();
    //                lstPartner.DataBind();
    //            }

    //            mainPartner++;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //protected void lstPartner_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkPartner = (HyperLink)e.Item.FindControl("lnkPartner");
    //            Image imgPartner = (Image)e.Item.FindControl("imgPartner");
    //            imgPartner.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgPartner.ImageUrl;
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //#endregion

    //#region--> FillFooterNavigation
    //protected void FillFooterNavigation()
    //{
    //    try
    //    {
    //        ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
    //        Result = FooterNavigationDomain.GetFooterAllWithoutAsync();
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            long _parentID = 0;

    //            var record = Result.List.Where(s => s.ParentID == _parentID && s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).FirstOrDefault();
    //            if (record != null)
    //            {
    //                _parentID = record.ID;
    //                lblFooterNavTitle.Text = record.Title;
    //            }

    //            Result.List = Result.List.Where(s => s.ParentID == _parentID && s.IsDeleted == false && s.IsPublished == true && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).ToList();

    //            lstFooterNavigation.DataSource = Result.List.ToList();
    //            lstFooterNavigation.DataBind();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //    }
    //}
    //protected void lstFooterNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkFooterNav = (HyperLink)e.Item.FindControl("lnkFooterNav");

    //            if (string.IsNullOrEmpty(lnkFooterNav.NavigateUrl) || lnkFooterNav.NavigateUrl == "#")
    //            {
    //                lnkFooterNav.NavigateUrl = "javascript:void(0);";
    //            }
    //            if (lnkFooterNav.Target == "1")
    //            {
    //                lnkFooterNav.Target = "_blank";
    //            }
    //            else
    //            {
    //                lnkFooterNav.Target = "_parent";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

    //#region--> FillPhotoAlbum
    //List<List<PluginAlbumEntity>> splitAlbumList = new List<List<PluginAlbumEntity>>();
    //protected async void FillPhotoAlbum()
    //{
    //    try
    //    {
    //        ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();
    //        result = await PluginAlbumDomain.GetPluginAlbumAll();
    //        if (result.Status == ErrorEnums.Success)
    //        {
    //            result.List = result.List.Where(s => s.TypeID == 1 && s.LanguageID == CurrLangID && s.IsDeleted == false && s.IsPublish).OrderBy(s => s.AlbumOrder).Take(9).ToList();

    //            splitAlbumList = CommonFunction.SplitList(result.List, 3);

    //            lstPAlbumDots.DataSource = splitAlbumList.ToList();
    //            lstPAlbumDots.DataBind();

    //            lstPhotoMain.DataSource = splitAlbumList.ToList();
    //            lstPhotoMain.DataBind();

    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
    //int photoDotCount = 0;
    //protected void lstPAlbumDots_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl liPhotoDots = (HtmlGenericControl)e.Item.FindControl("liPhotoDots");
    //            if (photoDotCount == 0)
    //            {
    //                liPhotoDots.Attributes.Add("class", "active");
    //            }
    //            liPhotoDots.Attributes.Add("data-slide-to", photoDotCount.ToString());
    //            photoDotCount++;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //int PhotoMainCount = 0;
    //protected void lstPhotoMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divPhotoAlbum = (HtmlGenericControl)e.Item.FindControl("divPhotoAlbum");
    //            ListView lstPhotoAlbum = (ListView)e.Item.FindControl("lstPhotoAlbum");
    //            if (PhotoMainCount == 0)
    //            {
    //                divPhotoAlbum.Attributes.Add("class", "carousel-item active");
    //            }
    //            if (lstPhotoAlbum != null)
    //            {
    //                lstPhotoAlbum.DataSource = splitAlbumList[PhotoMainCount];
    //                lstPhotoAlbum.DataBind();
    //            }
    //            PhotoMainCount++;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void lstPhotoAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkPhotoAlbum = (HyperLink)e.Item.FindControl("lnkPhotoAlbum");
    //            HiddenField lblAlbumID = (HiddenField)e.Item.FindControl("lblAlbumID");
    //            HiddenField lblAlbumTitle = (HiddenField)e.Item.FindControl("lblAlbumTitle");
    //            Image imgPhotoAlbum = (Image)e.Item.FindControl("imgPhotoAlbum");
    //            string lang = string.Empty;
    //            if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }
    //            string title = Regex.Replace(lblAlbumTitle.Value, @"[\\:/*#.]+", string.Empty);
    //            int ID = Convert.ToInt32(lblAlbumID.Value.ToString());
    //            lnkPhotoAlbum.NavigateUrl = lang + "/PhotoGalleryDetail/" + title.Trim() + "/" + ID.ToString();
    //            imgPhotoAlbum.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgPhotoAlbum.ImageUrl;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion
    //#region--> FillVideoAlbum
    //List<List<PluginAlbumEntity>> splitVideoList = new List<List<PluginAlbumEntity>>();
    //protected async void FillVideoAlbum()
    //{
    //    try
    //    {
    //        ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();
    //        result = await PluginAlbumDomain.GetPluginAlbumAll();
    //        if (result.Status == ErrorEnums.Success)
    //        {
    //            result.List = result.List.Where(s => s.TypeID == 3 && s.LanguageID == CurrLangID && s.IsDeleted == false && s.IsPublish).OrderBy(s => s.AlbumOrder).Take(9).ToList();

    // splitVideoList = CommonFunction.SplitList(result.List, 3);

    //            lstVAlbumDots.DataSource = splitVideoList.ToList();
    //            lstVAlbumDots.DataBind();

    //            lstVideoMain.DataSource = splitVideoList.ToList();
    //            lstVideoMain.DataBind();

    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
    //int videoDotCount = 0;
    //protected void lstVAlbumDots_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl liVideoDots = (HtmlGenericControl)e.Item.FindControl("liVideoDots");
    //            if (videoDotCount == 0)
    //            {
    //                liVideoDots.Attributes.Add("class", "active");
    //            }
    //            liVideoDots.Attributes.Add("data-slide-to", videoDotCount.ToString());
    //            videoDotCount++;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //int VideoMainCount = 0;
    //protected void lstVideoMain_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl divVideoAlbum = (HtmlGenericControl)e.Item.FindControl("divVideoAlbum");
    //            ListView lstVideoAlbum = (ListView)e.Item.FindControl("lstVideoAlbum");
    //            if (VideoMainCount == 0)
    //            {
    //                divVideoAlbum.Attributes.Add("class", "carousel-item active");
    //            }
    //            if (lstVideoAlbum != null)
    //            {
    //                lstVideoAlbum.DataSource = splitVideoList[VideoMainCount];
    //                lstVideoAlbum.DataBind();
    //            }
    //            VideoMainCount++;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void lstVideoAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkVideoAlbum = (HyperLink)e.Item.FindControl("lnkVideoAlbum");
    //            HiddenField lblAlbumID = (HiddenField)e.Item.FindControl("lblAlbumID");
    //            HiddenField lblAlbumTitle = (HiddenField)e.Item.FindControl("lblAlbumTitle");
    //            Image imgVideoAlbum = (Image)e.Item.FindControl("imgVideoAlbum");
    //            string lang = string.Empty;
    //            if (CurrLangID == Convert.ToInt32(EnumLanguage.Arabic))
    //            {
    //                lang = "/ar";
    //            }
    //            else
    //            {
    //                lang = "/en";
    //            }



    //            string title = Regex.Replace(lblAlbumTitle.Value, @"[\\:/*#.]+", string.Empty);
    //            int ID = Convert.ToInt32(lblAlbumID.Value.ToString());
    //            //lnkVideoAlbum.NavigateUrl = lang + "/VideoGalleryDetail/" + title.Trim() + "/" + ID.ToString();
    //            imgVideoAlbum.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgVideoAlbum.ImageUrl;

    //            int PageID = 0;
    //            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
    //            if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
    //            {
    //                PageID = 4043;
    //            }
    //            else
    //            {
    //                PageID = 4043;
    //            }

    //            PageResult = PagesDomain.GetPagesByPageIDNotAsync(PageID);
    //            if (PageResult.Status == ErrorEnums.Success)
    //            {
    //                lnkVideoAlbum.NavigateUrl = PageResult.Entity.AliasPath;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion
    //#region-->

    //#endregion
    //#region--> Others
    //protected void lnkSubmitForm_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Page.Validate("g1");
    //        if (Page.IsValid)
    //        {
    //            //if (isName && isInterest && isEmail)
    //            //{
    //            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();
    //            ContactUsFormEntity entity = new ContactUsFormEntity();
    //            entity.Name = txtName.Text;
    //            entity.Email = txtEmail.Text;
    //            entity.Title = txtInterest.Text;
    //            entity.Message = txtMessage.Text;
    //            entity.AddDate = DateTime.Now;
    //            entity.IsDeleted = false;
    //            entity.Contact = 0;

    //            result = ContactUsFormDomain.InsertContactUsForm(entity);
    //            if (result.Status == ErrorEnums.Success)
    //            {
    //                txtName.Text = "";
    //                txtName.Style.Add("border", "0");
    //                txtEmail.Text = "";
    //                txtEmail.Style.Add("border", "0");
    //                txtInterest.Text = "";
    //                txtInterest.Style.Add("border", "0");
    //                txtMessage.Text = "";
    //                lblMessage.Text = "Your Inqiry submitted successfully";
    //                mpeInquiry.Show();
    //            }
    //            //}
    //            //else
    //            //{
    //            //    lnkSubmitForm.Focus();
    //            //}
    //        }
    //        else
    //        {

    //            if (!string.IsNullOrEmpty(txtName.Text))
    //            {

    //                txtName.Style.Add("border", "0");
    //            }
    //            else
    //            {
    //                txtName.Style.Add("border", "1px solid #ff0000");

    //            }
    //            if (!string.IsNullOrEmpty(txtInterest.Text))
    //            {

    //                txtInterest.Style.Add("border", "0");
    //            }
    //            else
    //            {
    //                txtInterest.Style.Add("border", "1px solid #ff0000");

    //            }

    //            if (!string.IsNullOrEmpty(txtEmail.Text))
    //            {
    //                bool isMatch = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    //                if (isMatch)
    //                {

    //                    txtEmail.Style.Add("border", "0");
    //                }
    //                else
    //                {
    //                    txtEmail.Style.Add("border", "1px solid #ff0000");
    //                }
    //            }
    //            else
    //            {
    //                txtEmail.Style.Add("border", "1px solid #ff0000");
    //            }
    //            lnkSubmitForm.Focus();

    //        }


    //        //bool isName = false;
    //        //bool isEmail = false;
    //        //bool isInterest = false;

    //        //if (!string.IsNullOrEmpty(txtName.Text))
    //        //{
    //        //    isName = true;
    //        //    txtName.Style.Add("border", "0");
    //        //}
    //        //else
    //        //{
    //        //    txtName.Style.Add("border", "1px solid #ff0000");

    //        //}
    //        //if (!string.IsNullOrEmpty(txtInterest.Text))
    //        //{
    //        //    isInterest = true;
    //        //    txtInterest.Style.Add("border", "0");
    //        //}
    //        //else
    //        //{
    //        //    txtInterest.Style.Add("border", "1px solid #ff0000");

    //        //}

    //        //if (!string.IsNullOrEmpty(txtEmail.Text))
    //        //{
    //        //    bool isMatch = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    //        //    if (isMatch)
    //        //    {
    //        //        isEmail = true;
    //        //        txtEmail.Style.Add("border", "0");
    //        //    }
    //        //    else
    //        //    {
    //        //        txtEmail.Style.Add("border", "1px solid #ff0000");
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    txtEmail.Style.Add("border", "1px solid #ff0000");
    //        //}





    //        //if (isName && isInterest && isEmail)
    //        //{
    //        //    ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();
    //        //    ContactUsFormEntity entity = new ContactUsFormEntity();
    //        //    entity.Name = txtName.Text;
    //        //    entity.Email = txtEmail.Text;
    //        //    entity.Title = txtInterest.Text;
    //        //    entity.Message = txtMessage.Text;
    //        //    entity.AddDate = DateTime.Now;
    //        //    entity.IsDeleted = false;
    //        //    entity.Contact = 0;

    //        //    result = ContactUsFormDomain.InsertContactUsForm(entity);
    //        //    if (result.Status == ErrorEnums.Success)
    //        //    {
    //        //        txtName.Text = "";
    //        //        txtEmail.Text = "";
    //        //        txtInterest.Text = "";
    //        //        txtMessage.Text = "";
    //        //        lblMessage.Text = "Your Inqiry submitted successfully";
    //        //        mpeSuccess.Show();
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    lnkSubmitForm.Focus();
    //        //}


    //    }
    //    catch
    //    {
    //    }
    //}
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string SearchText = string.Empty;
    //        string lang = string.Empty;
    //        if (!string.IsNullOrEmpty(txtSearch.Text))
    //            SearchText = txtSearch.Text.Trim();
    //        if (!string.IsNullOrEmpty(txtMobSearch.Text))
    //            SearchText = txtMobSearch.Text.Trim();
    //        if (LangID == 1)
    //        {
    //            lang = "en";
    //        }
    //        else
    //        {
    //            lang = "ar";
    //        }

    //        Response.Redirect("~/DetailsPage/" + lang + "/SearchPage.aspx?keyword=" + SearchText, false);
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void txtSearch_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //string SearchText = string.Empty;
    //        //string lang = string.Empty;
    //        //if (!string.IsNullOrEmpty(txtSearch.Text))
    //        //    SearchText = txtSearch.Text.Trim();
    //        //if (LangID == 1)
    //        //{
    //        //    lang = "en";               
    //        //}
    //        //else
    //        //{
    //        //    lang = "ar";

    //        //}            
    //        //Response.Redirect("~/DetailsPage/" + lang + "/SearchPage.aspx?keyword=" + SearchText, false);            
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void lnkLanguage_Click(object sender, EventArgs e)
    //{
    //    if (lblLangID.Value == "2")
    //    {
    //        lblTitle.Text = "Arabic language is coming soon";
    //        lblMessage.Text = "الموقع باللغة العربية تحت الانشاء";
    //        mpeSuccess.Show();
    //    }
    //}
    //#endregion

    //protected void btnNewLetterClose_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Default.aspx");
    //}

    //#region--> Get Tweets | ADD | Jigar Patel | 02052019
    //public class Tweets
    //{
    //    public string Id { get; set; }
    //    public string Text { get; set; }
    //    public string Link { get; set; }
    //    public List<string> hashTags { get; set; }
    //    public string UserName { get; set; }
    //    public string ScreenName { get; set; }
    //    public string PostDate { get; set; }
    //    public string PostTime { get; set; }
    //}
    //protected void FillTwitter()
    //{
    //    try
    //    {
    //        List<Tweets> listTweet = new List<Tweets>();
    //        //--------------------- Get Twitter Tweets --------------------------------------
    //        var twitter = new Twitter
    //        {
    //            OAuthConsumerKey = ConfigurationManager.AppSettings["APIKey"].ToString(),
    //            OAuthConsumerSecret = ConfigurationManager.AppSettings["APISecret"].ToString()
    //        };
    //        IEnumerable<dynamic> twitts = twitter.GetAccessToken("KHF_NHF", 50).Result;

    //        foreach (var t in twitts)
    //        {
    //            Tweets tw = new Tweets();
    //            var tID = (JValue)t["id"];
    //            var tText = (JValue)t["text"];
    //            var hashTags = t["entities"]["hashtags"];
    //            var tName = t["entities"]["user_mentions"];
    //            var tDate = (JValue)t["created_at"];
    //            string[] dateTime = tDate.ToString().Split(' ');

    //            tw.PostDate = dateTime[2] + " " + dateTime[1] + " " + dateTime[5];
    //            tw.PostTime = dateTime[3];

    //            List<string> htag = new List<string>();
    //            foreach (var h in hashTags)
    //            {
    //                try
    //                {
    //                    string tags = string.Empty;
    //                    string t1 = Convert.ToString((JValue)h["text"]);
    //                    tags = "#" + t1 + " ";
    //                    htag.Add(tags);

    //                }
    //                catch (Exception ex)
    //                {
    //                }
    //            }
    //            tw.hashTags = htag;


    //            foreach (var name in tName)
    //            {
    //                try
    //                {
    //                    string n1 = Convert.ToString((JValue)name["screen_name"]);
    //                    string n2 = Convert.ToString((JValue)name["name"]);
    //                    tw.ScreenName = n1;
    //                    tw.UserName = n2;
    //                }
    //                catch
    //                {
    //                }
    //            }
    //            try
    //            {
    //                var resultLink = t["extended_entities"];
    //                var tLink = resultLink["media"][0]["url"];
    //                if (tLink != null)
    //                    tw.Link = Convert.ToString(tLink);
    //                else
    //                {
    //                    tw.Link = "https://twitter.com/i/web/status/" + tID;
    //                }
    //            }
    //            catch
    //            {
    //                try
    //                {
    //                    var resultLink1 = t["entities"];
    //                    var tLink1 = resultLink1["urls"][0]["expanded_url"];
    //                    if (tLink1 != null)
    //                        tw.Link = Convert.ToString(tLink1);
    //                }
    //                catch
    //                {
    //                    tw.Link = "https://twitter.com/i/web/status/" + tID;
    //                }
    //            }
    //            if (tID != null)
    //                tw.Id = Convert.ToString(tID.Value);
    //            if (tText != null)
    //                tw.Text = Convert.ToString(tText.Value);


    //            if (htag.Count > 0)
    //            {
    //                foreach (var a in htag)
    //                {
    //                    try
    //                    {
    //                        tw.Text = tw.Text.Replace(a, "<span>" + a + "</span>");
    //                    }
    //                    catch
    //                    {
    //                    }
    //                }
    //            }

    //            // tw.hashTags.Add(tags);

    //            listTweet.Add(tw);
    //        }
    //        if (listTweet.Count >= 0)
    //        {
    //            //lstTweets.DataSource = listTweet.Take(2);
    //            //lstTweets.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //throw ex;
    //    }
    //}
    //protected void lstTweets_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Literal lblTime = (Literal)e.Item.FindControl("lblTime");
    //            Literal lblName2 = (Literal)e.Item.FindControl("lblName2");
    //            var dateTime = DateTime.ParseExact(lblTime.Text, "H:mm:ss", null, System.Globalization.DateTimeStyles.None);
    //            lblTime.Text = dateTime.ToString("hh:mm tt");
    //            if (!string.IsNullOrEmpty(lblName2.Text))
    //                lblName2.Text = "@" + lblName2.Text;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}
    //#endregion

    //protected void lnkSearch_Click(object sender, EventArgs e) {
    //    try {
    //        string SearchText = string.Empty;
    //        string lang = string.Empty;
    //        if (!string.IsNullOrEmpty(txtSearch.Text)) SearchText = txtSearch.Text.Trim();
    //        if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.Arabic) 
    //        { 
    //            LangID = 2;
    //            lang = "/ar"; 
    //        }
    //        else 
    //        { 
    //            LangID = 1;
    //            lang = "/en"; 
    //        }

    //        Response.Redirect("~/DetailsPage/" + lang + "/SearchPage.aspx?keyword=" + SearchText, false);
    //    } 
    //    catch (Exception ex) 
    //    { throw ex; }
    //}


    //protected void lstNavigation2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var test = ((HiddenField)lstNavigation2.Items[0].FindControl("hiddnloop")).Value;
    //    HtmlGenericControl lstmenu = ((HtmlGenericControl)lstNavigation2.Items[0].FindControl("lstmenu"));
    //    lstmenu.Attributes.Add("class", "active Mydropli dropli" + test);
    //}




    protected async void logout_Click(object sender, EventArgs e)
    {


        long LastLoginId = Convert.ToInt64(hdhLastLoginId.Value);
        if (LastLoginId >= 1)
        {
            long UserId = SessionManager.GetInstance.Users.ID;
            LastLoginTimeEntity LastLoginEntity = new LastLoginTimeEntity();
            LastLoginEntity.ServiceUserID = UserId;
            LastLoginEntity.LastLoginTime = DateTime.Now;
            var LastLoginResult = await LastLoginTimeDomain.Update(LastLoginEntity);
            if (LastLoginResult.Status == ErrorEnums.Success)
            {
                Session.Clear();
                Session.Abandon();
                //Response.Redirect("~/Login.aspx");
                Response.Redirect("~/LoginPage/Login.aspx", false);
            }
        }
        else
        {
            long UserId = SessionManager.GetInstance.Users.ID;
            LastLoginTimeEntity LastLoginEntity = new LastLoginTimeEntity();
            LastLoginEntity.ServiceUserID = UserId;
            LastLoginEntity.LastLoginTime = DateTime.Now;
            var LastLoginResult = await LastLoginTimeDomain.Insert(LastLoginEntity);
            if (LastLoginResult.Status == ErrorEnums.Success)
            {
                Session.Clear();
                Session.Abandon();
                //Response.Redirect("~/Login.aspx");
                Response.Redirect("~/LoginPage/Login.aspx", false);
            }
        }

        //Session.Clear();
        //Session.Abandon();
        ////Response.Redirect("~/Login.aspx");
        //Response.Redirect("~/LoginPage/Login.aspx", false);

    }


    protected void lnkFileDetails_Click(object sender, EventArgs e)
    {
        Session["FileDetails"] = htdFilenameDetais.Value.ToString();
        Response.Redirect(lang + "/Home/FileDatails", false);
    }
    protected void LnkPaymentDetails_Click(object sender, EventArgs e)
    {
        Session["PaymentDetails"] = htdFilenameDetais.Value.ToString();
        Response.Redirect(lang + "/Home/Payment", false);
    }
    protected async void btn_ok_Click(object sender, EventArgs e)
    {

        //Page.Validate("OTPValidation");
        //if (Page.IsValid)
        //{
            string OTp = txtOPT.Text;

           
            long UserId = SessionManager.GetInstance.Users.ID;


            ResultEntity<MobileRegistationEntity> MobileRegiEntity = new ResultEntity<MobileRegistationEntity>();
            MobileRegiEntity = MobileRegistationDomain.GetByIDNotAsync(UserId);
            if (MobileRegiEntity.Status == ErrorEnums.Success)
            {

                if (MobileRegiEntity.Entity.OTP == OTp)
                {
                    MobileRegistationEntity MemberOTPEntity = new MobileRegistationEntity();

                    MemberOTPEntity.RegistationID = MobileRegiEntity.Entity.RegistationID;
                    MemberOTPEntity.ServiceUserID = MobileRegiEntity.Entity.ServiceUserID;
                    MemberOTPEntity.MobileNumber = MobileRegiEntity.Entity.MobileNumber;
                    MemberOTPEntity.OTP = MobileRegiEntity.Entity.OTP;
                    MemberOTPEntity.IsVerify = true;


                    var MemberOTPResult = MobileRegistationDomain.UpdateNotAsync(MemberOTPEntity);
                    if (MemberOTPResult.Status == ErrorEnums.Success)
                    {

                        FillServiceUser();
                    }
                    else
                    {
                    lblErroreOTP.Visible = true;
                        FillServiceUser();
                    }
                }
                else
                {
                lblErroreOTP.Visible = true;
                FillServiceUser();
                }

            }

       // }

       



     }

    public async Task<GetSMSCred> GetAccessToken()
    {
        GetSMSCred sMSCred = new GetSMSCred();
        try
        {
            var httpClient = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
            var request = new HttpRequestMessage(HttpMethod.Post, ConfigurationManager.AppSettings["TokenURL"].ToString());

            string UserName = ConfigurationManager.AppSettings["SMSUName"].ToString();
            string Password = ConfigurationManager.AppSettings["SMSPWD"].ToString();

            request.Headers.Add("username", UserName);
            request.Headers.Add("password", Password);

            HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            sMSCred.AccessToken = Convert.ToString(item["result"]["integration_token"]);
            sMSCred.SenderID = Convert.ToString(item["result"]["accountSid"]);
        }
        catch
        {
        }
        return sMSCred;
    }

    public class GetSMSCred
    {
        public string AccessToken { get; set; }
        public string SenderID { get; set; }
    }

    public static string Generatenumber()
    {
        var chars = "0123456789";
        var stringChars = new char[6];
        var random = new Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        var finalString = new String(stringChars);
        return finalString;
    }


    #region GetComplainData 

    protected async void FillCompalinData()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultList<Plugin_UserComplainEntity> res = new ResultList<Plugin_UserComplainEntity>();
            res = await Plugin_UserComplainDomain.GetAll();
            if (res.Status == ErrorEnums.Success)
            {

                lstComplain.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished  && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ServiceUserID == ServiceUserID).OrderByDescending(s => s.PublishedDate).Take(4).ToList();
                lstComplain.DataBind();
                int Complaincout = lstComplain.Items.Count();

                if (Complaincout > 0)
                {
                    ComplainCount.Text = Complaincout.ToString();
                    hndCountofCmpln.Value = Complaincout.ToString();
                    //lblCountCoplains.Text = " شكاوى " + Complaincout.ToString() + " لقد قمت بتقديم ";
                    lblCountCoplains.Text = " لقد قمت بتقديم  " + Complaincout.ToString() + " شكاوى ";
                    CopmlainEmptyDiv.Attributes.Add("style", "display:none");
                }
                else
                {
                    ComplainCount.Text = "0";
                    CopmlainEmptyDiv.Attributes.Add("style", "display:block");
                }

               


            }
            




        }
        catch (Exception ex)
        {
        }

    }

    protected void lstComplain_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Literal lblDate = (Literal)e.Item.FindControl("lblCompainDate");               
                var date = Convert.ToDateTime(lblDate.Text);

                var m = date.ToString("MMM");
                var month = date.ToString("MMM", new CultureInfo("ar-AE"));
                var Date = date.ToString("dd", new CultureInfo("ar-AE"));
                var Years = date.ToString("yyyy", new CultureInfo("ar-AE"));
                lblDate.Text = "<small><span class='LTR'> " + Date + "</span> " + month + " <span class='LTR'> " + Years + " </span></small>";

                Literal lblComplainType = (Literal)e.Item.FindControl("lblComplainType");

                ResultList<Lookup_ComplainTypeEntity> Result = new ResultList<Lookup_ComplainTypeEntity>();
                Result = Lookup_ComplainTypeDomain.GetAllNotAsync();

                if (Result.Status == ErrorEnums.Success)
                {
                    lblComplainType.Text = Result.List[0].ComplainType;

                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    #endregion


    #region  GetGevernal
    [WebMethod]
    public static List<Giovernat> BindGovernetData()
    {


        string genGovernateData = "";
        genGovernateData = ExecuteGovernal(genGovernateData);

        List<Giovernat> GiovernatList = new List<Giovernat>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(genGovernateData);
        XmlElement root = doc.DocumentElement;

        XmlNodeList nodes = root.SelectNodes("//NewDataSet/Table");
        foreach (XmlNode node in nodes)
        {
            var BranchID = node["BranchID"].InnerText;
            var code = node["code"].InnerText;
            var desc1 = node["desc1"].InnerText;
            var Country = node["Country"].InnerText;
            var ISHQ = node["ISHQ"].InnerText;
            var desc2 = node["desc2"].InnerText;
            var logo = node["logo"].InnerText;

            Giovernat Giovernat = new Giovernat();
            Giovernat.BranchID = BranchID;
            Giovernat.code = code;
            Giovernat.desc1 = desc1;
            Giovernat.Country = Country;
            Giovernat.ISHQ = ISHQ;
            Giovernat.desc2 = desc2;
            Giovernat.logo = logo;
            GiovernatList.Add(Giovernat);


        }

        return GiovernatList;
    }

    public static string ExecuteGovernal(string getGernetdata)
    {


        HttpWebRequest request = CreateWebRequest();
        XmlDocument soapEnvelopeXml = new XmlDocument();

        soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <GetBranchList xmlns=""http://tempuri.org/"">
                        <CompanyID>1</CompanyID>
                        <Lang>1</Lang>
                        </GetBranchList>
                 </soap:Body>
                </soap:Envelope>");

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse())
        {
            try
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                    string testData = soapResult.ToString();

                    getGernetdata = testData;

                }


            }
            catch (Exception e)
            {

                throw e;
            }


        }
        return getGernetdata;
    }

    /// <summary>
    /// Create a soap webrequest to [Url]
    /// </summary>
    /// <returns></returns>
    public static HttpWebRequest CreateWebRequest()
    {

        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
         string urls = ComplianAPIURL + "GetBranchList";
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urls);
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetBranchList");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" "+ urls + " ");
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=GetBranchList"); //Work
        webRequest.Headers.Add(@"SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }



    public class Giovernat
    {
        public string BranchID { get; set; }
        public string code { get; set; }
        public string desc1 { get; set; }
        public string Country { get; set; }
        public string ISHQ { get; set; }

        public string desc2 { get; set; }

        public string logo { get; set; }



    }

    #endregion


    #region GetArea1


    [WebMethod]
    public static List<Arias1> BindAreaDatas(string govid)
    {

        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKMailData(stgArea, govid);

        List<Arias1> AreaList = new List<Arias1>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        XmlNodeList nodes = root.SelectNodes("//NewDataSet/Table");
        foreach (XmlNode node in nodes)
        {
            var ServiceID = node["ServiceID"].InnerText;
            var Desc1 = node["Desc1"].InnerText;

            Arias1 Arias1 = new Arias1();
            Arias1.ServiceID = ServiceID;
            Arias1.Desc1 = Desc1;
            AreaList.Add(Arias1);

        }

        return AreaList;
    }


    public static string ExecuteAreas(string stgArea, string govID)
    {


        HttpWebRequest request = CreateWebRequest();
        XmlDocument soapEnvelopeXml = new XmlDocument();



        soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <GetBranchList xmlns=""http://tempuri.org/"">
                        <UserID>1</UserID>
                        <ProjectID>1</ProjectID>
                        <BranchID></BranchID>                       
                        <Lang>1</Lang>
                    </GetBranchList>
                 </soap:Body>
                </soap:Envelope>");

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse())
        {
            try
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                    string testData = soapResult.ToString();

                    stgArea = testData;

                }


            }
            catch (Exception e)
            {

                throw e;
            }


        }
        return stgArea;
    }

    public class Arias1
    {
        public string ServiceID { get; set; }
        public string Desc1 { get; set; }
    }


    public static string getUKMailData(string xml, string address)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<GetProjectServicesList xmlns=""http://tempuri.org/"">");
        xml2.Append("<UserID>1</UserID>");
        xml2.Append("<ProjectID>1</ProjectID>");
        xml2.Append("<BranchID>" + address + "</BranchID>");
        //xml2.Append("<BranchID>1</BranchID>");
        xml2.Append("<Lang>1</Lang>");
        xml2.Append("</GetProjectServicesList>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestMy();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }

    public static HttpWebRequest CreateWebRequestMy()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "GetProjectServicesList";
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=GetProjectServicesList");
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetProjectServicesList");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetProjectServicesList");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    #endregion


    #region GetArea2 

    [WebMethod]
    public static List<Arias2> BindArea2Datas(string areaid, string govid)
    {

        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKArea2Data(stgArea, areaid, govid);

        List<Arias2> Area2List = new List<Arias2>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        XmlNodeList nodes = root.SelectNodes("//NewDataSet/Table");
        foreach (XmlNode node in nodes)
        {
            var code = node["code"].InnerText;
            var Desc1 = node["Desc1"].InnerText;

            Arias2 Arias2 = new Arias2();
            Arias2.code = code;
            Arias2.Desc1 = Desc1;
            Area2List.Add(Arias2);

        }

        return Area2List;
    }


    public class Arias2
    {
        public string code { get; set; }
        public string Desc1 { get; set; }
    }

    public static string getUKArea2Data(string xml, string address, string govid)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<GetServiceCategories xmlns=""http://tempuri.org/"">");
        xml2.Append("<ServiceID>" + address + "</ServiceID>");
        xml2.Append("<BranchID>" + govid + "</BranchID>");
        xml2.Append("<Lang>1</Lang>");
        xml2.Append("</GetServiceCategories>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestArea2();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }

    public static HttpWebRequest CreateWebRequestArea2()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "GetServiceCategories";

        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetServiceCategories");
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=GetServiceCategories");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    #endregion

    #region Street 

    public class Street
    {
        public string code { get; set; }
        public string Desc1 { get; set; }

        public string Desc2 { get; set; }
        public string prefix { get; set; }
        public string StatusID { get; set; }

    }

    [WebMethod]
    public static List<Street> BindStreetDatas(string area2id, string govid)
    {

        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKSteetData(stgArea, area2id, govid);

        List<Street> StreetList = new List<Street>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        



        XmlNodeList nodes = root.SelectNodes("//NewDataSet/Table");
        foreach (XmlNode node in nodes)
        {
            var code = node["code"].InnerText;
            var Desc1 = node["Desc1"].InnerText;
            var Desc2 = node["Desc2"].InnerText;
            var prefix = node["prefix"].InnerText;
            var StatusID = node["StatusID"].InnerText;

            Street Street = new Street();
            Street.code = code;
            Street.Desc1 = Desc1;
            Street.Desc2 = Desc2;
            Street.prefix = prefix;
            Street.StatusID = StatusID;
            StreetList.Add(Street);

        }

        return StreetList;
    }

    public static string getUKSteetData(string xml, string area2id, string govid)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<getIssueSubCategories xmlns=""http://tempuri.org/"">");

        xml2.Append("<BranchID>" + govid + "</BranchID>");
        xml2.Append("<Lang>1</Lang>");
        xml2.Append("<MajorCategoryID>" + area2id + "</MajorCategoryID>");
        xml2.Append("<orderby>1</orderby>");
        xml2.Append("<OrderByType>1</OrderByType>");
        xml2.Append("</getIssueSubCategories>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestSteet();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }


    public static HttpWebRequest CreateWebRequestSteet()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "GetIssueSubCategories";

        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetIssueSubCategories");
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=GetIssueSubCategories");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }


    #endregion

    #region SaveComplainData 
    public class ComplainResult
    {
        public string JEPCO_IssueSaveResult { get; set; }

    }

    //BranchID:'" + BranchID + "',RequesterMobile:'" + RequesterMobile + "',RequesterName:'" + RequesterName + "',ServiceID:'" + ServiceID + "',CategoryID:'" + CategoryID + "',SubCategoryID:'" + SubCategoryID + "',IssueTitle:'" + IssueTitle + "',IssueDescription:'" + IssueDescription + "'
    [WebMethod]
    public static string SaveComplainData(string BranchID, string RequesterMobile, string RequesterName, string ServiceID, string CategoryID, string SubCategoryID, string IssueTitle, string IssueDescription,string TeleMeterNo)
    {
        string Result = "";
        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKSaveData(stgArea, BranchID, RequesterMobile, RequesterName, ServiceID, CategoryID, SubCategoryID, IssueTitle, IssueDescription, TeleMeterNo);

        //List<ComplainResult> ComplainResultList = new List<ComplainResult>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        string sdfjlsd = root.InnerText;

        //XmlNodeList nodes2 = root.SelectNodes("/JEPCO_IssueSaveResult");

        ////string text = "<E:Events xmlns:E=\"Event-Details\"><Date>12/27/2012</Date><Time>‎11:12 PM</Time><Message>Happy Birthday</Message></E:Events>";
        //string text = stgArea;
        //XElement myEle = XElement.Parse(text);
        //string sdfjlsd = root.InnerText;
        //string fhsdf = myEle.Element("JEPCO_IssueSaveResponse").Value;
        //string sjas = myEle.Element("JEPCO_IssueSaveResult").Value;

        //var IssueSaveResults2 = root["JEPCO_IssueSaveResult"].InnerText;
        //var IssueSaveResults3 = root["/JEPCO_IssueSaveResult"].InnerText;

        //var IssueSaveResults = root.SelectNodes("JEPCO_IssueSaveResult");

        //XmlNodeList nodes = root.SelectNodes("JEPCO_IssueSaveResponse");

        //XmlNodeList nodes3 = root.SelectNodes("//JEPCO_IssueSaveResponse");
        //foreach (XmlNode node in nodes)
        //{
        //    var IssueSaveResult = node["JEPCO_IssueSaveResult"].InnerText;


        //    ComplainResult ComplainResult = new ComplainResult();
        //    ComplainResult.JEPCO_IssueSaveResult = IssueSaveResult;

        //    ComplainResultList.Add(ComplainResult);

        //}
        Result = sdfjlsd.ToString();
        return Result;
    }

    public static string getUKSaveData(string xml, string BranchID, string RequesterMobile, string RequesterName, string ServiceID, string CategoryID, string SubCategoryID, string IssueTitle, string IssueDescription, string TeleMeterNo)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<JEPCO_IssueSave xmlns=""http://tempuri.org/"">");
        xml2.Append("<BranchID>" + BranchID + "</BranchID>");
        xml2.Append("<RequesterMobile>" + RequesterMobile + "</RequesterMobile>");
        xml2.Append("<RequesterName>" + RequesterName + "</RequesterName>");
        xml2.Append("<RequesterTel>" + TeleMeterNo + "</RequesterTel>");
        xml2.Append("<ServiceID>" + ServiceID + "</ServiceID>");
        xml2.Append("<CategoryID>" + CategoryID + "</CategoryID>");
        xml2.Append("<SubCategoryID>" + SubCategoryID + "</SubCategoryID>");
        xml2.Append("<SubItemID>-1</SubItemID>");
        xml2.Append("<IssueTitle>" + IssueTitle + "</IssueTitle>");
        xml2.Append("<IssueDescription>" + IssueDescription + "</IssueDescription>");
        xml2.Append("<FailureTypeID>1</FailureTypeID>");
        xml2.Append("<AttachName></AttachName>");
        xml2.Append("<AttachValue>1</AttachValue>");
        xml2.Append("</JEPCO_IssueSave>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestSaveComplain();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }

    public static HttpWebRequest CreateWebRequestSaveComplain()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "JEPCO_IssueSave";

        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/xmltest/issue.asmx?op=JEPCO_IssueSave");
        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/xml/issue.asmx?op=JEPCO_IssueSave");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    #endregion

    #region Get Complain StatusID 
    public class ComplainStatusID
    {
        public string GetIssueIDFromIssueRefCodeResult { get; set; }

    } 

    [WebMethod]
    public static string GetComplainStatus(string RefCode, string BranchID)
    {
        string Result = "";
        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKComplianStatusID(stgArea, RefCode, BranchID);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        string sdfjlsd = root.InnerText;

       
        Result = sdfjlsd.ToString();
        return Result;
    }

    public static string getUKComplianStatusID(string xml, string RefCode, string BranchID)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<GetIssueIDFromIssueRefCode xmlns=""http://tempuri.org/"">");
        xml2.Append("<RefCode>" + RefCode + "</RefCode>");
        xml2.Append("<BranchID>" + BranchID + "</BranchID>");        
        xml2.Append("</GetIssueIDFromIssueRefCode>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestGetComplainID();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }

    public static HttpWebRequest CreateWebRequestGetComplainID()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "GetIssueIDFromIssueRefCode";
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=GetIssueIDFromIssueRefCode");
        // HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=GetIssueIDFromIssueRefCode");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    #endregion

    #region GetCoplain StatusBYID
    public class ComplainStatus
    {
        public string StatusName { get; set; }

    }

    [WebMethod]
    public static List<ComplainStatus> BindCopalianStstubyID(string CompalinStatusID, string StutuBtranchid)
    {

        string stgArea = "";
        // stgArea = ExecuteAreas(stgArea, govid);
        stgArea = getUKComplianStatusBYID(stgArea, CompalinStatusID, StutuBtranchid);

        List<ComplainStatus> ComplainStatusList = new List<ComplainStatus>();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(stgArea);
        XmlElement root = doc.DocumentElement;

        XmlNodeList nodes = root.SelectNodes("//NewDataSet/Table");
        foreach (XmlNode node in nodes)
        {
            var StatusName = node["StatusName"].InnerText;
           

            ComplainStatus ComplainStatus = new ComplainStatus();
            ComplainStatus.StatusName = StatusName;

            ComplainStatusList.Add(ComplainStatus);

        }

        return ComplainStatusList;
    }

    public static string getUKComplianStatusBYID(string xml, string CompalinStatusID, string BranchID)
    {


        StringBuilder xml2 = new StringBuilder();
        xml2.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        xml2.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ");
        xml2.Append(@"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ");
        xml2.Append(@"xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
        xml2.Append("<soap:Body>");
        xml2.Append(@"<IssueInfoViewSelect xmlns=""http://tempuri.org/"">");
        xml2.Append("<IssueID>" + CompalinStatusID + "</IssueID>");
        xml2.Append("<BranchID>" + BranchID + "</BranchID>");
        xml2.Append("<Lang>1</Lang>");
        xml2.Append("</IssueInfoViewSelect>");
        xml2.Append("</soap:Body>");
        xml2.Append("</soap:Envelope>");


        string abcd = xml2.ToString();
        HttpWebRequest request = CreateWebRequestGetComplainBYID();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(abcd);

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse()) // Error occurs here
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);

                xml = soapResult.ToString();
            }
        }

        return xml;
    }

    public static HttpWebRequest CreateWebRequestGetComplainBYID()
    {
        string ComplianAPIURL = ConfigurationManager.AppSettings["ComplainAPIPAth"].ToString();
        string urls = ComplianAPIURL + "IssueInfoViewSelect";
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XMLtest/issue.asmx?op=IssueInfoViewSelect");
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://94.142.37.83/XML/issue.asmx?op=IssueInfoViewSelect");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@" " + urls + " ");
        webRequest.Headers.Add("SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }
    #endregion


    #region FillUnReadMSG 


    protected void FillUnReadMSG()
    {
        try {
            long UserId = SessionManager.GetInstance.Users.ID;
            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {               
                unReadMSGCount.Text = "0";
            }
            else
            {
                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> RenwabaleEnergyCompanyEntity = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                RenwabaleEnergyCompanyEntity = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(UserId);
                if (RenwabaleEnergyCompanyEntity.Status == ErrorEnums.Success)
                {
                    long CompanyId = RenwabaleEnergyCompanyEntity.Entity.RenwabaleEnergyCompanyID;
                    // UnRead MSG Count
                    ResultList<MessagesAndNotificationsEntity> Result = new ResultList<MessagesAndNotificationsEntity>();
                    Result = MessagesAndNotificationsDomain.GetAllNotAsync();                   
                    if (Result.Status == ErrorEnums.Success)
                    {
                        unReadMSGCount.Text = "0";
                        var Unreads = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && q.MsgToUserID == CompanyId && q.IsRead == false).ToList();
                        unReadMSGCount.Text = Unreads.Count.ToString();
                    }
                    else
                    {
                        unReadMSGCount.Text = "0";
                    }
                }
            }
        }
        catch { }       
    }

    #endregion


    #region 
    //===  Ajay Patel 081022020
    [WebMethod]
    public static List<RenewableEnergyCompanyDeviceEntity> BindDeivcetoDropdownByDistingCompanName()
    {
        List<RenewableEnergyCompanyDeviceEntity> details = new List<RenewableEnergyCompanyDeviceEntity>();
        ResultList<RenewableEnergyCompanyDeviceEntity> Result = new ResultList<RenewableEnergyCompanyDeviceEntity>();
        Result = RenewableEnergyCompanyDeviceDomain.GetAllDistinctCompanyNameNotAsync();
        try
        {
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanyDeviceEntity item in Result.List)
                {
                    RenewableEnergyCompanyDeviceEntity ldentity = new RenewableEnergyCompanyDeviceEntity();
                    //ldentity.RenewbleCompnyDevice = item.RenewbleCompnyDevice;
                    ldentity.CompanyName = item.CompanyName;
                    //ldentity.ModelNo = item.ModelNo;
                    details.Add(ldentity);
                }
            }
        }
        catch { }
        return details;
    }

    //===  Ajay Patel 081022020
    [WebMethod]
    public static List<RenewableEnergyCompanyDeviceEntity> BindDeivcetoDropdownByCompanyName(string CopmanyName)
    {
        List<RenewableEnergyCompanyDeviceEntity> details = new List<RenewableEnergyCompanyDeviceEntity>();
        ResultList<RenewableEnergyCompanyDeviceEntity> Result = new ResultList<RenewableEnergyCompanyDeviceEntity>();
        Result = RenewableEnergyCompanyDeviceDomain.GetAllDistinctCompanyNameNotAsync();
        try
        {
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanyDeviceEntity item in Result.List)
                {
                    RenewableEnergyCompanyDeviceEntity ldentity = new RenewableEnergyCompanyDeviceEntity();
                    //ldentity.RenewbleCompnyDevice = item.RenewbleCompnyDevice;
                    ldentity.CompanyName = item.CompanyName;
                    //ldentity.ModelNo = item.ModelNo;
                    details.Add(ldentity);
                }
            }
        }
        catch { }
        return details;
    }


    [WebMethod]
    public static List<RenewableEnergyCompanyDeviceEntity> BindDeivcetoDropdown()
    {
        List<RenewableEnergyCompanyDeviceEntity> details = new List<RenewableEnergyCompanyDeviceEntity>();
        ResultList<RenewableEnergyCompanyDeviceEntity> Result = new ResultList<RenewableEnergyCompanyDeviceEntity>();
        Result = RenewableEnergyCompanyDeviceDomain.GetAllNotAsync();
        try
        {
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanyDeviceEntity item in Result.List)
                {
                    RenewableEnergyCompanyDeviceEntity ldentity = new RenewableEnergyCompanyDeviceEntity();
                    ldentity.RenewbleCompnyDevice = item.RenewbleCompnyDevice;
                    ldentity.CompanyName = item.CompanyName;
                    ldentity.ModelNo = item.ModelNo;
                    details.Add(ldentity);
                }
            }
        }
        catch { }
        return details;
    }


    //===  Ajay Patel 081022020

    [WebMethod]
    public static List<RenewableEnergyCompanySolarCellEntity> BindSollerCelltoDropdownByDistingCompanName()
    {
        List<RenewableEnergyCompanySolarCellEntity> details = new List<RenewableEnergyCompanySolarCellEntity>();
        ResultList<RenewableEnergyCompanySolarCellEntity> Result = new ResultList<RenewableEnergyCompanySolarCellEntity>();
        Result = RenewableEnergyCompanySolarCellDomain.GetAllDistinctCompanyNameNotAsync();
        try
        {
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanySolarCellEntity item in Result.List)
                {
                    RenewableEnergyCompanySolarCellEntity ldentity = new RenewableEnergyCompanySolarCellEntity();
                    //ldentity.RenewbleCompnyDevice = item.RenewbleCompnyDevice;
                    ldentity.CompanyName = item.CompanyName;
                    //ldentity.ModelNo = item.ModelNo;
                    details.Add(ldentity);
                }
            }
        }
        catch { }
        return details;
    }



    [WebMethod]
    public static List<RenewableEnergyCompanySolarCellEntity> BindSelltoDropdown()
    {
        List<RenewableEnergyCompanySolarCellEntity> details = new List<RenewableEnergyCompanySolarCellEntity>();
        ResultList<RenewableEnergyCompanySolarCellEntity> Result = new ResultList<RenewableEnergyCompanySolarCellEntity>();
        Result = RenewableEnergyCompanySolarCellDomain.GetAllNotAsync();
        try
        {
            if (Result.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanySolarCellEntity item in Result.List)
                {
                    RenewableEnergyCompanySolarCellEntity ldentity = new RenewableEnergyCompanySolarCellEntity();
                    ldentity.RenewbleCompnySolarCell = item.RenewbleCompnySolarCell;
                    ldentity.CompanyName = item.CompanyName;
                    ldentity.ModelNo = item.ModelNo;
                    details.Add(ldentity);
                }
            }
        }
        catch { }
        return details;
    }


    [WebMethod]
    public static string BindDeivceTextBox(string Deivceid)
    {
        try {

            string DevicePower = "";
            long DID = Convert.ToInt64(Deivceid);
            ResultEntity<RenewableEnergyCompanyDeviceEntity> details = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();
            details = RenewableEnergyCompanyDeviceDomain.GetByIDNotAsync(DID);
            if (details.Status == ErrorEnums.Success)
            {
                DevicePower = details.Entity.DevicePower;
            }
            return DevicePower;
        }
        catch (Exception exp) {
            throw exp;
       
        }
        
    }


    [WebMethod]
    public static string BindSolerCellTextBox(string Sollerid)
    {
        try
        {

            string DevicePower = "";
            long DID = Convert.ToInt64(Sollerid);
            ResultEntity<RenewableEnergyCompanySolarCellEntity> details = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();
            details = RenewableEnergyCompanySolarCellDomain.GetByIDNotAsync(DID);
            if (details.Status == ErrorEnums.Success)
            {
                DevicePower = details.Entity.DevicePower;
            }
            return DevicePower;
        }
        catch (Exception exp)
        {
            throw exp;

        }

    }

    //===  Ajay Patel 081022020
    [WebMethod]
    public static List<RenewableEnergyCompanyDeviceEntity> BindModelDATAS(string Deivceid)
    {
        try
        {
            //RenewableEnergyCompanyDeviceEntity Resultdetails = new RenewableEnergyCompanyDeviceEntity();
            List<RenewableEnergyCompanyDeviceEntity> Resultdetails = new List<RenewableEnergyCompanyDeviceEntity>();

            ResultList<RenewableEnergyCompanyDeviceEntity> details = new ResultList<RenewableEnergyCompanyDeviceEntity>();
            details = RenewableEnergyCompanyDeviceDomain.GetAllDistinctCompanyNameNotAsync(Deivceid);
            if (details.Status == ErrorEnums.Success)
            {
                //Resultdetails.DevicePower = details.Entity.DevicePower;
                //Resultdetails.DeviceDocument = details.Entity.DeviceDocument;
                //Resultdetails.ModelNo = details.Entity.ModelNo;

                foreach (RenewableEnergyCompanyDeviceEntity item in details.List)
                {
                    RenewableEnergyCompanyDeviceEntity ldentity = new RenewableEnergyCompanyDeviceEntity();
                    ldentity.RenewbleCompnyDevice = item.RenewbleCompnyDevice;
                    ldentity.CompanyName = item.CompanyName;
                    ldentity.ModelNo = item.ModelNo;
                    ldentity.DevicePower = item.DevicePower;
                    Resultdetails.Add(ldentity);
                }


            }
            return Resultdetails;
        }
        catch (Exception exp)
        {
            throw exp;

        }

    }

    //===  Ajay Patel 081022020
    [WebMethod]
    public static List<RenewableEnergyCompanySolarCellEntity> BindModelSollerDATAS(string Sollerid)
    {
        try
        {
            List<RenewableEnergyCompanySolarCellEntity> Resultdetails = new List<RenewableEnergyCompanySolarCellEntity>();
            ResultList<RenewableEnergyCompanySolarCellEntity> details = new ResultList<RenewableEnergyCompanySolarCellEntity>();
            details = RenewableEnergyCompanySolarCellDomain.GetAllDistinctCompanyNameNotAsync(Sollerid);
            if (details.Status == ErrorEnums.Success)
            {
                foreach (RenewableEnergyCompanySolarCellEntity item in details.List)
                {
                    RenewableEnergyCompanySolarCellEntity ldentity = new RenewableEnergyCompanySolarCellEntity();
                    ldentity.RenewbleCompnySolarCell = item.RenewbleCompnySolarCell;
                    ldentity.CompanyName = item.CompanyName;
                    ldentity.ModelNo = item.ModelNo;
                    ldentity.DevicePower = item.DevicePower;
                    Resultdetails.Add(ldentity);
                }
            }
            return Resultdetails;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    [WebMethod]
    public static RenewableEnergyCompanyDeviceEntity BindDeivceDATAS(string Deivceid)
    {
        try
        {
            RenewableEnergyCompanyDeviceEntity Resultdetails = new RenewableEnergyCompanyDeviceEntity();
            long DID = Convert.ToInt64(Deivceid);
            ResultEntity<RenewableEnergyCompanyDeviceEntity> details = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();
            details = RenewableEnergyCompanyDeviceDomain.GetByIDNotAsync(DID);
            if (details.Status == ErrorEnums.Success)
            {
                Resultdetails.DevicePower = details.Entity.DevicePower;
                Resultdetails.DeviceDocument =  details.Entity.DeviceDocument;
                Resultdetails.ModelNo = details.Entity.ModelNo;
            }
            return Resultdetails;
        }
        catch (Exception exp)
        {
            throw exp;

        }

    }

    [WebMethod]
    public static RenewableEnergyCompanySolarCellEntity BindSolerCellDATAS(string Sollerid)
    {
        try
        {
            RenewableEnergyCompanySolarCellEntity Resultdetails = new RenewableEnergyCompanySolarCellEntity();
            long DID = Convert.ToInt64(Sollerid);
            ResultEntity<RenewableEnergyCompanySolarCellEntity> details = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();
            details = RenewableEnergyCompanySolarCellDomain.GetByIDNotAsync(DID);
            if (details.Status == ErrorEnums.Success)
            {
                Resultdetails.DevicePower = details.Entity.DevicePower;
                Resultdetails.SolarCellDocument = details.Entity.SolarCellDocument;
                Resultdetails.ModelNo = details.Entity.ModelNo;

            }
            return Resultdetails;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    #endregion


    #region

    [WebMethod]
    public static void PaymentGetWayCall(string BillNO, string BillAmount)
    {
        try
        {
            
            //HttpContext.Current.Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$R3K7OZt.PClq7gjXCmUrguVPkgBugQp3ra35l5ibw/IcT1YwSkAX2",false);
            //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$R3K7OZt.PClq7gjXCmUrguVPkgBugQp3ra35l5ibw/IcT1YwSkAX2", false);

            // return Resultdetails;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    #endregion



    protected void htdFilenameDetais_ValueChanged(object sender, EventArgs e)
    {

    }
}
