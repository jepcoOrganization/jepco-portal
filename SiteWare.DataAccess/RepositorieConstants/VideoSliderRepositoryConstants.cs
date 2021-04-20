using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class VideoSliderRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.ID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.Title;
        public const string VideoID = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.VideoID;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + VideoSliderEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_VideoSlider_Insert";
        public const string SP_Update = "Plugin_VideoSlider_Update";
        public const string SP_UpdateByIsDeleted = "Plugin_VideoSlider_UpdateByIsDeleted";
        public const string SP_Delete = "Plugin_VideoSlider_Delete";
        public const string SP_SelectAll = "Plugin_VideoSlider_SelectAll";
        public const string SP_SelectByID = "Plugin_VideoSlider_SelectByID";
    }
}
