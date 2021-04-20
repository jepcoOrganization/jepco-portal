using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using Siteware.Entity.Constants.Entity;

namespace Siteware.DataAccess.RepositorieConstants
{
    public class Plugin_Facility_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.Summary;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.URL;
        public const string ImageUrl = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.ImageUrl;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.TargetID;
        public const string ParentID = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.ParentID;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Facility_EntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Facility_Insert";
        public const string SP_Update = "Plugin_Facility_Update";
        public const string SP_Delete = "Plugin_Facility_Delete";
        public const string SP_DeleteByParentID = "Plugin_Facility_DeleteByParentID";
        public const string SP_SelectAll = "Plugin_Facility_SelectAll";
        public const string SP_SelectByID = "Plugin_Facility_SelectAllByID";
        public const string SP_SelectParentByID = "Plugin_Facility_SelectAllByParentID";



    }
}
