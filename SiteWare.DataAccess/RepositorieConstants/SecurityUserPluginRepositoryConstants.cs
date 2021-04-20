using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class SecurityUserPluginRepositoryConstants
    {
        public const string UserID = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.UserID;
        public const string PluginID = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.PluginID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + SecurityUserPluginEntityConstants.EditUser;

        public const string SP_Insert = "Security_UserPlugin_Insert";
        //public const string SP_Update = "User_Update";
        public const string SP_Delete = "Security_UserPlugin_Delete";
        public const string SP_DeleteAll = "Security_UserPlugin_DeleteAllForUser";

        //public const string SP_SelectAll = "User_SelectAll";
        //public const string SP_SelectByUserID = "Security_UserPlugin_SelectAllByUserID";
        //public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
