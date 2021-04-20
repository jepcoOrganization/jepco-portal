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
    public static class User_Login_IntranetDomain
    {
        public async static Task<ResultList<User_Login_IntranetEntity>> GetUserLoginAll()
        {
            ResultList<User_Login_IntranetEntity> result = new ResultList<User_Login_IntranetEntity>();

            result = await User_Login_IntranetRepository.SelectAll();

            return result;
        }
        public static ResultList<User_Login_IntranetEntity> GetuserLoginAllNotAsync()
        {
            ResultList<User_Login_IntranetEntity> result = new ResultList<User_Login_IntranetEntity>();

            result = User_Login_IntranetRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<User_Login_IntranetEntity>> GetUserLoginByID(long ProviderID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            result = await User_Login_IntranetRepository.User_Login_SelectByID(ProviderID);

            return result;
        }

        public  static ResultEntity<User_Login_IntranetEntity> GetUserLoginByIDNotAsync(long ProviderID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            result = User_Login_IntranetRepository.User_Login_SelectByIDNotAsync(ProviderID);

            return result;
        }

        public async static Task<ResultEntity<User_Login_IntranetEntity>> InsertUser_Login(User_Login_IntranetEntity entity)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            result = await User_Login_IntranetRepository.User_Login_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<User_Login_IntranetEntity>> UpdateIsMail(long ID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            result = await User_Login_IntranetRepository.User_Login_UpdateIsMail(ID);

            return result;
        }

        public async static Task<ResultEntity<User_Login_IntranetEntity>> UpdateIsFirstlogIn(long ID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            result = await User_Login_IntranetRepository.User_Login_UpdateIsFirstLogIn(ID);

            return result;
        }
    }
}
