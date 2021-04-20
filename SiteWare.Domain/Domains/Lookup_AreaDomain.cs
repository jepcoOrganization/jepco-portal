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
    public static class Lookup_AreaDomain
    {
        public async static Task<ResultList<Lookup_AreaEntity>> GetLookupAreaAll()
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            result = await Lookup_AreaRepository.SelectAll();

            return result;
        }
        
        public static ResultList<Lookup_AreaEntity> GetLookupAreaAllNotAsync()
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            result = Lookup_AreaRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_AreaEntity>> GetLookupAreaByGovernateID(int GovernateID)
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            result = await Lookup_AreaRepository.Lookup_Area_ByGovernateID(GovernateID);

            return result;
        }

        public static ResultList<Lookup_AreaEntity> GetLookupAreaByGovernateIDNotAsync(int GovernateID)
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            result = Lookup_AreaRepository.Lookup_Area_ByGovernateIDNotAsync(GovernateID);

            return result;
        }

    }
}
