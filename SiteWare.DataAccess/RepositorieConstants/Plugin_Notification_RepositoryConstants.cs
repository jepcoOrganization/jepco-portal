using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_Notification_RepositoryConstants
    {
        public const string NotificationID = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.NotificationID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Summary;
        public const string DateTo = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.DateTo;
        public const string DateFrom = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.DateFrom;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Link;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Order;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.IsPublished;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.PublishDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_NotificationEntityConstants.LanguageName;

        

        public const string SP_Insert = "Plugin_Notification_Insert";
        public const string SP_Update = "Plugin_Notification_Update";
        public const string SP_Delete = "Plugin_Notification_Delete";
        public const string SP_SelectAll = "Plugin_Notification_SelectAll";
        public const string SP_SelectByID = "Plugin_Notification_SelectByID";
    }
}
