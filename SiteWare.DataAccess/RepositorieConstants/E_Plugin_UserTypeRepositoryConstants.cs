using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class E_Plugin_UserTypeRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.Title;
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.Icon;
        public const string IconHover = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.IconHover;
        public const string ServiceTypeID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.ServiceTypeID;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + E_Plugin_UserTypeEntityConstants.LanguageName;


        public const string SP_Insert = "E_Plugin_UserType_Insert";
        public const string SP_Update = "E_Plugin_UserType_Update";
        public const string SP_Delete = "E_Plugin_UserType_Delete";
        public const string SP_SelectAll = "E_Plugin_UserType_SelectAll";
        public const string SP_SelectByID = "E_Plugin_UserType_SelectByID";
        public const string SP_SelectByEServiceID = "E_Plugin_UserType_SelectByServiceTypeID";

    }
}
