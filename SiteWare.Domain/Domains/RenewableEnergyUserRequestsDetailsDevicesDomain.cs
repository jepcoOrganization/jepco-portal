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
    public class RenewableEnergyUserRequestsDetailsDevicesDomain
    {
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>> GetAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = await RenewableEnergyUserRequestsDetailsDevicesRepository.SelectAll();

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> GetAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = RenewableEnergyUserRequestsDetailsDevicesRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>> GetByID(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = await RenewableEnergyUserRequestsDetailsDevicesRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = RenewableEnergyUserRequestsDetailsDevicesRepository.SelectByIDNotAsync(ID);

            return result;
        }
        public static ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> GetByUserRequestsDetailsIDNotAsync(long ID)
        {
            ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = RenewableEnergyUserRequestsDetailsDevicesRepository.SelectByUserRequestsDetailsIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>> InsertRecord(RenewableEnergyUserRequestsDetailsDevicesEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = await RenewableEnergyUserRequestsDetailsDevicesRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> InsertRecordNotAsync(RenewableEnergyUserRequestsDetailsDevicesEntity entity)
        {
            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            result = RenewableEnergyUserRequestsDetailsDevicesRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
