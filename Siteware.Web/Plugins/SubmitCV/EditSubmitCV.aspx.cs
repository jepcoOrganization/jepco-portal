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
using System.Windows.Forms;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Globalization;

namespace Siteware.Web.Plugins.SubmitCV
{
    public partial class EditSubmitCV : System.Web.UI.Page
    {
        string PageName = "Career";
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
                       // FillLanguages();
                        //FillNews();
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
                Session["IDSelectPage"] = "~/Plugins/SubmitCV/ManageSubmitCV.aspx";

                
            }
        }

        protected async void FillDetails()
        {
            if (Session["SubmitCVIDSession"] != null)
            {
                int CVID = Convert.ToInt32(Session["SubmitCVIDSession"]);

                ResultEntity<Plugin_SubmitCVEntity> Result = new ResultEntity<Plugin_SubmitCVEntity>();

                Result = await Plugin_SubmitCVDomain.GetByID(CVID);
                if (Result.Status == ErrorEnums.Success)
                {
                    txtName.Text = Result.Entity.Name;
                    txtEmail.Text = Result.Entity.Email;
                    txtPhone.Text = Result.Entity.PhoneNo;
                    ddlInterest.SelectedValue = Result.Entity.Interest.ToString();

                    if(Result.Entity.AttachCV != string.Empty)
                    {
                        string abcd = Result.Entity.AttachCV.ToString();
                        string Cutted = abcd.Split('/').Last();

                        lnlCV.NavigateUrl = Result.Entity.AttachCV;
                        lnlCV.Text = Cutted;
                    }

                   

                    txtPublishDate.Value = Result.Entity.PublishedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                }
            }
        }
    }
}