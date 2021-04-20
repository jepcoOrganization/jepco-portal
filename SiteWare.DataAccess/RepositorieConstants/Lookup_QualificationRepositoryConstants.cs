using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_QualificationRepositoryConstants
    {
        public const string QualificationID = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.QualificationID;
        public const string QualificationName = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.QualificationName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_QualificationEntityConstants.EditUser;

        public const string SelectALL = "Lookup_Qualification_SelectAll";
        public const string SelectByID = "Lookup_Qualification_SelectByID";
    }
}
