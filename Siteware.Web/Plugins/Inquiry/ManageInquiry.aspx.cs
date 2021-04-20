using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;

namespace Siteware.Web.Plugins.Inquiry
{
    public partial class ManageInquiry : System.Web.UI.Page
    {
        string PageName = "Inquiry";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!FunctionSecurity.TestUserPermissionPage(SessionManager.GetInstance.Users.UserID, PageName))
                {
                    Response.Redirect("~/DashBoard.aspx", false);
                }
                if (!IsPostBack)
                {
                    if (SessionManager.GetInstance.Users != null)
                    {
                        FillNavigation();
                        Session["InquiryIDSession"] = null;
                        FillData();
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Redirect("~/Login.aspx", false);
                    }
                }
            }
            catch
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/Login.aspx", false);
            }
            
        }
        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                Session["IDSelectPage"] = "~/Plugins/Inquiry/ManageInquiry.aspx";
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
            }
        }
        protected async void FillData()
        {
            ResultList<ContactUsFormEntity> Result = new ResultList<ContactUsFormEntity>();

            Result = await ContactUsFormDomain.GetContactUsFormAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstInquiry.DataSource = Result.List.ToList();
                lstInquiry.DataBind();
            }
        }        
        protected void lstInquiry_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblInquiryDate = (Label)e.Item.FindControl("lblInquiryDate");
                lblInquiryDate.Text = Convert.ToDateTime(lblInquiryDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstInquiry_ItemCommand(object sender, ListViewCommandEventArgs e)
        {            
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["InquiryIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected async void DeleteItem()
        {
            if (Session["InquiryIDSession"] != null)
            {
                ContactUsFormEntity entity = new ContactUsFormEntity();

                entity.ID = Convert.ToInt32(Session["InquiryIDSession"].ToString());
                entity.IsDeleted = true;
                var Result = await ContactUsFormDomain.UpdateContactUsByIsDeleted(entity);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["InquiryIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstInquiry.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label FormID = ((Label)item.FindControl("lblID"));
                    ContactUsFormEntity entity = new ContactUsFormEntity();
                    entity.ID = Convert.ToInt32(FormID.Text);
                    entity.IsDeleted = true;

                    var Result = await ContactUsFormDomain.UpdateContactUsByIsDeleted(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
            }

        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Inquiry/AddInquiry.aspx", false);
        }
        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {            
            DeleteItem();
            Response.Redirect("~/Plugins/Inquiry/ManageInquiry.aspx", false);
        }

        
    }
}