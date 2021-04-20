using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_JobNameRepositoryConstants
    {
        public const string JobNameID = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.JobNameID;
        public const string JobName = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.JobName;

        public const string JobTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.JobTypeID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_JobNameEntityConstants.EditUser;

        public const string SelectALL = "Lookup_JobName_SelectAll";
        public const string SelectByID = "Lookup_JobName_SelectByID";

    }
}
