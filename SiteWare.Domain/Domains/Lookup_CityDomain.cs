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
    public static class Lookup_CityDomain
    {
        public async static Task<ResultList<Lookup_CityEntity>> GetLookupCityAll()
        {
            ResultList<Lookup_CityEntity> result = new ResultList<Lookup_CityEntity>();

            result = await Lookup_CityRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_CityEntity> GetLookupCityAllNotAsync()
        {
            ResultList<Lookup_CityEntity> result = new ResultList<Lookup_CityEntity>();

            result = Lookup_CityRepository.SelectAllNotAsync();

            return result;
        }
    }
}
