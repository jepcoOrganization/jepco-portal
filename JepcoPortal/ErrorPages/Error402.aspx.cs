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

public partial class ErrorPages_Error402 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillContactUs();
        }
    }
    protected void FillContactUs()
    {
        ResultList<PluginContactUsEntity> Result = new ResultList<PluginContactUsEntity>();

        Result = PluginContactUsDomain.GetPluginContactAllNotAsync();
        if (Result.Status == ErrorEnums.Success)
        {
            lstContactUs.DataSource = Result.List.Where(a => a.IsDeleted == false).ToList(); 
            lstContactUs.DataBind(); 
        }
    }
    int count = 1;
    protected void lstContactUs_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            HyperLink lbl = (HyperLink)e.Item.FindControl("lblItem");
            switch (count)
            {
                case 1:
                    lbl.NavigateUrl = "callto:" + lbl.Text;
                    break;
                case 2:
                    lbl.NavigateUrl = "callto:" + lbl.Text;
                    break;
                case 3:
                    lbl.NavigateUrl = "mailto:" + lbl.Text;
                    break;
                case 4:
                    lbl.Text = lbl.Text;
                    break;
            }
            Image Img = (Image)e.Item.FindControl("Img");
            Img.ImageUrl = Img.ImageUrl.Replace("~/", "~/Siteware/"); 
            count = count + 1;

        }
    }
}