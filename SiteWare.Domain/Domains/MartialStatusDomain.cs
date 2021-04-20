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
   public class MartialStatusDomain
    {
        public async static Task<ResultList<MartialStatusEntity>> GetMartialStatus()
        {
            ResultList<MartialStatusEntity> result = new ResultList<MartialStatusEntity>();

            result = await MartialStatusRepository.SelectAll();

            return result;
        }
        public static ResultList<MartialStatusEntity> GetMartialStatusNotAsync()
        {
            ResultList<MartialStatusEntity> result = new ResultList<MartialStatusEntity>();

            result = MartialStatusRepository.SelectAllNotAsync();

            return result;
        }
    }
}
