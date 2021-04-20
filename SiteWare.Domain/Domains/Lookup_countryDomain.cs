using SiteWare.DataAccess.RepositorieConstants;
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
    public class Lookup_countryDomain
    {
        public async static Task<ResultList<Lookup_CountryEntity>> GetAll()
        {
            ResultList<Lookup_CountryEntity> result = new ResultList<Lookup_CountryEntity>();
            result = await Lookup_CountryRepository.SelectAll();

            return result;
        }
        public static ResultList<Lookup_CountryEntity> GetAllNotAsync()
        {
            ResultList<Lookup_CountryEntity> result = new ResultList<Lookup_CountryEntity>();
            result = Lookup_CountryRepository.SelectAllNotAsync();

            return result;
        }

    }
}
