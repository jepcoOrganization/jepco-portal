using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_AreaOneRepositoryConstants
    {
        public const string AreaOneID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.AreaOneID;
        public const string AreaOneName = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.AreaOneName;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_AreaOneEntityConstants.EditUser;

        public const string SelectALL = "Lookup_AreaOne_SelectAll";
        public const string SelectByID = "Lookup_AreaOne_SelectByID";
    }
}
