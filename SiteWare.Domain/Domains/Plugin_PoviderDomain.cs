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
    public static class Plugin_PoviderDomain
    {
        public async static Task<ResultList<Plugin_ProviderEntity>> GetProviderAll()
        {
            ResultList<Plugin_ProviderEntity> result = new ResultList<Plugin_ProviderEntity>();

            result = await Plugin_ProviderRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_ProviderEntity> GetProviderAllNotAsync()
        {
            ResultList<Plugin_ProviderEntity> result = new ResultList<Plugin_ProviderEntity>();

            result = Plugin_ProviderRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProviderEntity>> UpdateNewsByIsDeleted(Plugin_ProviderEntity entity)
        {
            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            result = await Plugin_ProviderRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProviderEntity>> InsertProvider(Plugin_ProviderEntity entity)
        {
            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            result = await Plugin_ProviderRepository.InsertProvider(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_ProviderEntity>> GetPagesByProviderID(long ProviderID)
        {
            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            result = await Plugin_ProviderRepository.SelectByProviderID(ProviderID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_ProviderEntity>> UpdateProvider(Plugin_ProviderEntity entity)
        {
            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            result = await Plugin_ProviderRepository.Update(entity);

            return result;
        }
    }
}
