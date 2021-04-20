using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class InnerLinkRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + InnerLinkEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Inner_Link_Insert";
        public const string SP_Update = "Plugin_Inner_Link_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_Inner_Link_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_Inner_Link_Delete";
        public const string SP_SelectAll = "Plugin_Inner_Link_SelectAll";
        public const string SP_SelectByID = "Plugin_Inner_Link_SelectByID";
    }
}
