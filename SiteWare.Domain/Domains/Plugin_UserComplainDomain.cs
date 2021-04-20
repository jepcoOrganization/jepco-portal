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
   public static class Plugin_UserComplainDomain
    {
        public async static Task<ResultList<Plugin_UserComplainEntity>> GetAll()
        {
            ResultList<Plugin_UserComplainEntity> result = new ResultList<Plugin_UserComplainEntity>();

            result = await Plugin_UserComplainRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_UserComplainEntity> GetAllNotAsync()
        {
            ResultList<Plugin_UserComplainEntity> result = new ResultList<Plugin_UserComplainEntity>();

            result = Plugin_UserComplainRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_UserComplainEntity>> GetByID(long PersonalID)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = await Plugin_UserComplainRepository.SelectByID(PersonalID);

            return result;
        }
        public static ResultEntity<Plugin_UserComplainEntity> GetByIDNotAsync(long PersonalID)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = Plugin_UserComplainRepository.SelectByIDNotAsync(PersonalID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Update(Plugin_UserComplainEntity entity)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = await Plugin_UserComplainRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_UserComplainEntity> UpdateNotAsync(Plugin_UserComplainEntity entity)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = Plugin_UserComplainRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = await Plugin_UserComplainRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Insert(Plugin_UserComplainEntity entity)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = await Plugin_UserComplainRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_UserComplainEntity> InsertNotAsync(Plugin_UserComplainEntity entity)
        {
            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            result = Plugin_UserComplainRepository.InsertNotAsync(entity);

            return result;
        }


    }
}
