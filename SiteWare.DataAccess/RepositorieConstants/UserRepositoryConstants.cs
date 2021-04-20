using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class UserRepositoryConstants
    {
        public const string UserID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.UserID;
        public const string LoginID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.LoginID;
        public const string Password = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Password;
        public const string CountryID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.CountryID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Image;
        public const string FirstName = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.FirstName;
        public const string SecondName = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.SecondName;
        public const string LastName = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.LastName;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Email;
        public const string LastLoginDate = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.LastLoginDate;
        public const string BirthDate = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.BirthDate;
        public const string MaritalStatusID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.MaritalStatusID;
        public const string GenderID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.GenderID;
        public const string DepartmentID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.DepartmentID;
        public const string SectionID = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.SectionID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Title;
        public const string Telephone = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Telephone;
        public const string Ext = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Ext;
        public const string Mobile = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Mobile;
        public const string HireDate = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.HireDate;
        public const string Status = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Status;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.IsDeleted;
        public const string Address = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.Address;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + UsersEntityConstants.EditUser;

        public const string SP_Insert = "User_Insert";
        public const string SP_Update = "User_Update";
        public const string SP_Delete = "User_Delete";
        public const string SP_SelectAll = "User_SelectAll";
        public const string SP_SelectByUserID = "User_SelectByUserID";
        public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        public const string SP_UpdateByPassword = "User_UpdateByPassword";
        public const string SP_UpdateStatus = "Security_Users_UpdateStatus";

    }
}
