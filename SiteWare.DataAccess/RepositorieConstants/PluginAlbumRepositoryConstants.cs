using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginAlbumRepositoryConstants
    { 
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.Title;
        public const string TypeID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.TypeID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.Image;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.ViewCount;
        public const string ImageTitle = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.ImageTitle;
        public const string AltIamge = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.AltIamge;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.LanguageID;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.LanguageName;
        public const string AlbumOrder = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.AlbumOrder;
        public const string IsPublish = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.IsPublish;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.PublishDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginAlbumEntityConstants.EditUser; 

        public const string SP_Insert = "Plugin_Album_Insert";
        public const string SP_Update = "Plugin_Album_Update";
        public const string SP_Delete = "Plugin_Album_Delete";
        public const string SP_SelectAll = "Plugin_Album_SelectAll";
        public const string SP_SelectByID = "Plugin_Album_SelectByID";
        public const string SP_SelectByTypeID = "Plugin_Album_SelectByTypeID";
        public const string SP_UpdateViewCount = "Plugin_Album_UpdateViewCount";

    }
}
