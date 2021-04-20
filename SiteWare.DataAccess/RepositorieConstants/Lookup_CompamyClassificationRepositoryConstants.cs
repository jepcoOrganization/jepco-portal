using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_CompamyClassificationRepositoryConstants
    {
        public const string CompanyClassificationID = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.CompanyClassificationID;
        public const string CompanyClassificationName = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.CompanyClassificationName;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_CompamyClassificationEntityConstants.EditUser;


        public const string SelectAll = "Lookup_CompamyClassification_SelectAll";
        public const string SelectByID = "Lookup_CompamyClassification_SelectByID";
        
    }
}
