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
   public static class E_Plugin_ServiceTypeDomain
    {
        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> GetAll()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Plugin_ServiceTypeEntity> GetAllNotAsync()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = E_Plugin_ServiceTypeRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> GetNavigationByParentID(int ParentMenuID)
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.SelectByParentID(ParentMenuID);

            return result;
        }

        public static ResultList<E_Plugin_ServiceTypeEntity> GetNavigationByParentIDNotAsync(int ParentMenuID)
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = E_Plugin_ServiceTypeRepository.SelectByParentIDNotAsync(ParentMenuID);

            return result;
        }

        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> GetByParentMenu()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.SelectByParentMenu();

            return result;
        }

        public static ResultList<E_Plugin_ServiceTypeEntity> GetByParentMenuNotAsync()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            result = E_Plugin_ServiceTypeRepository.SelectByParentMenuNotAsync();

            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Update(E_Plugin_ServiceTypeEntity entity)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Plugin_ServiceTypeEntity> UpdateNotAsync(E_Plugin_ServiceTypeEntity entity)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result = E_Plugin_ServiceTypeRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Delete(int ID)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();
            result = await E_Plugin_ServiceTypeRepository.Delete(ID);
            return result;
        }

        public static ResultEntity<E_Plugin_ServiceTypeEntity> DeleteNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();
            result = E_Plugin_ServiceTypeRepository.DeleteNotAsync(ID);
            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> GetByID(int ID)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.SelectByID(ID);

            return result;
        }
        public  static ResultEntity<E_Plugin_ServiceTypeEntity> GetByIDNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result =  E_Plugin_ServiceTypeRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Insert(E_Plugin_ServiceTypeEntity entity)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result = await E_Plugin_ServiceTypeRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Plugin_ServiceTypeEntity> InsertNotAsync(E_Plugin_ServiceTypeEntity entity)
        {
            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            result = E_Plugin_ServiceTypeRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
