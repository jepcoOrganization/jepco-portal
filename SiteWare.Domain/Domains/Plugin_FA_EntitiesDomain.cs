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
    public class Plugin_FA_EntitiesDomain
    {

        public async static Task<ResultList<Plugin_FA_EntitiesEntity>> GetAll()
        {
            ResultList<Plugin_FA_EntitiesEntity> result = new ResultList<Plugin_FA_EntitiesEntity>();

            result = await Plugin_FA_EntitiesRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_FA_EntitiesEntity> GetAllNotAsync()
        {
            ResultList<Plugin_FA_EntitiesEntity> result = new ResultList<Plugin_FA_EntitiesEntity>();

            result = Plugin_FA_EntitiesRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = await Plugin_FA_EntitiesRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_FA_EntitiesEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = Plugin_FA_EntitiesRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> InsertRecord(Plugin_FA_EntitiesEntity entity)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = await Plugin_FA_EntitiesRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_FA_EntitiesEntity> InsertRecordNotAsync(Plugin_FA_EntitiesEntity entity)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = Plugin_FA_EntitiesRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> UpdateRecord(Plugin_FA_EntitiesEntity entity)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = await Plugin_FA_EntitiesRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_FA_EntitiesEntity> UpdateRecordNotAsync(Plugin_FA_EntitiesEntity entity)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = Plugin_FA_EntitiesRepository.UpdateNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            result = await Plugin_FA_EntitiesRepository.Delete(ID);

            return result;
        }
    }
}
