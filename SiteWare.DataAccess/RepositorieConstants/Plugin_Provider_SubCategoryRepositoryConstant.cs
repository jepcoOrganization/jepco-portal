using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_Provider_SubCategoryRepositoryConstant
    {
        public const string SubCategoryID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.SubCategoryID;
        public const string CategoryID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.CategoryID;
        public const string SubCatName = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.SubCatName;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.Image;
        public const string Summury = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.Summury;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.Description;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.PublishedDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Provider_SubCategoryEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Provider_SubCategory_Insert";
        public const string SP_Update = "Plugin_Provider_SubCategory_Update";
        public const string SP_Delete = "Plugin_Provider_SubCategory_DELETE";
        public const string SP_SelectAll = "Plugin_Provider_SubCategory_SelectAll";
        public const string SP_SelectByID = "Plugin_Provider_SubCategory_SelectByID";
    }
}
