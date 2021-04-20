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
   public static class E_Lookup_ServiceCategoryDomain
    {
        public async static Task<ResultList<E_Lookup_ServiceCategoryEntity>> GetAll()
        {
            ResultList<E_Lookup_ServiceCategoryEntity> result = new ResultList<E_Lookup_ServiceCategoryEntity>();

            result = await E_Lookup_ServiceCategoryRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Lookup_ServiceCategoryEntity> GetAllNotAsync()
        {
            ResultList<E_Lookup_ServiceCategoryEntity> result = new ResultList<E_Lookup_ServiceCategoryEntity>();

            result = E_Lookup_ServiceCategoryRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Update(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            result = await E_Lookup_ServiceCategoryRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Lookup_ServiceCategoryEntity> UpdateNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            result = E_Lookup_ServiceCategoryRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Delete(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();
            result = await E_Lookup_ServiceCategoryRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<E_Lookup_ServiceCategoryEntity> DeleteNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();
            result = E_Lookup_ServiceCategoryRepository.DeleteNotAsync(entity);
            return result;
        }

        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> GetByID(int ID)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            result = await E_Lookup_ServiceCategoryRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Insert(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            result = await E_Lookup_ServiceCategoryRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Lookup_ServiceCategoryEntity> InsertNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {
            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            result = E_Lookup_ServiceCategoryRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
