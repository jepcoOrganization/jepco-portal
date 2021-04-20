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
    public static class FAQDomain
    {
        public static ResultList<FAQEntity> GetNewsAllNotAsync()
        {
            ResultList<FAQEntity> result = new ResultList<FAQEntity>();

            result = FAQRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<FAQEntity>> GetFAQByID(int ID)
        {
            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            result = await FAQRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<FAQEntity>> GetFAQAll()
        {
            ResultList<FAQEntity> result = new ResultList<FAQEntity>();

            result = await FAQRepository.SelectAll();

            return result;
        }

        public static ResultList<FAQEntity> GetFAQAllNotAsync()
        {
            ResultList<FAQEntity> result = new ResultList<FAQEntity>();

            result = FAQRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<FAQEntity>> InsertFAQ(FAQEntity entity)
        {
            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            result = await FAQRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<FAQEntity>> Update(FAQEntity entity)
        {
            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            result = await FAQRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<FAQEntity>> UpdateByIsDeleted(FAQEntity entity)
        {
            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            result = await FAQRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
