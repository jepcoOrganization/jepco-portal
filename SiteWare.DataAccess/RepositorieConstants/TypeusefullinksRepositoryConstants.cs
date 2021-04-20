using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class TypeusefullinksRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.ID;
        public const string Tilte = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.Tilte; 
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.LanguageID; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + TypeusefullinksEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_Typeusefullinks_Insert";
        public const string SP_Update = "Plugin_Typeusefullinks_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_Typeusefullinks_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_Typeusefullinks_Delete";
        public const string SP_SelectAll = "Plugin_Typeusefullinks_SelectAll";
        public const string SP_SelectByID = "Plugin_Typeusefullinks_SelectByID";
    }
}
