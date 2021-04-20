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
    public static class PagesDomain
    {
        public async static Task<ResultList<PagesEntity>> GetPagesAll(int UserID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = await PagesRepository.SelectAll(UserID);

            return result;
        }


        public async static Task<ResultList<PagesEntity>> GetPagesAllSuperAdmin()
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = await PagesRepository.SelectAllSuperAdmin();

            return result;
        }

        public static ResultList<PagesEntity> GetPagesAllSuperAdminNotAsync()
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = PagesRepository.SelectAllSuperAdminNotAsync();

            return result;
        }


        public static ResultList<PagesEntity> GetPagesAllNotAsync(int UserID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = PagesRepository.SelectAllNotAsync(UserID);

            return result;
        }
        public async static Task<ResultEntity<PagesEntity>> GetPagesByPageID(int PageID)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.SelectByPageID(PageID);

            return result;
        }

        // Created By Simran 02/07/2018

        public static ResultEntity<PagesEntity> GetPagesByPageIDNotAsync(int PageID)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result =  PagesRepository.SelectByPageIDNotAsync(PageID);

            return result;
        }
        public async static Task<ResultList<PagesEntity>> GetPagesByPageID2(int PageID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = await PagesRepository.SelectByPageID2(PageID);

            return result;
        }

        public async static Task<ResultEntity<PagesEntity>> UpdateViewCountByAliasPath(string Alias)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.UpdateViewCountByPageAliasPath(Alias);

            return result;
        }
        public async static Task<ResultList<PagesEntity>> GetPagesByKyeword(string keyword,byte LanguageId)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = await PagesRepository.Search_Page_SelectByKeyword(keyword,LanguageId);

            return result;
        }
        public async static Task<ResultEntity<PagesEntity>> GetPagesByAliasPath(string Alias, byte langId)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.SelectByPageAliasPath(Alias,langId);

            return result;
        }
        public static ResultEntity<PagesEntity> GetPagesByAliasPathNotAsync(string Alias, byte langId)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = PagesRepository.SelectByPageAliasPathNotAsync(Alias, langId);

            return result;
        }
        public async static Task<ResultEntity<PagesEntity>> UpdatePages(PagesEntity entity)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<PagesEntity>> UpdatePagesByIsDeleted(PagesEntity entity)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<PagesEntity>> InsertPages(PagesEntity entity)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.InsertPage(entity);

            return result;
        }

        public async static Task<ResultEntity<PagesEntity>> DeletePages(PagesEntity entity)
        {
            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            result = await PagesRepository.DeletePage(entity);

            return result;
        }

        public async static Task<ResultList<PagesEntity>> GetPagesByKyewordPageNo(string keyword, byte LanguageId, int pageno, int pagesize)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            result = await PagesRepository.Search_Page_SelectByKeywordPageNo(keyword, LanguageId,pageno,pagesize);

            return result;
        }
    }
}
