using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Enums;
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Siteware.Web.Plugins.Calendar
{
    public partial class EditCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillNavigation();
                    FillLanguages();
                    FillDetails();
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void FillNavigation()
        {
            var masterPage = this.Master;
            if (masterPage != null)
            {
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "");
                //liPlugins.Attributes.Add("class", "active dropdown");
                //ulPlugins.Attributes.Add("style", "display: block;");
                Session["IDSelectPage"] = "~/Plugins/Calendar/ManageCalendar.aspx";
            }
        }
        protected async void FillDetails()
        {
            if (Session["CalendarIDSession"] != null)
            {
                int CalendarID = Convert.ToInt32(Session["CalendarIDSession"]);

                ResultEntity<CalendarEntity> Result = new ResultEntity<CalendarEntity>();

                Result = await CalendarDomain.GetCalendarByID(CalendarID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtCalendarName.Text = Result.Entity.CalendarName;
                    lblCalendarName1.Text = Result.Entity.CalendarName;
                    lblCalendarName2.Text = Result.Entity.CalendarName;
                    txtEventDate.Value = Result.Entity.EventDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    txtPublishDate.Value = Result.Entity.PublishDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    CBIsPublished.Checked = Result.Entity.IsPublished;
                    ddlLanguages.SelectedValue = Result.Entity.LanguageID.ToString();
                    hdnCalID.Value = Result.Entity.ID.ToString();
                    hdnEntityID.Value = Result.Entity.EntityID.ToString();
                    hdnLangID.Value = Result.Entity.LanguageID.ToString();
                    int LangID = Convert.ToInt32(Result.Entity.LanguageID);
                 //   FillEntity(LangID);
                    //ddlEntity.SelectedValue = Result.Entity.EntityID.ToString();
                }
            }
        }
        protected void FillLanguages()
        {
            ddlLanguages.Items.Insert(0, new ListItem("Select Language", "0"));

            ResultList<LanguageEntity> Result = new ResultList<LanguageEntity>();
            Result = LanguageDomain.GetLanguagesAllNotAsync();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (LanguageEntity item in Result.List)
                {
                    ddlLanguages.Items.Add(new ListItem(item.Name.ToString(), item.ID.ToString()));
                }
            }
        }
        //protected void FillEntity(int LangID)
        //{
        //    try
        //    {
        //        ddlEntity.Items.Clear();
        //        ddlEntity.Items.Insert(0, new ListItem("Select Entity", "0"));

        //        ResultList<Plugin_FA_EntitiesEntity> Result = new ResultList<Plugin_FA_EntitiesEntity>();
        //        Result = Plugin_FA_EntitiesDomain.GetAllNotAsync();

        //        if (Result.Status == ErrorEnums.Success)
        //        {
        //            foreach (Plugin_FA_EntitiesEntity item in Result.List)
        //            {
        //                ddlEntity.Items.Add(new ListItem(item.Title.ToString(), item.FocusEntityId.ToString()));
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        protected async void btnAdd2_Click(object sender, EventArgs e)
        {
            CalendarEntity entity = new CalendarEntity();
            if (Session["CalendarIDSession"] != null)
            {
                entity.ID = Convert.ToInt32(Session["CalendarIDSession"]);
                entity.CalendarName = txtCalendarName.Text;
                entity.EventDate = DateTime.ParseExact(txtEventDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.LanguageID = Convert.ToByte(ddlLanguages.SelectedValue);
                entity.PublishDate = DateTime.ParseExact(txtPublishDate.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                entity.IsPublished = CBIsPublished.Checked;
                entity.IsDeleted = false;
                entity.EditDate = Convert.ToDateTime(DateTime.Now);
                entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();
                entity.EntityID = 0;
                ResultList<CalendarEntity> EntityAll = new ResultList<CalendarEntity>();

                EntityAll = await CalendarDomain.GetCalendarAll();
                if (EntityAll.Status == ErrorEnums.Success)
                {
                    bool isExist = true;
                    if (Convert.ToInt64(hdnEntityID.Value) == entity.EntityID)
                    {
                        isExist = true;
                    }
                    else
                    {
                        var record = EntityAll.List.Where(s => s.EventDate == entity.EventDate).FirstOrDefault();
                        if (record != null)
                        {
                            isExist = false;
                            mpeSuccess2.Show();
                            return;
                        }
                        else
                        {
                            isExist = true;
                        }
                    }

                    if (isExist)
                    {
                        var Result = await CalendarDomain.Update(entity);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            mpeSuccess.Show();
                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    var Result = await CalendarDomain.Update(entity);
                    if (Result.Status == ErrorEnums.Success)
                    {
                        mpeSuccess.Show();
                    }
                }
                
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Plugins/Calendar/ManageCalendar.aspx");
        }
        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int LanguageID = Convert.ToInt32(ddlLanguages.SelectedValue);                
               // FillEntity(LanguageID);
                if (Convert.ToInt32(hdnLangID.Value) == LanguageID)
                {
                   // ddlEntity.SelectedValue = hdnEntityID.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}