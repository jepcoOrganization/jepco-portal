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
   public class Plugin_ServiceUserDomain
    {
        public async static Task<ResultList<Plugin_ServiceUserEntity>> GetAll()
        {
            ResultList<Plugin_ServiceUserEntity> result = new ResultList<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_ServiceUserEntity> GetAllNotAsync()
        {
            ResultList<Plugin_ServiceUserEntity> result = new ResultList<Plugin_ServiceUserEntity>();

            result = Plugin_ServiceUserRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_ServiceUserEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = Plugin_ServiceUserRepository.SelectByIDNotAsync(ID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Update(Plugin_ServiceUserEntity entity)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_ServiceUserEntity> UpdateNotAsync(Plugin_ServiceUserEntity entity)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = Plugin_ServiceUserRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Insert(Plugin_ServiceUserEntity entity)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_ServiceUserEntity> InsertNotAsync(Plugin_ServiceUserEntity entity)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = Plugin_ServiceUserRepository.InsertNotAsync(entity);

            return result;
        }
        
        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> CheckUserLogin(string Email, string password)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            result = await Plugin_ServiceUserRepository.SelectByEmailAndPassword(Email, password);

            return result;
        }

    }
}
