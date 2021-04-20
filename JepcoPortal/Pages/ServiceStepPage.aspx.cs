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
using HtmlAgilityPack;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web.Services;

public partial class Pages_ServiceStepPage : SiteBasePage
{
    public DateTime currentDate = DateTime.Now;
    public int LangID = 2;
    public int MenuIDs = 0;
    private byte CurrLangID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillData();
            FillServiceType();
        }

     
    }

    protected async void FillData()
    {
        try
        {
            // int NewsID = 1;

            ResultEntity<PagesEntity> PageResult = new ResultEntity<PagesEntity>();
            byte LangID = Convert.ToByte(Session["CurrentLanguage"]);
            int PageID = 0;
            string PageName = string.Empty;

            string Alias = string.Empty;
            if (LangID == Convert.ToInt32(EnumLanguage.Arabic))
            {
                PageID = 5055;
                //PageID = 3;
            }
            else
            {
                PageID = 5055;
            }

            PageResult = PagesDomain.GetPagesByPageIDNotAsync(PageID);
            PageName = Convert.ToString(PageResult.Entity.Name);

            if (PageResult.Status == ErrorEnums.Success)
            {
                if (PageResult.Entity.LanguageID == Convert.ToInt32(EnumLanguage.English))
                {
                    lnkParentName.NavigateUrl = PageResult.Entity.AliasPath;
                    lnkParentName.Text = PageResult.Entity.Name;
                }
                else
                {
                    lnkParentName.NavigateUrl = PageResult.Entity.AliasPath;
                    lnkParentName.Text = PageResult.Entity.Name;
                }
            }
            else
            {
                lstParent.Visible = false;
            }
            lblChildName.Text = PageResult.Entity.Name;



        }
        catch (Exception e)
        {
            throw;
        }
    }

    protected async void FillServiceType()
    {
        try
        {

            ResultList<E_Plugin_ServiceTypeEntity> res = new ResultList<E_Plugin_ServiceTypeEntity>();
            res = E_Plugin_ServiceTypeDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
                lstServiceType.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ParentID == 0).OrderBy(s => s.Order).ToList();
                lstServiceType.DataBind();



            }

        }
        catch { }
    }

    #region Call when only Is Usertype true
    [WebMethod]
    public static List<E_Plugin_UserTypeEntity> BindUserType(string id)
    {
        try {

            ResultList<E_Plugin_UserTypeEntity> res = new ResultList<E_Plugin_UserTypeEntity>();
            res = E_Plugin_UserTypeDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
               var data = res.List.Where(s => !s.IsDeleted && s.IsPublished  && s.LanguageID == 2 && s.ServiceTypeID == Convert.ToInt64(id)).OrderBy(s => s.Order).ToList();

                foreach (var item in data)
                {
                    string Icons = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + item.Icon;
                    item.Icon = Icons;

                    string IconHover = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + item.IconHover;
                    item.IconHover = IconHover;

                }

                return data;
            }
            return null;

        }
        catch {
            throw; 
        }

    }

    [WebMethod]
    public static List<E_Plugin_ServiceInformationEntity> BindServiceInformation(string id)
    {
        try
        {

            ResultList<E_Plugin_ServiceInformationEntity> res = new ResultList<E_Plugin_ServiceInformationEntity>();
            res = E_Plugin_ServiceInformationDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
                var data = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == 2 && s.UserTypeID == Convert.ToInt64(id)).OrderBy(s => s.Order).Take(1).ToList();


                return data;
            }
            return null;

        }
        catch
        {
            throw;
        }

    }


    [WebMethod]
    public static List<E_Plugin_ServiceStepEntity> BindServiceStep(string id)
    {
        try
        {

            ResultList<E_Plugin_ServiceStepEntity> res = new ResultList<E_Plugin_ServiceStepEntity>();
            res = E_Plugin_ServiceStepDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
                var data = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == 2 && s.UserTypeID == Convert.ToInt64(id)).OrderBy(s => s.Order).ToList();


                return data;
            }
            return null;

        }
        catch
        {
            throw;
        }

    }

    #endregion

    int looplstProjectTab = 0;
    protected void lstServiceType_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HyperLink lnkparent = (HyperLink)e.Item.FindControl("lnkparent");
                lnkparent.Attributes["href"] = "#ContentPlaceHolder1_lstServiceType_ca_" + looplstProjectTab;

                ListView lstSecondServiceType = (ListView)e.Item.FindControl("lstSecondServiceType");
                HiddenField hdnId = (HiddenField)e.Item.FindControl("hdnId");

                ResultList<E_Plugin_ServiceTypeEntity> res = new ResultList<E_Plugin_ServiceTypeEntity>();
                res = E_Plugin_ServiceTypeDomain.GetAllNotAsync();
                if (res.Status == ErrorEnums.Success)
                {
                    lstSecondServiceType.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ParentID == Convert.ToInt64(hdnId.Value)).OrderBy(s => s.Order).ToList();
                    lstSecondServiceType.DataBind();

                }


            }
        }
        catch (Exception ex)
        {
        }
    }



    protected void lstSecondServiceType_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnkSecondNav = (HyperLink)e.Item.FindControl("lnkSecondNav");
                HiddenField hdhServiceId = (HiddenField)e.Item.FindControl("hdhServiceId");
                HiddenField hdnHasUserType = (HiddenField)e.Item.FindControl("hdnHasUserType");
                HiddenField hdnServiceName = (HiddenField)e.Item.FindControl("hdnServiceName");
                HiddenField hdnParentID = (HiddenField)e.Item.FindControl("hdnParentID");
                string parentname = "";


                ResultEntity <E_Plugin_ServiceTypeEntity> res = new ResultEntity<E_Plugin_ServiceTypeEntity>();
                res = E_Plugin_ServiceTypeDomain.GetByIDNotAsync(Convert.ToInt32(hdnParentID.Value));
                if (res.Status == ErrorEnums.Success)
                {
                   parentname = res.Entity.ServiceName;
                }

                if (hdnHasUserType.Value == "True") {
                   // lnkSecondNav.Attributes.Add("onclick", "chageStep2("+hdhServiceId.Value+")");
                    lnkSecondNav.Attributes["onClick"] = "chageStep2('" + hdhServiceId.Value + "', '" + hdnServiceName.Value + "', '"+ parentname + "')";
                }
                else
                {
                    //lnkSecondNav.Attributes.Add("onclick", "chageStep3(" + hdhServiceId.Value + ")");
                    lnkSecondNav.Attributes["onClick"] = "chageStep3('" + hdhServiceId.Value + "', '" + hdnServiceName.Value + "', '" + parentname + "')";
                    //lnkSecondNav.Attributes["onClick"] = "chageStep3('" + hdhServiceId.Value + "')";
                }
                
                

            }
        }
        catch (Exception ex)
        {
        }
    }

    #region When IsUsetType False 

    [WebMethod]
    public static List<E_Plugin_ServiceInformationEntity> BindServiceInformationByServiveTypeID (string id)
    {
        try
        {

            ResultList<E_Plugin_ServiceInformationEntity> res = new ResultList<E_Plugin_ServiceInformationEntity>();
            res = E_Plugin_ServiceInformationDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
                var data = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == 2 && s.ServiceTypeID == Convert.ToInt64(id)).OrderBy(s => s.Order).Take(1).ToList();


                return data;
            }
            return null;

        }
        catch
        {
            throw;
        }

    }

    [WebMethod]
    public static List<E_Plugin_ServiceStepEntity> BindServiceStepByServiceTypeId(string id)
    {
        try
        {

            ResultList<E_Plugin_ServiceStepEntity> res = new ResultList<E_Plugin_ServiceStepEntity>();
            res = E_Plugin_ServiceStepDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {
                var data = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == 2 && s.ServiceTypeID == Convert.ToInt64(id)).OrderBy(s => s.Order).ToList();


                return data;
            }
            return null;

        }
        catch
        {
            throw;
        }

    }
    #endregion


}