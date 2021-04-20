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
    public static class PluginLogoDomain
    {

        public async static Task<ResultList<PluginLogoEntity>> GetPluginLogoAll()
        {
            ResultList<PluginLogoEntity> result = new ResultList<PluginLogoEntity>();

            result = await PluginLogoRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginLogoEntity> GetPluginLogoAllNotAsync()
        {
            ResultList<PluginLogoEntity> result = new ResultList<PluginLogoEntity>();

            result = PluginLogoRepository.SelectAllNotAsync();

            return result;
        } 
        public async static Task<ResultEntity<PluginLogoEntity>> UpdateLogo(PluginLogoEntity entity)
        {
            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            result = await PluginLogoRepository.Plugin_Logo_Update(entity);

          
            return result;
        }
        public async static Task<ResultEntity<PluginLogoEntity>> GetPluginContactByID(int ID)
        {
            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            result = await PluginLogoRepository.Plugin_Logo_SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<PluginLogoEntity>> InsertLogo(PluginLogoEntity entity)
        {
            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            result = await PluginLogoRepository.InsertLogo(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginLogoEntity>> DeleteLogo(int ID)
        {
            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            result = await PluginLogoRepository.DeleteLogo(ID);

            return result;
        }
    }
}
