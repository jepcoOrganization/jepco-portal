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
    public static class Plugin_PropertyAlbumDetailDomain
    {
        public async static Task<ResultList<Plugin_PropertyAlbumDetailEntity>> GetPluginAlbumDetailAll()
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.SelectAll();

            return result;
        }

        public async static Task<ResultList<Plugin_PropertyAlbumDetailEntity>> GetAlbumByAlbumID(int AlbumID)
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.SelectPropertyAlbumDetailByAlbumID(AlbumID);

            return result;
        }

        public static ResultList<Plugin_PropertyAlbumDetailEntity> GetPluginAlbumDetailAllNotAsync()
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            result = Plugin_PropertyAlbumDetailRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> GetPluginAlbumDetailByID(int ID)
        {
            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.PropertyAlbumsDetail_SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> UpdatePluginAlbumDetail(Plugin_PropertyAlbumDetailEntity entity)
        {
            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.Plugin_PropertyAlbumsDetail_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> InsertPluginAlbumDetail(Plugin_PropertyAlbumDetailEntity entity)
        {
            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.Plugin_PropertyAlbumsDetail_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> DeletePluginAlbumDetail(int ID)
        {
            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            result = await Plugin_PropertyAlbumDetailRepository.Plugin_PropertyAlbumsDetail_Delete(ID);

            return result;
        }
    }
}
