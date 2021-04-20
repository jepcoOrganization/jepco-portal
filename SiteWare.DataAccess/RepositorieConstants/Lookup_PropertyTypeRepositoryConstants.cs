using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Lookup_PropertyTypeRepositoryConstants
    {
        public const string PropertyTypeID = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.PropertyTypeID;
       
        public const string PropertyType = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.PropertyType;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_PropertyTypeEntityConstants.EditUser;

        public const string SP_SelectAll = "Lookup_PropertyType_SelectAll";
    }
}
