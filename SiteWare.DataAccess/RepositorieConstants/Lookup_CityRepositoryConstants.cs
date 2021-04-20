using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_CityRepositoryConstants
    {
        public const string CityID = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.CityID;

        public const string CityName = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.CityName;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CityEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_City_SelectAll";
    }
}
