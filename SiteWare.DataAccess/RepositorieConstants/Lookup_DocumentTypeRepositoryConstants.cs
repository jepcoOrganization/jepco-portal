using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Lookup_DocumentTypeRepositoryConstants
    {
        public const string DocumentTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.DocumentTypeID;
        public const string DocumentType = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.DocumentType;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_DocumentTypeEntityConstants.EditUser;

        public const string SelectALL = "Lookup_DocumentType_SelectAll";
        public const string SelectByID = "Lookup_DocumentType_SelectByID";
    }
}
