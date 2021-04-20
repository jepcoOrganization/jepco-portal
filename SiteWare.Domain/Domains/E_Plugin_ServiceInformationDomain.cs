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
   public static class E_Plugin_ServiceInformationDomain
    {
        public async static Task<ResultList<E_Plugin_ServiceInformationEntity>> GetAll()
        {
            ResultList<E_Plugin_ServiceInformationEntity> result = new ResultList<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Plugin_ServiceInformationEntity> GetAllNotAsync()
        {
            ResultList<E_Plugin_ServiceInformationEntity> result = new ResultList<E_Plugin_ServiceInformationEntity>();

            result = E_Plugin_ServiceInformationRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Update(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Plugin_ServiceInformationEntity> UpdateNotAsync(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = E_Plugin_ServiceInformationRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Delete(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();
            result = await E_Plugin_ServiceInformationRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<E_Plugin_ServiceInformationEntity> DeleteNotAsync(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();
            result = E_Plugin_ServiceInformationRepository.DeleteNotAsync(entity);
            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> GetByID(int ID)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> GetByServiceID(int ID)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.SelectByServiceTypeID(ID);

            return result;
        }

        public  static ResultEntity<E_Plugin_ServiceInformationEntity> GetByServiceIDNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result =  E_Plugin_ServiceInformationRepository.SelectByServiceTypeIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> GetByUserTypeID(int ID)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.SelectByUserTypeID(ID);

            return result;
        }

        public  static ResultEntity<E_Plugin_ServiceInformationEntity> GetByUserTypeNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result =  E_Plugin_ServiceInformationRepository.SelectByUserTypeIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Insert(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = await E_Plugin_ServiceInformationRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Plugin_ServiceInformationEntity> InsertNotAsync(E_Plugin_ServiceInformationEntity entity)
        {
            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            result = E_Plugin_ServiceInformationRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
