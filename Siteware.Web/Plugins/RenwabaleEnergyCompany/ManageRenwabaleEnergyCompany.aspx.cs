using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Siteware.Web.Plugins.Plugin_RenwabaleEnergyCompany
{
    public partial class ManageRenwabaleEnergyCompany : System.Web.UI.Page
    {
        string PageName = "RenwabaleEnergyCompany";
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
                        Session["RenwabaleEnergyCompanyIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/ServiceNote/ManageRenwabaleEnergyCompany.aspx";

            }
        }
        protected async void FillData()
        {
            ResultList<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();

            Result = await Plugin_RenwabaleEnergyCompanyDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstAnnouncement.DataSource = Result.List.Where(s => s.IsDeleted == false).ToList();
                lstAnnouncement.DataBind();
            }
        }
        protected void lstAnnouncement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                System.Web.UI.WebControls.Label lblPublishDate = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblPublishDate");
                
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
            }
        }
        protected void lstAnnouncement_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["RenwabaleEnergyCompanyIDSession"] = ID;

                Response.Redirect("~/Plugins/RenwabaleEnergyCompany/EditRenwabaleEnergyCompany.aspx", false);
            }
            //if (e.CommandName == "DeleteItem")
            //{
            //    int ID = Convert.ToInt32(e.CommandArgument);
            //    Session["ServiceNoteIDSession"] = ID;
            //    mpeSuccess.Show();
            //}
        }
        //protected async void DeleteItem()
        //{
        //    if (Session["ServiceNoteIDSession"] != null)
        //    {
        //        Plugin_ServiceNoteEntity entity = new Plugin_ServiceNoteEntity();

        //        entity.ServiceNoteID = Convert.ToInt32(Session["ServiceNoteIDSession"].ToString());
        //        entity.IsDelete = true;
        //        var Result = await Plugin_ServiceNoteDomain.UpdateByIsDeleted(entity);
        //        if (Result.Status == ErrorEnums.Success)
        //        {
        //            Session["ServiceNoteIDSession"] = null;
        //        }
        //    }
        //    var sessionChecked = Session["SelectedItems"] as List<String>;
        //    if (sessionChecked != null)
        //    {
        //        foreach (var item in sessionChecked)
        //        {
        //            Plugin_ServiceNoteEntity entity = new Plugin_ServiceNoteEntity();
        //            entity.ServiceNoteID = Convert.ToInt32(item);
        //            entity.IsDelete = true;

        //            var Result = await Plugin_ServiceNoteDomain.UpdateByIsDeleted(entity);
        //            if (Result.Status == ErrorEnums.Success)
        //            {
        //                // mpeSuccess.Show();
        //            }

        //        }
        //    }
        //}

        //protected void btnAdd2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Plugins/ServiceNote/AddServiceNote.aspx", false);
        //}
        //protected void BtnDelete2_Click(object sender, EventArgs e)
        //{
        //    List<String> checkedList = new List<string>();
        //    foreach (ListViewItem item in lstAnnouncement.Items)
        //    {

        //        CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
        //        if (CBID.Checked)
        //        {
        //            Label FormID = ((Label)item.FindControl("lblID"));
        //            checkedList.Add(FormID.Text);

        //        }
        //        Session.Add("SelectedItems", checkedList);
        //        var size = checkedList.Count();
        //    }
        //    mpeSuccess.Show();
        //}
        protected void btnOk_Click(object sender, EventArgs e)
        {

            //DeleteItem();
            //Response.Redirect("~/Plugins/ServiceNote/ManageServiceNote.aspx", false);
        }
        [WebMethod]
        public static LangDetails[] BindDatatoDropdown()
        {
            try
            {
                ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
                List<LangDetails> details = new List<LangDetails>();
                Result = LanguageDomain.GetLanguagesAllNotAsync();
                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (var item in Result.List)
                    {
                        LangDetails lang = new LangDetails();
                        lang.LangId = item.ID;
                        lang.LangName = item.Name;
                        details.Add(lang);
                    }
                }
                return details.ToArray();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }
    }
}