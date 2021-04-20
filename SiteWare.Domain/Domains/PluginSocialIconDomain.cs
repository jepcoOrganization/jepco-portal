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
    public static class PluginSocialIconDomain
    {

        public async static Task<ResultList<PluginSocialIconEntity>> GetPluginSocialIconAll()
        {
            ResultList<PluginSocialIconEntity> result = new ResultList<PluginSocialIconEntity>();

            result = await PluginSocialIconRepository.SelectAll();

            return result;
        }
 
    
        public static ResultList<PluginSocialIconEntity> GetPluginSocialIconAllNotAsync()
        {
            ResultList<PluginSocialIconEntity> result = new ResultList<PluginSocialIconEntity>();

            result = PluginSocialIconRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginSocialIconEntity>> GetPluginSocialIconByID(int ID)
        {
            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            result = await PluginSocialIconRepository.Plugin_SocialIcons_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginSocialIconEntity>> UpdatePluginSocialIcon(PluginSocialIconEntity entity)
        {
            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            result = await PluginSocialIconRepository.Plugin_SocialIcons_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSocialIconEntity>> InsertPluginSocialIcon(PluginSocialIconEntity entity)
        {
            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            result = await PluginSocialIconRepository.Plugin_SocialIcons_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSocialIconEntity>> SocialIconType_Delete(int ID)
        {
            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            result = await PluginSocialIconRepository.Plugin_SocialIcons_Delete(ID);

            return result;
        }
    }
}
