using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class Plugin_FinancePerformanceRepositoryConstants
    {
        public const string FinanceID = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.FinanceID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Summary;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Image;
        public const string Title2 = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Title2;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Description;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.ParentID;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Link;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Order;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.IsPublished;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.PublishDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_FinancePerformanceEntityConstants.LanguageName;



        public const string SP_Insert = "Plugin_FinancePerformance_Insert";
        public const string SP_Update = "Plugin_FinancePerformance_Update";
        public const string SP_Delete = "Plugin_FinancePerformance_Delete";
        public const string SP_SelectAll = "Plugin_FinancePerformance_SelectAll";
        public const string SP_SelectByID = "Plugin_FinancePerformance_SelectByID";
    }
}
