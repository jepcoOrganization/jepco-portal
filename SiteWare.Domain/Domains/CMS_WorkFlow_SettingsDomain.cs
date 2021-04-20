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
   public static class CMS_WorkFlow_SettingsDomain
    {
        public async static Task<ResultList<CMS_WorkFlow_SettingsEntity>> GetAll()
        {
            ResultList<CMS_WorkFlow_SettingsEntity> result = new ResultList<CMS_WorkFlow_SettingsEntity>();

            result = await CMS_WorkFlow_SettingsRepository.SelectAll();

            return result;
        }
        public static ResultList<CMS_WorkFlow_SettingsEntity> GetAllNotAsync()
        {
            ResultList<CMS_WorkFlow_SettingsEntity> result = new ResultList<CMS_WorkFlow_SettingsEntity>();

            result = CMS_WorkFlow_SettingsRepository.SelectAllNotAsync();

            return result;
        }


    }
}
