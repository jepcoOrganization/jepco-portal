using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_ServiceUserRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.ID;
        public const string FirstName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.FirstName;
        public const string SecondName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.SecondName;
        public const string ThirdName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.ThirdName;
        public const string FamilyName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.FamilyName;
        public const string UserID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.UserID;
        public const string UserType = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.UserType;
        public const string IDType = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.IDType;
        public const string IDNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.IDNumber;
        public const string MobileNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.MobileNumber;
        public const string TelephoneNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.TelephoneNumber;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Email;
        public const string Password = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Password;
        public const string Country = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Country;
        public const string City = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.City;
        public const string Area1 = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Area1;
        public const string Area2 = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Area2;
        public const string Address = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Address;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Latitude;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Longitude;





        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.LanguageName;
        public const string NationalityID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceUserEntityConstants.NationalityID;

        public const string SP_Insert = "Plugin_ServiceUser_Insert";
        public const string SP_Update = "Plugin_ServiceUser_Update";
        public const string SP_Delete = "Plugin_ServiceUser_Delete";
        public const string SP_SelectAll = "Plugin_ServiceUser_SelectAll";
        public const string SP_SelectByID = "Plugin_ServiceUser_SelectByID";
        public const string SP_SelectByEmailAndPassword = "ServiceUserSelectByEmailandPassword";
    }
}
