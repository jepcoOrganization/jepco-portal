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
   public class SectionLanguageDomain
    {
        public async static Task<ResultList<SectionLanguageEntity>> GetSection()
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            result = await SectionLanguageRepository.SelectAll();

            return result;
        }
        public static ResultList<SectionLanguageEntity> GetSectionNotAsync()
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            result = SectionLanguageRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultList<SectionLanguageEntity>> GetSectionByDepartmentID(int Department)
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            result = await SectionLanguageRepository.SelectByDepartmentID(Convert.ToInt32(Department));

            return result;
        }
    }
}
