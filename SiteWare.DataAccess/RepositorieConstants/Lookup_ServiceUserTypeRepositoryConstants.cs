using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Lookup_ServiceUserTypeRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.ID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.Name;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ServiceUserTypeEntityConstants.EditUser;
        
        public const string SP_SelectAll = "Lookup_ServiceUserType_SelectAll";
    }
}
