using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class CMS_PropertyKeywordRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.ID;
        public const string PropertyID = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.PropertyID;
        public const string Keyword = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.Keyword;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + CMS_PropertyKeywordEntityConstants.EditUser;

        public const string SP_Insert = "CMS_PropertyKeyword_Insert";
        public const string SP_Update = "CMS_PropertyKeyword_Update";
        public const string SP_Delete = "CMS_PropertyKeyword_Delete";
        public const string SP_SelectAll = "CMS_PropertyKeyword_SelectAll";
        public const string SP_DeleteByPropertyID = "CMS_PropertyKeyword_DeleteByPropertyID";
        public const string SP_Keywordlistbykeywords = "Plugin_Property_Keywords";
        public const string SP_CMS_Property_SelectInnerJoinByPropertyID = "CMS_Property_SelectInnerJoinByPropertyID";
    }
}
