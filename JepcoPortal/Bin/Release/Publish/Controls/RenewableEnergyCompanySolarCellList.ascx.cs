using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_RenewableEnergyCompanySolarCellList : System.Web.UI.UserControl
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

            ResultList<RenewableEnergyCompanySolarCellEntity> res = new ResultList<RenewableEnergyCompanySolarCellEntity>();
            res = RenewableEnergyCompanySolarCellDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstCompanyDevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString()).OrderByDescending(s => s.RenewbleCompnySolarCell).ToList();
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

                if (!string.IsNullOrEmpty(lnkSecondNav.NavigateUrl))
                    lnkSecondNav.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav.NavigateUrl.Replace("~/", "~/Siteware/");


                HyperLink lnkSecondNav2 = (HyperLink)e.Item.FindControl("lnkSecondNav2");

                if (!string.IsNullOrEmpty(lnkSecondNav2.NavigateUrl))
                    lnkSecondNav2.NavigateUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + lnkSecondNav2.NavigateUrl.Replace("~/", "~/Siteware/");
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