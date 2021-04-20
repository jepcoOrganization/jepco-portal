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
    public static class Lookup_ProvenanceDomain
    {
        public async static Task<ResultList<Lookup_ProvenanceEntity>> GetAll()
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            result = await Lookup_ProvenanceRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_ProvenanceEntity> GetAllNotAsync()
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            result = Lookup_ProvenanceRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_ProvenanceEntity>> GetByID(int ProvenanceID)
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            result = await Lookup_ProvenanceRepository.SelectByID(ProvenanceID);

            return result;
        }

        public static ResultList<Lookup_ProvenanceEntity> GetByIDNotAsync(int ProvenanceID)
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            result = Lookup_ProvenanceRepository.SelectByIDNotAsync(ProvenanceID);

            return result;
        }
    }
}
