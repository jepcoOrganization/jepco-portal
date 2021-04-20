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

public partial class Controls_ComplainList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {

                FillCompain();
               
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

            ResultList<Plugin_UserComplainEntity> res = new ResultList<Plugin_UserComplainEntity>();
            res =  Plugin_UserComplainDomain.GetAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstComplain.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.ServiceUserID == ServiceUserID).ToList();
                lstComplain.DataBind();
                int Complaincout = lstComplain.Items.Count();




                //ComplainCount.Text = Complaincout.ToString();


                if (Complaincout > 0)
                {
                    ComplainCount.Text = Complaincout.ToString();                  
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
                lblDate.Text = "<small><span class='LTR'>" + Date + "</span> " + month + "<span class='LTR'>" + Years + "</span></small>";

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

    
}