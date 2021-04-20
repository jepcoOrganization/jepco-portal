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
    public static  class Lookup_LicenceTypeDomain
    {
        public async static Task<ResultList<Lookup_LicenceTypeEntity>> GetAll()
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            result = await Lookup_LicenceTypeRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_LicenceTypeEntity> GetAllNotAsync()
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            result = Lookup_LicenceTypeRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_LicenceTypeEntity>> GetByID(int LicenceTypeID)
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            result = await Lookup_LicenceTypeRepository.SelectByID(LicenceTypeID);

            return result;
        }
    
        public static ResultList<Lookup_LicenceTypeEntity> GetByIDNotAsync(int LicenceTypeID)
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            result = Lookup_LicenceTypeRepository.SelectByIDNotAsync(LicenceTypeID);

            return result;
        }
    }
}
