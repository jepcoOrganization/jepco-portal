using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_Provider_RegionRepositoryConstant
    {
        public const string RegionID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.RegionID;
        public const string GovernateID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.GovernateID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.Name;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_RegionEntityConstants.EditUser;

        //public const string SP_Insert = "Plugin_Provider_SubCategory_Insert";
        //public const string SP_Update = "Plugin_Provider_SubCategory_Update";
        //public const string SP_Delete = "Plugin_Provider_SubCategory_DELETE";
        public const string SP_SelectAll = "Plugin_Provider_Region_SelectAll";
       // public const string SP_SelectByID = "Plugin_Provider_SubCategory_SelectByID";
    }
}
