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
    public static class Plugin_Provider_SubCategoryDomain
    {
        public static ResultList<Plugin_Provider_SubCategoryEntity> GetSubCategoryAllNotAsync()
        {
            ResultList<Plugin_Provider_SubCategoryEntity> result = new ResultList<Plugin_Provider_SubCategoryEntity>();

            result = Plugin_Provider_SubCategoryRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> GetSubCategoryByID(long ID)
        {
            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            result = await Plugin_Provider_SubCategoryRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<Plugin_Provider_SubCategoryEntity>> GetSubCategoryAll()
        {
            ResultList<Plugin_Provider_SubCategoryEntity> result = new ResultList<Plugin_Provider_SubCategoryEntity>();

            result = await Plugin_Provider_SubCategoryRepository.SelectAll();

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> InsertSubCategory(Plugin_Provider_SubCategoryEntity entity)
        {
            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            result = await Plugin_Provider_SubCategoryRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> Update(Plugin_Provider_SubCategoryEntity entity)
        {
            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            result = await Plugin_Provider_SubCategoryRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> UpdateByIsDeleted(long SubCatID)
        {
            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            result = await Plugin_Provider_SubCategoryRepository.UpdateByIsDeleted(SubCatID);

            return result;
        }
    }
}
