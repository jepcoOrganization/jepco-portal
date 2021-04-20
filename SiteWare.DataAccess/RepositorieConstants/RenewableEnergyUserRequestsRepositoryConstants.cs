using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyUserRequestsRepositoryConstants
    {
        public const string RenwableEnergyID      = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.RenwableEnergyID     ;
        public const string UserID                = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.UserID               ;
        public const string RenwableEnergyTypeID  = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.RenwableEnergyTypeID ;
        //public const string RenewbleCompnyDevice  = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.RenewbleCompnyDevice ;
        public const string MeterStatus           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.MeterStatus          ;
        public const string ReferenceNumber       = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.ReferenceNumber      ;
        public const string CompanyID             = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.CompanyID            ;
        public const string CompanyAcceptedStatus = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.CompanyAcceptedStatus;
        public const string AcceptStatusDate      = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.AcceptStatusDate     ;
        public const string AcceptStatusUser      = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.AcceptStatusUser     ;
        public const string Attachemnt1           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Attachemnt1          ;
        public const string Attachemnt2           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Attachemnt2          ;
        public const string Attachemnt3           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Attachemnt3          ;
        public const string Attachemnt4           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Attachemnt4          ;
        public const string Order                 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Order                ;
        public const string LanguageID            = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.LanguageID           ;
        public const string PublishDate           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.PublishDate          ;
        public const string IsPublished           = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.IsPublished          ;
        public const string IsDeleted             = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.IsDeleted            ;
        public const string AddDate               = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.AddDate              ;
        public const string AddUser               = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.AddUser              ;
        public const string EditDate              = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.EditDate             ;
        public const string EditUser              = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.EditUser             ;
        public const string LanguageName          = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.LanguageName;
        public const string RefeenceType          = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.RefeenceType;

        
        public const string Attachemnt5 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.Attachemnt5;
        public const string GUID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsEntityConstants.GUID; 

        public const string SP_SelectByID = "RenewableEnergyUserRequests_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyUserRequests_SelectAll";
        public const string SP_Insert = "RenewableEnergyUserRequests_Insert";
        
        public const string Update_AfterCompanyRequest = "RenewableEnergyUserRequestsUpdate_AfterCompanyRequest";
    }
}
