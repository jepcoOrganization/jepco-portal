using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PluginServiceTabRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.ID;        
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.Image;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.Title;        
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.LanguageName;
        public const string Image2 = CommonRepositoryConstants.PreSQLParameter + PluginServiceTabEntityConstants.Image2;
        
        public const string SP_Insert = "Plugin_ServiceTab_Insert";
        public const string SP_Update = "Plugin_ServiceTab_Update";
        public const string SP_Delete = "Plugin_ServiceTab_Delete";
        public const string SP_SelectAll = "Plugin_ServiceTab_SelectAll";
        public const string SP_SelectByID = "Plugin_ServiceTab_SelectByID";
        public const string SP_UpdateByIsDeleted = "Plugin_ServiceTab_UpdateByIsDeleted";
    }
}
