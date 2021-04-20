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
    public class RenwableEnergyType3Phase1DetailsDomain
    {

        public async static Task<ResultList<RenwableEnergyType3Phase1DetailsEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase1DetailsEntity> result = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();

            result = await RenwableEnergyType3Phase1DetailsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase1DetailsEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1DetailsEntity> result = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();

            result = RenwableEnergyType3Phase1DetailsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = await RenwableEnergyType3Phase1DetailsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = RenwableEnergyType3Phase1DetailsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> InsertRecord(RenwableEnergyType3Phase1DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = await RenwableEnergyType3Phase1DetailsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> InsertRecordNotAsync(RenwableEnergyType3Phase1DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = RenwableEnergyType3Phase1DetailsRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> UpdateIsAccepted(RenwableEnergyType3Phase1DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = await RenwableEnergyType3Phase1DetailsRepository.UpdateIsAccepted(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> UpdateIsAcceptedNotAsync(RenwableEnergyType3Phase1DetailsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            result = RenwableEnergyType3Phase1DetailsRepository.UpdateIsAcceptedWithOutAsny(entity);

            return result;
        }



    }
}
