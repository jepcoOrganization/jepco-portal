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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.Timeline
{
    public partial class ManageTimeline : System.Web.UI.Page
    {
        string PageName = "Timeline";
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
                        Session["TimelineID"] = null;
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
                Session["TimelineID"] = "~/Plugins/Timeline/ManageTimeline.aspx";

            }
        }

        protected async void FillData()
        {
            ResultList<Plugin_TimelineEntity> Result = new ResultList<Plugin_TimelineEntity>();

            Result = await Plugin_TimelineDomain.GetAll();
            if (Result.Status == ErrorEnums.Success)
            {
                lstTimelineEntity.DataSource = Result.List.ToList();
                lstTimelineEntity.DataBind();
            }
        }

        protected void lstTimelineEntity_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");

            }
        }

        protected void lstTimelineEntity_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["TimelineID"] = ID;

                Response.Redirect("~/Plugins/Timeline/EditTimeline.aspx", false);
            }
            if (e.CommandName == "DeleteItem")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["TimelineID"] = ID;
                mpeSuccess.Show();
            }
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Timeline/AddTimeline.aspx", false);
        }

        protected async void DeleteItem()
        {
            if (Session["TimelineID"] != null)
            {
                Plugin_TimelineEntity entity = new Plugin_TimelineEntity();

                entity.TimelineID = Convert.ToInt64(Session["TimelineID"].ToString());
                entity.IsDelete = true;
                var Result = await Plugin_TimelineDomain.DeleteRecord(entity.TimelineID);
                if (Result.Status == ErrorEnums.Success)
                {
                    Session["TimelineID"] = null;
                }
            }
            foreach (ListViewItem item in lstTimelineEntity.Items)
            {
                CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
                if (CBID.Checked)
                {
                    Label TimelineID = ((Label)item.FindControl("lblID"));
                    Plugin_TimelineEntity entity = new Plugin_TimelineEntity();
                    entity.TimelineID = Convert.ToInt32(TimelineID.Text);
                    entity.IsDelete = true;

                    var Result = await Plugin_FA_EntitiesDomain.DeleteRecord(entity.TimelineID);
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
            Response.Redirect("~/Plugins/Timeline/ManageTimeline.aspx", false);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            mpeSuccess.Show();
        }
    }
}