using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class User_Login_IntranetRepositoryConstant
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.ID;
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.ProviderID;
        public const string UserID = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.UserID;
        public const string Password = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.Password;
        public const string IsFirstLogin = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.IsFirstLogin;
        public const string IsMail = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.IsMail;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + User_Login_IntranetEntityConstants.EditUser;

        public const string User_Login_Insert = "User_Login_Insert";
        public const string User_Login_SelectAll = "User_Login_SelectAll";
        public const string User_Login_IsMailUpdate = "User_Login_UpdateIsMail";
        public const string User_Login_SelectByProviderID = "User_Login_SelectByProviderID";
        public const string User_Login_IsFirstLogin = "User_Login_IsFirsrLogUpdate";
        public const string User_Login_CheckValid = "User_Login_CheckValid";
        public const string User_Login_ResetPasswordUpdate = "User_Login_ResetPasswordUpdate";

        //public const string User_Login_Update = "BannerType_Update";
        //public const string User_Login_Delete = "BannerType_Delete";

    }
}
