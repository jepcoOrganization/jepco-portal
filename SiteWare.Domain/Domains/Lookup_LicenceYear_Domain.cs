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
    public static  class Lookup_LicenceYear_Domain
    {
        public async static Task<ResultList<Lookup_LicenceYearEntity>> GetAll()
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            result = await Lookup_LicenceYearRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_LicenceYearEntity> GetAllNotAsync()
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            result = Lookup_LicenceYearRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_LicenceYearEntity>> GetByID(int LicenceYearID)
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            result = await Lookup_LicenceYearRepository.SelectByID(LicenceYearID);

            return result;
        }

        public static ResultList<Lookup_LicenceYearEntity> GetByIDNotAsync(int LicenceYearID)
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            result = Lookup_LicenceYearRepository.SelectByIDNotAsync(LicenceYearID);

            return result;
        }
    }
}
