using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Lookup_CertificationType_RepositoryConstatnts
    {
        public const string CertificationTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.CertificationTypeID;
        public const string CertificationType = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.CertificationType;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.LanguageID;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CertificationTypeEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_CertificationType_SelectAll";

    }
}
