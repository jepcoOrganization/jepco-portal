using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class MobileRegistationRepositoryConstants
    {
        public const string RegistationID = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.RegistationID;
        public const string ServiceUserID = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.ServiceUserID;
        public const string MobileNumber = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.MobileNumber;
        public const string OTP = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.OTP;
        public const string IsVerify = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.IsVerify;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.AddDate;
        public const string VerifyDate = CommonRepositoryConstants.PreSQLParameter + MobileRegistationEntityConstants.VerifyDate;



        public const string Insert = "MobileRegistation_Insert";
        public const string Update = "MobileRegistation_Update";      
        public const string SelectByServiceUserID = "MobileRegistation_ServiceUserID";
        public const string SelectAll = "MobileRegistation_SelectAll";


    }
}
