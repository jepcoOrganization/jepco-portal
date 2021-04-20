using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class Plugin_PropertyAlbumRepositoryConstants
    {
        public const string AlbumID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.AlbumID;
        public const string PropertyID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.PropertyID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.Image;
        public const string ImageTitle = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.ImageTitle;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.LanguageID;
        public const string IsPublish = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.IsPublish;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.PublishDate;
        public const string AlbumOrder = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.AlbumOrder;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_PropertyAlbum_Insert";
        public const string SP_Update = "Plugin_PropertyAlbum_Update";
        public const string SP_Delete = "Plugin_PropertyAlbum_Delete";
        public const string SP_SelectAll = "Plugin_PropertyAlbum_SelectAll";
        public const string SP_SelectbyID = "Plugin_PropertyAlbum_SelectByID";
        public const string SP_SelectbyPropertyID = "Plugin_PropertyAlbum_SelectByPropertyID";

    }
}
