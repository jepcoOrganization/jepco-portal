using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteware.Web.AppCode;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System.Globalization;
using SiteWare.Entity;

namespace Siteware.Web.Security
{
    public partial class ManageUserPermission : System.Web.UI.Page
    {
        string PageName = "Manage User";
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

                    if (Session["ManageUserIDSession"] != null)
                    {
                        int ID = Convert.ToInt32(Session["ManageUserIDSession"].ToString());


                        Session["ManageUserIDSession"] = null;
                        ViewState["ManageUserIDViewState"] = ID;

                        FillAllPageMaster(ID);
                        FillAllPluginMaster(ID);

                        FillAllPageUser(ID);
                        FillAllPluginUser(ID);

                        FillMartialStatus();
                        FillGender();
                        FillCountry();
                        FillDepartment();
                        FillSection();
                        FillDetails(ID);
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
                //HtmlGenericControl liDashboard = (HtmlGenericControl)masterPage.FindControl("liDashboard");
                //HtmlGenericControl liPages = (HtmlGenericControl)masterPage.FindControl("liPages");
                //HtmlGenericControl liPlugins = (HtmlGenericControl)masterPage.FindControl("liPlugins");
                //HtmlGenericControl ulPlugins = (HtmlGenericControl)masterPage.FindControl("ulPlugins");

                //liDashboard.Attributes.Add("class", "");
                //liPages.Attributes.Add("class", "active");

                Session["IDSelectPage"] = "~/Security/ManageUser.aspx";
            }
        }


