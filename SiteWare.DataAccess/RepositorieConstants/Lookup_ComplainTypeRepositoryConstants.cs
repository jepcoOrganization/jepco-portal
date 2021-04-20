using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Lookup_ComplainTypeRepositoryConstants
    {
        public const string ComplainTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.ComplainTypeID;
        public const string ComplainType = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.ComplainType;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ComplainTypeEntityConstants.EditUser;

        public const string SelectALL = "Lookup_ComplainType_SelectAll";
        public const string SelectByID = "Lookup_ComplainType_SelectByID";
    }
}
