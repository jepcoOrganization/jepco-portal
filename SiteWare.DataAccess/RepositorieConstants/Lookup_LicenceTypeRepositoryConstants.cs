using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_LicenceTypeRepositoryConstants
    {
        public const string LicenceTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.LicenceTypeID;
        public const string LicenceTypeName = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.LicenceTypeName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceTypeEntityConstants.EditUser;

        public const string SelectALL = "Lookup_LicenceType_SelectAll";
        public const string SelectByID = "Lookup_LicenceType_SelectByID";
    }
}
