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

public partial class Controls_MessagesAndNotificationsList : System.Web.UI.UserControl
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
                    FillUser();
                    //Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                     FillCompain(1);
                    
                }
                FillDropwonn();
            }

            
            //For Pagination 
            //pager1 = lstCompanyDevice.FindControl("DataPager1") as DataPager;
            //if (pager1 != null)
            //{
            //    pager1.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            //}
        }
        catch
        {
        }
    }

    protected void FillCompain(int a)
    {
        try
        {
            try
            {
                long ServiceUserID = SessionManager.GetInstance.Users.ID;
                long CompanyId = 0;
                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> Result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                Result = Plugin_RenwabaleEnergyCompanyDomain.GetByServiceUserIDNotAsync(ServiceUserID);
                if (Result.Status == ErrorEnums.Success)
                {
                   CompanyId = Result.Entity.RenwabaleEnergyCompanyID;                    
                }

                ResultList<MessagesAndNotificationsEntity> res = new ResultList<MessagesAndNotificationsEntity>();
                res = MessagesAndNotificationsDomain.GetAllNotAsync();
                if (res.Status == ErrorEnums.Success)
                {
                    if (a == 1)
                    {
                        lstNotificationDevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.MsgToUserID == CompanyId).OrderByDescending(s => s.PublishDate).ToList();
                        lstNotificationDevice.DataBind();
                        hdnCountRecord.Value = lstNotificationDevice.Items.Count.ToString();
                    }
                    else
                    {
                        lstNotificationDevice.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.MsgToUserID == CompanyId).OrderBy(s => s.PublishDate).ToList();
                        lstNotificationDevice.DataBind();

                        hdnCountRecord.Value = lstNotificationDevice.Items.Count.ToString();
                    }
                   

                    //int Complaincout = lstCompanyDevice.Items.Count();
                    //lblTotalCount.Text = Complaincout.ToString();


                    //var AppoverCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString() && s.Status == "1").ToList();
                    //int Appover = AppoverCount.Count();
                    //lblAppoverCount.Text = Appover.ToString();

                    //var ReversingCount = res.List.Where(s => !s.IsDeleted && s.IsPublished && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"]) && s.AddUser == ServiceUserID.ToString() && s.Status == "2").ToList();
                    //int Reversing = AppoverCount.Count();
                    //lblReversingCount.Text = Reversing.ToString();


                }

            }
            catch (Exception ex)
            {
            }




        }
        catch (Exception ex)
        {
        }
    }

    int countLoop = 0;
    protected void lstNotificationDevice_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HiddenField hdnMsgFromUserID = (HiddenField)e.Item.FindControl("hdnMsgFromUserID");
                HiddenField hdnISRead = (HiddenField)e.Item.FindControl("hdnISRead");
                bool isReadMSG = Convert.ToBoolean(hdnISRead.Value);
                HtmlGenericControl ListLI = (HtmlGenericControl)e.Item.FindControl("ListLI");
                Label lblUserName = (Label)e.Item.FindControl("lblUserName"); 
                ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(Convert.ToInt64(hdnMsgFromUserID.Value));
                if(ServiceUserEntity.Status == ErrorEnums.Success)
                {
                    if (isReadMSG)
                    {
                        lblUserName.Text = "<p>" + ServiceUserEntity.Entity.FirstName + " " + ServiceUserEntity.Entity.SecondName + " " + ServiceUserEntity.Entity.FamilyName + "</p>";
                       
                    }
                    else {
                        lblUserName.Text = "<strong>" + ServiceUserEntity.Entity.FirstName + " " + ServiceUserEntity.Entity.SecondName + " " + ServiceUserEntity.Entity.FamilyName + "</strong>";
                        ListLI.Attributes.Add("class", "UnreadLI");
                    } 
                }
                HiddenField hdnPublishDate = (HiddenField)e.Item.FindControl("hdnPublishDate");
                Label lblPublishDate = (Label)e.Item.FindControl("lblPublishDate");
                string DateinText = Convert.ToDateTime(hdnPublishDate.Value).ToString("dd-MM-yyyy");
                lblPublishDate.Text = DateinText;
                Label lblPublishTime = (Label)e.Item.FindControl("lblPublishTime");
                lblPublishTime.Text = Convert.ToDateTime(hdnPublishDate.Value).ToLongTimeString();
                Label lblMsg = (Label)e.Item.FindControl("lblMsg");
                HiddenField hdnNotificationID = (HiddenField)e.Item.FindControl("hdnNotificationID");                
                HyperLink lnkNews = (HyperLink)e.Item.FindControl("lnkNews"); 
                string lang = string.Empty;
                lang = "/ar"; 
                string title = Regex.Replace(lblMsg.Text, @"[\\:/*#.]+", string.Empty);
                int ID = Convert.ToInt32(hdnNotificationID.Value.ToString());
                lnkNews.NavigateUrl = lang + "/NotificationAndMessagePage/" + title.Trim() + "/" + ID.ToString();
                //============= Sprite Details =============
                //Label lblDetials = (Label)e.Item.FindControl("lblDetials");
                //int lengthParentRext = Convert.ToInt32(lblDetials.Text.Length);
                //if (lengthParentRext > 30)
                //{
                //    lblDetials.Text = "..." + lblDetials.Text.Substring(0, 30);
                //}
                //else
                //{
                //    lblDetials.Text = lblDetials.Text;
                //}
                //int lengthtitleText = Convert.ToInt32(lblMsg.Text.Length);
                //if (lengthtitleText > 20)
                //{
                //    lblMsg.Text = "..." + lblMsg.Text.Substring(0, 20);
                //}
                //else
                //{
                //    lblMsg.Text = lblMsg.Text;
                //}
                HiddenField hndAttechment = (HiddenField)e.Item.FindControl("hndAttechment");
                //HtmlGenericControl idimg = (HtmlGenericControl)e.Item.FindControl("idimg");

                Image imgattech = (Image)e.Item.FindControl("imgattech");

                if (hndAttechment.Value == "" || hndAttechment.Value == null)
                {
                    //idimg.Attributes.Add("style", "display:none");

                    imgattech.Attributes.Add("style", "display:none");

                }
                else
                {
                    //idimg.Attributes.Add("style", "display:block");

                    //imgattech.Attributes.Add("style", "display:block");
                    imgattech.Attributes.Add("style", "display:inline-block");
                    
                }

                

                 

                countLoop++;

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

            int MappingValue = 1;
            int selectedMapping = Convert.ToInt32(ddlMapping.SelectedValue);
            if (selectedMapping == 1)
            {
                MappingValue = 1;
            }
            else
            {
                MappingValue = 2;
            }



            DataPager pager1;
            pager1 = lstNotificationDevice.FindControl("DataPager1") as DataPager;
            (pager1).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.FillCompain(MappingValue);
            //panelNews.Focus();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lstNotificationDevice.Items)
        {
            CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
            if (CBID.Checked)
            {
                HiddenField hdnNotificationID = ((HiddenField)item.FindControl("hdnNotificationID"));

                long NotificationID = Convert.ToInt64(hdnNotificationID.Value);

                MessagesAndNotificationsEntity MSEntity = new MessagesAndNotificationsEntity();
                MSEntity.NotificationID = NotificationID;

                var deleteRecord = MessagesAndNotificationsDomain.DeleteNotAsync(MSEntity);
                if (deleteRecord.Status == ErrorEnums.Success)
                {
                    // mpeSuccess.Show();
                }



            }
        }

        FillCompain(1);
    }


    protected void UnRead_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lstNotificationDevice.Items)
        {
            CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
            if (CBID.Checked)
            {
                HiddenField hdnNotificationID = ((HiddenField)item.FindControl("hdnNotificationID"));

                long NotificationID = Convert.ToInt64(hdnNotificationID.Value);

                MessagesAndNotificationsEntity MSEntity = new MessagesAndNotificationsEntity();
                MSEntity.NotificationID = NotificationID;

                var deleteRecord = MessagesAndNotificationsDomain.UnReadNotAsync(MSEntity);
                if (deleteRecord.Status == ErrorEnums.Success)
                {
                    // mpeSuccess.Show();
                }



            }
        }

        FillCompain(1);
    }

    protected void Read_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lstNotificationDevice.Items)
        {
            CheckBox CBID = ((CheckBox)item.FindControl("CBID"));
            if (CBID.Checked)
            {
                HiddenField hdnNotificationID = ((HiddenField)item.FindControl("hdnNotificationID"));

                long NotificationID = Convert.ToInt64(hdnNotificationID.Value);

                MessagesAndNotificationsEntity MSEntity = new MessagesAndNotificationsEntity();
                MSEntity.NotificationID = NotificationID;

                var deleteRecord = MessagesAndNotificationsDomain.ReadNotAsync(MSEntity);
                if (deleteRecord.Status == ErrorEnums.Success)
                {
                    // mpeSuccess.Show();
                }



            }
        }

        FillCompain(1);
    }




    protected void FillUser()
    {
        try
        {
           




        }
        catch (Exception ex)
        {
        }
    }

    protected void FillDropwonn()
    {
        try
        {

            ddlMapping.Items.Clear();
            ddlMapping.Items.Insert(0, new ListItem("من الأقدم الى الأحدث", "1"));
            ddlMapping.Items.Insert(1, new ListItem(" من الأحدث الى الأقدم", "2"));




        }
        catch (Exception ex)
        {
        }
    }



    protected void ddlMapping_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedMapping = Convert.ToInt32(ddlMapping.SelectedValue);
        if (selectedMapping == 1 )
        {
            FillCompain(1);
        }
        else
        {
            FillCompain(2);
        }

    }
}