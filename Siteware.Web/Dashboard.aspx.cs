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

namespace Siteware.Web
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (SessionManager.GetInstance.Users.Passwordd == "q/s?qs# m lc@")
                {
                    FillMenuSuperAdmin();
                }
                else
                {

                    FillMenu();
                    FillMenuSup();
                }
              
            }
        }


        void FillMenu()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_UserPlugin_SelectByUserID_DashBoard";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PluginName"].ToString()=="Pages")
                    {
                        liManagePages.Style.Add("display", "block");
                    }
                   
                    if (dt.Rows[i]["PluginName"].ToString() == "Navigation")
                    {
                        liManageNavigation.Style.Add("display", "block");

                    }

                }
                 
            }


        }


        void FillMenuSup()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_UserPlugin_SelectByUserID_DashBoard";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PluginName"].ToString() == "Banners")
                    {
                        liManageBanner.Style.Add("display", "block");

                    }
                    if (dt.Rows[i]["PluginName"].ToString() == "Marquee")
                    {
                        liManageNewsTicker.Style.Add("display", "block");

                    }

                }
                 
            }


        }


        void FillMenuSuperAdmin()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Security_UserPlugin_Select_DashBoardSuperAdmin";
            cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@UserID", SessionManager.GetInstance.Users.UserID.ToString());

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PluginName"].ToString() == "Pages")
                    {
                        liManagePages.Style.Add("display", "block");
                    }

                    if (dt.Rows[i]["PluginName"].ToString() == "Navigation")
                    {
                        liManageNavigation.Style.Add("display", "block");

                    }

                    if (dt.Rows[i]["PluginName"].ToString() == "Banners")
                    {
                        liManageBanner.Style.Add("display", "block");

                    }
                    if (dt.Rows[i]["PluginName"].ToString() == "Marquee")
                    {
                        liManageNewsTicker.Style.Add("display", "block");

                    }

                }

            }


        }


    }
}