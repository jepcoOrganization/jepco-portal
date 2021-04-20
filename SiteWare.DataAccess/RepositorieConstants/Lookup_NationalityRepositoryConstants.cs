using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Lookup_NationalityRepositoryConstants
    {
        public const string NationalityID = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.NationalityID;

        public const string Name = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.Name;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_NationalityEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_Nationality_SelectAll";
        public const string SP_SelectByID = "Lookup_Nationality_SelectByID";

    }
}
