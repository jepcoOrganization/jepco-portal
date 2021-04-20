using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using Siteware.Web.AppCode;

namespace Siteware.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            var Encrypt = new Encrypt();
            var Password = Encrypt.Encrypted(txtPassword.Text);
            //var Password1 = Encrypt.Decrypted(txtPassword.Text);

            ResultEntity<UserEntity> Result = await UsersDomain.CheckUserLogin(txtusername.Text, Password);
            if (Result.Status == ErrorEnums.Success)
            {
                if (Result.Entity.Status == true)
                {
                    SessionManager.GetInstance.Users = Result.Entity;
                    Response.Redirect("~/Dashboard.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username Or Password')", true);
                    return;
                }                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied", "alert('Invalid Username Or Password')", true);
                return;
            }
        }
    }
}