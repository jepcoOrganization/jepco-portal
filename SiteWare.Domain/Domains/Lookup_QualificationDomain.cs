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
    public static  class Lookup_QualificationDomain
    {
        public async static Task<ResultList<Lookup_QualificationEntity>> GetAll()
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            result = await Lookup_QualificationRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_QualificationEntity> GetAllNotAsync()
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            result = Lookup_QualificationRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_QualificationEntity>> GetByID(int QualificationID)
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            result = await Lookup_QualificationRepository.SelectByID(QualificationID);

            return result;
        }

        public static ResultList<Lookup_QualificationEntity> GetByIDNotAsync(int QualificationID)
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            result = Lookup_QualificationRepository.SelectByIDNotAsync(QualificationID);

            return result;
        }
    }
}
