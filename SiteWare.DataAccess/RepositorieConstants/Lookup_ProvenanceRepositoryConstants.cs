using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_ProvenanceRepositoryConstants
    {
        public const string ProvenanceID = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.ProvenanceID;
        public const string ProvenanceName = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.ProvenanceName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_ProvenanceEntityConstants.EditUser;

        public const string SelectALL = "Lookup_Provenance_SelectAll";
        public const string SelectByID = "Lookup_Provenance_SelectByID";

    }
}
