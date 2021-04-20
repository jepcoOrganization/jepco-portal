using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyUserRequestsDetails_TokenRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.ID;
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.DetailsID;
        public const string TokenNo = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.TokenNo;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddDate;
        public const string AddYear = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddYear;
        public const string AddMonth = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddMonth;
        public const string SP_Insert = "RenewableEnergyUserRequestsDetails_Token_Insert";
        public const string SP_SelectByLastData = "RenewableEnergyUserRequestsDetails_Token_LastSelect";
        public const string SP_SelectAll = "RenewableEnergyUserRequestsDetails_Token_Select";

    }
}
