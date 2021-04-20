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
    public static class Plugin_ServiceProviderDomain
    {
        public static ResultList<Plugin_ServiceProviderEntity> GetServiceProviderAllNotAsync()
        {
            ResultList<Plugin_ServiceProviderEntity> result = new ResultList<Plugin_ServiceProviderEntity>();

            result = Plugin_ServiceProviderRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> GetServiceProviderByID(long ID)
        {
            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            result = await Plugin_ServiceProviderRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<Plugin_ServiceProviderEntity>> GetServiceProviderAll()
        {
            ResultList<Plugin_ServiceProviderEntity> result = new ResultList<Plugin_ServiceProviderEntity>();

            result = await Plugin_ServiceProviderRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> InsertServiceProvider(Plugin_ServiceProviderEntity entity)
        {
            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            result = await Plugin_ServiceProviderRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> Update(Plugin_ServiceProviderEntity entity)
        {
            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            result = await Plugin_ServiceProviderRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> UpdateByIsDeleted(long ProviderID)
        {
            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            result = await Plugin_ServiceProviderRepository.UpdateByIsDeleted(ProviderID);

            return result;
        }
    }
}
