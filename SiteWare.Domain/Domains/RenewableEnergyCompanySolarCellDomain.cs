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
   public static class RenewableEnergyCompanySolarCellDomain
    {
        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> GetAll()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = await RenewableEnergyCompanySolarCellRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyCompanySolarCellEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = RenewableEnergyCompanySolarCellRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanySolarCellEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            result = await RenewableEnergyCompanySolarCellRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanySolarCellEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            result = RenewableEnergyCompanySolarCellRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanySolarCellEntity>> InsertRecord(RenewableEnergyCompanySolarCellEntity entity)
        {
            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            result = await RenewableEnergyCompanySolarCellRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanySolarCellEntity> InsertRecordNotAsync(RenewableEnergyCompanySolarCellEntity entity)
        {
            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            result = RenewableEnergyCompanySolarCellRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> GetAllDistinctCompanyName()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = await RenewableEnergyCompanySolarCellRepository.SelectAllDistinctCompanyName();

            return result;
        }
        public static ResultList<RenewableEnergyCompanySolarCellEntity> GetAllDistinctCompanyNameNotAsync()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = RenewableEnergyCompanySolarCellRepository.SelectAllDistinctCompanyNameNotAsync();

            return result;
        }

        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> GetAllDistinctCompanyName(string CompanyNama)
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = await RenewableEnergyCompanySolarCellRepository.SelectAllByCompanyName(CompanyNama);

            return result;
        }
        public static ResultList<RenewableEnergyCompanySolarCellEntity> GetAllDistinctCompanyNameNotAsync(string CompanyNama)
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            result = RenewableEnergyCompanySolarCellRepository.SelectAllByNameNotAsync(CompanyNama);

            return result;
        }

    }
}
