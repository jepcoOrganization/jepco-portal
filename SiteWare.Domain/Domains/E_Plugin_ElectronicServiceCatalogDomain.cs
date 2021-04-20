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
   public static class E_Plugin_ElectronicServiceCatalogDomain
    {
        public async static Task<ResultList<E_Plugin_ElectronicServiceCatalogEntity>> GetAll()
        {
            ResultList<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultList<E_Plugin_ElectronicServiceCatalogEntity>();

            result = await E_Plugin_ElectronicServiceCatalogRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Plugin_ElectronicServiceCatalogEntity> GetAllNotAsync()
        {
            ResultList<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultList<E_Plugin_ElectronicServiceCatalogEntity>();

            result = E_Plugin_ElectronicServiceCatalogRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Update(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            result = await E_Plugin_ElectronicServiceCatalogRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> UpdateNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            result =  E_Plugin_ElectronicServiceCatalogRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Delete(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();
            result = await E_Plugin_ElectronicServiceCatalogRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> DeleteNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();
            result = E_Plugin_ElectronicServiceCatalogRepository.DeleteNotAsync(entity);
            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> GetByID(int ID)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            result = await E_Plugin_ElectronicServiceCatalogRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Insert(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            result = await E_Plugin_ElectronicServiceCatalogRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> InsertNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {
            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            result = E_Plugin_ElectronicServiceCatalogRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
