using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class RenewableEnergyCompanySolarCellRepositoryConstants
    {
        public const string RenewbleCompnySolarCell = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.RenewbleCompnySolarCell;
        public const string CompanyName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.CompanyName;
        public const string ModelNo = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.ModelNo;
        public const string DevicePower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.DevicePower;
        public const string CountryOfOrigin = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.CountryOfOrigin;
        public const string SolarCellDocument = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.LanguageName;
        public const string Status = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.Status;
        public const string IsApproved = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.IsApproved;
        public const string CompanyID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.CompanyID;

        public const string SolarCellDocument2 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument2;

        public const string SP_SelectByID = "RenewableEnergyCompanySolarCell_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyCompanySolarCell_SelectAll";
        public const string SP_Insert = "RenewableEnergyCompanySolarCell_Insert";
        public const string SP_DistinctCompanyName = "SelectCompanySollerbyDistinctCompanyName";
        public const string SP_ByCompanyName = "SelectSollerByComapnyName";

    }
}
