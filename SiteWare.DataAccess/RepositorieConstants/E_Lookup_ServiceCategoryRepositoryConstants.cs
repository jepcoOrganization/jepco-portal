using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class E_Lookup_ServiceCategoryRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.ID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.Name;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Lookup_ServiceCategoryEntityConstants.EditUser;

        public const string SP_Insert = "E_Lookup_ServiceCategory_Insert";
        public const string SP_Update = "E_Lookup_ServiceCategory_Update";
        public const string SP_Delete = "E_Lookup_ServiceCategory_Delete";
        public const string SP_SelectAll = "E_Lookup_ServiceCategory_SelectAll";
        public const string SP_SelectByID = "E_Lookup_ServiceCategory_SelectByID";
    }
}
