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
    public static class Lookup_AreaOneDomain
    {
        public async static Task<ResultList<Lookup_AreaOneEntity>> GetAll()
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            result = await Lookup_AreaOneRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_AreaOneEntity> GetAllNotAsync()
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            result = Lookup_AreaOneRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_AreaOneEntity>> GetByID(int AreaOneID)
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            result = await Lookup_AreaOneRepository.SelectByID(AreaOneID);

            return result;
        }

        public static ResultList<Lookup_AreaOneEntity> GetByIDNotAsync(int AreaOneID)
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            result = Lookup_AreaOneRepository.SelectByIDNotAsync(AreaOneID);

            return result;
        }
    }
}
