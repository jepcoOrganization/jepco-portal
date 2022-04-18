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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_FocusAreaList : System.Web.UI.UserControl
{
    DateTime currentDate = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillFocusArea();
            }
        }
        catch
        {
        }

    }
    protected void FillFocusArea()
    {
        try
        {
            ResultList<Plugin_Focus_AreaEntity> Result = new ResultList<Plugin_Focus_AreaEntity>();
            Result = Plugin_Focus_AreaDomain.GetAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                int ID = Convert.ToInt32(Session["CurrentLanguage"].ToString());
                lstFocusArea.DataSource = Result.List.Where(q => q.IsDelete == false && q.IsPublished == true && q.LanguageID == ID && q.PublishedDate <= currentDate).OrderBy(s => s.FocusOrder).ToList();
                lstFocusArea.DataBind();
            }
        }
        catch
        {
        }
    }
    protected void lstFocusArea_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgFocusArea = (Image)e.Item.FindControl("imgFocusArea");
                HtmlGenericControl divfocus = (HtmlGenericControl)e.Item.FindControl("divfocus");
                HtmlGenericControl h3FocusTitle = (HtmlGenericControl)e.Item.FindControl("h3FocusTitle");
                HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                imgFocusArea.ImageUrl = ConfigurationManager.AppSettings["ImagePath"].ToString() + imgFocusArea.ImageUrl;

                divfocus.Style.Add("background", hdnColor.Value);
                h3FocusTitle.Style.Add("color", hdnColor.Value);
            }
        }
        catch
        {
        }
    }
}