using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_Video_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.Title;
        public const string CoverImage = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.CoverImage;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.Link;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.Order;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.IsPublished;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.PublishDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_Video_EntityConstants.LanguageName;



        public const string SP_Insert = "Plugin_Video_Insert";
        public const string SP_Update = "Plugin_Video_Update";
        public const string SP_Delete = "Plugin_Video_Delete";
        public const string SP_SelectAll = "Plugin_Video_SelectAll";
        public const string SP_SelectByID = "Plugin_Video_SelectByID";

    }
}
