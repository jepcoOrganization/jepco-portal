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
    public static class PluginContactUsDomain
    {

        public async static Task<ResultList<PluginContactUsEntity>> GetPluginContactAll()
        {
            ResultList<PluginContactUsEntity> result = new ResultList<PluginContactUsEntity>();

            result = await PluginContactUsRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginContactUsEntity> GetPluginContactAllNotAsync()
        {
            ResultList<PluginContactUsEntity> result = new ResultList<PluginContactUsEntity>();

            result = PluginContactUsRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginContactUsEntity>> GetPluginContactByID(int ID)
        {
            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            result = await PluginContactUsRepository.Plugin_ContactUs_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginContactUsEntity>> UpdateContact(PluginContactUsEntity entity)
        {
            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            result = await PluginContactUsRepository.Plugin_ContactUs_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginContactUsEntity>> InsertContact(PluginContactUsEntity entity)
        {
            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            result = await PluginContactUsRepository.Plugin_ContactUs_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginContactUsEntity>> DeleteContact(int ID)
        {
            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            result = await PluginContactUsRepository.Plugin_ContactUs_Delete(ID);

            return result;
        }
    }
}
