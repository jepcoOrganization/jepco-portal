using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginContactUsRepositoryConstants
    {
        

        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Title;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Description;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Image; 
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.LanguageID;
        public const string URL = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.URL; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.EditUser;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Target;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Order;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.PublishedDate;
        public const string Latitude = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Latitude;
        public const string Longitude = CommonRepositoryConstants.PreSQLParameter + PluginContactUsEntityConstants.Longitude;





        public const string SP_Insert = "Plugin_ContactUs_Insert";
        public const string SP_Update = "Plugin_ContactUs_Update";
        public const string SP_Delete = "Plugin_ContactUs_Delete";
        public const string SP_SelectAll = "Plugin_ContactUs_SelectAll";
        public const string SP_SelectByID = "Plugin_ContactUs_SelectByID";

       // public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
