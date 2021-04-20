using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_ServiceProviderRepositoryConstant
    {
        public const string ProviderID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.ProviderID;
        public const string CategoryID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.CategoryID;
        public const string SubCategoryID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.SubCategoryID;
        public const string Name = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Name;
        public const string Address1 = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Address1;
        public const string Address2 = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Address2;
        public const string MobileNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.MobileNumber;
        public const string GovernateID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.GovernateID;
        public const string RegionID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.RegionID;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Longitude;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Latitude;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Image;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.PublishedDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.EditUser;
        public const string Details = CommonRepositoryConstants.PreSQLParameter + Plugin_ServiceProviderEntityConstants.Details;

        public const string SP_Insert = "Plugin_ServiceProvider_Insert";
        public const string SP_Update = "Plugin_ServiceProvider_Update";
        public const string SP_Delete = "Plugin_ServiceProvider_Delete";
        public const string SP_SelectAll = "Plugin_ServiceProvider_SelectAll";
        public const string SP_SelectByID = "Plugin_ServiceProvider_SelectByID";
    }
}
