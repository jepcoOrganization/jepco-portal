using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_JobApplicationRepositoryConstants
    {
        public const string JobApplicationID = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.JobApplicationID;
        public const string JobType = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.JobType;
        public const string JobName = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.JobName;
        public const string FirstName = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.FirstName;
        public const string SecondName = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.SecondName;
        public const string ThirdName = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.ThirdName;
        public const string LastName = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.LastName;
        public const string Nationalid = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.Nationalid;
        public const string BirthDate = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.BirthDate;
        public const string MaritalState = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.MaritalState;
        public const string NoofChild = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.NoofChild;
        public const string HaveLicence = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.HaveLicence;
        public const string LicenceType = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.LicenceType;
        public const string YearOfLicence = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.YearOfLicence;
        public const string Qualification = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.Qualification;



        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_JobApplicationEntityConstants.EditUser;


        public const string SelectAll = "Plugin_JobApplication_SelectAll";
        public const string SelectByID = "Plugin_JobApplication_SelectByID";        
        public const string Insert = "Plugin_JobApplication_Insert";
        public const string Update = "Plugin_JobApplication_Update";
        public const string Delete = "Plugin_JobApplication_Delete";


    }
}
