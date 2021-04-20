using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class WelcomeNote_ImageRepositoryConstant
    {
        public const string ImageID = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.ImageID;
        public const string WelcomeNoteID = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.WelcomeNoteID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.Image;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.Target;
        public const string ImageOrder = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.ImageOrder;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.IsPublished;
        public const string Publisheddate = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.Publisheddate;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + WelcomeNote_ImageEntityConstants.EditUser;


        public const string SP_Insert = "Plugin_WelcomeNote_Image_Insert";
        public const string SP_Update = "Plugin_WelcomeNote_Image_Update";
        public const string SP_Delete = "Plugin_WelcomeNote_Image_UpdateIsDelete";
        public const string SP_SelectAll = "Plugin_WelcomeNote_Image_SelectAll";
        public const string SP_SelectByID = "Plugin_WelcomeNote_Image_SelectByID";
    }
}
