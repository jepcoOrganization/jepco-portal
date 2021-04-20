using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PagesKeywordRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.ID;
        public const string PageID = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.PageID;
        public const string Keyword = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.Keyword;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PagesKeywordEntityConstants.EditUser;

        public const string SP_Insert = "CMS_PageKeyword_Insert";
        public const string SP_Update = "CMS_PageKeyword_Update";
        public const string SP_Delete = "CMS_PageKeyword_Delete";
        public const string SP_SelectAll = "CMS_PageKeyword_SelectAll";
        public const string SP_DeleteByPageID = "CMS_PageKeyword_DeleteByPageID";
        public const string SP_CMS_Page_SelectInnerJoinByPageID = "CMS_Page_SelectInnerJoinByPageID";
    }
}
