using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_UserComplainRepositoryConstants
    {
        public const string ComplainID = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ComplainID;
        public const string ComplainTitle = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ComplainTitle;
        public const string ComplainDetails = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ComplainDetails;
        public const string ComplainType = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ComplainType;

        public const string FirstName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.FirstName;
        public const string SecondName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.SecondName;
        public const string ThirdName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ThirdName;
        public const string FamilyName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.FamilyName;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Email;


        public const string DocumentType = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.DocumentType;
        public const string DocumentNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.DocumentNumber;
        public const string Nationality = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Nationality;
        public const string MobileNo = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.MobileNo;
        public const string MeterNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.MeterNumber;
        public const string Governate = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Governate;
        public const string Area = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Area;
        public const string StreetName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.StreetName;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Latitude;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Longitude;


        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.LanguageName;

        public const string Area2 = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.Area2;
        public const string StreetID = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.StreetID;
        public const string IssueStatus = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.IssueStatus;
        public const string IssueResultNo = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.IssueResultNo;
        public const string LanguageIDAPI = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.LanguageIDAPI;


        public const string ServiceUserID = CommonRepositoryConstants.PreSQLParameter + Plugin_UserComplainEntityConstants.ServiceUserID;

        public const string SelectAll = "Plugin_Complain_SelectAll";
        public const string SelectByID = "Plugin_Complain_SelectByID";
        public const string Insert = "Plugin_Complain_Insert";
        public const string Update = "Plugin_Complain_Update";
        public const string Delete = "Plugin_Complain_Delete";
    }
}
