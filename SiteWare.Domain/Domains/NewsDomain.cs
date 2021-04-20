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
    public static class NewsDomain
    {
        public async static Task<ResultList<NewsEntity>> GetNewsTopThree()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            result = await NewsRepository.SelectTopThree();

            return result;
        }
        public async static Task<ResultList<NewsEntity>> GetNewsAll()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            result = await NewsRepository.SelectAll();

            return result;
        }
        public static ResultList<NewsEntity> GetNewsAllNotAsync()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            result = NewsRepository.SelectAllNotAsync();

            return result;
        }
        
        public async static Task<ResultEntity<NewsEntity>> GetPagesByNewsID(int NewsID)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.SelectByNewsID(NewsID);

            return result;
        }
        public async static Task<ResultEntity<NewsEntity>> GetPagesByNewsID(int NewsID,byte lang)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.SelectByNewsID(NewsID,lang);

            return result;
        }
        public static ResultList<NewsEntity> GetNewsByLanguage(byte lang)
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            result = NewsRepository.SelectNewsByLanguage(lang);

            return result;
        }

        public async static Task<ResultEntity<NewsEntity>> UpdateNews(NewsEntity entity)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsEntity>> UpdateNewsByIsDeleted(NewsEntity entity)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsEntity>> InsertNews(NewsEntity entity)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.InsertNews(entity);

            return result;
        }

        public async static Task<ResultEntity<NewsEntity>> DeleteNews(NewsEntity entity)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.DeleteNews(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsEntity>> UpdateNewsViewCount(int NewsID)
        {
            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            result = await NewsRepository.UpdateViewCount(NewsID);

            return result;
        }

        #region--> Get Month & Year List | Add | Jigar Patel | 27062018
        public static ResultList<Plugin_NewsYearMonthEntity> GetMonthYearList(byte lang)
        {
            ResultList<Plugin_NewsYearMonthEntity> result = new ResultList<Plugin_NewsYearMonthEntity>();

            result = NewsRepository.SelectMonthYearByLanguage(lang);

            return result;
        }
        #endregion
    }
}
