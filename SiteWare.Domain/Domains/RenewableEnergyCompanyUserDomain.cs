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
    public static class RenewableEnergyCompanyUserDomain
    {
        public async static Task<ResultList<RenewableEnergyCompanyUserEntity>> GetAll()
        {
            ResultList<RenewableEnergyCompanyUserEntity> result = new ResultList<RenewableEnergyCompanyUserEntity>();

            result = await RenewableEnergyCompanyUserRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyCompanyUserEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyCompanyUserEntity> result = new ResultList<RenewableEnergyCompanyUserEntity>();

            result = RenewableEnergyCompanyUserRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanyUserEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            result = await RenewableEnergyCompanyUserRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanyUserEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            result = RenewableEnergyCompanyUserRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanyUserEntity>> InsertRecord(RenewableEnergyCompanyUserEntity entity)
        {
            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            result = await RenewableEnergyCompanyUserRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanyUserEntity> InsertRecordNotAsync(RenewableEnergyCompanyUserEntity entity)
        {
            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            result = RenewableEnergyCompanyUserRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
