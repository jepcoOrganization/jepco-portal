using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.ID;
        public const string RenewableEnergyUserRequestsDetailsID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.RenewableEnergyUserRequestsDetailsID;
        public const string SollarCellID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellID;
        public const string SollarCellName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellName;
        public const string SollarCellPower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellPower;
        public const string SollarCellDocument = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellDocument;
        public const string NumberofUnits = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.NumberofUnits;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsSollarsEntityConstants.EditUser;

        public const string SP_SelectByID = "RenewableEnergyUserRequestsDetailsSollars_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyUserRequestsDetailsSollars_SelectAll";
        public const string SP_Insert = "RenewableEnergyUserRequestsDetailsSollars_Insert";
        public const string SP_SelectByUserRequestsDetailsID = "RenewableEnergyUserRequestsDetailsSollars_SelectByUserRequestsDetailsID";

    }
}
