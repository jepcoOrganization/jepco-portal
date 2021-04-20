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
    public class Plugin_SecondSliderDomain
    {
        public async static Task<ResultList<Plugin_SecondSliderEntity>> GetPluginSecondSliderAll()
        {
            ResultList<Plugin_SecondSliderEntity> result = new ResultList<Plugin_SecondSliderEntity>();

            result = await Plugin_SecondSliderRepository.SelectAll();

            return result;
        }


        public static ResultList<Plugin_SecondSliderEntity> GetPluginSecondSliderAllNotAsync()
        {
            ResultList<Plugin_SecondSliderEntity> result = new ResultList<Plugin_SecondSliderEntity>();

            result = Plugin_SecondSliderRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> GetPluginSecondSliderByID(long ID)
        {
            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            result = await Plugin_SecondSliderRepository.Plugin_SecondSlider_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> UpdatePluginSecondSlider(Plugin_SecondSliderEntity entity)
        {
            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            result = await Plugin_SecondSliderRepository.Plugin_SecondSlider_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> InsertPluginSecondSlider(Plugin_SecondSliderEntity entity)
        {
            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            result = await Plugin_SecondSliderRepository.Plugin_SecondSlider_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> SecondSlider_Delete(long ID)
        {
            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            result = await Plugin_SecondSliderRepository.Plugin_SecondSlider_Delete(ID);

            return result;
        }
    }
}
