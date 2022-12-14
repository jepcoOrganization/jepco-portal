using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_Provider_CategoryRepositoryConstant
    {
        public const string CategoryID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.CategoryID;
        public const string CategoryName = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.CategoryName;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.Image;
        public const string Summury = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.Summury;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.Description;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.PublishedDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_CategoryEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Provider_Category_Insert";
        public const string SP_Update = "Plugin_Provider_Category_Update";
        public const string SP_Delete = "Plugin_Provider_Category_Delete";
        public const string SP_SelectAll = "Plugin_Provider_Category_SelectAll";
        public const string SP_SelectByID = "Plugin_Provider_Category_SelectByID";
    }
}
