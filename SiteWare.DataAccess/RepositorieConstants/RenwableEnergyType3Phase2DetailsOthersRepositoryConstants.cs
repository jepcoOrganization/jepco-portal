using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenwableEnergyType3Phase2DetailsOthersRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.ID;
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.DetailsID;
        public const string Others = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.Others;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsOthersEntityConstants.EditUser;

        public const string SP_SelectByID = "RenwableEnergyType3Phase2DetailsOthers_SelectByID";
        public const string SP_SelectAll = "RenwableEnergyType3Phase2DetailsOthers_SelectAll";
        public const string SP_Insert = "RenwableEnergyType3Phase2DetailsOthers_Insert";
    }
}
