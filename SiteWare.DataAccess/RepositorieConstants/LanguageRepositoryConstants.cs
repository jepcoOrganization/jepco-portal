using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class LanguageRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.Name; 
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.EditUser;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + LanguageEntityConstants.IsDeleted;


        public const string Language_Insert = "Language_Insert";
        public const string Language_Update = "Language_Update";
        public const string Language_Delete = "Language_Delete";
        public const string Language_SelectAll = "Language_SelectAll";
        public const string Language_SelectByID = "Language_SelectByID";
    }
}
