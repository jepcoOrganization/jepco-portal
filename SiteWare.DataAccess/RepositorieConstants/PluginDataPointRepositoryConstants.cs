using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PluginDataPointRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.ID;
        public const string FocusID = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.FocusID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Image;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Title;
        public const string Points = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Points;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Summary;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Target;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + PluginDataPointEntityConstants.LanguageName;
        
        public const string SP_Insert = "Plugin_DataPoint_Insert";
        public const string SP_Update = "Plugin_DataPoint_Update";
        public const string SP_Delete = "Plugin_DataPoint_Delete";
        public const string SP_SelectAll = "Plugin_DataPoint_SelectAll";
        public const string SP_SelectByID = "Plugin_DataPoint_SelectByID";
        public const string SP_UpdateByIsDeleted = "Plugin_DataPoint_UpdateByIsDeleted";
    }
}
