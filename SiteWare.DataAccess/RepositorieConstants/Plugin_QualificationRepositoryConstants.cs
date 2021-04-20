using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_QualificationRepositoryConstants
    {
        public const string QualificationID = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.QualificationID;
        public const string JobApplicationID = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.JobApplicationID;
        public const string UniName = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.UniName;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Name;
        public const string Year = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Year;
        public const string Major = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Major;
        public const string Major_Two = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Major_Two;
        public const string Major_From = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Major_From;
        public const string AVG = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.AVG;
        public const string OverAllEval = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.OverAllEval;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_QualificationEntityConstants.EditUser;


        public const string SelectAll = "Plugin_Qualification_SelectAll";
        public const string SelectByID = "Plugin_Qualification_SelectByID";
        public const string SelectByAdmissionID = "Plugin_Qualification_SelectByJobApplicationID";
        public const string Insert = "Plugin_Qualification_Insert";
        public const string Update = "Plugin_Qualification_Update";
        public const string Delete = "Plugin_Qualification_Delete";
    }
}
