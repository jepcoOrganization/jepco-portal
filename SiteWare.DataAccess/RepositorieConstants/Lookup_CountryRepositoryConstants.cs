using SiteWare.DataAccess.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Lookup_CountryRepositoryConstants
    {
        public const string CountryID = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.CountryID;
        public const string CountryName = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.CountryName;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CountryEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_Country_SelectAll";

    }
}
