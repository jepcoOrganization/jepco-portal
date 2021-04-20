using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_JobTypeRepositoryConstants
    {
        public const string JobTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.JobTypeID;
        public const string JobTypeName = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.JobTypeName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_JobTypeEntityConstants.EditUser;

       
        public const string SelectALL = "Lookup_JobType_SelectAll";
        public const string SelectByID = "Lookup_JobType_SelectByID";


    }
}
