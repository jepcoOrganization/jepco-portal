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

public partial class Controls_RenewableEnergyCompanyUserList : System.Web.UI.UserControl
{
    DataPager pager1;
    protected void Page_Load(object sender, EventArgs e)
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

    protected void FillCompain()
    {
        try
        {
            long ServiceUserID = SessionManager.GetInstance.Users.ID;

            ResultList<RenewableEnergyCompanyUserEntity> res = new ResultList<RenewableEnergyCompanyUserEntity>();
            res = RenewableEnergyCompanyUserDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstCompanyDevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString()).OrderByDescending(s => s.RenewableEnergyCompanyUserID).ToList();
                lstCompanyDevice.DataBind();
                int Complaincout = lstCompanyDevice.Items.Count();

                lblTotalCount.Text = Complaincout.ToString();

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
                Image imgProfileimge = (Image)e.Item.FindControl("imgProfileimge");
                

                if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");

                if (!string.IsNullOrEmpty(imgProfileimge.ImageUrl)) { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgProfileimge.ImageUrl.Replace("~/", "~/Siteware/");  }
                else { imgProfileimge.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + "/Siteware/Siteware_File/image/JEPCO//Profile_pic.png";  }
                   
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