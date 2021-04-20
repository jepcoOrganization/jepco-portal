using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_Provider_GovernateRepositoryConstant
    {
        public const string CountryID = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.CountryID;
        public const string GovernateID = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.GovernateID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.Name;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_GovernateEntityConstants.EditUser;

        //public const string SP_Insert = "Plugin_Provider_Category_Insert";
        //public const string SP_Update = "Plugin_Provider_Category_Update";
        //public const string SP_Delete = "Plugin_Provider_Category_Delete";
        public const string SP_SelectAll = "Plugin_Governate_SelectAll";
        public const string SP_SelectGovernatebyCountryID = "Plugin_Governate_SelectByCountryID";

        //public const string SP_SelectByID = "Plugin_Provider_Category_SelectByID";
    }
}
