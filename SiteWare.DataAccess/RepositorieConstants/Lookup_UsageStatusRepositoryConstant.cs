using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_UsageStatusRepositoryConstant
    {
        public const string UsageStatusID = CommonRepositoryConstants.PreSQLParameter + Lookup_UsageStatusEntityConstant.UsageStatusID;
        public const string UsageStatus = CommonRepositoryConstants.PreSQLParameter + Lookup_UsageStatusEntityConstant.UsageStatus;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_UsageStatusEntityConstant.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_UsageStatusEntityConstant.IsDeleted;

        public const string SP_SelectAll = "Lookup_UsageStatus_SelectAll";
    }
}
