using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class SecondNavigationRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.ID;
        public const string MenuName = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.MenuName;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.URL;
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.Icon;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.TargetID; 
        public const string MenuOrder = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.MenuOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.EditUser;
        public const string MenuType = CommonRepositoryConstants.PreSQLParameter + SecondNavigationEntityConstants.MenuType;
        

        public const string SP_Insert = "CMS_Second_Navigation_Insert";
        public const string SP_Update = "CMS_Second_Navigation_Update";
        public const string SP_Delete = "CMS_Second_Navigation_Delete";
        public const string SP_SelectAll = "CMS_Second_Navigation_SelectAll";
        public const string SP_SelectByID = "CMS_Second_Navigation_SelectByID"; 
        
    }
}
