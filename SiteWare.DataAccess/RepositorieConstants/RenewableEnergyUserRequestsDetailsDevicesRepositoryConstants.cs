using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.ID;
        public const string RenewableEnergyUserRequestsDetailsID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.RenewableEnergyUserRequestsDetailsID;
        public const string DeviceID = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceID;
        public const string DeviceName = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceName;
        public const string DevicePower = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DevicePower;
        public const string DeviceDocument = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceDocument;
        public const string NumberofUnits = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.NumberofUnits;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenewableEnergyUserRequestsDetailsDevicesEntityConstants.EditUser;

        public const string SP_SelectByID = "RenewableEnergyUserRequestsDetailsDevices_SelectByID";
        public const string SP_SelectAll = "RenewableEnergyUserRequestsDetailsDevices_SelectAll";
        public const string SP_Insert = "RenewableEnergyUserRequestsDetailsDevices_Insert";
        public const string SP_SelectByUserRequestsDetailID = "RenewableEnergyUserRequestsDetailsDevices_SelectByUserRequestsDetailsID";


    }
}
