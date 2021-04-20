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
    public static class UsefullinksDomain
    {
        public static ResultList<UsefullinksEntity> GetNewsAllNotAsync()
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            result = UsefullinksRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<UsefullinksEntity>> GetUsefullinksByID(int ID)
        {
            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            result = await UsefullinksRepository.SelectByID(ID);

            return result;
        }
        public static ResultList<UsefullinksEntity> GetUsefullinksByType(int Type)
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            result =  UsefullinksRepository.SelectByType(Type);

            return result;
        }
        public async static Task<ResultList<UsefullinksEntity>> GetUsefullinksAll()
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            result = await UsefullinksRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<UsefullinksEntity>> InsertUsefullinks(UsefullinksEntity entity)
        {
            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            result = await UsefullinksRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<UsefullinksEntity>> Update(UsefullinksEntity entity)
        {
            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            result = await UsefullinksRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<UsefullinksEntity>> UpdateByIsDeleted(UsefullinksEntity entity)
        {
            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            result = await UsefullinksRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
