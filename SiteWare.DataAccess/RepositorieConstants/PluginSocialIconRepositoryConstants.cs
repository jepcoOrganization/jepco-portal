using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginSocialIconRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.Image;
        public const string Imageover = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.Imageover;
        public const string IconOrder = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.IconOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.LanguageID;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.Target;
        public const string ImageTitle = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.ImageTitle;
        public const string AltIamge = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.AltIamge;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginSocialIconEntityConstants.EditUser;


        public const string SP_Insert = "Plugin_SocialIcon_Insert";
        public const string SP_Update = "Plugin_SocialIcon_Update";
        public const string SP_Delete = "Plugin_SocialIcon_Delete";
        public const string SP_SelectAll = "Plugin_SocialIcon_SelectAll";
        public const string SP_SelectByID = "Plugin_SocialIcon_SelectByID"; 
       // public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
