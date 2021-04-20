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
    public class RenwableEnergyType3Phase2DetailsSollarsDomain
    {

        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = await RenwableEnergyType3Phase2DetailsSollarsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = RenwableEnergyType3Phase2DetailsSollarsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = await RenwableEnergyType3Phase2DetailsSollarsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = RenwableEnergyType3Phase2DetailsSollarsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>> InsertRecord(RenwableEnergyType3Phase2DetailsSollarsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = await RenwableEnergyType3Phase2DetailsSollarsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> InsertRecordNotAsync(RenwableEnergyType3Phase2DetailsSollarsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            result = RenwableEnergyType3Phase2DetailsSollarsRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
