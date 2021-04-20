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
    public static class PluginValueDomain
    {

        public async static Task<ResultList<PluginValueEntity>> GetPluginValueAll()
        {
            ResultList<PluginValueEntity> result = new ResultList<PluginValueEntity>();

            result = await PluginValueRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginValueEntity> GetPluginValueAllNotAsync()
        {
            ResultList<PluginValueEntity> result = new ResultList<PluginValueEntity>();

            result = PluginValueRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginValueEntity>> GetPluginValueByID(int ID)
        {
            ResultEntity<PluginValueEntity> result = new ResultEntity<PluginValueEntity>();

            result = await PluginValueRepository.Plugin_Value_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginValueEntity>> UpdateValue(PluginValueEntity entity)
        {
            ResultEntity<PluginValueEntity> result = new ResultEntity<PluginValueEntity>();

            result = await PluginValueRepository.Plugin_Value_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginValueEntity>> InsertValue(PluginValueEntity entity)
        {
            ResultEntity<PluginValueEntity> result = new ResultEntity<PluginValueEntity>();

            result = await PluginValueRepository.Plugin_Value_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginValueEntity>> DeleteValue(int ID)
        {
            ResultEntity<PluginValueEntity> result = new ResultEntity<PluginValueEntity>();

            result = await PluginValueRepository.Plugin_Value_Delete(ID);

            return result;
        }
    }
}
