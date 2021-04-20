using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_SecondSliderRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.ID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Image;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Title;
        public const string Brief = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Brief;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Target;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.LanguageID;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_SecondSliderEntityConstants.EditUser;


        public const string SP_Insert = "Plugin_SecondSlider_Insert";
        public const string SP_Update = "Plugin_SecondSlider_Update";
        public const string SP_Delete = "Plugin_SecondSliderDelete";
        public const string SP_SelectAll = "Plugin_SecondSlider_SelectAll";
        public const string SP_SelectByID = "Plugin_SecondSlider_SelectByID";
    }
}
