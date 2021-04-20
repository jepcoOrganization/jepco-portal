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
   public static class E_Plugin_ServiceStepDomain
    {
        public async static Task<ResultList<E_Plugin_ServiceStepEntity>> GetAll()
        {
            ResultList<E_Plugin_ServiceStepEntity> result = new ResultList<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.SelectAll();

            return result;
        }
        public static ResultList<E_Plugin_ServiceStepEntity> GetAllNotAsync()
        {
            ResultList<E_Plugin_ServiceStepEntity> result = new ResultList<E_Plugin_ServiceStepEntity>();

            result = E_Plugin_ServiceStepRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> GetByServiceID(int ID)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.SelectByServiceTypeID(ID);

            return result;
        }

        public static ResultEntity<E_Plugin_ServiceStepEntity> GetByServiceIDNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = E_Plugin_ServiceStepRepository.SelectByServiceTypeIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> GetByUserTypeID(int ID)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.SelectByUserTypeID(ID);

            return result;
        }

        public static ResultEntity<E_Plugin_ServiceStepEntity> GetByUserTypeNotAsync(int ID)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = E_Plugin_ServiceStepRepository.SelectByUserTypeIDNotAsync(ID);

            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Update(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.Update(entity);


            return result;
        }

        public static ResultEntity<E_Plugin_ServiceStepEntity> UpdateNotAsync(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = E_Plugin_ServiceStepRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Delete(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();
            result = await E_Plugin_ServiceStepRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<E_Plugin_ServiceStepEntity> DeleteNotAsync(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();
            result = E_Plugin_ServiceStepRepository.DeleteNotAsync(entity);
            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> GetByID(int ID)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Insert(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = await E_Plugin_ServiceStepRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<E_Plugin_ServiceStepEntity> InsertNotAsync(E_Plugin_ServiceStepEntity entity)
        {
            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            result = E_Plugin_ServiceStepRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
