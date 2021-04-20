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
    public static class Lookup_PropertyTypeDomain
    {
        public async static Task<ResultList<Lookup_PropertyTypeEntity>> GetLookup_PropertyTypeAll()
        {
            ResultList<Lookup_PropertyTypeEntity> result = new ResultList<Lookup_PropertyTypeEntity>();

            result = await Lookup_PropertyTypeRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_PropertyTypeEntity> GetLookup_PropertyTypeAllNotAsync()
        {
            ResultList<Lookup_PropertyTypeEntity> result = new ResultList<Lookup_PropertyTypeEntity>();

            result = Lookup_PropertyTypeRepository.SelectAllNotAsync();

            return result;
        }
    }
}
