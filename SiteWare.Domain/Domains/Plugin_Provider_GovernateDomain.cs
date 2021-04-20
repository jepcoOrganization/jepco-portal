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
    public static class Plugin_Provider_GovernateDomain
    {
        public static ResultList<Plugin_GovernateEntity> GetGovernateAllNotAsync()
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            result = Plugin_Provider_GovernateRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<Plugin_GovernateEntity>> GetGovernateAll()
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            result = await Plugin_Provider_GovernateRepository.SelectAll();

            return result;
        }

        public async static Task<ResultList<Plugin_GovernateEntity>> GetAllByCountryID(int CountryID)
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            result = await Plugin_Provider_GovernateRepository.SelectByCountryID(CountryID);


            return result;
        }
       
    }
}
