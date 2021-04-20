using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PluginServiceRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ID;
        public const string ServiceName = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ServiceName;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Title;
        public const string Page = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Page;        
        public const string Color = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Color;
        public const string ShowonSlider = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ShowonSlider;
        public const string ServiceIcon = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ServiceIcon;
        //public const string ServiceType = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ServiceType;
        public const string UserMustLoggedin = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.UserMustLoggedin;
        public const string ServiceTabID = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.ServiceTabID;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Target;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.LanguageName;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Image;
        public const string Image2 = CommonRepositoryConstants.PreSQLParameter + PluginServiceEntityConstants.Image2;
        
        public const string SP_Insert = "Plugin_Service_Insert";
        public const string SP_Update = "Plugin_Service_Update";
        public const string SP_Delete = "Plugin_Service_Delete";
        public const string SP_SelectAll = "Plugin_Service_SelectAll";
        public const string SP_SelectByID = "Plugin_Service_SelectByID";
        public const string SP_UpdateByIsDeleted = "Plugin_Service_UpdateByIsDeleted";
    }
}
