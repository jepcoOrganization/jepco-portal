using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_Core_ValueRepositoryConstants
    {
        public const string CoreID = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.CoreID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Summary;
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Icon;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Target;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Description;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.Order;
        public const string MappedCoreID1 = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.MappedCoreID1;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.IsDelete;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_Core_ValueEntityConstants.LanguageName;

        public const string SP_Insert = "Plugin_Core_Value_Insert";
        public const string SP_Update = "Plugin_Core_Value_Update";
        public const string SP_Delete = "Plugin_Core_Value_Delete";
        public const string SP_SelectAll = "Plugin_Core_Value_SelectAll";
        public const string SP_SelectByID = "Plugin_Core_Value_SelectByID";
    }
}
