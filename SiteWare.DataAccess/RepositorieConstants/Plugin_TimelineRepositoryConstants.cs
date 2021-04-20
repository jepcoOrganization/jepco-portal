using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_TimelineRepositoryConstants
    {
        public const string TimelineID = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.TimelineID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.Summary;     
        public const string FocusID = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.FocusID;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.Description;
        public const string Year = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.Year;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.Order;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.IsDelete;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_TimelineEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Timeline_Insert";
        public const string SP_Update = "Plugin_Timeline_Update";
        public const string SP_Delete = "Plugin_Timeline_Delete";
        public const string SP_SelectAll = "Plugin_Timeline_SelectAll";
        public const string SP_SelectByID = "Plugin_Timeline_SelectByID";

    }
}
