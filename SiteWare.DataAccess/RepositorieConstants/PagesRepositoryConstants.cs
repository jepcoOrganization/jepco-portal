using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PagesRepositoryConstants
    {
        public const string PageID = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.PageID;
        public const string AliasPath = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.AliasPath;
        public const string NamePath = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.NamePath;
        public const string LivePath = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.LivePath;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.ParentID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.LanguageID;

        public const string IsList = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.IsList;
        public const string ListLink = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.ListLink;

        public const string Image = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.Image;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.Name;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.Description;
        public const string ContentHTML = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.ContentHTML;
        public const string ContentHTML1 = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.ContentHTML1;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.IsDeleted;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.ViewCount;
        public const string SEOAttribute = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.SEOAttribute;
        public const string MetaTitle = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.MetaTitle;
        public const string MetaDescription = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.MetaDescription;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.EditUser;
        public const string MappedPage1 = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.MappedPage1;
        public const string MappedPage2 = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.MappedPage2;
        public const string MobileBanner = CommonRepositoryConstants.PreSQLParameter + PagesEntityConstants.MobileBanner;


        public const string SP_Insert = "CMS_Page_Insert";
        public const string SP_Update = "CMS_Page_Update";
        public const string SP_UpdateByIsDeleted = "CMS_Page_UpdateByIsDeleted";
        public const string SP_Delete = "CMS_Page_Delete";
        public const string SP_SelectAll = "CMS_Page_SelectAll";
        public const string SP_SelectAllSuperAdmin = "CMS_Page_SelectAll_SuperAdmin";

        public const string SP_SelectByPageID = "CMS_Page_SelectByPageID";
        public const string SP_SelectByAliasPath = "CMS_Page_SelectByAliasPath";
        public const string SP_UpdateViewCountByAliasPath = "CMS_Page_UpdateViewCountByAliasPath";

        public const string SP_Search_Page_SelectByKeyword = "Search_Page_SelectByKeyword";

        public const string SP_Search_Page_SelectByKeywordPageNo = "Search_Page_SelectByKeyword_PageNo";

    }
}
