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
    public static class PluginPartnerDomain
    {

        public async static Task<ResultList<PluginPartnerEntity>> GetPluginpartnerAll()
        {
            ResultList<PluginPartnerEntity> result = new ResultList<PluginPartnerEntity>();

            result = await PluginPartnerRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginPartnerEntity> GetPluginPartnerAllNotAsync()
        {
            ResultList<PluginPartnerEntity> result = new ResultList<PluginPartnerEntity>();

            result = PluginPartnerRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginPartnerEntity>> GetPluginPartnerByID(int ID)
        {
            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            result = await PluginPartnerRepository.Plugin_Partner_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginPartnerEntity>> UpdatePartner(PluginPartnerEntity entity)
        {
            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            result = await PluginPartnerRepository.Plugin_Partner_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginPartnerEntity>> InsertPartner(PluginPartnerEntity entity)
        {
            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            result = await PluginPartnerRepository.Plugin_Partner_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginPartnerEntity>> DeletePartner(int ID)
        {
            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            result = await PluginPartnerRepository.Plugin_Partner_Delete(ID);

            return result;
        }
    }
}
