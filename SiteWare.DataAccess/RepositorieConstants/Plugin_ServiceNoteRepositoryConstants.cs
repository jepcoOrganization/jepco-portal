using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_ServiceNoteRepositoryConstants
    {
        public const string ServiceNoteID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.ServiceNoteID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Title;
        public const string Title2 = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Title2;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Summary;
        public const string ContactDetail = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.ContactDetail;        
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Link;        
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Target;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.Order;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.PublishedDate;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.IsDelete;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.EditUser;                
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceNoteEntityConstants.LanguageName;

        public const string SP_Insert = "Plugin_ServiceNoteInsert";
        public const string SP_Update = "Plugin_ServiceNote_Update";
        public const string SP_SelectAll = "Plugin_ServiceNote_SelectAll";
        public const string SP_SelectByID = "Plugin_ServiceNote_SelectByID";
        public const string SP_UpdateByIsDelete = "[Plugin_ServiceNote_UpdateByIsDelete]";
    }
}
