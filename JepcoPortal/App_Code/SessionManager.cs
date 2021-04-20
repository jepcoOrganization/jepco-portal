using Microsoft.CSharp;
using System.Web;
using System;
using SiteWare.Entity.Entities;
public class SessionManager
{
    private const string _SiteID = "SiteNumber";

    private const string _ThemeName = "ThemeName";
    public int SiteID
    {
        get
        {
            if (HttpContext.Current.Session != null)
            {

                return Convert.ToInt32(HttpContext.Current.Session[_SiteID]);
            }
            else
            {
                return 0;
            }
           
        }
        set { HttpContext.Current.Session[_SiteID] = value; }
    }
    public  string ThemeName
    {
        get
        {
            if (HttpContext.Current.Session != null)
            { 
                return (string)HttpContext.Current.Session[_ThemeName];
            } 
            else
            {
                return null;
            }
           
        }
        set { HttpContext.Current.Session[_ThemeName] = value; }
    }
    public static SessionManager CurrentSessionManager
    {
        get { return new SessionManager(); }
    }


    #region  Date 12-06-2019 || AjayPatel || WebUSerLogin

    private const string _UserObject = "UserSessionObject";

    private static SessionManager _current = new SessionManager();

    public static SessionManager GetInstance
    {
        get
        {
            // if (_current != null)
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                return _current;
            }
            else
            {
                _current = new SessionManager();
                return _current;
            }
        }
    }

    public Plugin_ServiceUserEntity Users
    {
        get { return (Plugin_ServiceUserEntity)System.Web.HttpContext.Current.Session[_UserObject]; }
        set { HttpContext.Current.Session[_UserObject] = value; }
    }
    #endregion

}