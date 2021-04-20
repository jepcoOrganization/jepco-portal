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
    public class RenwableEnergyType3Phase1LocationsDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase1LocationsEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase1LocationsEntity> result = new ResultList<RenwableEnergyType3Phase1LocationsEntity>();

            result = await RenwableEnergyType3Phase1LocationsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase1LocationsEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1LocationsEntity> result = new ResultList<RenwableEnergyType3Phase1LocationsEntity>();

            result = RenwableEnergyType3Phase1LocationsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1LocationsEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            result = await RenwableEnergyType3Phase1LocationsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1LocationsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            result = RenwableEnergyType3Phase1LocationsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1LocationsEntity>> InsertRecord(RenwableEnergyType3Phase1LocationsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            result = await RenwableEnergyType3Phase1LocationsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1LocationsEntity> InsertRecordNotAsync(RenwableEnergyType3Phase1LocationsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            result = RenwableEnergyType3Phase1LocationsRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