        void FillAllPageMaster(int UserID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_Pages_SelectAll";
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));//SessionManager.GetInstance.Users.UserID.ToString()));
            cmd.Connection = con;
            da.SelectCommand = cmd;


            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lstPages.DataTextField = "PluginName";
                lstPages.DataValueField = "PluginID";
                lstPages.DataSource = dt;
                lstPages.DataBind();
            }
        }

        void FillAllPluginMaster(int UserID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_Plugin_SelectAll";
            //cmd.Parameters.Add(new SqlParameter("@UserID", SessionManager.GetInstance.Users.UserID.ToString()));
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            cmd.Connection = con;
            da.SelectCommand = cmd;


            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {


                lstPlugins.DataTextField = "PluginName";
                lstPlugins.DataValueField = "PluginID";
                lstPlugins.DataSource = dt;
                lstPlugins.DataBind();
            }
        }


        void FillAllPageUser(int UserID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_Pages_SelectAllByUserID";
            //cmd.Parameters.Add(new SqlParameter("@UserID", SessionManager.GetInstance.Users.UserID.ToString()));
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));

            cmd.Connection = con;
            da.SelectCommand = cmd;


            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lstUsersPages.DataTextField = "PluginName";
                lstUsersPages.DataValueField = "PluginID";
                lstUsersPages.DataSource = dt;
                lstUsersPages.DataBind();
            }
        }

        void FillAllPluginUser(int UserID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_Plugin_SelectAllByUserID";
            //cmd.Parameters.Add(new SqlParameter("@UserID", SessionManager.GetInstance.Users.UserID.ToString()));
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            cmd.Connection = con;
            da.SelectCommand = cmd;


            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {


                lstUsersPlugins.DataTextField = "PluginName";
                lstUsersPlugins.DataValueField = "PluginID";
                lstUsersPlugins.DataSource = dt;
                lstUsersPlugins.DataBind();
            }
        }


        protected void btnAdd2_Click(object sender, EventArgs e)
        {

            if (ViewState["ManageUserIDViewState"] != null)
            {

                Insert(Convert.ToInt32(ViewState["ManageUserIDViewState"].ToString()));
                UpdateInformation(Convert.ToInt32(ViewState["ManageUserIDViewState"].ToString()));


            }



        }



        async void Insert(int UserID)
        {
            SecurityUserPluginEntity entity = new SecurityUserPluginEntity();


            var ResultDelete = await SecurityUserPluginDomain.DeleteAll(UserID);

            //

            for (int i = 0; i < lstUsersPlugins.Items.Count; i++)
            {
                entity.UserID = Convert.ToInt32(UserID.ToString());
                entity.PluginID = Convert.ToInt32(lstUsersPlugins.Items[i].Value.ToString());

                entity.AddUser = UserID.ToString();

                var Result = await SecurityUserPluginDomain.InsertContact(entity);
            }

            for (int i = 0; i < lstUsersPages.Items.Count; i++)
            {
                entity.UserID = Convert.ToInt32(UserID.ToString());
                entity.PluginID = Convert.ToInt32(lstUsersPages.Items[i].Value.ToString());

                entity.AddUser = UserID.ToString();

                var Result = await SecurityUserPluginDomain.InsertContact(entity);
            }
        }



        protected void btnPluginsRemoveList_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < lstUsersPlugins.Items.Count; i++)
            {

                if (lstUsersPlugins.Items[i].Selected)
                {
                    lstPlugins.Items.Add(new ListItem(lstUsersPlugins.Items[i].Text, lstUsersPlugins.Items[i].Value));
                }

            }

            for (int i = 0; i < lstPlugins.Items.Count; i++)
            {
                for (int x = 0; x < lstUsersPlugins.Items.Count; x++)
                {
                    if (lstPlugins.Items[i].Value == lstUsersPlugins.Items[x].Value)
                    {
                        lstUsersPlugins.Items.Remove(lstUsersPlugins.Items[x]);

                    }
                }
            }


        }

        protected void btnPluginsAddList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstPlugins.Items.Count; i++)
            {
                
                if (lstPlugins.Items[i].Selected)
                {
                    lstUsersPlugins.Items.Add(new ListItem(lstPlugins.Items[i].Text, lstPlugins.Items[i].Value));
                }

            }

            for (int i = 0; i < lstUsersPlugins.Items.Count; i++)
            {
                for (int x = 0; x < lstPlugins.Items.Count; x++)
                {
                    if (lstUsersPlugins.Items[i].Value == lstPlugins.Items[x].Value)
                    {
                        lstPlugins.Items.Remove(lstPlugins.Items[x]);

                    }
                }
            }

        }

        protected void btnPagesRemoveList_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lstUsersPages.Items.Count; i++)
            //{
            //    if (lstUsersPages.Items[i].Selected)
            //    {
            //        lstPages.Items.Add(new ListItem(lstUsersPages.Items[i].Text, lstUsersPages.Items[i].Value));
            //        lstUsersPages.Items.Remove(lstUsersPages.Items[i]);
            //    }

            //}



            for (int i = 0; i < lstUsersPages.Items.Count; i++)
            {

                if (lstUsersPages.Items[i].Selected)
                {
                    lstPages.Items.Add(new ListItem(lstUsersPages.Items[i].Text, lstUsersPages.Items[i].Value));
                }

            }

            for (int i = 0; i < lstPages.Items.Count; i++)
            {
                for (int x = 0; x < lstUsersPages.Items.Count; x++)
                {
                    if (lstPages.Items[i].Value == lstUsersPages.Items[x].Value)
                    {
                        lstUsersPages.Items.Remove(lstUsersPages.Items[x]);

                    }
                }
            }


        }

        protected void btnPagesAddList_Click(object sender, EventArgs e)
        {

            //for (int i = 0; i < lstPages.Items.Count; i++)
            //{
            //    if (lstPages.Items[i].Selected)
            //    {
            //        lstUsersPages.Items.Add(new ListItem(lstPages.Items[i].Text, lstPages.Items[i].Value));
            //        lstPages.Items.Remove(lstPages.Items[i]);
            //    }

            //}


            for (int i = 0; i < lstPages.Items.Count; i++)
            {

                if (lstPages.Items[i].Selected)
                {
                    lstUsersPages.Items.Add(new ListItem(lstPages.Items[i].Text, lstPages.Items[i].Value));
                }

            }

            for (int i = 0; i < lstUsersPages.Items.Count; i++)
            {
                for (int x = 0; x < lstPages.Items.Count; x++)
                {
                    if (lstUsersPages.Items[i].Value == lstPages.Items[x].Value)
                    {
                        lstPages.Items.Remove(lstPages.Items[x]);

                    }
                }
            }

        }



        /////////////////////////////////////////////////////////////////




        protected async void FillDetails(int UserIDs)
        {
            int UserID = Convert.ToInt32(UserIDs);

            ResultEntity<UserEntity> Result = new ResultEntity<UserEntity>();

            Result = await UsersDomain.GetUserData(UserID);
            if (Result.Status == ErrorEnums.Success)
            {
                txtusername.Text = Result.Entity.LoginID;
                txtEmail.Text = Result.Entity.Email;
                CbStatus.Checked = Result.Entity.Status;
                CbIsDeleted.Checked = Result.Entity.IsDeleted;
                txtFirstName.Text = Result.Entity.FirstName.ToString();
                txtSecondName.Text = Result.Entity.SecondName.ToString();
                txtLastName.Text = Result.Entity.LastName.ToString();
                datepicker.Value = Result.Entity.BirthDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                ddlMartialStatus.SelectedValue = Result.Entity.MaritalStatusID.ToString();
                ddlGender.SelectedValue = Result.Entity.GenderID.ToString();
                ddlCountry.SelectedValue = Result.Entity.CountryID.ToString();
                txtTelephone.Text = Result.Entity.Telephone.ToString();
                txtEXT.Text = Result.Entity.Ext.ToString();
                txtMobile.Text = Result.Entity.Mobile.ToString();
                txtaddress.Text = Result.Entity.Address.ToString();
                txtaddress.Text = Result.Entity.Address.ToString();
                ddlDepartment.SelectedValue = Result.Entity.DepartmentID.ToString();
                ddlSection.SelectedValue = Result.Entity.SectionID.ToString();
                txtTitle.Text = Result.Entity.Title.ToString();
                datepicker2.Value = Result.Entity.HireDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                if (Result.Entity.Image != null && Result.Entity.Image != "")
                {
                    ImageUser.ImageUrl = Result.Entity.Image.ToString();
                }
                else
                {
                    ImageUser.ImageUrl = "/AppTheme/images/profilethumb.png";
                }
            }

            //

            //var Data = UsersRepository.SelectByUserID(UserID);
            //if (Data != null)
            //{
            //    


            //}
        }
        protected async void FillMartialStatus()
        {
            ddlMartialStatus.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<MartialStatusEntity> Result = new ResultList<MartialStatusEntity>();

            Result = await MartialStatusDomain.GetMartialStatus();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (MartialStatusEntity item in Result.List)
                {
                    ddlMartialStatus.Items.Add(new ListItem(item.Name.ToString(), item.MaritalStatusID.ToString()));
                }
            }
        }
        protected async void FillGender()
        {
            ddlGender.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<GenderLanguageEntity> Result = new ResultList<GenderLanguageEntity>();

            Result = await GenderLanguageDomain.GetGender();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (GenderLanguageEntity item in Result.List)
                {
                    ddlGender.Items.Add(new ListItem(item.Name.ToString(), item.GenderID.ToString()));
                }
            }

        }
        protected async void FillCountry()
        {
            ddlCountry.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<CountryLanguageEntity> Result = new ResultList<CountryLanguageEntity>();

            Result = await CountryLanguageDomain.GetCountry();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (CountryLanguageEntity item in Result.List)
                {
                    ddlCountry.Items.Add(new ListItem(item.Name.ToString(), item.CountryID.ToString()));
                }
            }

        }
        protected async void FillDepartment()
        {
            ddlDepartment.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<DepartmentLanguageEntity> Result = new ResultList<DepartmentLanguageEntity>();

            Result = await DepartmentLanguageDomain.GetDepartment();

            if (Result.Status == ErrorEnums.Success)
            {
                foreach (DepartmentLanguageEntity item in Result.List)
                {
                    ddlDepartment.Items.Add(new ListItem(item.Name.ToString(), item.DepartmentID.ToString()));
                }
            }

        }
        protected async void FillSection()
        {
            ddlSection.Items.Clear();
            ddlSection.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            ResultList<SectionLanguageEntity> Result = new ResultList<SectionLanguageEntity>();

            int DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

            if (DepartmentID == 0)
            {
                Result = await SectionLanguageDomain.GetSection();

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (SectionLanguageEntity item in Result.List)
                    {
                        ddlSection.Items.Add(new ListItem(item.Name.ToString(), item.SectionID.ToString()));
                    }
                }
            }
            else
            {
                Result = await SectionLanguageDomain.GetSectionByDepartmentID(DepartmentID);

                if (Result.Status == ErrorEnums.Success)
                {
                    foreach (SectionLanguageEntity item in Result.List)
                    {
                        ddlSection.Items.Add(new ListItem(item.Name.ToString(), item.SectionID.ToString()));
                    }
                }
            }



        }

        protected void FillUploadImage()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Siteware_File/");
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                Guid Image = Guid.NewGuid();
                FileUpload1.PostedFile.SaveAs(path + Image + FileUpload1.FileName);
                ImageUser.ImageUrl = "~/Siteware_File/" + Image + FileUpload1.FileName.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Denied02", "alert('Cannot accept files of this type')", true);
            }
        }
        protected void lnkFileUpload_Click(object sender, EventArgs e)
        {
            FillUploadImage();

        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillSection();
        }


        async void UpdateInformation(int UserIDs)
        {

            UserEntity entity = new UserEntity();

            //if (txtOldPassword.Text.Length > 0 && txtNewPassword.Text.Length > 0 && txtConfirmPassword.Text.Length > 0)
            //{

            //    int UserID = Convert.ToInt32(UserIDs.ToString());

            //    lblOldPassValidation.Visible = false;

            //    ResultEntity<UserEntity> GetData = new ResultEntity<UserEntity>();

            //    GetData = await UsersDomain.GetUserData(UserID);
            //    if (GetData.Status == ErrorEnums.Success)
            //    {
            //        string OldPassword = GetData.Entity.Passwordd;
            //        string PasswordDec = Encrypt.Encrypted(txtOldPassword.Text);

            //        if (OldPassword != PasswordDec)
            //        {
            //            lblOldPassValidation.Visible = true;
            //            return;
            //        }
            //        else
            //        {
            //            entity.UserID = Convert.ToInt32(UserIDs);
            //            entity.Passwordd = Encrypt.Encrypted(txtNewPassword.Text.ToString());

            //            var Result1 = UsersDomain.UpdateUserPassword(entity);
            //        }
            //    }
            //}

            entity.UserID = Convert.ToInt32(UserIDs);
            entity.LoginID = txtusername.Text.ToString();
            entity.CountryID = Convert.ToByte(ddlCountry.SelectedValue.ToString());
            entity.Image = ImageUser.ImageUrl.ToString();
            entity.FirstName = txtFirstName.Text.ToString();
            entity.SecondName = txtSecondName.Text.ToString();
            entity.LastName = txtLastName.Text.ToString();
            entity.Email = txtEmail.Text.ToString();
            entity.BirthDate = DateTime.ParseExact(datepicker.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            entity.MaritalStatusID = Convert.ToByte(ddlMartialStatus.SelectedValue.ToString());
            entity.GenderID = Convert.ToByte(ddlGender.SelectedValue.ToString());
            entity.DepartmentID = Convert.ToByte(ddlDepartment.SelectedValue.ToString());
            entity.SectionID = Convert.ToByte(ddlSection.SelectedValue.ToString());
            entity.Title = txtTitle.Text.ToString();
            entity.Telephone = txtTelephone.Text.ToString();
            entity.Ext = txtEXT.Text.ToString();
            entity.Mobile = txtMobile.Text.ToString();
            entity.HireDate = DateTime.ParseExact(datepicker2.Value.ToString(),"MM/dd/yyyy",CultureInfo.InvariantCulture);
            entity.Status = CbStatus.Checked;
            entity.IsDeleted = CbIsDeleted.Checked;
            entity.Address = txtaddress.Text.ToString();
            entity.EditDate = Convert.ToDateTime(DateTime.Now);
            entity.EditUser = SessionManager.GetInstance.Users.UserID.ToString();

            var Result = await UsersDomain.UpdateUserData(entity);
            if (Result.Status == ErrorEnums.Success)
            {
                mpeSuccess.Show();
            }
        }


        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (Result.Status == ErrorEnums.Success)
            //{
            //    mpeSuccess.Show();
            //}

        }


        protected async void btnRestPass_Click(object sender, EventArgs e)
        {
            ResultEntity<UserEntity> GetData = new ResultEntity<UserEntity>();
            UserEntity entity = new UserEntity();

            GetData = await UsersDomain.GetUserData(Convert.ToInt32(ViewState["ManageUserIDViewState"].ToString()));
            if (GetData.Status == ErrorEnums.Success)
            {
                entity.UserID = Convert.ToInt32(Convert.ToInt32(ViewState["ManageUserIDViewState"].ToString()));
                entity.Passwordd = Encrypt.Encrypted(GetData.Entity.LoginID.ToString());

                var Result1 = UsersDomain.UpdateUserPassword(entity);
            }
            //else
            //{
           
            //}
            //}
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Security/ManageUser.aspx", false);

        }


    }


}