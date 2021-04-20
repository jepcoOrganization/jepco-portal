using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class CountryLanguageRepositoryConstants
    {
        public const string CountryID = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.CountryID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.Name;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + CountryLanguageEntityConstants.EditUser;

        public const string SP_Insert = "CountryLanguage_Insert";
        public const string SP_Update = "CountryLanguage_Update";
        public const string SP_Delete = "CountryLanguage_Delete";
        public const string SP_SelectAll = "CountryLanguage_SelectAll";
        public const string SP_SelectAllByInnerJoin = "CountryLanguage_SelectAllByInnerJoin";
        public const string SP_SelectByLanguageID = "CountryLanguage_SelectByLanguageID";
        public const string SP_SelectByMaritalStatusID = "CountryLanguage_SelectByCountryID";
    }
}
