using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_SubmitCVRepositoryConstants
    {
        public const string SubmitCVID = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.SubmitCVID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.Name;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.Email;
        public const string PhoneNo = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.PhoneNo;
        public const string Interest = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.Interest;
        public const string AttachCV = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.AttachCV;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.LanguageID;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.Order;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.PublishedDate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.EditUser;
        
       
   
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_SubmitCVEntityConstants.LanguageName;


        public const string SelectAll = "Plugin_SubmitCV_SelectAll";
        public const string SelectById = "Plugin_SubmitCV_SelectByID";
        public const string Insert = "Plugin_SubmitCV_Insert";
        public const string Update = "Plugin_SubmitCV_Update";
        public const string Delete = "Plugin_SubmitCV_Delete";

    }
}
