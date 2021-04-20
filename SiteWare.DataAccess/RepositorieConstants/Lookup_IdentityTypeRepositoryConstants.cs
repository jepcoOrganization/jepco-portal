using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Lookup_IdentityTypeRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.ID;
        public const string IDType = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.IDType;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_IdentityTypeEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_IdentityType_SelectAll";
        public const string SP_Insert = "Lookup_IdentityType_Insert";
        public const string SP_Update = "Lookup_IdentityType_Update";
        public const string sp_delete = "Lookup_IdentityType_Delete";
        public const string SP_SelectByID = "Lookup_IdentityType_SelectByID";
    }
}
