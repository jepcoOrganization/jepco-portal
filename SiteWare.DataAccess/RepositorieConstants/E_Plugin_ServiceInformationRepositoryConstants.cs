using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class E_Plugin_ServiceInformationRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.ID;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Description;
        public const string Time = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Time;
        public const string Fees = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Fees;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Target;

        public const string UserTypeID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.UserTypeID;
        public const string ServiceTypeID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.ServiceTypeID;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_ServiceInformationEntityConstants.LanguageName;


        public const string SP_Insert = "E_Plugin_ServiceInformation_Insert";
        public const string SP_Update = "E_Plugin_ServiceInformation_Update";
        public const string SP_Delete = "E_Plugin_ServiceInformation_Delete";
        public const string SP_SelectAll = "E_Plugin_ServiceInformation_SelectAll";
        public const string SP_SelectByID = "E_Plugin_ServiceInformation_SelectByID";
        public const string SP_SelectByEServiceID = "E_Plugin_ServiceInformation_SelectByServiceTypeID";
        public const string SP_SelectByUserTypeID = "E_Plugin_ServiceInformation_SelectByUserTypeID";


    }
}
