using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class NavigationRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.ID;
        public const string MenuName = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.MenuName;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.URL;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.TargetID;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.ParentID;
        public const string MenuOrder = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.MenuOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.EditUser;
        public const string MenuTitle = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.MenuTitle;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.Summary;
        public const string MenuImage = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.MenuImage;
        public const string HoverImage = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.HoverImage;
        public const string Summary2 = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.Summary2;
         public const string ShowUser = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.ShowUser;
         public const string ShowCompany = CommonRepositoryConstants.PreSQLParameter + NavigationEntityConstants.ShowCompany;

        public const string SP_Insert = "CMS_Navigation_Insert";
        public const string SP_Update = "CMS_Navigation_Update";
        public const string SP_UpdateIsDeleted = "CMS_Navigation_UpdateByIsDeleted";
        public const string SP_UpdateParentID = "CMS_Navigation_UpdateParentID";
        public const string SP_Delete = "CMS_Navigation_Delete";
        public const string SP_SelectAll = "CMS_Navigation_SelectAll";
        public const string SP_SelectByRootMenu = "CMS_Navigation_SelectByRootMenu";
        public const string SP_SelectByID = "CMS_Navigation_SelectByID";
        public const string SP_SelectByUrl = "CMS_Navigation_SelectByUrl";
        public const string SP_SelectParentByID = "CMS_Navigation_SelectParentByID";

        public const string SP_SelectByParentMenuID = "CMS_Navigation_SelectByParentMenuID"; 
        
    }
}
