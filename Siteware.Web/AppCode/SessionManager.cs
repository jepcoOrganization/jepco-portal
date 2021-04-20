using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteWare.Entity.Entities;

namespace Siteware.Web.AppCode
{
    public class SessionManager
    {
        private const string _UserObject = "UserSessionObject";

        private static SessionManager _current = new SessionManager();

        public static SessionManager GetInstance
        {
            get
            {
               // if (_current != null)
                if(HttpContext.Current != null && HttpContext.Current.Request != null)
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

        public UserEntity Users
        {
            get { return (UserEntity)System.Web.HttpContext.Current.Session[_UserObject]; }
            set { HttpContext.Current.Session[_UserObject] = value; }
        }
    }
}