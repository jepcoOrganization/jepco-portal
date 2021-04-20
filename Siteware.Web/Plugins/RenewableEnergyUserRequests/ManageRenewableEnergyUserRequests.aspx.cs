using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Siteware.Web.Plugins.RenewableEnergyUserRequests
{
    public partial class ManageRenewableEnergyUserRequests : System.Web.UI.Page
    {
        string PageName = "RenewableEnergyUserRequests";
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
                        Session["RenewableEnergyUserRequestsIDSession"] = null;
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
                Session["IDSelectPage"] = "~/Plugins/RenewableEnergyUserRequests/ManageRenewableEnergyUserRequests.aspx";

            }
        }
        protected async void FillData()
        {

            ResultList<RenewableEnergyUserRequestsEntity> Result = new ResultList<RenewableEnergyUserRequestsEntity>();


            ResultList<CMS_WorkFlow_SettingsEntity> wresultList = new ResultList<CMS_WorkFlow_SettingsEntity>();
            wresultList = CMS_WorkFlow_SettingsDomain.GetAllNotAsync();
            if (wresultList.Status == ErrorEnums.Success)
            {
                wresultList.List = wresultList.List.Where(x => x.WF_ID.ToString() == "1" && x.UserID.ToString() == SessionManager.GetInstance.Users.UserID.ToString() && x.SettingID.ToString() == "1" && x.Value == true).ToList();
                if (wresultList.List.Count > 0)
                {
                    //foreach (var existsUser in wresultList.List)
                    //{
                    //if (existsUser.UserID.ToString() == SessionManager.GetInstance.Users.UserID.ToString())
                    //{
                    //if (existsUser.SettingID.ToString() == "1" && existsUser.Value == true)
                    //{
                    //show all data
                    Result = await RenewableEnergyUserRequestsDomain.GetAll();
                    if (Result.Status == ErrorEnums.Success)
                    {
                        lstAnnouncement.DataSource = Result.List.Where(s => s.IsDeleted == false).ToList();
                        lstAnnouncement.DataBind();
                    }
                    //}
                    //else
                    //{
                    //    ResultList<Plugin_CMS_WorkFlow_Entity> workflowResult = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                    //    workflowResult = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();
                    //    if (workflowResult.Status == ErrorEnums.Success)
                    //    {
                    //        workflowResult.List = workflowResult.List.Where(x => x.From_User.ToString() == SessionManager.GetInstance.Users.UserID.ToString() ||
                    //        x.To_User.ToString() == SessionManager.GetInstance.Users.UserID.ToString()).ToList();

                    //        if (workflowResult.List.Count > 0)
                    //        {
                    //            ResultList<RenewableEnergyUserRequestsEntity> re1 = new ResultList<RenewableEnergyUserRequestsEntity>();

                    //            Result = await RenewableEnergyUserRequestsDomain.GetAll();
                    //            if (Result.Status == ErrorEnums.Success)
                    //            {
                    //                foreach (var itm in workflowResult.List)
                    //                {
                    //                    var datareq = Result.List.Where(y => y.RenwableEnergyID == itm.RequestID).OrderBy(y => y.UserID).FirstOrDefault();
                    //                    if (!re1.List.Contains(datareq))
                    //                    {
                    //                        re1.List.Add(datareq);
                    //                    }
                    //                }

                    //            }
                    //            lstAnnouncement.DataSource = re1.List.Where(s => s.IsDeleted == false).ToList();
                    //            lstAnnouncement.DataBind();

                    //        }
                    //    }

                    //}
                    //}
                    //else
                    //{
                    //    if (existsUser.SettingID.ToString() == "1" && existsUser.Value == false)
                    //    {
                    //        //don't show data
                    //    }

                    //    //don't show data
                    //}
                    // }
                }
                else
                {
                    ResultList<Plugin_CMS_WorkFlow_Entity> workflowResult = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                    workflowResult = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();
                    if (workflowResult.Status == ErrorEnums.Success)
                    {
                        workflowResult.List = workflowResult.List.Where(x => x.From_User.ToString() == SessionManager.GetInstance.Users.UserID.ToString() ||
                        x.To_User.ToString() == SessionManager.GetInstance.Users.UserID.ToString()).ToList();

                        if (workflowResult.List.Count > 0)
                        {
                            ResultList<RenewableEnergyUserRequestsEntity> re1 = new ResultList<RenewableEnergyUserRequestsEntity>();

                            Result = await RenewableEnergyUserRequestsDomain.GetAll();
                            if (Result.Status == ErrorEnums.Success)
                            {
                                foreach (var itm in workflowResult.List)
                                {
                                    var datareq = Result.List.Where(y => y.RenwableEnergyID == itm.RequestID).OrderBy(y => y.UserID).FirstOrDefault();
                                    if (!re1.List.Contains(datareq))
                                    {
                                        re1.List.Add(datareq);
                                    }
                                }

                            }
                            lstAnnouncement.DataSource = re1.List.Where(s => s.IsDeleted == false).ToList();
                            lstAnnouncement.DataBind();

                        }
                    }
                }



                #region old code for workflow
                //wresultList.List = wresultList.List.Where(x => x.UserID.ToString() == SessionManager.GetInstance.Users.UserID.ToString()).ToList();

                //if (wresultList.List.Count > 0)
                //{
                //    //1 1 9 1
                //    if (wresultList.List[0].SettingID == 1 && wresultList.List[0].WF_ID == 1 && wresultList.List[0].Value == true)
                //    {
                //        Result = await RenewableEnergyUserRequestsDomain.GetAll();
                //        if (Result.Status == ErrorEnums.Success)
                //        {
                //            lstAnnouncement.DataSource = Result.List.Where(s => s.IsDeleted == false).ToList();
                //            lstAnnouncement.DataBind();
                //        }
                //    }
                //    // (1 or 0) 1 9 0
                //    else if (wresultList.List[0].SettingID == 1 || wresultList.List[0].SettingID == 0 && wresultList.List[0].WF_ID == 1 && wresultList.List[0].Value == false)
                //    {
                //        //workflowsetting_notfound.Style.Add("display", "block");
                //        // do nothing
                //    }
                //    // 0 1 9 1 
                //    else
                //    {
                //        ResultList<Plugin_CMS_WorkFlow_Entity> result1 = new ResultList<Plugin_CMS_WorkFlow_Entity>();
                //        result1 = Plugin_CMS_WorkFlow_Domain.GetAllNotAsync();
                //        if (result1.Status == ErrorEnums.Success)
                //        {
                //            result1.List = result1.List.Where(x => x.To_User == SessionManager.GetInstance.Users.UserID.ToString() || x.From_User == SessionManager.GetInstance.Users.UserID.ToString()).ToList();
                //            ResultList<RenewableEnergyUserRequestsEntity> re1 = new ResultList<RenewableEnergyUserRequestsEntity>();

                //            Result = await RenewableEnergyUserRequestsDomain.GetAll();
                //            if (Result.Status == ErrorEnums.Success)
                //            {
                //                foreach (var itm in result1.List)
                //                {
                //                    var datareq = Result.List.Where(y => y.RenwableEnergyID == itm.RequestID).FirstOrDefault();
                //                    re1.List.Add(datareq);
                //                }

                //            }
                //            lstAnnouncement.DataSource = re1.List.Where(s => s.IsDeleted == false).ToList();
                //            lstAnnouncement.DataBind();

                //        }
                //    }

                //}
                #endregion



            }




        }
        protected void lstAnnouncement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                System.Web.UI.WebControls.Label lblPublishDate = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblPublishDate");
                System.Web.UI.WebControls.Label lblAcceptDate = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblAcceptDate");
                System.Web.UI.WebControls.Label lblRequestType = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblRequestType");

                lblPublishDate.Text = Convert.ToDateTime(lblPublishDate.Text).ToString("dd-MM-yyyy");
                lblAcceptDate.Text = Convert.ToDateTime(lblAcceptDate.Text).ToString("dd-MM-yyyy");


                System.Web.UI.WebControls.Label lblUserID = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblUserID");

                ResultEntity<Plugin_ServiceUserEntity> ServiceUserEntity = new ResultEntity<Plugin_ServiceUserEntity>();
                ServiceUserEntity = Plugin_ServiceUserDomain.GetByIDNotAsync(Convert.ToInt32(lblUserID.Text));
                if (ServiceUserEntity.Status == ErrorEnums.Success)
                {
                    lblUserID.Text = ServiceUserEntity.Entity.FirstName + ServiceUserEntity.Entity.SecondName + ServiceUserEntity.Entity.FamilyName;
                }

                System.Web.UI.WebControls.Label lblCompID = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblCompID");

                ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> CompanyResult = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();
                CompanyResult = Plugin_RenwabaleEnergyCompanyDomain.GetByIDNotAsync(Convert.ToInt64(lblCompID.Text));
                if (CompanyResult.Status == ErrorEnums.Success)
                {
                    lblCompID.Text = CompanyResult.Entity.CompanyName;
                }

                if (lblRequestType.Text == "1")
                {
                    lblRequestType.Text = "صغير صافي قياس";
                }
                else if (lblRequestType.Text == "2") { lblRequestType.Text = "كبير صافي قياس"; }
                else
                {
                    lblRequestType.Text = "عبور";
                }

            }
        }
        protected void lstAnnouncement_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Session["RenewableEnergyUserRequestsIDSession"] = ID;

                Response.Redirect("~/Plugins/RenewableEnergyUserRequests/ViewRenewableEnergyUserRequests.aspx", false);
            }

        }

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