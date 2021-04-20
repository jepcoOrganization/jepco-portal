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
    public static class PagesKeywordDomain
    {
        public async static Task<ResultList<PagesKeywordEntity>> GetKeywordByPageID(int PageID)
        {
            ResultList<PagesKeywordEntity> result = new ResultList<PagesKeywordEntity>();

            result = await PagesKeywordRepository.SelectKeywordByPageID(PageID);

            return result;
        }

        public async static Task<ResultEntity<PagesKeywordEntity>> DeleteKeywordByPageID(int PageID)
        {
            ResultEntity<PagesKeywordEntity> result = new ResultEntity<PagesKeywordEntity>();

            result = await PagesKeywordRepository.DeleteByPageID(PageID);

            return result;
        }

        public async static Task<ResultEntity<PagesKeywordEntity>> InsertKeyword(PagesKeywordEntity entity)
        {
            ResultEntity<PagesKeywordEntity> result = new ResultEntity<PagesKeywordEntity>();

            result = await PagesKeywordRepository.InsertKeyword(entity);

            return result;
        }
    }
}
