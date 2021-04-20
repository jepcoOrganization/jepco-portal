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
    public static class NewsTickerDomain
    {
        public async static Task<ResultList<NewsTickerEntity>> GetNewsTickerAll()
        {
            ResultList<NewsTickerEntity> result = new ResultList<NewsTickerEntity>();

            result = await NewsTickerRepository.SelectAll();

            return result;
        }
        public static ResultList<NewsTickerEntity> GetNewsTickerAllNotAsync()
        {
            ResultList<NewsTickerEntity> result = new ResultList<NewsTickerEntity>();

            result = NewsTickerRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<NewsTickerEntity>> GetNewsTicerByNewsTickerID(int NewsTickerID)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = await NewsTickerRepository.SelectByNewsTickerID(NewsTickerID);

            return result;
        }
        public  static ResultEntity<NewsTickerEntity> GetNewsTicerByNewsTickerIDNotAsync(int NewsTickerID)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result =  NewsTickerRepository.SelectByNewsTickerIDNotAsync(NewsTickerID);

            return result;
        }
        public async static Task<ResultEntity<NewsTickerEntity>> UpdateNewsTicker(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = await NewsTickerRepository.Update(entity);

            return result;
        }

        public  static ResultEntity<NewsTickerEntity> UpdateNewsTickerNotAsync(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = NewsTickerRepository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsTickerEntity>> UpdateNewsTickerByIsDeleted(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = await NewsTickerRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsTickerEntity>> InsertNewsTicker(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = await NewsTickerRepository.InsertNewsTicker(entity);

            return result;
        }
        public  static ResultEntity<NewsTickerEntity> InsertNewsTickerNotAsync(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result =  NewsTickerRepository.InsertNewsTickerNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<NewsTickerEntity>> DeleteNewsTicker(NewsTickerEntity entity)
        {
            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            result = await NewsTickerRepository.DeleteNewsTicker(entity);

            return result;
        }
    }
}
