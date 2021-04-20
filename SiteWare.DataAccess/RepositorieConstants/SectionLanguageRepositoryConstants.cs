using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class SectionLanguageRepositoryConstants
    {
        public const string SectionID = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.SectionID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.LanguageID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.Name;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.EditUser;
        public const string DepartmentID = CommonRepositoryConstants.PreSQLParameter + SectionLanguageEntityConstants.DepartmentID;

        public const string SP_Insert = "SectionLanguage_Insert";
        public const string SP_Update = "SectionLanguage_Update";
        public const string SP_Delete = "SectionLanguage_Delete";
        public const string SP_SelectAll = "SectionLanguage_SelectAll";
        public const string SP_SelectAllByInnerJoin = "SectionLanguage_SelectAllByInnerJoin";
        public const string SP_SelectByLanguageID = "SectionLanguage_SelectByLanguageID";
        public const string SP_SelectBySectionID = "SectionLanguage_SelectBySectionID";
        public const string SP_SelectByDepartmentID = "SectionLanguage_SelectInnerJoinByDepartmentID";
    }
}
