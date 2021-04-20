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
    public static class PluginAnnouncementDomain
    {

        public async static Task<ResultList<PluginAnnouncementEntity>> GetAnnouncementTopThree()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.SelectTopThree();

            return result;
        }

        public async static Task<ResultList<PluginAnnouncementEntity>> GetAnnouncementAll()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.SelectAll();

            return result;
        }

        public static ResultList<PluginAnnouncementEntity> GetAnnouncementAllNotAsync()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = PluginAnnouncementRepository.SelectAllNotAsync();

            return result;
        }

        public static ResultList<PluginAnnouncementEntity> GetAnnouncementWithPaginationNotAsync(byte LanguageID, int pageno, int pagesize)
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = PluginAnnouncementRepository.SelectWithPaginationAllNotAsync(LanguageID, pageno, pagesize);

            return result;
        }

        public async static Task<ResultEntity<PluginAnnouncementEntity>> GetPagesByAnnouncementID(int AnnouncementID)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.SelectByAnnouncementID(AnnouncementID);

            return result;
        }

        public async static Task<ResultEntity<PluginAnnouncementEntity>> GetPagesByAnnouncementID(int ID,byte lang)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.SelectByAnnouncementID(ID,lang);

            return result;
        }

        public async static Task<ResultEntity<PluginAnnouncementEntity>> UpdateAnnouncement(PluginAnnouncementEntity entity)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAnnouncementEntity>> UpdateAnnouncementByIsDeleted(PluginAnnouncementEntity entity)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.UpdateByIsDeleted(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAnnouncementEntity>> InsertAnnouncement(PluginAnnouncementEntity entity)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.InsertAnnouncement(entity);

            return result;
        }
                                                       
        public async static Task<ResultEntity<PluginAnnouncementEntity>> DeleteAnnouncement(PluginAnnouncementEntity entity)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.DeleteAnnouncement(entity);

            return result;
        }

        public async static Task<ResultList<PluginAnnouncementEntity>> GetAnnouncementByKyeword(string keyword, byte LanguageId,int year, int pageno, int pagesize)
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.Search_Announcement_SelectByKeyword(keyword, LanguageId,year,pageno,pagesize);

            return result;
        }

        public async static Task<ResultList<PluginAnnouncementEntity>> GetAllAnnouncementByKyeword(string keyword, byte LanguageId, int year)
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.Search_AllAnnouncement_SelectByKeyword(keyword, LanguageId, year);

            return result;
        }
        public async static Task<ResultEntity<PluginAnnouncementEntity>> UpdateAnnouncementViewCount(PluginAnnouncementEntity entity)
        {
            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            result = await PluginAnnouncementRepository.UpdateViewCount(entity);

            return result;
        }
    }
}
