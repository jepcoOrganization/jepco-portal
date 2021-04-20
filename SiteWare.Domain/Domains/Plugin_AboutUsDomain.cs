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
    public static class Plugin_AboutUsDomain
    {

        public async static Task<ResultList<Plugin_AboutUsEntity>> GetAll()
        {
            ResultList<Plugin_AboutUsEntity> result = new ResultList<Plugin_AboutUsEntity>();

            result = await Plugin_AboutUsRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_AboutUsEntity> GetAllNotAsync()
        {
            ResultList<Plugin_AboutUsEntity> result = new ResultList<Plugin_AboutUsEntity>();

            result = Plugin_AboutUsRepository.SelectAllNotAsync();

            return result;
        } 
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> UpdateAboutUs(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            result = await Plugin_AboutUsRepository.Update(entity);

          
            return result;
        }
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> UpdateByIsDeleted(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();
            result = await Plugin_AboutUsRepository.Plugin_AboutUs_UpdateByIsDelete(entity);
            return result;
        }

        public  static ResultEntity<Plugin_AboutUsEntity> UpdateByIsDeletedNotAsync(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();
            result =  Plugin_AboutUsRepository.Plugin_AboutUs_UpdateByIsDeleteNotAsync(entity);
            return result;
        }
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> GetByID(int ID)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            result = await Plugin_AboutUsRepository.AboutUs_SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_AboutUsEntity>> InsertAboutUs(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            result = await Plugin_AboutUsRepository.Insert(entity);

            return result;
        }
    }
}
