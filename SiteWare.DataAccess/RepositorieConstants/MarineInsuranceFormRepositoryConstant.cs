using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class MarineInsuranceFormRepositoryConstant
    {
        public const string MarineInsuranceID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.MarineInsuranceID;
        public const string InsuranceID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.InsuranceID;
        public const string TripTypeID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.TripTypeID;
        public const string CargoType = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.CargoType;
        public const string CargoValue = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.CargoValue;
        public const string CargoSourceID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.CargoSourceID;
        public const string TransportTypeID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.TransportTypeID;
        public const string HowtoFill = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.HowtoFill;
        public const string IncotermsID = CommonRepositoryConstants.PreSQLParameter + MarineInsuranceFormEntityConstants.IncotermsID;

        public const string SP_Insert = "MarineInsuranceForm_Insert";
    }
}
