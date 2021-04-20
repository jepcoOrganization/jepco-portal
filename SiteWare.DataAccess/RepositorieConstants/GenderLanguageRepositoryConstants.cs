using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class GenderLanguageRepositoryConstants
    {
        public const string GenderID = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.GenderID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.Name;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + GenderLanguageEntityConstants.EditUser;

        public const string SP_Insert = "GenderLanguage_Insert";
        public const string SP_Update = "GenderLanguage_Update";
        public const string SP_Delete = "GenderLanguage_Delete";
        public const string SP_SelectAll = "GenderLanguage_SelectAll";
        public const string SP_SelectAllByInnerJoin = "GenderLanguage_SelectAllByInnerJoin";
        public const string SP_SelectByLanguageID = "GenderLanguage_SelectByLanguageID";
        public const string SP_SelectByGenderID = "GenderLanguage_SelectByGenderID";
    }
}
