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
    public static class PluginServiceTabDomain
    {
        public async static Task<ResultEntity<PluginServiceTabEntity>> GetDataPointByID(int ID)
        {
            ResultEntity<PluginServiceTabEntity> result = new ResultEntity<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultList<PluginServiceTabEntity>> GetDataPointAll()
        {
            ResultList<PluginServiceTabEntity> result = new ResultList<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.SelectAll();

            return result;
        }

        public static ResultList<PluginServiceTabEntity> GetDataPointAllNotAsync()
        {
            ResultList<PluginServiceTabEntity> result = new ResultList<PluginServiceTabEntity>();

            result = PluginServiceTabRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<PluginServiceTabEntity>> UpdateDataPoint(PluginServiceTabEntity entity)
        {
            ResultEntity<PluginServiceTabEntity> result = new ResultEntity<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceTabEntity>> UpdateDataPointByIsDeleted(PluginServiceTabEntity entity)
        {
            ResultEntity<PluginServiceTabEntity> result = new ResultEntity<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.UpdateByIsDeleted(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceTabEntity>> InsertDataPoint(PluginServiceTabEntity entity)
        {
            ResultEntity<PluginServiceTabEntity> result = new ResultEntity<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginServiceTabEntity>> DeleteDataPoint(PluginServiceTabEntity entity)
        {
            ResultEntity<PluginServiceTabEntity> result = new ResultEntity<PluginServiceTabEntity>();

            result = await PluginServiceTabRepository.Delete(entity);

            return result;
        }

    }
}
