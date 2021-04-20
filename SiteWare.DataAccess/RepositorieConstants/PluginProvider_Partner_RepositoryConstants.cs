using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class PluginProvider_Partner_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.ID;
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.ProviderID;
        public const string PartnerName = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.PartnerName;
        public const string PartnerPhoneNo = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.PartnerPhoneNo;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.IsDelete;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.IsPublished;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginProvider_Partner_EntityConstants.EditUser;

        public const string Partner_Insert = "Plugin_Provier_Partner_Insert";
        public const string Partner_Update = "Plugin_Provier_Partner_Update";
        public const string Partner_SelectAll = "Plugin_Provier_Partner_SelectAll";
        public const string SP_SelectByProviderID = "Plugin_Provier_Partner_GetByProviderID";
        public const string SP_DeleteActingManager = "PluginProvider_Partner_Delete";
    }
}
