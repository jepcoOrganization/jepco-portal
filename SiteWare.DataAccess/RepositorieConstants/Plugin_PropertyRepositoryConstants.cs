using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_PropertyRepositoryConstants
    {
        public const string PropertyID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyID;
        public const string PropertyTitle = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyTitle;
        public const string PropertyTypeID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyTypeID;
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.ProviderID;
        public const string CountryID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.CountryID;
        public const string GovernateID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.GovernateID;
        public const string AreaID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.AreaID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.LanguageID;
        public const string PropertyType = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyType;
        public const string ProviderName = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.ProviderName;
        public const string CountryName = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.CountryName;
        public const string AreaName = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.AreaName;
        public const string GovernateName = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.GovernateName;
        public const string PropertyCost = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyCost;
        public const string PropertyAge = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyAge;
        public const string PropertyArea = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PropertyArea;
        public const string NoOfBedrooms = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.NoOfBedrooms;
        public const string NoOfBathrooms = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.NoOfBathrooms;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.Description;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.Longitude;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.Latitude;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.IsDeleted;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.Order;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.EditUser;
        public const string PhoneNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.PhoneNumber;
        public const string MobileNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_PropertyEntityConstants.MobileNumber;


        public const string Property_Insert = "Plugin_Poperty_Insert";
        public const string Property_Update = "Plugin_Property_Update";
        public const string Property_Delete = "Plugin_Property_Delete";
        public const string Property_SelectAll = "Plugin_Property_SelectAll";
        public const string Property_SelectByID = "Plugin_Property_SelectByID";
        public const string Property_UpdateByIsdeleted = "Plugin_Property_UpdateByIsDeleted";
        public const string Property_SearchFilter = "Plugin_Property_SearchFilter";
        public const string GetAll_PropertyIDS = "Plugin_ALLPropertyIDS";
        public const string GetAll_CMSPropertySearch = "Plugin_Property_CMSSearch";
        public const string GetAll_Property_SearchByFilter = "Plugin_Property_SearchByFilter";
        public const string GetAll_Property_SearchFilter = "Plugin_Property_SearchFilter";
    }
}
