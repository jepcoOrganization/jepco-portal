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
   public static class Lookup_ComplainTypeDomain
    {
        public async static Task<ResultList<Lookup_ComplainTypeEntity>> GetAll()
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            result = await Lookup_ComplainTypeRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_ComplainTypeEntity> GetAllNotAsync()
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            result = Lookup_ComplainTypeRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_ComplainTypeEntity>> GetByID(int DocumentTypeID)
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            result = await Lookup_ComplainTypeRepository.SelectByID(DocumentTypeID);

            return result;
        }

        public static ResultList<Lookup_ComplainTypeEntity> GetByIDNotAsync(int DocumentTypeID)
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            result = Lookup_ComplainTypeRepository.SelectByIDNotAsync(DocumentTypeID);

            return result;
        }

    }
}
