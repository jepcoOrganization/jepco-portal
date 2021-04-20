using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PluginAnnouncementRepositoryConstants
    {
        public const string AnnouncementID = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.AnnouncementID;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Image;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Title;
        public const string Author = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Author;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Target;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Summary;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Description;
        public const string AnnouncementDate = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.AnnouncementDate;
        public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.ViewCount;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.EditUser;
        public const string MapAnnouncementId1 = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.MapAnnouncementId1;
        public const string MapAnnouncementId2 = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.MapAnnouncementId2;
        public const string IsNotication= CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.IsNotication;
        public const string MediaType = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.MediaType;
        public const string VideoType = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.VideoType;
        public const string PageNumber = CommonRepositoryConstants.PreSQLParameter + "PageNumber";
        public const string PageSize = CommonRepositoryConstants.PreSQLParameter + "PageSize";
       
        //public const string AnnouncementDateStr = CommonRepositoryConstants.PreSQLParameter + PluginAnnouncementEntityConstants.AnnouncementDate;


        public const string SP_Insert = "Plugin_Announcement_Insert";
        public const string SP_Update = "Plugin_Announcement_Update";
        public const string SP_Delete = "Plugin_Announcement_Delete";
        public const string SP_SelectAll = "Plugin_Announcement_SelectAll";
        public const string SP_SelectByAnnouncementID = "Plugin_Announcement_SelectByAnnouncementID";
        public const string SP_SelectByAnnouncementIDWithLanguage = "Plugin_Announcement_SelectByAnnouncementIDWithLanguage";
        public const string SP_UpdateByIsDeleted = "Plugin_Announcement_UpdateByIsDeleted";
        public const string SP_SelectTopThree = "Plugin_Announcement_SelectTopThree";
        public const string SP_SelectAll_With_Pagination = "Plugin_Announcement_SelectAll_With_Pagination";
        public const string SP_Search_Announcement_SelectByKeyword = "Search_Announcement_SelectByKeyword";
        public const string SP_Search_AllAnnouncement_SelectByKeyword = "Search_Announcement_SelectByKeyword_WithoutPage";
        public const string SP_UpdateByViewCount = "Plugin_Announcement_UpdateViewCount";
    }
}
