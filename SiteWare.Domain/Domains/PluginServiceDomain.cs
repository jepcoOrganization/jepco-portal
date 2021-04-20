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
    public static class PluginServiceDomain
    {
        public async static Task<ResultEntity<PluginServiceEntity>> GetDataPointByID(int ID)
        {
            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            result = await PluginServiceRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultList<PluginServiceEntity>> GetDataPointAll()
        {
            ResultList<PluginServiceEntity> result = new ResultList<PluginServiceEntity>();

            result = await PluginServiceRepository.SelectAll();

            return result;
        }

        public static ResultList<PluginServiceEntity> GetDataPointAllNotAsync()
        {
            ResultList<PluginServiceEntity> result = new ResultList<PluginServiceEntity>();

            result = PluginServiceRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<PluginServiceEntity>> UpdateDataPoint(PluginServiceEntity entity)
        {
            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            result = await PluginServiceRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceEntity>> UpdateDataPointByIsDeleted(PluginServiceEntity entity)
        {
            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            result = await PluginServiceRepository.UpdateByIsDeleted(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceEntity>> InsertDataPoint(PluginServiceEntity entity)
        {
            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            result = await PluginServiceRepository.Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceEntity>> DeleteDataPoint(PluginServiceEntity entity)
        {
            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            result = await PluginServiceRepository.Delete(entity);

            return result;
        }

    }
}
