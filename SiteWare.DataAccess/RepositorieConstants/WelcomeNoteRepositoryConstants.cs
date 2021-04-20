using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class WelcomeNoteRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Link;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.TargetID;

        public const string Title = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Summary;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Description;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.LanguageID;
        public const string ButtonText = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonText;
        public const string ButtonLink = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonLink;
        public const string ButtonTarget = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonTarget;
        public const string ButtonText1 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonText1;
        public const string ButtonLink1 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonLink1;
        public const string ButtonTarget1 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonTarget1;
        public const string ButtonText2 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonText2;
        public const string ButtonLink2 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonLink2;
        public const string ButtonTarget2 = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.ButtonTarget2;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.EditUser;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + WelcomeNoteEntityConstants.Order;

        public const string SP_Insert = "Plugin_WelcomeNote_Insert";
        public const string SP_Update = "Plugin_WelcomeNote_Update";
        public const string SP_UpdateIsDeleted = "Plugin_WelcomeNote_UpdateIsDeleted";
        public const string SP_Delete = "Plugin_WelcomeNote_Delete";
        public const string SP_SelectAll = "Plugin_WelcomeNote_SelectAll";
        public const string SP_SelectByID = "Plugin_WelcomeNote_SelectByID";
        public const string SP_SelectTopOne = "Plugin_WelcomeNote_SelectTopOne";
    }
}
