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
   public class DepartmentLanguageDomain
    {
        public async static Task<ResultList<DepartmentLanguageEntity>> GetDepartment()
        {
           
            ResultList<DepartmentLanguageEntity> result = new ResultList<DepartmentLanguageEntity>();

            result = await DepartmentLanguageRepository.SelectAll();

            return result;
        }
        public static ResultList<DepartmentLanguageEntity> GetDepartmentNotAsync()
        {

            ResultList<DepartmentLanguageEntity> result = new ResultList<DepartmentLanguageEntity>();

            result = DepartmentLanguageRepository.SelectAllNotAsync();

            return result;
        }
    }
}
