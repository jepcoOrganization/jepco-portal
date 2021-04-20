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
    public static class RenewableEnergyUserRequestsDetails_TokenDomain
    {
        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>> GetByLastRecord()
        {
            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = await RenewableEnergyUserRequestsDetails_TokenRepository.SelectByLastData();

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> GetByLastRecordNotAsync()
        {
            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = RenewableEnergyUserRequestsDetails_TokenRepository.SelectByLastDataNotAsync();

            return result;
        }
        
        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>> InsertRecord(RenewableEnergyUserRequestsDetails_TokenEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = await RenewableEnergyUserRequestsDetails_TokenRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> InsertRecordNotAsync(RenewableEnergyUserRequestsDetails_TokenEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = RenewableEnergyUserRequestsDetails_TokenRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>> GetAll()
        {
            ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = await RenewableEnergyUserRequestsDetails_TokenRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();

            result = RenewableEnergyUserRequestsDetails_TokenRepository.SelectAllNotAsync();

            return result;
        }
    }
}
