using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_AreaRepositoryConstants
    {


        public const string AreaID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.AreaID;
        public const string GovernateID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.GovernateID;
        public const string AreaName = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.AreaName;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_Area_SelectAll";
        public const string SP_SelectByGovID = "Lookup_Area_SelectByGovernateID";

    }
}
