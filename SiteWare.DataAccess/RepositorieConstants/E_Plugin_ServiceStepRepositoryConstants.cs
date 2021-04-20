using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class E_Plugin_ServiceStepRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.ID;
        public const string StepTitle = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.StepTitle;
        public const string UserTypeID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.UserTypeID;
        public const string ServiceTypeID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.ServiceTypeID;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceStepEntityConstants.LanguageName;


        public const string SP_Insert = "E_Plugin_ServiceStep_Insert";
        public const string SP_Update = "E_Plugin_ServiceStep_Update";
        public const string SP_Delete = "E_Plugin_ServiceStep_Delete";
        public const string SP_SelectAll = "E_Plugin_ServiceStep_SelectAll";
        public const string SP_SelectByID = "E_Plugin_ServiceStep_SelectByID";
        public const string SP_SelectByEServiceID = "E_Plugin_ServiceStep_SelectByServiceTypeID";
        public const string SP_SelectByUserTypeID = "E_Plugin_ServiceStep_SelectByUserTypeID";


    }
}
