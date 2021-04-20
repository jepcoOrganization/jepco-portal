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
   public static class NewSub_Lookup_NationalityDomain
    {
        public async static Task<ResultList<NewSub_Lookup_NationalityEntity>> GetAll()
        {
            ResultList<NewSub_Lookup_NationalityEntity> result = new ResultList<NewSub_Lookup_NationalityEntity>();

            result = await NewSub_Lookup_NationalityRepository.SelectAll();

            return result;
        }

        public static ResultList<NewSub_Lookup_NationalityEntity> GetAllNotAsync()
        {
            ResultList<NewSub_Lookup_NationalityEntity> result = new ResultList<NewSub_Lookup_NationalityEntity>();

            result = NewSub_Lookup_NationalityRepository.SelectAllNotAsync();

            return result;
        }
        

    }
}
