using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class MartialStatusRepositoryConstants
    {
        public const string MaritalStatusID = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.MaritalStatusID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.Name;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + MartialStatusEntityConstatnts.EditUser;

        public const string SP_Insert = "MartialStatusLanguage_Insert";
        public const string SP_Update = "MartialStatusLanguage_Update";
        public const string SP_Delete = "MartialStatusLanguage_Delete";
        public const string SP_SelectAll = "MartialStatusLanguage_SelectAll";
        public const string SP_SelectAllByInnerJoin = "MartialStatusLanguage_SelectAllByInnerJoin";
        public const string SP_SelectByLanguageID = "MartialStatusLanguage_SelectByLanguageID";
        public const string SP_SelectByMaritalStatusID = "MartialStatusLanguage_SelectByMaritalStatusID";

    }
}
