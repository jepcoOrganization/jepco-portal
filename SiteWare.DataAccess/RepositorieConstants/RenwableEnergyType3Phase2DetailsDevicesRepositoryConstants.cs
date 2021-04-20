using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.ID;
        public const string DetailsID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DetailsID;
        public const string DeviceID = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceID;
        public const string DeviceName = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceName;
        public const string DevicePower = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DevicePower;
        public const string DeviceDocument = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceDocument;
        public const string NumberofUnits = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.NumberofUnits;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + RenwableEnergyType3Phase2DetailsDevicesEntityConstants.EditUser;

        public const string SP_SelectByID = "RenwableEnergyType3Phase2DetailsDevices_SelectByID";
        public const string SP_SelectAll = "RenwableEnergyType3Phase2DetailsDevices_SelectAll";
        public const string SP_Insert = "RenwableEnergyType3Phase2DetailsDevices_Insert";


    }
}
