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
   public class GenderLanguageDomain
   {
        public async static Task<ResultList<GenderLanguageEntity>> GetGender()
        {
            ResultList<GenderLanguageEntity> result = new ResultList<GenderLanguageEntity>();

            result = await GenderLanguageRepository.SelectAll();

            return result;
        }
        public static ResultList<GenderLanguageEntity> GetGenderNotAsync()
        {
            ResultList<GenderLanguageEntity> result = new ResultList<GenderLanguageEntity>();

            result =  GenderLanguageRepository.SelectAllNotAsync();

            return result;
        }
    }
}
