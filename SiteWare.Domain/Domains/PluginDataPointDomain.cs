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
    public static class PluginDataPointDomain
    {
        public async static Task<ResultEntity<PluginDataPointEntity>> GetDataPointByID(int ID)
        {
            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            result = await PluginDataPointRepository.SelectByID(ID);

            return result;
        }

        public async static Task<ResultList<PluginDataPointEntity>> GetDataPointAll()
        {
            ResultList<PluginDataPointEntity> result = new ResultList<PluginDataPointEntity>();

            result = await PluginDataPointRepository.SelectAll();

            return result;
        }

        public static ResultList<PluginDataPointEntity> GetDataPointAllNotAsync()
        {
            ResultList<PluginDataPointEntity> result = new ResultList<PluginDataPointEntity>();

            result = PluginDataPointRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<PluginDataPointEntity>> UpdateDataPoint(PluginDataPointEntity entity)
        {
            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            result = await PluginDataPointRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginDataPointEntity>> UpdateDataPointByIsDeleted(PluginDataPointEntity entity)
        {
            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            result = await PluginDataPointRepository.UpdateByIsDeleted(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginDataPointEntity>> InsertDataPoint(PluginDataPointEntity entity)
        {
            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            result = await PluginDataPointRepository.Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginDataPointEntity>> DeleteDataPoint(PluginDataPointEntity entity)
        {
            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            result = await PluginDataPointRepository.Delete(entity);

            return result;
        }

    }
}
