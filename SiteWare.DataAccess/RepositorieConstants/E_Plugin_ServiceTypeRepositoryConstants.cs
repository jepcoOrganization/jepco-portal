using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class E_Plugin_ServiceTypeRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.ID;
        public const string ServiceName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.ServiceName;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.ParentID;
        public const string EServiceID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.EServiceID;
        public const string HasUserType = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.HasUserType;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceTypeEntityConstants.LanguageName;


        public const string SP_Insert = "E_Lookup_ServiceType_Insert";
        public const string SP_Update = "E_Lookup_ServiceType_Update";
        public const string SP_Delete = "E_Lookup_ServiceType_Delete";
        public const string SP_SelectAll = "E_Lookup_ServiceType_SelectAll";
        public const string SP_SelectByID = "E_Lookup_ServiceType_SelectByID";
        public const string SP_SelectByEServiceID = "E_Lookup_ServiceType_SelectByEServiceID";
        public const string SP_SelectByParentID = "E_Lookup_ServiceType_SelectByParentID";
        public const string SP_SelectByParentMenu = "E_Lookup_ServiceType_SelectByParentMenu";


    }
}
