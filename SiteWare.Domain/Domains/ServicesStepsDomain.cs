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
    public class ServicesStepsDomain
    {
        public async static Task<ResultList<ServicesStepsEntity>> GetAll()
        {
            ResultList<ServicesStepsEntity> result = new ResultList<ServicesStepsEntity>();

            result = await ServicesStepsRepository.SelectAll();

            return result;
        }
        public static ResultList<ServicesStepsEntity> GetAllNotAsync()
        {
            ResultList<ServicesStepsEntity> result = new ResultList<ServicesStepsEntity>();

            result = ServicesStepsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<ServicesStepsEntity>> GetByID(long ID)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = await ServicesStepsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<ServicesStepsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = ServicesStepsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<ServicesStepsEntity>> InsertRecord(ServicesStepsEntity entity)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = await ServicesStepsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<ServicesStepsEntity> InsertRecordNotAsync(ServicesStepsEntity entity)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = ServicesStepsRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<ServicesStepsEntity>> GetByServiceID(string ServiceID)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = await ServicesStepsRepository.SelectByServiceID(ServiceID);

            return result;
        }
        public static ResultEntity<ServicesStepsEntity> GetByServiceIDNotAsync(string ServiceID)
        {
            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            result = ServicesStepsRepository.SelectByServiceIDNotAsync(ServiceID);

            return result;
        }

    }
}
