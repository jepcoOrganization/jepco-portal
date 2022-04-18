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
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Web.Routing;
using Siteware.Entity.Entities;
using Siteware.Domain.Domains;
using System.Globalization;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
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

                //if (RouteData.Values["language"] == null)
                //{
                //    Response.Redirect("ar/Home");
                //}
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
                FillCapctha();
                FillUnReadMSG();

                FillMenuBreadCump();
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
        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Session["CurrentLanguage"] == null)
        //        {
        //            Response.Redirect("ar/Home");
        //        }
        //        CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
        //        if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
        //        {
        //            LangID = 1;
        //            lang = "/en";
        //            //lblLangID.Value = "2";
        //            // lnkLanguage.Text = "عربى";
        //        }
        //        else
        //        {
        //            LangID = 2;
        //            lang = "/ar";
        //            //lblLangID.Value = "1";
        //            // lnkLanguage.Text = "English";
        //        }

        //        ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
        //        Result = SettingDomain.GetSettingAllWithoutAsync();
        //        if (Result.Status == ErrorEnums.Success)
        //        {
        //            imgLogo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].Logo;
        //            //imgFooterLogo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].FooterLogo;
        //            lblCopyright.Text = FetchLinksFromSource(Result.List[0].CopyRights);
        //        }
        //        FillSecondNavigation();
        //        FillSocialMedia();
        //        FillContactUs();
        //        FillNavigation();
        //        FillFooterNavigation();
        //        FillServices();
        //        FillVideos();
        //        FillApp();

        //        //FillSecondNavigation();
        //        //FillSocialIcon();
        //        //FillNavigation();
        //        //FillFooterNavigation();
        //        //FillContactUs();
        //    }
        //}
        //catch (Exception ex)
        //{
        //}
    }


    #region--> FillSecondNavigation
    protected void FillSecondNavigation()
    {
        try
        {
            //ResultList<SecondNavigationEntity> Result = new ResultList<SecondNavigationEntity>();
            ResultList<FooterNavigationEntity> Result = new ResultList<FooterNavigationEntity>();
            //Result = await FooterNavigationDomain.GetFooterAll();
            Result = FooterNavigationDomain.GetFooterAllWithoutAsync();

            if (Result.Status == ErrorEnums.Success)
            {


                lstSecondNavFooter1.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Take(5).ToList();
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


    #region--> FillSocialMedia
    protected void FillSocialMedia()
    {
        try
        {
            ResultList<PluginSocialIconEntity> res = new ResultList<PluginSocialIconEntity>();
           // res = await PluginSocialIconDomain.GetPluginSocialIconAll();
            res = PluginSocialIconDomain.GetPluginSocialIconAllNotAsync();
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


            if (userType == "1")
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


        if (hdnid.Value == "8")
        {
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
        else
        {
            unReadMSgMenu.Text = "";
        }

    }

    #endregion

    #region FillServiceUser

    protected void FillServiceUser()
    {
        try
        {
            long UserId = SessionManager.GetInstance.Users.ID;

            ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();

            //ServiceUserEntity = await Plugin_ServiceUserDomain.GetByID(UserId);
            ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(UserId);
            if (ServiceUserEntity.Status == ErrorEnums.Success)
            {
                lblUserName.Text = ServiceUserEntity.Entity.FirstName;
                lblUserAddress.Text = ServiceUserEntity.Entity.Address;
                lblUSerEmail.Text = ServiceUserEntity.Entity.Email;
                lblUSerMobile.Text = ServiceUserEntity.Entity.MobileNumber;
                hdnmobileno.Value = ServiceUserEntity.Entity.MobileNumber;
                lblUSerRegiDate.Text = ServiceUserEntity.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                lblUserLastName.Text = ServiceUserEntity.Entity.FamilyName;


            }


            try
            {

                ResultEntity<LastLoginTimeEntity> LastLoginEntity = new ResultEntity<LastLoginTimeEntity>();
                //LastLoginEntity = await LastLoginTimeDomain.GetByServiceUserID(UserId);
                LastLoginEntity = LastLoginTimeDomain.GetByServiceUserIDNotAsync(UserId);
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

    #region FillDailyAdvace
    protected void FillDailyAdvise()
    {
        try
        {
            ResultList<Plugin_DailyAdviseEntity> Result = new ResultList<Plugin_DailyAdviseEntity>();

            //Result = await Plugin_DailyAdviseDomain.GetAll();
            Result = Plugin_DailyAdviseDomain.GetAllNotAsync();
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

   
    #endregion

    #region--> FillBanner
    protected void FillBanner()
    {
        try
        {
            ResultList<PluginBannerEntity> res = new ResultList<PluginBannerEntity>();
            //res = await PluginBannerDomain.GetPluginBannerAll();
            res = PluginBannerDomain.GetPluginBannerAllNotAsync();

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

    #region FillNews 
    protected void FillNews()
    {
        try
        {
            ResultList<NewsEntity> res = new ResultList<NewsEntity>();
            //res = await NewsDomain.GetNewsAll();

            res = NewsDomain.GetNewsAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                //lstNews.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderByDescending(s => s.NewsDate).ThenBy(s => s.NewsOrder).Take(2).ToList();
                //lstNews.DataBind();

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

    //#region--> FillSecondNavigation
    //protected  void FillSecondNavigation()
    //{
    //    try
    //    {
    //        ResultList<SecondNavigationEntity> Result = new ResultList<SecondNavigationEntity>();
    //        Result =  SecondNavigationDomain.GetNavigationAllNotAsync();

    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstSecondNav.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate && s.MenuType == 1).OrderBy(s => s.MenuOrder).Take(8).ToList();
    //            lstSecondNav.DataBind();

    //            lstMOBSecondNav.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate && s.MenuType == 1).OrderBy(s => s.MenuOrder).Take(8).ToList();
    //            lstMOBSecondNav.DataBind();

    //            lstSecondNavFooter1.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate && s.MenuType == 2).OrderBy(s => s.MenuOrder).Take(5).ToList();
    //            lstSecondNavFooter1.DataBind();

    //            lstSecondNavFooter2.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate && s.MenuType == 2).OrderBy(s => s.MenuOrder).Skip(5).Take(3).ToList();
    //            lstSecondNavFooter2.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void lstSecondNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
    //            var lnkSecondNav1 = lnkSecondNav.Text;
    //            if (lnkSecondNav.Target == "1")
    //            {
    //                lnkSecondNav.Target = "_blank";
    //            }
    //            else
    //            {
    //                lnkSecondNav.Target = "_parent";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //#endregion

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

    //#region--> FillNavigation
    //protected void FillNavigation()
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    // ResultList<NavigationEntity> rootmenu = new ResultList<NavigationEntity>();

    //    Result = NavigationDomain.GetNavigationWebsiteAllNotAsync();
    //    // rootmenu = await NavigationDomain.GetNavigationByRootMenu();

    //    if (Result.Status == ErrorEnums.Success)
    //    {
    //        lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
    //        lstNavigation.DataBind();

    //        lstNavigation2.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
    //        lstNavigation2.DataBind();

    //        lstMobileNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID && q.IsDeleted == false && q.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(q => q.MenuOrder).Take(6).ToList();
    //        lstMobileNavigation.DataBind();
    //    }
    //}

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

    //            //lstmenu.Attributes.Add("class", "active Mydropli dropli" + menucount);
    //            lstmenu.Attributes.Add("onclick", "return callsubmenu(" + menucount + ");");

    //        }

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

    //#endregion

    //#region--> FillSocialMedia
    //protected void FillSocialMedia()
    //{
    //    try
    //    {
    //        ResultList<PluginSocialIconEntity> res = new ResultList<PluginSocialIconEntity>();
    //        res =  PluginSocialIconDomain.GetPluginSocialIconAllNotAsync();
    //        if (res.Status == ErrorEnums.Success)
    //        {

    //            lstSocial.DataSource = res.List.Where(s => !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.IconOrder).Take(4).ToList();
    //            lstSocial.DataBind();

    //            lstSocialFooter.DataSource = res.List.Where(s => !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.IconOrder).Take(4).ToList();
    //            lstSocialFooter.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstSocial_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgsocial = (Image)e.Item.FindControl("imgsocial");
    //            if (!string.IsNullOrEmpty(imgsocial.ImageUrl))
    //                imgsocial.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgsocial.ImageUrl.Replace("~/", "~/Siteware/");

    //            HiddenField imgURL = (HiddenField)e.Item.FindControl("imgURL");               
    //            if (imgURL != null)
    //            {
    //                if (!string.IsNullOrEmpty(imgURL.Value))
    //                {
    //                    string imageover = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgURL.Value.Replace("~/", "~/Siteware/");
    //                    imgsocial.Attributes.Add("onmouseover", "this.src='" + imageover + "'");
    //                    imgsocial.Attributes.Add("onmouseout", "this.src='" + imgsocial.ImageUrl + "'");
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
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



    //#region--> FillService
    //protected  void FillServices()
    //{
    //    try
    //    {
    //        ResultList<PluginServiceEntity> Result = new ResultList<PluginServiceEntity>();

    //        Result =  PluginServiceDomain.GetDataPointAllNotAsync();

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

    //protected void btnSubscribes_click(object sender, EventArgs e)
    //{
    //    Page.Validate("grp1");
    //    if (Page.IsValid)
    //    {
    //        Plugin_News_LetterEntity entity = new Plugin_News_LetterEntity();
    //        entity.EmailNewsLetter = txtSubscribe.Text;
    //        entity.SubscribeNewsLetter = true;
    //        entity.AddDate = DateTime.Now;
    //        entity.AddUser = "web";
    //        entity.EditDate = DateTime.Now;
    //        entity.EditUser = "web";

    //        var Result = Plugin_News_LetterDomain.InsertPlugin_News_LetterNonasync(entity);
    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            //btnSubscribe.Text = "";
    //            txtSubscribe.Text = "";
    //            if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.Arabic)
    //            {
    //                lblMessage.Text = "Your email has been successfully registered";
    //                //btnOk.Text = "Ok";
    //            }
    //            else
    //            {
    //                lblMessage.Text = "Your email has been successfully registered";
    //                //btnOk.Text = "Ok";
    //            }
    //            txtSubscribe.Attributes.Add("style", "");
    //            mpeSuccess.Show();
    //            //mpeSubscribe.Show();

    //        }
    //    }
    //    else
    //    {

    //        txtSubscribe.Attributes.Add("style", "border: 1px solid red");
    //    }
    //}

    //protected void Button8_Click(object sender, EventArgs e)
    //{
    //    mpeSuccess.Hide();
    //}



    //#endregion




    //#region--> FillVideos
    //protected void FillVideos()
    //{
    //    try
    //    {
    //        ResultList<Plugin_VideoEntity> Result = new ResultList<Plugin_VideoEntity>();

    //        Result =  Plugin_VideoDomain.GetAllNotAsync();
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

    //#region--> FillFillApp
    //protected void FillApp()
    //{
    //    try
    //    {
    //        ResultList<PluginBannerEntity> res = new ResultList<PluginBannerEntity>();
    //        res =  PluginBannerDomain.GetPluginBannerAllNotAsync();
    //        if (res.Status == ErrorEnums.Success)
    //        {



    //            lstFooterApp.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishDate.Date <= currentDate.Date && s.CategoryID == 1 && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.BannerOrder).Take(2).ToList();
    //            lstFooterApp.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void lstApp_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            Image imgApp = (Image)e.Item.FindControl("imgApp");
    //            if (!string.IsNullOrEmpty(imgApp.ImageUrl))
    //                imgApp.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgApp.ImageUrl.Replace("~/", "~/Siteware/");

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

    protected void logout_Click(object sender, EventArgs e)
    {


        long LastLoginId = Convert.ToInt64(hdhLastLoginId.Value);
        if (LastLoginId >= 1)
        {
            long UserId = SessionManager.GetInstance.Users.ID;
            LastLoginTimeEntity LastLoginEntity = new LastLoginTimeEntity();
            LastLoginEntity.ServiceUserID = UserId;
            LastLoginEntity.LastLoginTime = DateTime.Now;
            //var LastLoginResult = await LastLoginTimeDomain.Update(LastLoginEntity);
            var LastLoginResult = LastLoginTimeDomain.UpdateNotAsync(LastLoginEntity);
            if (LastLoginResult.Status == ErrorEnums.Success)
            {
                Session.Clear();
                Session.Abandon();
                //Response.Redirect("~/Login.aspx");
                //Response.Redirect("~/LoginPage/Login.aspx", false);
            }
        }
        else
        {
            long UserId = SessionManager.GetInstance.Users.ID;
            LastLoginTimeEntity LastLoginEntity = new LastLoginTimeEntity();
            LastLoginEntity.ServiceUserID = UserId;
            LastLoginEntity.LastLoginTime = DateTime.Now;
            //var LastLoginResult = await LastLoginTimeDomain.Insert(LastLoginEntity);
            var LastLoginResult = LastLoginTimeDomain.InsertNotAsync(LastLoginEntity);
            if (LastLoginResult.Status == ErrorEnums.Success)
            {
                Session.Clear();
                Session.Abandon();
                //Response.Redirect("~/Login.aspx");
                //Response.Redirect("~/LoginPage/Login.aspx", false);
            }
        }

        Response.Redirect("~/LoginPage/Login.aspx", false);


        //Session.Clear();
        //Session.Abandon();
        ////Response.Redirect("~/Login.aspx");
        //Response.Redirect("~/LoginPage/Login.aspx", false);

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

    //protected void lnkSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
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

    //#region--> FillNavigation
    //protected void FillNavigation()
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    ResultList<NavigationEntity> rootmenu = new ResultList<NavigationEntity>();

    //    Result = NavigationDomain.GetNavigationWebsiteAllNotAsync();
    //    rootmenu = NavigationDomain.GetNavigationByRootMenuNotAsync();

    //    if (Result.Status == ErrorEnums.Success)
    //    {
    //        lstNavigation.DataSource = Result.List.Where(q => q.IsPublished == true && q.LanguageID == CurrLangID);
    //        lstNavigation.DataBind();
    //    }
    //}

    //protected void lstNavigation_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    ResultList<NavigationEntity> Result = new ResultList<NavigationEntity>();
    //    if (e.Item.ItemType == ListViewItemType.DataItem)
    //    {
    //        HtmlGenericControl lstmenu = (HtmlGenericControl)e.Item.FindControl("lstmenu");
    //        HiddenField ID = (HiddenField)e.Item.FindControl("MenuID");
    //        HyperLink lnk = (HyperLink)e.Item.FindControl("lnkMenu");
    //        HtmlGenericControl ulsubmenu = (HtmlGenericControl)e.Item.FindControl("ulsubmenu");

    //        if (lnk.Target == "1")
    //        { lnk.Target = "_blank"; }
    //        else
    //        { lnk.Target = "_parent"; }


    //        if (string.IsNullOrEmpty(lnk.NavigateUrl) || lnk.NavigateUrl == "#")
    //        {
    //            lnk.NavigateUrl = "javascript:void(0);";
    //        }

    //        ListView lstSubNavgation = (ListView)e.Item.FindControl("lstSubNavgation");

    //        Result = NavigationDomain.GetNavigationByParentMenuID_Website(Convert.ToInt32(ID.Value));

    //        if (Result.List.Count == 0)
    //        {
    //            if (string.IsNullOrEmpty(lnk.NavigateUrl) || lnk.NavigateUrl == "#")
    //            {
    //                lnk.NavigateUrl = "javascript:void(0);";
    //            }
    //            ulsubmenu.Visible = false;
    //        }
    //        else
    //        {
    //            lstmenu.Attributes.Add("class", "nav-item dropdown");
    //            lnk.Attributes.Add("class", "nav-link dropdown-toggle");
    //            lnk.Attributes.Add("data-toggle", "dropdown");
    //            lnk.Attributes.Add("aria-haspopup", "true");
    //            lnk.Attributes.Add("aria-expanded", "false");
    //            lnk.Attributes.Add("role", "button");
    //            lnk.NavigateUrl = "javascript:void(0);";
    //            lnk.Text = lnk.Text;
    //            lstSubNavgation.DataSource = Result.List.Where(a => a.IsDeleted == false && a.IsPublished == true).OrderBy(a => a.MenuOrder);
    //            lstSubNavgation.DataBind();
    //        }
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
    //#endregion

    //#region--> FillSecondNavigation
    //protected void FillSecondNavigation()
    //{
    //    try
    //    {
    //        ResultList<SecondNavigationEntity> Result = new ResultList<SecondNavigationEntity>();
    //        Result = SecondNavigationDomain.GetNavigationAllNotAsync();

    //        if (Result.Status == ErrorEnums.Success)
    //        {
    //            lstSecondNav.DataSource = Result.List.Where(s => s.IsPublished && !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.PublishDate <= currentDate).OrderBy(s => s.MenuOrder).Take(4).ToList();
    //            lstSecondNav.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void lstSecondNav_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");

    //            if (lnkSecondNav.Target == "1")
    //            {
    //                lnkSecondNav.Target = "_blank";
    //            }
    //            else
    //            {
    //                lnkSecondNav.Target = "_parent";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
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
    //#region--> FillContactUs
    //protected void FillContactUs()
    //{
    //    try
    //    {
    //        ResultList<PluginContactUsEntity> res = new ResultList<PluginContactUsEntity>();
    //        res = PluginContactUsDomain.GetPluginContactAllNotAsync();
    //        if (res.Status == ErrorEnums.Success)
    //        {
    //            res.List = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishedDate.Date <= currentDate.Date).OrderBy(s => s.Order).ToList();
    //            lstContactUs.DataSource = res.List;
    //            lstContactUs.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //int contctCount = 0;
    //protected void lstContactUs_ItemDataBound(object sender, ListViewItemEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Item.ItemType == ListViewItemType.DataItem)
    //        {
    //            HtmlGenericControl contact_p = (HtmlGenericControl)e.Item.FindControl("contact_p");
    //            HyperLink lnkContact = (HyperLink)e.Item.FindControl("lnkContact");
    //            if (contctCount == 0)
    //            {
    //                contact_p.Attributes.Add("class", "footer-desc");
    //            }
    //            if (contctCount == 1)
    //            {
    //               // contact_p.Attributes.Add("class", "mt-4");
    //            }
    //            contctCount++;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
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
    //    }
    //    catch
    //    {
    //    }


    //    //try
    //    //{
    //    //    bool isName = false;
    //    //    bool isEmail = false;
    //    //    bool isInterest = false;

    //    //    if (!string.IsNullOrEmpty(txtName.Text))
    //    //    {
    //    //        isName = true;
    //    //        txtName.Style.Add("border", "0");
    //    //    }
    //    //    else
    //    //    {
    //    //        txtName.Style.Add("border", "1px solid #ff0000");
    //    //    }
    //    //    if (!string.IsNullOrEmpty(txtInterest.Text))
    //    //    {
    //    //        isInterest = true;
    //    //        txtInterest.Style.Add("border", "0");
    //    //    }
    //    //    else
    //    //    {
    //    //        txtInterest.Style.Add("border", "1px solid #ff0000");
    //    //    }

    //    //    if (!string.IsNullOrEmpty(txtEmail.Text))
    //    //    {
    //    //        bool isMatch = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    //    //        if (isMatch)
    //    //        {
    //    //            isEmail = true;
    //    //            txtEmail.Style.Add("border", "0");
    //    //        }
    //    //        else
    //    //        {
    //    //            txtEmail.Style.Add("border", "1px solid #ff0000");
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        txtEmail.Style.Add("border", "1px solid #ff0000");
    //    //    }
    //    //    if (isName && isInterest && isEmail)
    //    //    {
    //    //        ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();
    //    //        ContactUsFormEntity entity = new ContactUsFormEntity();
    //    //        entity.Name = txtName.Text;
    //    //        entity.Email = txtEmail.Text;
    //    //        entity.Title = txtInterest.Text;
    //    //        entity.Message = txtMessage.Text;
    //    //        entity.AddDate = DateTime.Now;
    //    //        entity.IsDeleted = false;
    //    //        entity.Contact = 0;

    //    //        result = ContactUsFormDomain.InsertContactUsForm(entity);
    //    //        if (result.Status == ErrorEnums.Success)
    //    //        {
    //    //            txtName.Text = "";
    //    //            txtEmail.Text = "";
    //    //            txtInterest.Text = "";
    //    //            txtMessage.Text = "";
    //    //            lblMessage.Text = "Your Inqiry submitted successfully";
    //    //            mpeSuccess.Show();
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        lnkSubmitForm.Focus();
    //    //    }

    //    //}
    //    //catch
    //    //{
    //    //}
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
    //        if (Convert.ToInt32(Session["CurrentLanguage"]) == 1)
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

    //public string FetchLinksFromSource(string htmlSource)
    //{
    //    HtmlDocument doc = new HtmlDocument();
    //    doc.LoadHtml(htmlSource);
    //    if (doc.DocumentNode.SelectNodes("//img") != null)
    //    {
    //        foreach (var img in doc.DocumentNode.SelectNodes("//img"))
    //        {
    //            string orig = img.Attributes["src"].Value;
    //            string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
    //            img.SetAttributeValue("src", newsrc);
    //        }
    //    }
    //    return doc.DocumentNode.OuterHtml;
    //}
    //#endregion

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        mpeSuccess.Hide();
    }

    #region FillUnReadMSG 


    protected void FillUnReadMSG()
    {
        try
        {
            long UserId = SessionManager.GetInstance.Users.ID;
            string ServeceUserType = SessionManager.GetInstance.Users.UserType;
            if (ServeceUserType != "2")
            {
                //Response.Redirect("~/Default.aspx", false);
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

    #region FillBreadCump 
    protected void FillMenuBreadCump()
    {
        try {
            string urllang = Page.RouteData.Values["Language"].ToString();
            string AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
            string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;

            ResultEntity<PagesEntity> Result = new ResultEntity<PagesEntity>();  
            Result = PagesDomain.GetPagesByAliasPathNotAsync(Alias, 2);


            if (Result.Status == ErrorEnums.Success)
            {
               
                if (Result.Entity.ParentID > 0)
                {
                    ResultEntity<PagesEntity> ParentResult = new ResultEntity<PagesEntity>();                   
                    ParentResult = PagesDomain.GetPagesByPageIDNotAsync(Result.Entity.ParentID);

                    lnkParentName.Text = ParentResult.Entity.Name;
                    lnkParentName.NavigateUrl = ParentResult.Entity.AliasPath;

                    lstParent.Visible = true;
                }
                else
                {
                    lstParent.Visible = false;
                }
                lblChildName.Text = Result.Entity.Name;
               
            }
            else
            {
                Response.Redirect("/" + urllang + "/home", false);
            }





        }
        catch { }
       }
    #endregion'

}
