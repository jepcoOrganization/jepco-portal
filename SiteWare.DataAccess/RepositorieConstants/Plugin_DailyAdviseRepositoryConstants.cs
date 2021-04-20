using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_DailyAdviseRepositoryConstants
    {
        public const string AdviseID = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.AdviseID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Summary;
        public const string DateTo = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.DateTo;
        public const string DateFrom = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.DateFrom;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Link;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Order;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.IsPublished;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.PublishDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_DailyAdviseEntityConstants.LanguageName;



        public const string SP_Insert = "Plugin_DailyAdvise_Insert";
        public const string SP_Update = "Plugin_DailyAdvise_Update";
        public const string SP_Delete = "Plugin_DailyAdvise_Delete";
        public const string SP_SelectAll = "Plugin_DailyAdvise_SelectAll";
        public const string SP_SelectByID = "Plugin_DailyAdvise_SelectByID";
    }
}
