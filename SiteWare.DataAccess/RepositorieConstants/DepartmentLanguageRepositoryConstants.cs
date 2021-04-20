using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class DepartmentLanguageRepositoryConstants
    {
        public const string DepartmentID = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.DepartmentID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.Name;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + DepartmentLanguageEntityConstants.EditUser;

        public const string SP_Insert = "DepartmentLanguage_Insert";
        public const string SP_Update = "DepartmentLanguage_Update";
        public const string SP_Delete = "DepartmentLanguage_Delete";
        public const string SP_SelectAll = "DepartmentLanguage_SelectAll";
        public const string SP_SelectAllByInnerJoin = "DepartmentLanguage_selectAllByInnerJoin";
        public const string SP_SelectByLanguageID = "DepartmentLanguage_SelectByLanguageID";
        public const string SP_SelectByDepartmentID = "DepartmentLanguage_SelectByDepartmentID";
    }
}
