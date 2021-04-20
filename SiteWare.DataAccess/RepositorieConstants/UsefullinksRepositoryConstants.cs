using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class UsefullinksRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.ID;
        public const string Type = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.Type;
        public const string Tilte = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.Tilte;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.URL;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + UsefullinksEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Usefullinks_Insert";
        public const string SP_Update = "Plugin_Usefullinks_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_Usefullinks_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_Usefullinks_Delete";
        public const string SP_SelectAll = "Plugin_Usefullinks_SelectAll";
        public const string SP_SelectByID = "Plugin_Usefullinks_SelectByID";
        public const string SP_SelectByType = "Plugin_Usefullinks_SelectByType";
        
    }
}
