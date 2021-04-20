using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class DirectNoteRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.ID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.Link;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.TargetID;

        public const string Title = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.Summary;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.Description;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + DirectNoteEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_DirectNote_Insert";
        public const string SP_Update = "Plugin_DirectNote_Update";
        public const string SP_UpdateIsDeleted = "Plugin_DirectNote_UpdateIsDeleted";
        public const string SP_Delete = "Plugin_DirectNote_Delete";
        public const string SP_SelectAll = "Plugin_DirectNote_SelectAll";
        public const string SP_SelectByID = "Plugin_DirectNote_SelectByID";
        public const string SP_SelectTopOne = "Plugin_DirectNote_SelectTopOne";
    }
}
