using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class MessagesAndNotificationsRepositoryConstants
    {
        public const string NotificationID = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.NotificationID;
        public const string MsgFromUserID = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.MsgFromUserID;
        public const string FromUserType = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.FromUserType;
        public const string MsgToUserID = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.MsgToUserID;
        public const string ToUserType = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.ToUserType;
        public const string Subject = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Subject;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Description;
        public const string Attachment1 = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Attachment1;
        public const string Attachment2 = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Attachment2;
        public const string Attachment3 = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Attachment3;
        public const string Attachment4 = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Attachment4;
        public const string IsRead = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.IsRead;
        public const string RequestID = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.RequestID;
        public const string RequestType = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.RequestType;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + MessagesAndNotificationsEntityConstants.EditUser;

        public const string SP_SelectByID = "MessagesAndNotifications_SelectByID";
        public const string SP_SelectAll = "MessagesAndNotifications_SelectAll";
        public const string SP_Insert = "MessagesAndNotifications_Insert";
        public const string SP_Delete = "MessagesAndNotifications_Delete";

        public const string SP_UnRead = "MessagesAndNotifications_AsUnRead";
        public const string SP_Read = "MessagesAndNotifications_AsRead";


    }
}
