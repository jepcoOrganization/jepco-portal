using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class PluginProvider_ActingManager_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.ID;
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.ProviderID;
        public const string ActingManagerName = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.ActingManagerName;
        public const string ActingManagerPhoneNo = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.ActingManagerPhoneNo;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.IsDelete;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.IsPublished;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginProvider_ActingManager_EntityConstants.EditUser;

        public const string ActingManager_Insert = "Plugin_Provier_ActingManager_Insert";
        public const string ActingManager_Update = "Plugin_Provier_ActingManager_Update";
        public const string ActingManager_SelectAll = "Plugin_Provier_ActingManager_SelectAll";
        public const string SP_SelectByProviderID = "Plugin_Provier_ActingManager_SelectByProviderID";
        public const string SP_DeleteActingManager = "PluginProvider_ActingManager_Delete";
    }
}
