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
    public class PluginProvider_ActingManager_Domain
    {
        public async static Task<ResultList<PluginProvider_ActingManagerEntity>> GetBodyBannerAll()
        {
            ResultList<PluginProvider_ActingManagerEntity> result = new ResultList<PluginProvider_ActingManagerEntity>();

            result = await PluginProvider_ActingManager_Repository.SelectAll();

            return result;
        }

        public async static Task<ResultList<PluginProvider_ActingManagerEntity>> GetActingManagerByProviderID(long ProviderID)
        {
            ResultList<PluginProvider_ActingManagerEntity> result = new ResultList<PluginProvider_ActingManagerEntity>();

            result = await PluginProvider_ActingManager_Repository.SelectByProviderID(ProviderID);

            return result;
        }
        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> UpdateActingManager(PluginProvider_ActingManagerEntity entity)
        {
            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            result = await PluginProvider_ActingManager_Repository.ActingManager_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> UpdateActingManagerByIsDelete(PluginProvider_ActingManagerEntity entity)
        {
            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            result = await PluginProvider_ActingManager_Repository.ActingManagerUpdateByIsDelete(entity);

            return result;
        }


        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> InsertActingManager(PluginProvider_ActingManagerEntity entity)
        {
            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            result = await PluginProvider_ActingManager_Repository.ActingManager_Insert(entity);

            return result;
        }
    }
}
