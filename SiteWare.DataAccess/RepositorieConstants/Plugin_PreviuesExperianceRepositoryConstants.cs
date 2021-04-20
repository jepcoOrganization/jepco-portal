using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_PreviuesExperianceRepositoryConstants
    {
        public const string PreviuesExperianceID = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.PreviuesExperianceID;
        public const string JobApplicationID = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.JobApplicationID;
        public const string EntityName = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.EntityName;
        public const string ExperianceType = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.ExperianceType;
        public const string NumberOfYear = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.NumberOfYear;




        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PreviuesExperianceEntityConstants.EditUser;


        public const string SelectAll = "Plugin_PreviuesExperiance_SelectAll";
        public const string SelectByID = "Plugin_PreviuesExperiance_SelectByID";
        public const string SelectByAdmissionID = "Plugin_PreviuesExperiance_SelectByJobApplicationID";
        public const string Insert = "Plugin_PreviuesExperiance_Insert";
        public const string Update = "Plugin_PreviuesExperiance_Update";
        public const string Delete = "Plugin_PreviuesExperiance_Delete";
    }
}
