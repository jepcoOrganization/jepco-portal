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
    public static class Lookup_UsageStatusDomain
    {
        public static ResultList<Lookup_UsageStatusEntity> GetUsageStatusAllNotAsync()
        {
            ResultList<Lookup_UsageStatusEntity> result = new ResultList<Lookup_UsageStatusEntity>();

            result = Lookup_UsageStatusRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<Lookup_UsageStatusEntity>> GetUsageStatusAll()
        {
            ResultList<Lookup_UsageStatusEntity> result = new ResultList<Lookup_UsageStatusEntity>();

            result = await Lookup_UsageStatusRepository.SelectAll();

            return result;
        }
    }
}
