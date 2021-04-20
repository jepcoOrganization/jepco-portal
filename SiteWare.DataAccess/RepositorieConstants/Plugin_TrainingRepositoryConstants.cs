using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_TrainingRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.ID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.LanguageID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.Image;
        public const string Details = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.Details;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.ViewCount;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.Summary;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.Order;
        public const string TrainingDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.TrainingDate;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_TrainingEntityConstants.EditUser;


        public const string Plugin_Training_Insert = "PluginTraining_Insert";
        public const string Plugin_Training_Update = "PluginTraining_Update";
        public const string Plugin_Training_Delete = "PluginTraining_Delete";
        public const string Plugin_Training_SelectAll = "PluginTraining_SelectAll";
        public const string Plugin_Training_SelectByID = "PluginTraining_SelectByID";
        public const string Plugin_Training_ViewCount = "Plugin_Training_UpdateViewCount";
    }
}
