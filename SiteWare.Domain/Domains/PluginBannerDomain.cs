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
    public static class PluginBannerDomain
    {

        public async static Task<ResultList<PluginBannerEntity>> GetPluginBannerAll()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            result = await PluginBannerRepository.SelectAll();

            return result;
        }

        public async static Task<ResultList<PluginBannerEntity>> GetBannerByCategory(int CatID)
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            result = await PluginBannerRepository.SelectBannerByCategory(CatID);

            return result;
        }
        public static ResultList<PluginBannerEntity> GetBannerByCategoryAllnotAsync(int CatID)
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            result = PluginBannerRepository.SelectBannerByCategoryNotAsync(CatID);

            return result;
        }
        public async static Task<ResultList<PluginBannerEntity>> GetPluginBannerAllByBodyBannar()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            result = await PluginBannerRepository.SelectAllByBodyBannar();

            return result;
        }
        public static ResultList<PluginBannerEntity> GetPluginBannerAllNotAsync()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            result = PluginBannerRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginBannerEntity>> GetPluginBannerByID(int ID)
        {
            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            result = await PluginBannerRepository.Plugin_Banners_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginBannerEntity>> UpdatePluginBanner(PluginBannerEntity entity)
        {
            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            result = await PluginBannerRepository.Plugin_Banners_Update(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginBannerEntity>> InsertPluginBanner(PluginBannerEntity entity)
        {
            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            result = await PluginBannerRepository.Plugin_Banners_Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginBannerEntity>> BannerType_Delete(int ID)
        {
            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            result = await PluginBannerRepository.Plugin_Banners_Delete(ID);

            return result;
        }
    }
}
