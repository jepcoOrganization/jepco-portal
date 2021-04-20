using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class StatisticNoteRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.ID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.Link;
        public const string TargetID = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.TargetID;

        public const string Title = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.Summary;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.Description;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + StatisticNoteEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_StatisticNote_Insert";
        public const string SP_Update = "Plugin_StatisticNote_Update";
        public const string SP_UpdateIsDeleted = "Plugin_StatisticNote_UpdateIsDeleted";
        public const string SP_Delete = "Plugin_StatisticNote_Delete";
        public const string SP_SelectAll = "Plugin_StatisticNote_SelectAll";
        public const string SP_SelectByID = "Plugin_StatisticNote_SelectByID";
        public const string SP_SelectTopOne = "Plugin_StatisticNote_SelectTopOne";
    }
}
