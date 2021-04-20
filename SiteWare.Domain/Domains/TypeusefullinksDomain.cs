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
    public static class TypeusefullinksDomain
    {
        public static ResultList<TypeusefullinksEntity> GetNewsAllNotAsync()
        {
            ResultList<TypeusefullinksEntity> result = new ResultList<TypeusefullinksEntity>();

            result = TypeusefullinksRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<TypeusefullinksEntity>> GetTypeusefullinksByID(int ID)
        {
            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            result = await TypeusefullinksRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<TypeusefullinksEntity>> GetTypeusefullinksAll()
        {
            ResultList<TypeusefullinksEntity> result = new ResultList<TypeusefullinksEntity>();

            result = await TypeusefullinksRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<TypeusefullinksEntity>> InsertTypeusefullinks(TypeusefullinksEntity entity)
        {
            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            result = await TypeusefullinksRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<TypeusefullinksEntity>> Update(TypeusefullinksEntity entity)
        {
            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            result = await TypeusefullinksRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<TypeusefullinksEntity>> UpdateByIsDeleted(TypeusefullinksEntity entity)
        {
            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            result = await TypeusefullinksRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
