using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class NewsRepositoryConstants
    {
        public const string NewsID = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.NewsID;
        public const string NewsImage = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.NewsImage;
        public const string Headline = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.Headline;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.Summary;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.Description;
        public const string NewsDate = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.NewsDate;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.ViewCount;
        public const string NewsOrder = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.NewsOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.IsDeleted;
        public const string ShowInMarquee = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.ShowInMarquee;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.EditUser;
        public const string MappedNewsID1 = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.MappedNewsID1;
        public const string MappedNewsID2 = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.MappedNewsID2;
        public const string IsNotification = CommonRepositoryConstants.PreSQLParameter + NewsEntityConstants.IsNotification;
        public const string PageNumber = CommonRepositoryConstants.PreSQLParameter + "PageNumber";
        public const string PageSize = CommonRepositoryConstants.PreSQLParameter + "PageSize";

        public const string SP_Insert = "Plugin_News_Insert";
        public const string SP_Update = "Plugin_News_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_News_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_News_Delete";
        public const string SP_SelectAll = "Plugin_News_SelectAll";
        public const string SP_SelectAll_With_Pagination = "Plugin_News_SelectAll_With_Pagination";
        public const string SP_SelectByNewsID = "Plugin_News_SelectByNewsID";
        public const string SP_SelectNewsByLanguage = "Plugin_News_SelectByLanguageID";
        public const string SP_SelectByNewsIDWithLanguage = "Plugin_News_SelectByNewsIDWithLanguage";
        public const string SP_SelectTopThree = "Plugin_News_SelectTopThree";
        public const string SP_UpdateViewCount = "Plugin_News_UpdateViewCount";
        public const string SP_GetMonthYearList = "Plugin_NewsMonthYear";
    }
}
