using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class ContactUsFormRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.ID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.Name; 
        public const string Email = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.Email; 
        public const string Message = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.Message;
        public const string Contact = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.Contact;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.AddDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.IsDeleted;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + ContactUsFormEntityConstants.Title;


        public const string SP_Insert = "ContactUsForm_Insert";
        public const string SP_Update = "ContactUsForm_Update";
        public const string SP_Delete = "ContactUsForm_Delete";
        public const string SP_UpdateByIsDeleted = "Plugin_ContactUsForm_UpdateByIsDeleted";
        public const string SP_SelectAll = "ContactUsForm_SelectAll";
        public const string SP_SelectByID = "ContactUsForm_SelectByID";
    }
}
