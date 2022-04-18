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

public partial class Controls_RenewableEnergyCompanyDeviceList : System.Web.UI.UserControl
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
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {



                    FillCompain();


                }


               

            }

            //For Pagination 
            pager1 = lstCompanyDevice.FindControl("DataPager1") as DataPager;

            if (pager1 != null)
            {
                pager1.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }

        }
        catch
        {
        }
    }

    protected void FillCompain()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultList<RenewableEnergyCompanyDeviceEntity> res = new ResultList<RenewableEnergyCompanyDeviceEntity>();
            res = RenewableEnergyCompanyDeviceDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstCompanyDevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString()).OrderByDescending(s => s.RenewbleCompnyDevice).ToList();
                lstCompanyDevice.DataBind();

                int Complaincout = lstCompanyDevice.Items.Count();
                lblTotalCount.Text = Complaincout.ToString();


                var AppoverCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString() && s.Status == "1").ToList();
                int Appover = AppoverCount.Count();
                lblAppoverCount.Text = Appover.ToString();

                var ReversingCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString() && s.Status == "2").ToList();
                int Reversing = AppoverCount.Count();
                lblReversingCount.Text = Reversing.ToString();


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

                HyperLink lnkSecondNav2 = (HyperLink)e.Item.FindControl("lnkSecondNav2");

                if (!string.IsNullOrEmpty(lnkSecondNav2.NavigateUrl))
                    lnkSecondNav2.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav2.NavigateUrl.Replace("~/", "~/Siteware/");

                HiddenField hdnstatusRecord = (HiddenField)e.Item.FindControl("hdnstatusRecord");

                HtmlGenericControl divIsIsApproved = (HtmlGenericControl)e.Item.FindControl("divIsIsApproved");
                HtmlGenericControl divIsUnderTest = (HtmlGenericControl)e.Item.FindControl("divIsUnderTest");
                



                string hdnVal = hdnstatusRecord.Value.ToString();
                if (hdnVal == "1") {
                    divIsIsApproved.Visible = true;
                    divIsUnderTest.Visible = false;
                }
                else {
                    divIsIsApproved.Visible = false;
                    divIsUnderTest.Visible = true;
                }


            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lstNewsRow_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try
        {
            DataPager pager1;
            pager1 = lstCompanyDevice.FindControl("DataPager1") as DataPager;
            (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.FillCompain();
            //panelNews.Focus();
        }
        catch (Exception ex)
        {

        }
    }
}