using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class MenuFooterRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.Title;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.URL;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.Target;
        
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + MenuFooterEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_MenuFooter_Insert";
        public const string SP_Update = "Plugin_MenuFooter_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_MenuFooter_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_MenuFooter_Delete";
        public const string SP_SelectAll = "Plugin_MenuFooter_SelectAll";
        public const string SP_SelectByID = "Plugin_MenuFooter_SelectByID";
    }
}
