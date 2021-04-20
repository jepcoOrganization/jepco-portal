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
   public static class ServicesStepsValuesDomain
    {
        public async static Task<ResultList<ServicesStepsValuesEntity>> GetAll()
        {
            ResultList<ServicesStepsValuesEntity> result = new ResultList<ServicesStepsValuesEntity>();

            result = await ServicesStepsValuesRepository.SelectAll();

            return result;
        }
        public static ResultList<ServicesStepsValuesEntity> GetAllNotAsync()
        {
            ResultList<ServicesStepsValuesEntity> result = new ResultList<ServicesStepsValuesEntity>();

            result = ServicesStepsValuesRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<ServicesStepsValuesEntity>> GetByID(long ID)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = await ServicesStepsValuesRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<ServicesStepsValuesEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = ServicesStepsValuesRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<ServicesStepsValuesEntity>> Update(ServicesStepsValuesEntity entity)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = await ServicesStepsValuesRepository.Update(entity);

            return result;
        }
        public static ResultEntity<ServicesStepsValuesEntity> UpdateNotAsync(ServicesStepsValuesEntity entity)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = ServicesStepsValuesRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<ServicesStepsValuesEntity>> Insert(ServicesStepsValuesEntity entity)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = await ServicesStepsValuesRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<ServicesStepsValuesEntity> InsertNotAsync(ServicesStepsValuesEntity entity)
        {
            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            result = ServicesStepsValuesRepository.InsertNotAsync(entity);

            return result;
        }

        
    }
}
