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
    public static class Lookup_JobTypeDomain
    {
        public async static Task<ResultList<Lookup_JobTypeEntity>> GetAll()
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            result = await Lookup_JobTypeRepository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_JobTypeEntity> GetAllNotAsync()
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            result = Lookup_JobTypeRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_JobTypeEntity>> GetByID(int JobTypeID)
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            result = await Lookup_JobTypeRepository.SelectByID(JobTypeID);

            return result;
        }
        
        public static ResultList<Lookup_JobTypeEntity> GetByIDNotAsync(int JobTypeID)
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            result = Lookup_JobTypeRepository.SelectByIDNotAsync(JobTypeID);

            return result;
        }
       
    }
}
