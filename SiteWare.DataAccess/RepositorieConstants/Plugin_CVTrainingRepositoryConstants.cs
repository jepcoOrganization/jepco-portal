using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_CVTrainingRepositoryConstants
    {
        public const string TrainingID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.TrainingID;
        public const string JobApplicationID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.JobApplicationID;
        public const string CourceType = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.CourceType;
        public const string CourceName = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.CourceName;
        public const string CourceDuration = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.CourceDuration;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CVTrainingEntityConstants.EditUser;


        public const string SelectAll = "Plugin_CVTraining_SelectAll";
        public const string SelectByID = "Plugin_CVTraining_SelectByID";
        public const string SelectByAdmissionID = "Plugin_CVTraining_SelectByJobApplicationID";
        public const string Insert = "Plugin_CVTraining_Insert";
        public const string Update = "Plugin_CVTraining_Update";
        public const string Delete = "Plugin_CVTraining_Delete";

    }
}
