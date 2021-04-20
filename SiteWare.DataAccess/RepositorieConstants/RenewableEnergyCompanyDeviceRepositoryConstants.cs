using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyCompanyDeviceRepositoryConstants
    {
        public const string RenewbleCompnyDevice = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.RenewbleCompnyDevice;
        public const string CompanyName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.CompanyName;
        public const string ModelNo = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.ModelNo;
        public const string DevicePower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.DevicePower;
        public const string CountryOfOrigin = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.CountryOfOrigin;
        public const string DeviceDocument = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.LanguageName;


        public const string Status = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.Status;
        public const string IsApproved = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.IsApproved;
        public const string CompanyID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.CompanyID;

        public const string DeviceDocument2 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument2;
        public const string DeviceDocument3 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument3;
        public const string DeviceDocument4 = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument4;

        public const string SP_SelectByID = "RenewableEnergyCompanyDevice_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyCompanyDevice_SelectAll";
        public const string SP_Insert = "RenewableEnergyCompanyDevice_Insert"; 
        public const string SP_DistinctCompanyName = "SelectCompanyDevicebyDistinctCompanyName";
        public const string SP_ByCompanyName = "SelectDeviceByComapnyName";


    }
}
