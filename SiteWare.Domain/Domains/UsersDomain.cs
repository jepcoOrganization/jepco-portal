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
    public static class UsersDomain
    {
        public async static Task<ResultEntity<UserEntity>> CheckUserLogin(string useranme, string password)
        {
            
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = await UsersRepository.SelectByLoginIDAndPassword(useranme, password);

            return result;
        }
        
        public async static Task<ResultEntity<UserEntity>> GetUserData(int UserID)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = await UsersRepository.SelectByUserID(UserID);

            return result;
        }
        public static ResultEntity<UserEntity> GetUserDataWithoutAsync(int UserID)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = UsersRepository.SelectByUserIDWithoutAsync(UserID);

            return result;
        }
        public async static Task<ResultEntity<UserEntity>> UpdateUserData(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = await UsersRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<UserEntity>> Insert(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result =await UsersRepository.Insert(entity);

            return result;
        }


        public async static Task<ResultEntity<UserEntity>> UpdateUserPassword(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = await UsersRepository.UpdateByPassword(entity);

            return result;
        }


        public async static Task<ResultList<UserEntity>> GetUserAll()
        {
            ResultList<UserEntity> result = new ResultList<UserEntity>();

            result = await UsersRepository.SelectAll();

            return result;
        }

        public static ResultEntity<UserEntity> UpdateUserStatus(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = UsersRepository.UpdateStatus(entity);

            return result;
        }

        public static ResultEntity<UserEntity> DeleteUser(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            result = UsersRepository.Delete(entity);

            return result;
        }

    }
}
