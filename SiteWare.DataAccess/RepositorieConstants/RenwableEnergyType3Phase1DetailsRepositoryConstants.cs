using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenwableEnergyType3Phase1DetailsRepositoryConstants
    {
        public const string Type3Phase1DetailsID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.Type3Phase1DetailsID;
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.DetailsID;
        public const string IsApproved = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.IsApproved;
        public const string ApprovedDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.ApprovedDate;
        public const string TotalPower = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.TotalPower;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase1DetailsEntityConstants.EditUser;

        public const string SP_SelectByID = "RenwableEnergyType3Phase1Details_SelectByID";
        public const string SP_SelectAll = "RenwableEnergyType3Phase1Details_SelectAll";
        public const string SP_Insert = "RenwableEnergyType3Phase1Details_Insert";
        public const string SP_UpadateIsAcceted  = "RenwableEnergyType3Phase1Details_UpdateISAccepter";
        


    }
}
