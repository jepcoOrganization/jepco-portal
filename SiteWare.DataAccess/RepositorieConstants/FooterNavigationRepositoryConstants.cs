using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class FooterNavigationRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.Title;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.URL;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.Target;
        public const string MenuOrder = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.MenuOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.LanguageID;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.ParentID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + FooterNavigationEntityConstants.EditUser;

        public const string SP_Insert = "CMS_Footer_Navigation_Insert";
        public const string SP_Update = "CMS_Footer_Navigation_Update";
        public const string SP_UpdateByIsDeleted = "CMS_Footer_Navigation_UpdateByIsDeleted";
        public const string SP_Delete = "CMS_Footer_Navigation_Delete";
        public const string SP_SelectAll = "CMS_Footer_Navigation_SelectAll";
        public const string SP_SelectByID = "CMS_Footer_Navigation_SelectByID";
    }
}
