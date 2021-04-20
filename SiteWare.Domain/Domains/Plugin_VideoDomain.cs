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
   public class Plugin_VideoDomain
    {
        public async static Task<ResultList<Plugin_VideoEntity>> GetAll()
        {
            ResultList<Plugin_VideoEntity> result = new ResultList<Plugin_VideoEntity>();

            result = await Plugin_Video_Repository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_VideoEntity> GetAllNotAsync()
        {
            ResultList<Plugin_VideoEntity> result = new ResultList<Plugin_VideoEntity>();

            result = Plugin_Video_Repository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_VideoEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = await Plugin_Video_Repository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_VideoEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = Plugin_Video_Repository.SelectByIDNotAsync(ID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_VideoEntity>> Update(Plugin_VideoEntity entity)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = await Plugin_Video_Repository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_VideoEntity> UpdateNotAsync(Plugin_VideoEntity entity)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = Plugin_Video_Repository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_VideoEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = await Plugin_Video_Repository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_VideoEntity>> Insert(Plugin_VideoEntity entity)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = await Plugin_Video_Repository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_VideoEntity> InsertNotAsync(Plugin_VideoEntity entity)
        {
            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            result = Plugin_Video_Repository.InsertNotAsync(entity);

            return result;
        }

    }
}
