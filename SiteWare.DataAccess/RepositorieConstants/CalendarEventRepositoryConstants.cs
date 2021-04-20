using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class CalendarEventRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.ID;
        public const string EntityID = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EntityID;
        public const string CalendarID = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.CalendarID;
        public const string EventTitle = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EventTitle;
        public const string EventDescription = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EventDescription;
        public const string EventURL = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EventURL;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.ViewCount;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.TargetID;
        public const string EventTime = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EventTime;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.EditUser;
        public const string MapEventID1 = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.MapEventID1;
        public const string MapEventID2 = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.MapEventID2;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.Summary;
        public const string IsNotification = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.IsNotification;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + CalendarEventEntityConstants.Link;

        public const string SP_Insert = "Plugin_CalendarEvents_Insert";
        public const string SP_Update = "Plugin_CalendarEvents_Update";
        public const string SP_UpdateIsDeleted = "Plugin_CalendarEvents_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_CalendarEvents_Delete";
        public const string SP_SelectAll = "Plugin_CalendarEvents_SelectAll";
        public const string SP_SelectByID = "Plugin_CalendarEvents_SelectByID";
        public const string SP_SelectByID_With_Language = "Plugin_CalendarEvents_SelectByID_With_Language";
        public const string SP_SelectByCalendarID = "Plugin_CalendarEvents_SelectByCalendarID";
        public const string SP_GetMonthYearList = "Plugin_EventMonthYear";
        public const string SP_UpdateViewCount = "Plugin_Events_UpdateViewCount";

    }
}
