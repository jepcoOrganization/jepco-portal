using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class NewSub_Lookup_NationalityRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.ID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.Name;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + NewSub_Lookup_NationalityEntityConstants.EditUser;

        public const string SelectALL = "NewSub_Lookup_Nationality_SelectAll";

    }
}
