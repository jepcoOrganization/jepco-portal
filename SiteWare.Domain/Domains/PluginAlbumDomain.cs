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
    public static class PluginAlbumDomain
    {

        public async static Task<ResultList<PluginAlbumEntity>> GetPluginAlbumAll()
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            result = await PluginAlbumRepository.SelectAll();

            return result;
        }
        public async static Task<ResultList<PluginAlbumEntity>> GetAlbumByType(int TypeID)
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            result = await PluginAlbumRepository.SelectAlbumByType(TypeID); ;

            return result;
        }

        public static ResultList<PluginAlbumEntity> GetAlbumByTypeNotAsync(int TypeID)
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            result = PluginAlbumRepository.SelectAlbumByTypeNotAsync(TypeID); ;

            return result;
        }

        public static ResultList<PluginAlbumEntity> GetPluginAlbumAllNotAsync()
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            result = PluginAlbumRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginAlbumEntity>> GetPluginAlbumByID(int ID)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            result = await PluginAlbumRepository.Plugin_Albums_SelectByID(ID);

            return result;
        }

        public static ResultList<PluginAlbumEntity> GetPluginAlbumByIDNotAsync(int ID)
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            result = PluginAlbumRepository.Plugin_Albums_SelectByIDNotAsync(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginAlbumEntity>> UpdatePluginAlbum(PluginAlbumEntity entity)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            result = await PluginAlbumRepository.Plugin_Albums_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAlbumEntity>> InsertPluginAlbum(PluginAlbumEntity entity)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            result = await PluginAlbumRepository.Plugin_Albums_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAlbumEntity>> DeletePluginAlbum(int ID)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            result = await PluginAlbumRepository.Plugin_Albums_Delete(ID);

            return result;
        }


        public async static Task<ResultEntity<PluginAlbumEntity>> UpdateViewCountByAliasPath(int id)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            result = await PluginAlbumRepository.UpdateViewCount(id);

            return result;
        }
    }
}
