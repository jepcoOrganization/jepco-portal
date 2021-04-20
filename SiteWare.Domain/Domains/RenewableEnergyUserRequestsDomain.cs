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
    public class RenewableEnergyUserRequestsDomain
    {

        public async static Task<ResultList<RenewableEnergyUserRequestsEntity>> GetAll()
        {
            ResultList<RenewableEnergyUserRequestsEntity> result = new ResultList<RenewableEnergyUserRequestsEntity>();

            result = await RenewableEnergyUserRequestsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsEntity> result = new ResultList<RenewableEnergyUserRequestsEntity>();

            result = RenewableEnergyUserRequestsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = await RenewableEnergyUserRequestsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = RenewableEnergyUserRequestsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> InsertRecord(RenewableEnergyUserRequestsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = await RenewableEnergyUserRequestsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsEntity> InsertRecordNotAsync(RenewableEnergyUserRequestsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = RenewableEnergyUserRequestsRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> UpdateAfterCompanyRequest(RenewableEnergyUserRequestsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = await RenewableEnergyUserRequestsRepository.UpdateAfterCompanyRequest(entity);

            return result;
        } 
        public static ResultEntity<RenewableEnergyUserRequestsEntity> UpdateAfterCompanyRequestNotAsync(RenewableEnergyUserRequestsEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            result = RenewableEnergyUserRequestsRepository.UpdateAfterCompanyRequestNotAsync(entity);

            return result;
        }
    }
}
