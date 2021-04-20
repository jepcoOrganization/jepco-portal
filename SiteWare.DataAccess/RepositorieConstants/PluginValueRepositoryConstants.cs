using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginValueRepositoryConstants
    {   
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.Image; 
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.LanguageID;
        public const string Summury = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.Summury;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.URL; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.EditUser;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginValueEntityConstants.Target;


        public const string SP_Insert = "Plugin_Value_Insert";
        public const string SP_Update = "Plugin_Value_Update";
        public const string SP_Delete = "Plugin_Value_IsDelete";
        public const string SP_SelectAll = "Plugin_Value_SelectAll";
        public const string SP_SelectByID = "Plugin_Value_SelectByID";

       // public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
