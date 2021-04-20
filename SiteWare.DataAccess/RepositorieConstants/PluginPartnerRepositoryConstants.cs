using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginPartnerRepositoryConstants
    {   
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.Summary;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.Image; 
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.LanguageID;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.URL; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.EditUser;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.Target;       
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.LanguageName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.Order;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.IsPublished;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.PublishDate;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + PluginPartnerEntityConstants.ParentID;

        public const string SP_Insert = "Plugin_Partner_Insert";
        public const string SP_Update = "Plugin_Partner_Update";
        public const string SP_Delete = "Plugin_Partner_Delete";
        public const string SP_SelectAll = "Plugin_Partner_SelectAll";
        public const string SP_SelectByID = "Plugin_Partner_SelectByID";

       // public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
