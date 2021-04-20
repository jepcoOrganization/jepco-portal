using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class LastLoginTimeRepositoryConstants
    {
        public const string LoginId = CommonRepositoryConstants.PreSQLParameter + LastLoginTimeEntityConstants.LoginId;
        public const string ServiceUserID = CommonRepositoryConstants.PreSQLParameter + LastLoginTimeEntityConstants.ServiceUserID;
       
        public const string LastLoginTime = CommonRepositoryConstants.PreSQLParameter + LastLoginTimeEntityConstants.LastLoginTime;
       


        public const string GetLastLogin = "GetLastLogin";
        public const string UpadateLastLogin = "UpadateLastLogin";
        public const string InsertLastLogin = "InsertLastLogin";


    }
}
