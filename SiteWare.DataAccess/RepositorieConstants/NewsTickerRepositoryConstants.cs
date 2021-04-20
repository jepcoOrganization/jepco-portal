using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class NewsTickerRepositoryConstants
    {
        public const string NewsTickerID = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.NewsTickerID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.Name;
        public const string NewsURL = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.NewsURL;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.TargetID;
        public const string NewsOrder = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.NewsOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + NewsTickerEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_NewsTicker_Insert";
        public const string SP_Update = "Plugin_NewsTicker_Update";
        public const string SP_UpdateIsDeleted = "Plugin_NewsTicker_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_NewsTicker_Delete";
        public const string SP_SelectAll = "Plugin_NewsTicker_SelectAll";
        public const string SP_SelectByNewsTickerID = "Plugin_NewsTicker_SelectByNewsTickerID";
    }
}
