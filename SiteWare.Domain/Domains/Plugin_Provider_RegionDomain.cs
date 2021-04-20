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
    public static class Plugin_Provider_RegionDomain
    {
        public static ResultList<Plugin_Provider_RegionEntity> GetRegionAllNotAsync()
        {
            ResultList<Plugin_Provider_RegionEntity> result = new ResultList<Plugin_Provider_RegionEntity>();

            result = Plugin_Provider_RegionRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<Plugin_Provider_RegionEntity>> GetRegionAll()
        {
            ResultList<Plugin_Provider_RegionEntity> result = new ResultList<Plugin_Provider_RegionEntity>();

            result = await Plugin_Provider_RegionRepository.SelectAll();

            return result;
        }
    }
}
