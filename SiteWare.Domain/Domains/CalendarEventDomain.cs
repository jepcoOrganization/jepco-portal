using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Domains
{
    public static class CalendarEventDomain
    {
        public static ResultList<CalendarEventEntity> GetCalendarEventAllNotAsync()
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            result = CalendarEventRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<CalendarEventEntity>> GetCalendarEventAll()
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            result = await CalendarEventRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> GetCalendarEventByID(int ID)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> UpdateEventViewCount(CalendarEventEntity entity)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.UpdateViewCount(entity);

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> GetCalendarEventByID(int ID, byte LanguageID)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.SelectByID(ID, LanguageID);

            return result;
        }

        public async static Task<ResultList<CalendarEventEntity>> GetCalendarEventByCalendarID(int CalendarID)
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            result = await CalendarEventRepository.SelectByCalendarID(CalendarID);

            return result;
        }
        public  static ResultList<CalendarEventEntity> GetCalendarEventByCalendarIDNotAsync(int CalendarID)
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            result =  CalendarEventRepository.SelectByCalendarIDNotAsync(CalendarID);

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> Update(CalendarEventEntity entity)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> UpdateByIsDeleted(CalendarEventEntity entity)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<CalendarEventEntity>> Insert(CalendarEventEntity entity)
        {
            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            result = await CalendarEventRepository.Insert(entity);

            return result;
        }

        #region ---> EventList | Add | Simran(28062018)
        public static ResultList<Plugin_EventYearMonthEntity> GetMonthYearList(byte lang)
        {
            ResultList<Plugin_EventYearMonthEntity> result = new ResultList<Plugin_EventYearMonthEntity>();

            result = CalendarEventRepository.SelectMonthYearByLanguage(lang);

            return result;
        }
        #endregion
    }
}
