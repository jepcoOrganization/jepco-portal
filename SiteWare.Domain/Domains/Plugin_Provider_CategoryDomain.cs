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
    public static class Plugin_Provider_CategoryDomain
    {
        public static ResultList<Plugin_Provider_CategoryEntity> GetCategoryAllNotAsync()
        {
            ResultList<Plugin_Provider_CategoryEntity> result = new ResultList<Plugin_Provider_CategoryEntity>();

            result = Plugin_Provider_CategoryRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> GetCategoryByID(long ID)
        {
            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            result = await Plugin_Provider_CategoryRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<Plugin_Provider_CategoryEntity>> GetCategoryAll()
        {
            ResultList<Plugin_Provider_CategoryEntity> result = new ResultList<Plugin_Provider_CategoryEntity>();

            result = await Plugin_Provider_CategoryRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> InsertCategory(Plugin_Provider_CategoryEntity entity)
        {
            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            result = await Plugin_Provider_CategoryRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> Update(Plugin_Provider_CategoryEntity entity)
        {
            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            result = await Plugin_Provider_CategoryRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> UpdateByIsDeleted(long CatID)
        {
            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            result = await Plugin_Provider_CategoryRepository.UpdateByIsDeleted(CatID);

            return result;
        }
    }
}
