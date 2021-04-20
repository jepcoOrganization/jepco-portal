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
    public class RenwableEnergyType3Phase1MetersDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase1MetersDataEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultList<RenwableEnergyType3Phase1MetersDataEntity>();

            result = await RenwableEnergyType3Phase1MetersDataRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase1MetersDataEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultList<RenwableEnergyType3Phase1MetersDataEntity>();

            result = RenwableEnergyType3Phase1MetersDataRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            result = await RenwableEnergyType3Phase1MetersDataRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            result = RenwableEnergyType3Phase1MetersDataRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>> InsertRecord(RenwableEnergyType3Phase1MetersDataEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            result = await RenwableEnergyType3Phase1MetersDataRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> InsertRecordNotAsync(RenwableEnergyType3Phase1MetersDataEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            result = RenwableEnergyType3Phase1MetersDataRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
