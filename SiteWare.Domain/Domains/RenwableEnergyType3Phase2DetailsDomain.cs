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
    public class RenwableEnergyType3Phase2DetailsDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsEntity>();

            result = await RenwableEnergyType3Phase2DetailsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase2DetailsEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsEntity>();

            result = RenwableEnergyType3Phase2DetailsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            result = await RenwableEnergyType3Phase2DetailsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            result = RenwableEnergyType3Phase2DetailsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsEntity>> InsertRecord(RenwableEnergyType3Phase2DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            result = await RenwableEnergyType3Phase2DetailsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsEntity> InsertRecordNotAsync(RenwableEnergyType3Phase2DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            result = RenwableEnergyType3Phase2DetailsRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
