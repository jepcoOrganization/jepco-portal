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
   public class Plugin_PriceDomain
    {
        public async static Task<ResultList<Plugin_PriceEntity>> GetAll()
        {
            ResultList<Plugin_PriceEntity> result = new ResultList<Plugin_PriceEntity>();

            result = await Plugin_PriceRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_PriceEntity> GetAllNotAsync()
        {
            ResultList<Plugin_PriceEntity> result = new ResultList<Plugin_PriceEntity>();

            result = Plugin_PriceRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_PriceEntity>> GetByID(long PriceID)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = await Plugin_PriceRepository.SelectByID(PriceID);

            return result;
        }
        public static ResultEntity<Plugin_PriceEntity> GetByIDNotAsync(long PriceID)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = Plugin_PriceRepository.SelectByIDNotAsync(PriceID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_PriceEntity>> Update(Plugin_PriceEntity entity)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = await Plugin_PriceRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_PriceEntity> UpdateNotAsync(Plugin_PriceEntity entity)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = Plugin_PriceRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_PriceEntity>> Delete(long PriceID)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = await Plugin_PriceRepository.Delete(PriceID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PriceEntity>> Insert(Plugin_PriceEntity entity)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = await Plugin_PriceRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_PriceEntity> InsertNotAsync(Plugin_PriceEntity entity)
        {
            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            result = Plugin_PriceRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
