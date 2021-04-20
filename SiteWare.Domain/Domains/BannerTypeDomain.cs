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
    public static class BannerTypeDomain
    {

        public async static Task<ResultList<BannerTypeEntity>> GetBodyBannerAll()
        {
            ResultList<BannerTypeEntity> result = new ResultList<BannerTypeEntity>();

            result = await BannerTypeRepository.SelectAll();

            return result;
        }
        public static ResultList<BannerTypeEntity> GetBodyBannerAllNotAsync()
        {
            ResultList<BannerTypeEntity> result = new ResultList<BannerTypeEntity>();

            result = BannerTypeRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<BannerTypeEntity>> GetBodyBannerByID(int ID)
        {
            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            result = await BannerTypeRepository.BannerType_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<BannerTypeEntity>> UpdateBodyBanner(BannerTypeEntity entity)
        {
            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            result = await BannerTypeRepository.BannerType_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<BannerTypeEntity>> InsertBodyBanner(BannerTypeEntity entity)
        {
            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            result = await BannerTypeRepository.BannerType_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<BannerTypeEntity>> DeleteBodyBanner(int ID)
        {
            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            result = await BannerTypeRepository.BannerType_Delete(ID);

            return result;
        }
    }
}
