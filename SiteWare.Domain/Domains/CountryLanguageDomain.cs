using SiteWare.DataAccess.Repositories;
using SiteWare.Entity;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Domains
{
   public class CountryLanguageDomain
    {
        public async static Task<ResultList<CountryLanguageEntity>> GetCountry()
        {
            ResultList<CountryLanguageEntity> result = new ResultList<CountryLanguageEntity>();

            result = await CountryLanguageRepository.SelectAll();

            return result;
        }
        public static ResultList<CountryLanguageEntity> GetCountryNotAsync()
        {
            ResultList<CountryLanguageEntity> result = new ResultList<CountryLanguageEntity>();

            result = CountryLanguageRepository.SelectAllNotAsync();

            return result;
        }
    }
}
