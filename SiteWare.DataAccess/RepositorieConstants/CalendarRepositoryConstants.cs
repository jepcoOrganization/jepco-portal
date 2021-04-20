using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class CalendarRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.ID;
        public const string CalendarName = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.CalendarName;
        public const string EntityID = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.EntityID;
        public const string EventDate = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.EventDate;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + CalendarEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Calendar_Insert";
        public const string SP_Update = "Plugin_Calendar_Update";
        public const string SP_UpdateIsDeleted = "Plugin_Calendar_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_Calendar_Delete";
        public const string SP_SelectAll = "Plugin_Calendar_SelectAll";
        public const string SP_SelectByID = "Plugin_Calendar_SelectByID";
        public const string SP_SelectByCalendarEvents = "Plugin_Calendar_SelectByCalendarEvents";
    }
}
