using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants  
{
    public class Plugin_ProviderDocumentationRepositoryConstant
    {
        public const string ProviderDocumentaionID = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.ProviderDocumentaionID;
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.ProviderID;
        public const string DocumentTypeID = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.DocumentTypeID;
        public const string DocumentType = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.DocumentType;
        public const string FileName = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.FileName;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.IsPublished;
        public const string IsApproved = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.IsApproved;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ProviderDocumentationEntityConstants.EditUser;


        public const string SP_Insert = "Plugin_ProviderDocumentation_Insert";
        public const string SP_Update = "Plugin_ProviderDocument_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_ProviderDocument_UpdateByIsDeleted";
        public const string ProviderDocumentation_SelectAll = "";
        public const string SP_SelectByProviderID ="Plugin_ProviderDocumentation_SelectByProviderID";
    }
}
