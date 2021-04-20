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
    public static class RenwableEnergyType3Phase2DetailsOthersDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsOthersEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = await RenwableEnergyType3Phase2DetailsOthersRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase2DetailsOthersEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = RenwableEnergyType3Phase2DetailsOthersRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = await RenwableEnergyType3Phase2DetailsOthersRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = RenwableEnergyType3Phase2DetailsOthersRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>> InsertRecord(RenwableEnergyType3Phase2DetailsOthersEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = await RenwableEnergyType3Phase2DetailsOthersRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> InsertRecordNotAsync(RenwableEnergyType3Phase2DetailsOthersEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsOthersEntity>();

            result = RenwableEnergyType3Phase2DetailsOthersRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
