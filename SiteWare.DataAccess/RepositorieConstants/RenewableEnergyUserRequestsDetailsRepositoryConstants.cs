using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyUserRequestsDetailsRepositoryConstants
    {
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.DetailsID;
        public const string UserRequestID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.UserRequestID;
        public const string EnergyType = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.EnergyType;
        public const string EnergyTypeOther = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.EnergyTypeOther;
        public const string PowerType = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.PowerType;
        public const string CompanyUserID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.CompanyUserID;
        public const string ACPower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.ACPower;
        public const string DCPower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.DCPower;
        public const string Attachment1 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.Attachment1;
        public const string Attachment2 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.Attachment2;
        public const string Attachment3 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.Attachment3;
        public const string Attachment4 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.Attachment4;
        public const string IsAgree = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.IsAgree;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsEntityConstants.LanguageName;


        public const string SP_SelectByID = "RenewableEnergyUserRequestsDetails_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyUserRequestsDetails_SelectAll";
        public const string SP_Insert = "RenewableEnergyUserRequestsDetails_Insert";
    }
}
