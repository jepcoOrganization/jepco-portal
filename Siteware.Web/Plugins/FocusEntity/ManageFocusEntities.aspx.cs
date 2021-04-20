using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.FocusEntity
{
    public partial class ManageFocusEntities : System.Web.UI.Page
    {
        string PageName = "Entities";
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
                        Session["FocusEntityIDSession"] = null;
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
                throw e;
            }

        }

        public class LangDetails
        {
            public int LangId { get; set; }
            public string LangName { get; set; }
        }

        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                Session["FocusEntityIDSession"] = "~/Plugins/FocusEntity/ManageFocusEntities.aspx";

            }
        }

        protected async void FillData()
        {
            ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();

            Result = await Plugin_FA_EntitiesDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstFocusEntity.DataSource = Result.List.ToList();
                lstFocusEntity.DataBind();
            }
        }

        protected void lstFocusEntity_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                HiddenField lblLangID = (HiddenField)e.Item.FindControl("lblLangID");
                Label lblFocusEntityId = (Label)e.Item.FindControl("lblFocusEntityId");
                Label lblTitle = (Label)e.Item.FindControl("lblTitle");
                HyperLink lnkEntityDetail = (HyperLink)e.Item.FindControl("lnkEntityDetail");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

                string lang = string.Empty;
                if (lblLangID.Value == "1")
                {
                    lang = "/en";
                }
                else
                {
                    lang = "/ar";
                }

                string title = Regex.Replace(lblTitle.Text, @"[\\:/*#.]+", string.Empty);
                int ID = Convert.ToInt32(lblFocusEntityId.Text.ToString());

                lnkEntityDetail.Text = lang + "/EntityPage/" + title.Trim() + "/" + ID.ToString();
                lnkEntityDetail.NavigateUrl = lang + "/EntityPage/" + title.Trim() + "/" + ID.ToString();

            }
        }

        protected void lstFocusEntity_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["FocusEntityIDSession"] = ID;

                Response.Redirect("~/Plugins/FocusEntity/EditFocusEntities.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["FocusEntityIDSession"] = ID;
                mpeSuccess.Show();
            }
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/FocusEntity/AddFocusEntities.aspx", false);
        }

        protected async void DeleteItem()
        {
            if (Session["FocusEntityIDSession"] != null)
            {
                Plugin_FA_EntitiesEntity entity = new Plugin_FA_EntitiesEntity();

                entity.FocusEntityId = Convert.ToInt64(Session["FocusEntityIDSession"].ToString());
                entity.IsDelete = true;
                var Result = await Plugin_FA_EntitiesDomain.DeleteRecord(entity.FocusEntityId);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["FocusEntityIDSession"] = null;
                }
            }
            foreach (ListViewItem item in lstFocusEntity.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label FocusEntityID = ((Label)item.FindControl("lblID"));
                    Plugin_FA_EntitiesEntity entity = new Plugin_FA_EntitiesEntity();
                    entity.FocusEntityId = Convert.ToInt64(FocusEntityID.Text);
                    entity.IsDelete = true;

                    var Result = await Plugin_FA_EntitiesDomain.DeleteRecord(entity.FocusEntityId);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        // mpeSuccess.Show();
                    }
                }
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

            DeleteItem();
            Response.Redirect("~/Plugins/FocusEntity/ManageFocusEntities.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
    }
}