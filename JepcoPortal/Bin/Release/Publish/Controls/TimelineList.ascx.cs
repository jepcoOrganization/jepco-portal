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

public partial class Controls_TimelineList : System.Web.UI.UserControl
{
    DateTime currentDate = DateTime.Now;
    DataPager pager1;
    string lang = string.Empty;
    int newsCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
            {
                lang = "/ar";
            }
            else
            {
                lang = "/en";
            }
            ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
            Result = SettingDomain.GetSettingAllWithoutAsync();
            if (Result.Status == ErrorEnums.Success)
            {
                // imgbottom.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].Logo;
                imgbottom.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + "/Siteware/Siteware_File/image/KHF/crown.png";
                lblpageYear.Text = Result.List[0].Year;
                //lblCopyright.Text = FetchLinksFromSource(Result.List[0].CopyRights);
               // lblYear.Text = Result.List[0].Year;
            }
            FillTimeline();

        }
    }


   

    //    ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
    //    Result = SettingDomain.GetSettingAllWithoutAsync();
    //                if (Result.Status == ErrorEnums.Success)
    //                {
    //                    imgLogo.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + Result.List[0].Logo;
    //                    lblCopyright.Text = FetchLinksFromSource(Result.List[0].CopyRights);
    //}

    protected void FillTimeline()
    {
        try
        {
            ResultList<Plugin_TimelineEntity> result = new ResultList<Plugin_TimelineEntity>();
            result = Plugin_TimelineDomain.GetAllNotAsync();
            if (result.Status == ErrorEnums.Success)
            {
                var res = result.List;
                res = res.Where(s => !s.IsDelete && s.IsPublished && s.PublishedDate.Date <= currentDate.Date && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ThenBy(s => s.Year).ToList();
                mylistcount.Value = Convert.ToString(res.Count());
                lstTimeline.DataSource = res.ToList();
                lstTimeline.DataBind();

            }
        }
        catch (Exception ex)
        {

        }
    }

    int ListCount = 1;
    protected void lstTimeline_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                string lang = string.Empty;
                if (Convert.ToInt32(Session["CurrentLanguage"]) == Convert.ToInt32(EnumLanguage.Arabic))
                {
                    lang = "/ar";
                }
                else
                {
                    lang = "/en";
                }

                ListViewDataItem i = (ListViewDataItem)e.Item;
                var c = i.DataItemIndex;
                HtmlGenericControl myLi = (HtmlGenericControl)e.Item.FindControl("ListCounts");
                if (ListCount%2 == 0)
                {
                    if (ListCount == 2 )
                    {
                        myLi.Attributes.Add("class", "right_side color_"+ ListCount + " wow slideInUp mar_top_100");
                    }
                    else
                    {
                        myLi.Attributes.Add("class", "right_side color_" + ListCount + " wow slideInUp");
                    }
                   
                }
                else
                {
                    myLi.Attributes.Add("class", "left_side color_" + ListCount + " wow slideInUp");
                }

                HiddenField hdntextHead = (HiddenField)e.Item.FindControl("hdntextHead");
                HiddenField hdntextYear = (HiddenField)e.Item.FindControl("hdntextYear");
                Literal lblTextheadYear = (Literal)e.Item.FindControl("lblTextheadYear");
                lblTextheadYear.Text = hdntextHead.Value + "<span>"+ hdntextYear.Value+ "</span>";
                HiddenField hdncolors = (HiddenField)e.Item.FindControl("hdncolors");
                hdncolors.ID = "hdncolors" + ListCount;
                string title = Regex.Replace(hdntextHead.Value, @"[\\:/*#.]+", "");
                HiddenField hdnTimelineID = (HiddenField)e.Item.FindControl("hdnTimelineID");
                int ID = Convert.ToInt32(hdnTimelineID.Value.ToString());
                HyperLink lnkTimelineDetail1 = (HyperLink)e.Item.FindControl("lnkTimelineDetail1");
                lnkTimelineDetail1.NavigateUrl = lang + "/TimelinePage/" + title + "/" + ID.ToString();

                ListCount++;
            }
        }
        catch (Exception ex)
        {

        }
    }
}

//HtmlGenericControl myLi = (HtmlGenericControl)e.Item.FindControl("daylistid");