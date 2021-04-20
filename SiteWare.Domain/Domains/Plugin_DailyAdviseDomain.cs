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
   public class Plugin_DailyAdviseDomain
    {
        public async static Task<ResultList<Plugin_DailyAdviseEntity>> GetAll()
        {
            ResultList<Plugin_DailyAdviseEntity> result = new ResultList<Plugin_DailyAdviseEntity>();

            result = await Plugin_DailyAdviseRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_DailyAdviseEntity> GetAllNotAsync()
        {
            ResultList<Plugin_DailyAdviseEntity> result = new ResultList<Plugin_DailyAdviseEntity>();

            result = Plugin_DailyAdviseRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> GetByID(long AdviseID)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = await Plugin_DailyAdviseRepository.SelectByID(AdviseID);

            return result;
        }
        public static ResultEntity<Plugin_DailyAdviseEntity> GetByIDNotAsync(long AdviseID)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = Plugin_DailyAdviseRepository.SelectByIDNotAsync(AdviseID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Update(Plugin_DailyAdviseEntity entity)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = await Plugin_DailyAdviseRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_DailyAdviseEntity> UpdateNotAsync(Plugin_DailyAdviseEntity entity)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = Plugin_DailyAdviseRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Delete(long AdviseID)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = await Plugin_DailyAdviseRepository.Delete(AdviseID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Insert(Plugin_DailyAdviseEntity entity)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = await Plugin_DailyAdviseRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_DailyAdviseEntity> InsertNotAsync(Plugin_DailyAdviseEntity entity)
        {
            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            result = Plugin_DailyAdviseRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
