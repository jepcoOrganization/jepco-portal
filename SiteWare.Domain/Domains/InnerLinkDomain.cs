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
    public static class InnerLinkDomain
    {
        public async static Task<ResultEntity<InnerLinkEntity>> GetInnerLinkByID(int ID)
        {
            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            result = await InnerLinkRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<InnerLinkEntity>> GetInnerLinkAll()
        {
            ResultList<InnerLinkEntity> result = new ResultList<InnerLinkEntity>();

            result = await InnerLinkRepository.SelectAll();

            return result;
        }
        public static ResultList<InnerLinkEntity> GetInnerLinkAllWithoutAsync()
        {
            ResultList<InnerLinkEntity> result = new ResultList<InnerLinkEntity>();

            result = InnerLinkRepository.SelectAllWithoutAsync();

            return result;
        }
        public async static Task<ResultEntity<InnerLinkEntity>> InsertInnerLink(InnerLinkEntity entity)
        {
            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            result = await InnerLinkRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<InnerLinkEntity>> Update(InnerLinkEntity entity)
        {
            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            result = await InnerLinkRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<InnerLinkEntity>> UpdateByIsDeleted(InnerLinkEntity entity)
        {
            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            result = await InnerLinkRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
