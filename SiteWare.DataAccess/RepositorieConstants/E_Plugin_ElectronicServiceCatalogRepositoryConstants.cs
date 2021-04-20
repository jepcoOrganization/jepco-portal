using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class E_Plugin_ElectronicServiceCatalogRepositoryConstants
    {
        public const string ElectronicServiceID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.ElectronicServiceID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.Title;
        public const string ServiceType = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceType;
        public const string ServiceCategory = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceCategory;
        public const string UserType = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.UserType;
        public const string HasUserType = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.HasUserType;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ElectronicServiceCatalogEntityConstants.LanguageName;


        public const string SP_Insert = "E_Plugin_ElectronicServiceCatalog_Insert";
        public const string SP_Update = "E_Plugin_ElectronicServiceCatalog_Update";
        public const string SP_Delete = "E_Plugin_ElectronicServiceCatalog_Delete";
        public const string SP_SelectAll = "E_Plugin_ElectronicServiceCatalog_SelectAll";
        public const string SP_SelectByID = "E_Plugin_ElectronicServiceCatalog_SelectByID";

    }
}
