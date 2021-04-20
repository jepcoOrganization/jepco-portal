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
    public class RenwableEnergyType3Phase2DetailsDevicesDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = await RenwableEnergyType3Phase2DetailsDevicesRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = RenwableEnergyType3Phase2DetailsDevicesRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = await RenwableEnergyType3Phase2DetailsDevicesRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = RenwableEnergyType3Phase2DetailsDevicesRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>> InsertRecord(RenwableEnergyType3Phase2DetailsDevicesEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = await RenwableEnergyType3Phase2DetailsDevicesRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> InsertRecordNotAsync(RenwableEnergyType3Phase2DetailsDevicesEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            result = RenwableEnergyType3Phase2DetailsDevicesRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
