using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_LicenceYearRepositoryConstants
    {
        public const string LicenceYearID = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.LicenceYearID;
        public const string LicenceYearName = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.LicenceYearName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_LicenceYearEntityConstants.EditUser;

        public const string SelectALL = "Lookup_LicenceYear_SelectAll";
        public const string SelectByID = "Lookup_LicenceYear_SelectByID";
    }
}
