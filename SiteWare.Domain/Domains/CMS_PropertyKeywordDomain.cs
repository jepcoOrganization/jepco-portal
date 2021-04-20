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
    public static class CMS_PropertyKeywordDomain
    {
        public async static Task<ResultList<CMS_PropertyKeywordEntity>> GetKeywordByPropertyID(long PropertyID)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            result = await CMS_PropertyKeywordRepository.SelectKeywordByPropertyID(PropertyID);

            return result;
        }

        public static ResultList<CMS_PropertyKeywordEntity> GetKeywordByPropertyIDNotasync(long PropertyID)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            result = CMS_PropertyKeywordRepository.SelectKeywordByPropertyIDNotAsync(PropertyID);

            return result;
        }

        public async static Task<ResultEntity<CMS_PropertyKeywordEntity>> DeleteKeywordByPropertyID(long PropertyID)
        {
            ResultEntity<CMS_PropertyKeywordEntity> result = new ResultEntity<CMS_PropertyKeywordEntity>();

            result = await CMS_PropertyKeywordRepository.DeleteByPropertyID(PropertyID);

            return result;
        }

        public async static Task<ResultEntity<CMS_PropertyKeywordEntity>> InsertKeyword(CMS_PropertyKeywordEntity entity)
        {
            ResultEntity<CMS_PropertyKeywordEntity> result = new ResultEntity<CMS_PropertyKeywordEntity>();

            result = await CMS_PropertyKeywordRepository.InsertKeyword(entity);

            return result;
        }

        public static ResultList<CMS_PropertyKeywordEntity> GetKeywordListbyKeywords(string keywords)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            result = CMS_PropertyKeywordRepository.SelectKeywordListByKeywords(keywords);

            return result;
        }

    }
}
