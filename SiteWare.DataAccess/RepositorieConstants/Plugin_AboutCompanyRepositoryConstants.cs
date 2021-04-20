using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_AboutCompanyRepositoryConstants
    {
        public const string CompanyID = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.CompanyID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Title;
        public const string Title2 = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Title2;
        public const string Title3 = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Title3;
      
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Icon;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Target;
        public const string Summery = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Summery;
       
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.Order;
      
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.IsDelete;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_AboutCompanyEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_AboutCompany_Insert";
        public const string SP_Update = "Plugin_AboutCompany_Update";
        public const string SP_Delete = "Plugin_AboutCompany_Delete";
        public const string SP_SelectAll = "Plugin_AboutCompany_SelectAll";
        public const string SP_SelectByID = "Plugin_AboutCompany_SelectByID";
    }
}
