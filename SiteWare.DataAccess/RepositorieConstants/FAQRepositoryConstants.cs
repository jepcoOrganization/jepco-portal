using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class FAQRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.ID; 
        public const string Question = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.Question;
        public const string Answer = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.Answer;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.LanguageID;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.Order;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + FAQEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_FAQ_Insert";
        public const string SP_Update = "Plugin_FAQ_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_FAQ_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_FAQ_Delete";
        public const string SP_SelectAll = "Plugin_FAQ_SelectAll";
        public const string SP_SelectByID = "Plugin_FAQ_SelectByID";
    }
}
