using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static  class RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.ID;
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.DetailsID;
        public const string SollarCellID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellID;
        public const string SollarCellName = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellName;
        public const string SollarCellPower = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellPower;
        public const string SollarCellDocument = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellDocument;
        public const string NumberofUnits = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.NumberofUnits;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsSollarsEntityConstants.EditUser;

        public const string SP_SelectByID = "RenwableEnergyType3Phase2DetailsSollars_SelectByID";
        public const string SP_SelectAll = "RenwableEnergyType3Phase2DetailsSollars_SelectAll";
        public const string SP_Insert = "RenwableEnergyType3Phase2DetailsSollars_Insert";
    }
}
