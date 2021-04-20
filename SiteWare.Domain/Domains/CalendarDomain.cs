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
    public static class CalendarDomain
    {
        public async static Task<ResultList<CalendarEntity>> GetCalendarAll()
        {
            ResultList<CalendarEntity> result = new ResultList<CalendarEntity>();

            result = await CalendarRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<CalendarEntity>> GetCalendarByID(int ID)
        {
            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            result = await CalendarRepository.SelectByID(ID);

            return result;
        }
        public static ResultList<CalendarEntity> GetCalendarByCalendarEvents()
        {
            ResultList<CalendarEntity> result = new ResultList<CalendarEntity>();

            result = CalendarRepository.SelectByCalendarEvents();

            return result;
        }
        public async static Task<ResultEntity<CalendarEntity>> Update(CalendarEntity entity)
        {
            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            result = await CalendarRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<CalendarEntity>> UpdateByIsDeleted(CalendarEntity entity)
        {
            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            result = await CalendarRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<CalendarEntity>> Insert(CalendarEntity entity)
        {
            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            result = await CalendarRepository.Insert(entity);

            return result;
        }
    }
}
