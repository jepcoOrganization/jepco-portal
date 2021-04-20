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
   public static class E_Plugin_UserTypeDomain
    {
        public async static Task<ResultList<E_Plugin_UserTypeEntity>> GetAll()
        {
            ResultList<E_Plugin_UserTypeEntity> result = new ResultList<E_Plugin_UserTypeEntity>();

            result = await E_Plugin_UserTypeRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Plugin_UserTypeEntity> GetAllNotAsync()
        {
            ResultList<E_Plugin_UserTypeEntity> result = new ResultList<E_Plugin_UserTypeEntity>();

            result = E_Plugin_UserTypeRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Update(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            result = await E_Plugin_UserTypeRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Plugin_UserTypeEntity> UpdateNotAsync(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            result = E_Plugin_UserTypeRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Delete(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();
            result = await E_Plugin_UserTypeRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<E_Plugin_UserTypeEntity> DeleteNotAsync(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();
            result = E_Plugin_UserTypeRepository.DeleteNotAsync(entity);
            return result;
        }

        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> GetByID(int ID)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            result = await E_Plugin_UserTypeRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Insert(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            result = await E_Plugin_UserTypeRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Plugin_UserTypeEntity> InsertNotAsync(E_Plugin_UserTypeEntity entity)
        {
            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            result = E_Plugin_UserTypeRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
