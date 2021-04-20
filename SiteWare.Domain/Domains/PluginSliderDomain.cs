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
    public static class PluginSliderDomain
    {

        public async static Task<ResultList<PluginSliderEntity>> GetSliderAll()
        {
            ResultList<PluginSliderEntity> result = new ResultList<PluginSliderEntity>();

            result = await PluginSliderRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginSliderEntity> GetSliderAllNotAsync()
        {
            ResultList<PluginSliderEntity> result = new ResultList<PluginSliderEntity>();

            result = PluginSliderRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginSliderEntity>> GetSliderByID(int ID)
        {
            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            result = await PluginSliderRepository.Plugin_Slider_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginSliderEntity>> UpdateSliderBanner(PluginSliderEntity entity)
        {
            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            result = await PluginSliderRepository.Plugin_Slider_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSliderEntity>> InsertSlider(PluginSliderEntity entity)
        {
            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            result = await PluginSliderRepository.Plugin_Slider_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSliderEntity>> Slider_Delete(int ID)
        {
            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            result = await PluginSliderRepository.Plugin_Slider_Delete(ID);

            return result;
        }
    }
}
