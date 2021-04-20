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
    public class RenwableEnergyType3Phase2DetailsAttechmentDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = await RenwableEnergyType3Phase2DetailsAttechmentRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = RenwableEnergyType3Phase2DetailsAttechmentRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = await RenwableEnergyType3Phase2DetailsAttechmentRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = RenwableEnergyType3Phase2DetailsAttechmentRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>> InsertRecord(RenwableEnergyType3Phase2DetailsAttechmentEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = await RenwableEnergyType3Phase2DetailsAttechmentRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> InsertRecordNotAsync(RenwableEnergyType3Phase2DetailsAttechmentEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            result = RenwableEnergyType3Phase2DetailsAttechmentRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
