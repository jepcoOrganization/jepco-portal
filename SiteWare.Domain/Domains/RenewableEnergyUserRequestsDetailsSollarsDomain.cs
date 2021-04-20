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
    public class RenewableEnergyUserRequestsDetailsSollarsDomain
    {
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>> GetAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = await RenewableEnergyUserRequestsDetailsSollarsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = RenewableEnergyUserRequestsDetailsSollarsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = await RenewableEnergyUserRequestsDetailsSollarsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = RenewableEnergyUserRequestsDetailsSollarsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>> InsertRecord(RenewableEnergyUserRequestsDetailsSollarsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = await RenewableEnergyUserRequestsDetailsSollarsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> InsertRecordNotAsync(RenewableEnergyUserRequestsDetailsSollarsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            result = RenewableEnergyUserRequestsDetailsSollarsRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
