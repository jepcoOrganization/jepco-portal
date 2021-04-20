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
   public class PluginProvider_Partner_Domain
    {
        public async static Task<ResultList<PluginProvider_Partner_Entity>> GetPartnerAll()
        {
            ResultList<PluginProvider_Partner_Entity> result = new ResultList<PluginProvider_Partner_Entity>();

            result = await PluginProvider_Partner_Repository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> UpdateActingManager(PluginProvider_Partner_Entity entity)
        {
            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            result = await PluginProvider_Partner_Repository.Partner_Update(entity);

            return result;
        }
        public async static Task<ResultList<PluginProvider_Partner_Entity>> GetPartnerByProviderID(long ProviderID)
        {
            ResultList<PluginProvider_Partner_Entity> result = new ResultList<PluginProvider_Partner_Entity>();

            result = await PluginProvider_Partner_Repository.SelectByProviderID(ProviderID);

            return result;
        }
        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> InsertPartner(PluginProvider_Partner_Entity entity)
        {
            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            result = await PluginProvider_Partner_Repository.Partner_Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> UpdatePartnerByIsDelete(PluginProvider_Partner_Entity entity)
        {
            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            result = await PluginProvider_Partner_Repository.PartnerUpdateByIsDelete(entity);

            return result;
        }
    }
}
