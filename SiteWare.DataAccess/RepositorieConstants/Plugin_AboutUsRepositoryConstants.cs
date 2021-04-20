using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_AboutUsRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Image;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.LanguageID;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Link;        
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Target;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.EditUser;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Summary;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.PublishedDate;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.Order;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutUsEntityConstants.LanguageName;

        public const string SP_Insert = "Plugin_AboutUsInsert";
        public const string SP_Update = "Plugin_AboutUS_Update";
        public const string SP_SelectAll = "Plugin_AboutUs_SelectAll";
        public const string SP_SelectByID = "Plugin_AboutUs_SelectByID";
        public const string SP_UpdateByIsDelete = "PluginAboutUs_UpdateByIsDelete";
    }
}
