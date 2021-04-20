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
    public static class SettingDomain
    {
        public async static Task<ResultEntity<SettingEntity>> GetSettingByID(int ID)
        {
            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            result = await SettingRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<SettingEntity>> GetSettingAll()
        {
            ResultList<SettingEntity> result = new ResultList<SettingEntity>();

            result = await SettingRepository.SelectAll();

            return result;
        }
        public static ResultList<SettingEntity> GetSettingAllWithoutAsync()
        {
            ResultList<SettingEntity> result = new ResultList<SettingEntity>();

            result = SettingRepository.SelectAllWithoutAsync();

            return result;
        }
        public async static Task<ResultEntity<SettingEntity>> InsertSetting(SettingEntity entity)
        {
            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            result = await SettingRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<SettingEntity>> Update(SettingEntity entity)
        {
            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            result = await SettingRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<SettingEntity>> UpdateByIsDeleted(SettingEntity entity)
        {
            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            result = await SettingRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
