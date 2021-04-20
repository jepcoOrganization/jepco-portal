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
   public static class Lookup_NationalityDomain
    {
        public static ResultList<Lookup_NationalityEntity> GetAllNotAsync()
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();
            try
            {
                result = Lookup_NationalityRepository.SelectAllNotAsync();
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultList<Lookup_NationalityEntity>> GetAll()
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();
            try
            {
                result = await Lookup_NationalityRepository.SelectAll();
            }
            catch
            {
            }
            return result;
        }
        public static ResultList<Lookup_NationalityEntity> GetByIDNotAsync(int NationalityID)
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();
            try
            {
                result = Lookup_NationalityRepository.SelectByIDNotAsync(NationalityID);
            }
            catch
            {
            }
            return result;
        }

        public async static Task<ResultList<Lookup_NationalityEntity>> GetByID(int NationalityID)
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();
            try
            {
                result = await Lookup_NationalityRepository.SelectByID(NationalityID);
            }
            catch
            {
            }
            return result;
        }


    }
}
