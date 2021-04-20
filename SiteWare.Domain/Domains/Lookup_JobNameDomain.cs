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
    public static class Lookup_JobNameDomain
    {
        public async static Task<ResultList<Lookup_JobNameEntity>> GetAll()
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            result = await Lookup_JobNameRepository.SelectAll();

            return result;
        }
        
        public static ResultList<Lookup_JobNameEntity> GetAllNotAsync()
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            result = Lookup_JobNameRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<Lookup_JobNameEntity>> GetByID(int JobTypeID)
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            result = await Lookup_JobNameRepository.SelectByID(JobTypeID);

            return result;
        }

        public static ResultList<Lookup_JobNameEntity> GetByIDNotAsync(int JobTypeID)
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            result = Lookup_JobNameRepository.SelectByIDNotAsync(JobTypeID);

            return result;
        }
    }
}
