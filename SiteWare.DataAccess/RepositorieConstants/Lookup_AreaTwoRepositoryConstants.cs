using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_AreaTwoRepositoryConstants
    {
        public const string AreaTwoID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.AreaTwoID;
        public const string AreaTwoName = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.AreaTwoName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaTwoEntityConstants.EditUser;

        public const string SelectALL = "Lookup_AreaTwo_SelectAll";
        public const string SelectByID = "Lookup_AreaTwo_SelectByID";
    }
}
