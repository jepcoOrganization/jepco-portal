using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_Focus_AreaRepositoryConstants
    {
        public const string FocusID = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.FocusID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Summary;
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Icon;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Image;
        public const string Color = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Color;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.LanguageID;
        public const string FocusOrder = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.FocusOrder;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.PublishedDate;
             
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_Focus_AreaEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Focus_Area_Insert";
        public const string SP_Update = "Plugin_Focus_Area_Update";
        public const string SP_Delete = "Plugin_Focus_Area_Delete";
        public const string SP_SelectAll = "Plugin_Focus_Area_SelectAll";
        public const string SP_SelectByID = "Plugin_Focus_Area_SelectByID";
    }
}
