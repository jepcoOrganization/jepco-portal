using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginAlbumDetailRepositoryConstants
    {


        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.Title;
        public const string AlbumID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.AlbumID;
        public const string CoverImage = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.CoverImage;
        public const string ItemOredr = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.ItemOredr;
        public const string ItemLink = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.ItemLink;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.LanguageID;
        public const string IsPublish = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.IsPublish;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.PublishDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.EditUser;
        public const string OpenIn = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.OpenIn;
        public const string TypeID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumDetailEntityConstants.TypeID;

        public const string SP_Insert = "Plugin_AlbumDetail_Insert";
        public const string SP_Update = "Plugin_AlbumDetail_Update";
        public const string SP_Delete = "Plugin_AlbumDetail_Delete";
        public const string SP_SelectAll = "Plugin_AlbumDetail_SelectAll";
        public const string SP_SelectByID = "Plugin_AlbumDetail_SelectByID";
        public const string SP_SelectByTypeID = "Plugin_AlbumDetail_SelectByAlbumID";
        public const string SP_SelectAllByType = "Plugin_AlbumDetail_SelectAllByType";
    }
}
