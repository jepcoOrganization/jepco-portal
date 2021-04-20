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
    public static class Plugin_PropertyAlbumDomain
    {
        public async static Task<ResultList<Plugin_PropertyAlbumEntity>> GetPluginAlbumAll()
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.SelectAll();

            return result;
        }
        public async static Task<ResultList<Plugin_PropertyAlbumEntity>> GetAlbumByPropertyID(int ID)
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.SelectPropertyAlbumByProperty(ID); 

            return result;
        }

        public static ResultList<Plugin_PropertyAlbumEntity> GetPluginAlbumAllNotAsync()
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            result = Plugin_PropertyAlbumRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> GetPluginAlbumByID(int ID)
        {
            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.PropertyAlbums_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> UpdatePluginAlbum(Plugin_PropertyAlbumEntity entity)
        {
            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.Plugin_PropertyAlbums_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> InsertPluginAlbum(Plugin_PropertyAlbumEntity entity)
        {
            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.Plugin_PropertyAlbums_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> DeletePluginAlbum(int ID)
        {
            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            result = await Plugin_PropertyAlbumRepository.Plugin_PropertyAlbums_Delete(ID);

            return result;
        }
    }
}
