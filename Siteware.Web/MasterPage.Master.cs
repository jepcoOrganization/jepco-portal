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
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;


namespace Siteware.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.Header.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users != null)
                {
                    FillUserInformation();
                    ResultList<NewsEntity> ResultNews = new ResultList<NewsEntity>();
                    ResultNews = NewsDomain.GetNewsAllNotAsync();
                    if (ResultNews.Status == ErrorEnums.Success)
                    {
                        lblNewsNumber.Text = ResultNews.List.Count().ToString();
                    }
                    if (SessionManager.GetInstance.Users.Passwordd == "q/s?qs# m lc@")
                    {
                        FillMenu_SuperAdmin();
                        ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
                        Result = PagesDomain.GetPagesAllSuperAdminNotAsync();
                        if (Result.Status == ErrorEnums.Success)
                        {
                            lblPageNumber.Text = Result.List.Count().ToString();
                        }
                    }
                    else
                    {
                        ResultList<PagesEntity> Result = new ResultList<PagesEntity>();
                        Result = PagesDomain.GetPagesAllNotAsync(SessionManager.GetInstance.Users.UserID);
                        if (Result.Status == ErrorEnums.Success)
                        {
                            lblPageNumber.Text = Result.List.Count().ToString();
                        }
                        FillMenu();
                    }
                    string menuName = hfClickMenuName.Value;
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void FillUserInformation()
        {
            int UserID = Convert.ToInt32(SessionManager.GetInstance.Users.UserID);

            ResultEntity<UserEntity> Result = new ResultEntity<UserEntity>();

            Result = UsersDomain.GetUserDataWithoutAsync(UserID);
            if (Result.Status == ErrorEnums.Success)
            {
                lblName.Text = Result.Entity.FirstName + " " + Result.Entity.LastName;
                lblUser_Email.Text = Result.Entity.Email;
                //ImageUser.ImageUrl = Result.Entity.Image;
                ImageUser.ImageUrl = "/Siteware/"+Result.Entity.Image;
            }


        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }


        void FillMenu()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_UserPlugin_SelectByUserID";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lstViewMainMenu.DataSource = dt;
                lstViewMainMenu.DataBind();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    

                    if (dt.Rows[i]["URL"].ToString() == "~/Pages/ManagePages.aspx")
                    {
                        HeaderPages.Style.Add("display", "block");

                    }

                }
            }


        }


        void FillMenu_SuperAdmin()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_UserPlugin_SelectSuperAdmin";
            cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lstViewMainMenu.DataSource = dt;
                lstViewMainMenu.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    if (dt.Rows[i]["URL"].ToString() == "~/Pages/ManagePages.aspx")
                    {
                        HeaderPages.Style.Add("display", "block");

                    }
                   
                }
            }


        }

        protected void lstViewMainMenu_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
                    ListView lstViewMainMenuSup = (ListView)e.Item.FindControl("lstViewMainMenuSup");
                    HiddenField lblPluginID = (HiddenField)e.Item.FindControl("lblPluginID");
                    HtmlControl li = (HtmlControl)e.Item.FindControl("liPlugins");

                    //li.Attributes.Add("class", "active");
                    if (lblPluginID.Value != null)
                    {

                        if (SessionManager.GetInstance.Users.Passwordd == "q/s?qs# m lc@")
                        {

                            SqlDataAdapter da = new SqlDataAdapter();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Security_UserPlugin_Select_SubSuperAdmin";
                            cmd.Connection = con;
                            //cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());
                            cmd.Parameters.AddWithValue("@ParentPluginID", lblPluginID.Value);

                            da.SelectCommand = cmd;

                            DataTable dt = new DataTable();
                          
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                //class="dropdown"
                                li.Attributes.Add("class", "dropdown");
                                DataView dv = dt.DefaultView;
                                dv.Sort = "PluginName";
                                lstViewMainMenuSup.DataSource = dv;
                                lstViewMainMenuSup.DataBind();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["URL"].ToString() == "~/Plugins/News/ManageNews.aspx")
                                    {
                                        HeaderPluginsNews.Style.Add("display", "block");

                                    }                                   
                                }
                            }
                        }
                        else
                        {

                            SqlDataAdapter da = new SqlDataAdapter();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Security_UserPlugin_SelectByUserID_Sub";
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());
                            cmd.Parameters.AddWithValue("@ParentPluginID", lblPluginID.Value);

                            da.SelectCommand = cmd;

                            DataTable dt = new DataTable();
                            
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                //class="dropdown"
                                li.Attributes.Add("class", "dropdown");
                                DataView dv = dt.DefaultView;
                                dv.Sort = "PluginName";
                                lstViewMainMenuSup.DataSource = dv;
                                lstViewMainMenuSup.DataBind();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["URL"].ToString() == "~/Plugins/News/ManageNews.aspx")
                                    {
                                        HeaderPluginsNews.Style.Add("display", "block");

                                    }                                
                                }
                            }
                        }
                    }
                    var rowView = e.Item.DataItem as DataRowView;
                    HtmlControl lli = e.Item.FindControl("liPlugins") as HtmlControl;
                    HtmlControl Ull = e.Item.FindControl("ulPlugins") as HtmlControl;

                    var hyperLink = e.Item.FindControl("linkMenu") as HyperLink;
                    hyperLink.NavigateUrl = rowView["URL"].ToString();
                    //hyperLink.CssClass = rowView["menu"].ToString();
                    string strPathe = Request.Path.ToString() + ".aspx";
                    strPathe = strPathe.Substring(9).Insert(0, "~");

                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "active");
                    }
                    else if (Session["IDSelectPage"] != null)
                    {
                        //hyperLink.NavigateUrl = Session["IDSelectPage"].ToString();
                        //hyperLink.CssClass = rowView["menu"].ToString();
                        strPathe = Session["IDSelectPage"].ToString();
                        //strPathe = strPathe.Substring(8);
                        if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                        {
                            lli.Attributes.Add("class", "active");
                            Session["IDSelectPage"] = null;
                        }
                    }

                    strPathe = Request.Path.Substring(10).Substring(0, 7);
                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "dropdown active");

                        Ull.Attributes.CssStyle.Add("display", "block");//("class", "active");
                    }

                    strPathe = Request.Path.Substring(10).Substring(0, 10);
                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "dropdown active");

                        Ull.Attributes.CssStyle.Add("display", "block");//("class", "active");
                    }

                    strPathe = Request.Path.Substring(10).Substring(0, 8);
                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "dropdown active");

                        Ull.Attributes.CssStyle.Add("display", "block");//("class", "active");
                    }

                    strPathe = Request.Path.Substring(10).Substring(0, 16).Substring(6);
                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "dropdown active");

                        Ull.Attributes.CssStyle.Add("display", "block");//("class", "active");
                    }
                    strPathe = Request.Path.Substring(4).Substring(0, 11).Substring(6);
                    if (strPathe.ToLower() == rowView["URL"].ToString().ToLower())
                    {
                        lli.Attributes.Add("class", "dropdown active");

                        Ull.Attributes.CssStyle.Add("display", "block");//("class", "active");
                    }


                    HyperLink linkMenu = (HyperLink)e.Item.FindControl("linkMenu");
                    if (!linkMenu.NavigateUrl.ToString().Contains("~/"))
                    {
                        linkMenu.NavigateUrl = "~/DashBoard.aspx";
                    }


                }
            }
            catch
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    HyperLink linkMenu = (HyperLink)e.Item.FindControl("linkMenu");
                    if (!linkMenu.NavigateUrl.ToString().Contains("~/"))
                    {
                        linkMenu.NavigateUrl = "~/DashBoard.aspx";
                    }
                }


            }
        }



    }
}