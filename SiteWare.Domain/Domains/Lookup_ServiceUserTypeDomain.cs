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
   public class Lookup_ServiceUserTypeDomain
    {
        public async static Task<ResultList<Lookup_ServiceUserTypeEntity>> GetAll()
        {
            ResultList<Lookup_ServiceUserTypeEntity> result = new ResultList<Lookup_ServiceUserTypeEntity>();
            result = await Lookup_ServiceUserTypeRepository.SelectAll();

            return result;
        }
        public static ResultList<Lookup_ServiceUserTypeEntity> GetAllNotAsync()
        {
            ResultList<Lookup_ServiceUserTypeEntity> result = new ResultList<Lookup_ServiceUserTypeEntity>();
            result = Lookup_ServiceUserTypeRepository.SelectAllNotAsync();

            return result;
        }

    }
}
