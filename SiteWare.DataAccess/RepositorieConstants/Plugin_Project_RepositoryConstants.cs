using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using Siteware.Entity.Constants.Entity;
namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_Project_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.Summary;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.URL;
        public const string ImageUrl = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.ImageUrl;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.TargetID;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.EditUser;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + Plugin_Project_EntityConstants.ParentID;

        public const string SP_Insert = "Plugin_Project_Insert";
        public const string SP_Update = "Plugin_Project_Update";
        public const string SP_Delete = "Plugin_Project_UpdateByIsDelete";
        public const string SP_SelectAll = "Plugin_Project_SelectAll";
        public const string SP_SelectByID = "Plugin_Project_SelectAllByID";
    }
}
