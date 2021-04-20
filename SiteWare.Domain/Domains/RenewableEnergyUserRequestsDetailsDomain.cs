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
    public class RenewableEnergyUserRequestsDetailsDomain
    {
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsEntity>> GetAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();

            result = await RenewableEnergyUserRequestsDetailsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsDetailsEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();

            result = RenewableEnergyUserRequestsDetailsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            result = await RenewableEnergyUserRequestsDetailsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            result = RenewableEnergyUserRequestsDetailsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsEntity>> InsertRecord(RenewableEnergyUserRequestsDetailsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            result = await RenewableEnergyUserRequestsDetailsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsEntity> InsertRecordNotAsync(RenewableEnergyUserRequestsDetailsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            result = RenewableEnergyUserRequestsDetailsRepository.InsertNotAsync(entity);

            return result;
        }

       
    }
}
