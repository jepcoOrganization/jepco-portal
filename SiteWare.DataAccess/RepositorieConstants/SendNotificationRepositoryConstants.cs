using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class SendNotificationRepositoryConstants
    {
        public const string SendNotificationID = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.SendNotificationID;
        public const string DeviceID = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.DeviceID;
        public const string NotificationType = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.NotificationType;
        public const string NotificationID = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.NotificationID;
        public const string Notification = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.Notification;
        public const string IoSnotificationResult = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.IoSnotificationResult;
        public const string AndroidnotificationResult = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.AndroidnotificationResult;
        public const string DateGenerated = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.DateGenerated;
        public const string DateGeneratedDate = CommonRepositoryConstants.PreSQLParameter + SendNotificationEntityConstants.DateGeneratedDate;

        public const string SP_Insert = "SendNotification_Insert";
        public const string SP_SelectAll = "SendNotification_SelectAll";
    }
}
