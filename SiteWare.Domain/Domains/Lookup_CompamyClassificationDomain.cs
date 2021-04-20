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
    public static class Lookup_CompamyClassificationDomain
    {
        public async static Task<ResultList<Lookup_CompamyClassificationEntity>> GetAll()
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            result = await Lookup_CompamyClassificationRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_CompamyClassificationEntity> GetAllNotAsync()
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            result = Lookup_CompamyClassificationRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_CompamyClassificationEntity>> GetByID(int DocumentTypeID)
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            result = await Lookup_CompamyClassificationRepository.SelectByID(DocumentTypeID);

            return result;
        }

        public static ResultList<Lookup_CompamyClassificationEntity> GetByIDNotAsync(int DocumentTypeID)
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            result = Lookup_CompamyClassificationRepository.SelectByIDNotAsync(DocumentTypeID);

            return result;
        }
    }
}
