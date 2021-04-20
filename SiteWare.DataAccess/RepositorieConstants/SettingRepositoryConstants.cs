using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class SettingRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.ID;
        public const string Website = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Website;
        public const string Logo = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Logo;
        public const string GoogleAnalytic = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.GoogleAnalytic;
        public const string DateFormat = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.DateFormat;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Email;
        public const string PasswordEmail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.PasswordEmail;
        public const string SMTPServer = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.SMTPServer;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Longitude;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Latitude;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.LanguageID;
        public const string PageName = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.PageName;
        public const string CopyRights = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.CopyRights;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.EditUser;
        public const string PortNumber = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.PortNumber;
        public const string WorkingHours = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.WorkingHours;
        public const string FooterLogo = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.FooterLogo;
        public const string Year = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.Year;
        public const string IsEnableSSL = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.IsEnableSSL;
        public const string FromMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.FromMail;
        public const string MailContent = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.MailContent;
        public const string UserMailContent = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.UserMailContent;

        public const string RenewableDeviceUserMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableDeviceUserMail;
        public const string RenewableDeviceAdminMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableDeviceAdminMail;
        public const string RenewableSolarCellUserMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableSolarCellUserMail;
        public const string RenewableSolarCellAdminMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableSolarCellAdminMail;
        public const string RenewableRegistrationUserMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableRegistrationUserMail;
        public const string RenewableRegistrationAdminMail = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.RenewableRegistrationAdminMail;

        public const string ForgetPasswordAdmin = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.ForgetPasswordAdmin;
        public const string ForgetPasswordUser = CommonRepositoryConstants.PreSQLParameter + SettingEntityConstants.ForgetPasswordUser;


        public const string SP_Insert = "CMS_Setting_Insert";
        public const string SP_Update = "CMS_Setting_Update";
        public const string SP_UpdateByIsDeleted = "CMS_Setting_UpdateByIsDeleted";
        public const string SP_Delete = "CMS_Setting_Delete";
        public const string SP_SelectAll = "CMS_Setting_SelectAll";
        public const string SP_SelectByID = "CMS_Setting_SelectByID";
    }
}
