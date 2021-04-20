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
   public static class Lookup_IdentityTypeDomain
    {
        public static ResultList<Lookup_IdentityTypeEntity> GetAllNotAsyncIdentity()
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();
            try
            {
                result = Lookup_IdentityTypeRepository.SelectAllNotAsync();
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultList<Lookup_IdentityTypeEntity>> GetAllIdentity()
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();
            try
            {
                result = await Lookup_IdentityTypeRepository.SelectAll();
            }
            catch
            {
            }
            return result;
        }
        public static ResultList<Lookup_IdentityTypeEntity> GetLookup_IdentityByIDNotAsync(int ID)
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();
            try
            {
                result = Lookup_IdentityTypeRepository.SelectByIDNotAsync(ID);
            }
            catch
            {
            }
            return result;
        }

        public async static Task<ResultList<Lookup_IdentityTypeEntity>> GetLookup_IdentityByID(int ID)
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();
            try
            {
                result = await Lookup_IdentityTypeRepository.SelectByID(ID);
            }
            catch
            {
            }
            return result;
        }

    
    }
}
