using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginLogoRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.Image;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.LanguageID;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.URL; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.EditUser;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.PublishedDate;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginLogoEntityConstants.Order;

        public const string SP_Insert = "Plugin_Logo_Insert";
        public const string SP_Update = "Plugin_Logo_Update";
        public const string SP_SelectAll = "Plugin_Logo_SelectAll";
        public const string SP_SelectByID = "Plugin_Logo_SelectByID";
        public const string SP_Delete = "Plugin_Logo_Delete";
    }
}
