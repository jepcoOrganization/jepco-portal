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
    public static class PluginAlbumDetailDomain
    {

        public async static Task<ResultList<PluginAlbumDetailEntity>> GetPluginAlbumDetailAll()
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.SelectAll();

            return result;
        }

        public async static Task<ResultList<PluginAlbumDetailEntity>> GetAlbumByAlbumID(int AlbumID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.SelectAlbumByAlbumID(AlbumID);

            return result;
        }
        public static ResultList<PluginAlbumDetailEntity> GetAlbumByAlbumIDNotAsync(int AlbumID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = PluginAlbumDetailRepository.SelectAlbumByAlbumIDNotAsync(AlbumID);

            return result;
        }
        public async static Task<ResultList<PluginAlbumDetailEntity>> GetPluginAlbumDetailAllByTypeID(int TypeID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.SelectAlbumByTypeID(TypeID);

            return result;
        }

        public static ResultList<PluginAlbumDetailEntity> GetPluginAlbumDetailAllByTypeIDNotAsync(int TypeID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = PluginAlbumDetailRepository.SelectAlbumByTypeIDNotAsync(TypeID);

            return result;
        }
        public static ResultList<PluginAlbumDetailEntity> GetPluginAlbumDetailAllNotAsync()
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            result = PluginAlbumDetailRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginAlbumDetailEntity>> GetPluginAlbumDetailByID(int ID)
        {
            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.Plugin_Albums_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginAlbumDetailEntity>> UpdatePluginAlbumDetail(PluginAlbumDetailEntity entity)
        {
            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.Plugin_Albums_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAlbumDetailEntity>> InsertPluginAlbumDetail(PluginAlbumDetailEntity entity)
        {
            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.Plugin_Albums_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginAlbumDetailEntity>> DeletePluginAlbumDetail(int ID)
        {
            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            result = await PluginAlbumDetailRepository.Plugin_Albums_Delete(ID);

            return result;
        }
    }
}
