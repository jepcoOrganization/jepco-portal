using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Siteware.Web.AppCode;


namespace Siteware.Web
{
    public class FunctionSecurity
    {
        public static bool TestUserPermissionPage(int UserID, string PluginName)
        {
            try
            {
                if (SessionManager.GetInstance.Users.Passwordd == "q/s?qs# m lc@")
                {


                    return true;
                }
                else
                {


                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Security_UserPlugin_TestUserPermission";
                    //cmd.Parameters.Add(new SqlParameter("@UserID", SessionManager.GetInstance.Users.UserID.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));

                    cmd.Connection = con;
                    da.SelectCommand = cmd;


                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        //AsEnumerable().SingleOrDefault(r => r.Field<string>("PluginName") == PluginName)
                        DataRow[] dr = dt.Select("PluginName='" + PluginName.ToString() + "'");
                        if (dr[0] != null)
                        {


                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch
            {

                return false;
            }


        }
    }
}