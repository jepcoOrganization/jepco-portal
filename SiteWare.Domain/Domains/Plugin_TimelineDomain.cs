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
    public class Plugin_TimelineDomain
    {

        public async static Task<ResultList<Plugin_TimelineEntity>> GetAll()
        {
            ResultList<Plugin_TimelineEntity> result = new ResultList<Plugin_TimelineEntity>();

            result = await Plugin_TimelineRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_TimelineEntity> GetAllNotAsync()
        {
            ResultList<Plugin_TimelineEntity> result = new ResultList<Plugin_TimelineEntity>();

            result = Plugin_TimelineRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_TimelineEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = await Plugin_TimelineRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_TimelineEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = Plugin_TimelineRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_TimelineEntity>> InsertRecord(Plugin_TimelineEntity entity)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = await Plugin_TimelineRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_TimelineEntity> InsertRecordNotAsync(Plugin_TimelineEntity entity)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = Plugin_TimelineRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_TimelineEntity>> UpdateRecord(Plugin_TimelineEntity entity)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = await Plugin_TimelineRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_TimelineEntity> UpdateRecordNotAsync(Plugin_TimelineEntity entity)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = Plugin_TimelineRepository.UpdateNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_TimelineEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            result = await Plugin_TimelineRepository.Delete(ID);

            return result;
        }

    }
}
