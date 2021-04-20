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
    public static class Lookup_AreaTwoDomain
    {
        public async static Task<ResultList<Lookup_AreaTwoEntity>> GetAll()
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            result = await Lookup_AreaTwoRepository.SelectAll();

            return result;
        }
        
        public static ResultList<Lookup_AreaTwoEntity> GetAllNotAsync()
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            result = Lookup_AreaTwoRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_AreaTwoEntity>> GetByID(int AreaTwoID)
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            result = await Lookup_AreaTwoRepository.SelectByID(AreaTwoID);

            return result;
        }

        public static ResultList<Lookup_AreaTwoEntity> GetByIDNotAsync(int AreaTwoID)
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            result = Lookup_AreaTwoRepository.SelectByIDNotAsync(AreaTwoID);

            return result;
        }
    }
}
