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
    public static class VideoSliderDomain
    {
        public async static Task<ResultEntity<VideoSliderEntity>> GetVideoSliderByID(int ID)
        {
            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            result = await VideoSliderRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<VideoSliderEntity>> GetVideoSliderAll()
        {
            ResultList<VideoSliderEntity> result = new ResultList<VideoSliderEntity>();

            result = await VideoSliderRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<VideoSliderEntity>> InsertVideoSlider(VideoSliderEntity entity)
        {
            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            result = await VideoSliderRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<VideoSliderEntity>> Update(VideoSliderEntity entity)
        {
            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            result = await VideoSliderRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<VideoSliderEntity>> UpdateByIsDeleted(VideoSliderEntity entity)
        {
            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            result = await VideoSliderRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
