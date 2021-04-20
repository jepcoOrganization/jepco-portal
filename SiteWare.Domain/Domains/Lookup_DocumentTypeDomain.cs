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
   public static class Lookup_DocumentTypeDomain
    {
        public async static Task<ResultList<Lookup_DocumentTypeEntity>> GetAll()
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            result = await Lookup_DocumentTypeRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_DocumentTypeEntity> GetAllNotAsync()
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            result = Lookup_DocumentTypeRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_DocumentTypeEntity>> GetByID(int DocumentTypeID)
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            result = await Lookup_DocumentTypeRepository.SelectByID(DocumentTypeID);

            return result;
        }

        public static ResultList<Lookup_DocumentTypeEntity> GetByIDNotAsync(int DocumentTypeID)
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            result = Lookup_DocumentTypeRepository.SelectByIDNotAsync(DocumentTypeID);

            return result;
        }

    }
}
