using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_PropertyAlbumDetailRepositoryConstants
    {
        public const string AlbumDetailID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.AlbumDetailID;
        public const string AlbumID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.AlbumID;
        public const string PropertyID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.PropertyID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.Title;
        public const string ItemLink = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.ItemLink;
        public const string ItemOredr = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.ItemOredr;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.LanguageID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.Image;
        public const string IsPublish = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.IsPublish;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.PublishDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyAlbumDetailEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_PropertyAlbumDetail_Insert";
        public const string SP_Update = "Plugin_PropertyAlbumDetail_Update";
        public const string SP_Delete = "Plugin_PropertyAlbumDetail_Delete";
        public const string SP_SelectAll = "Plugin_PropertyAlbumDetail_SelectAll";
        public const string SP_SelectbyID = "Plugin_PropertyAlbumDetail_SelectByID";
        public const string SP_SelectbyAlbumID = "Plugin_PropertyAlbumDetail_SelectByAlbumID";
    }
}
