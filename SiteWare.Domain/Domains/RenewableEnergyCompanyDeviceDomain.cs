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
    public class RenewableEnergyCompanyDeviceDomain
    {
        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> GetAll()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = await RenewableEnergyCompanyDeviceRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyCompanyDeviceEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = RenewableEnergyCompanyDeviceRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanyDeviceEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            result = await RenewableEnergyCompanyDeviceRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanyDeviceEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            result = RenewableEnergyCompanyDeviceRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyCompanyDeviceEntity>> InsertRecord(RenewableEnergyCompanyDeviceEntity entity)
        {
            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            result = await RenewableEnergyCompanyDeviceRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyCompanyDeviceEntity> InsertRecordNotAsync(RenewableEnergyCompanyDeviceEntity entity)
        {
            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            result = RenewableEnergyCompanyDeviceRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> GetAllDistinctCompanyName()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = await RenewableEnergyCompanyDeviceRepository.SelectAllDistinctCompanyName();

            return result;
        }
        public static ResultList<RenewableEnergyCompanyDeviceEntity> GetAllDistinctCompanyNameNotAsync()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = RenewableEnergyCompanyDeviceRepository.SelectAllDistinctCompanyNameNotAsync();

            return result;
        }

        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> GetAllDistinctCompanyName(string CompanyNama)
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = await RenewableEnergyCompanyDeviceRepository.SelectAllByCompanyName(CompanyNama);

            return result;
        }
        public static ResultList<RenewableEnergyCompanyDeviceEntity> GetAllDistinctCompanyNameNotAsync(string CompanyNama)
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            result = RenewableEnergyCompanyDeviceRepository.SelectAllByNameNotAsync(CompanyNama);

            return result;
        }
    }
}
