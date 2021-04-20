using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class BannerTypeRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.ID;
        public const string BannerName = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.BannerName; 
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + BannerTypeEntityConstants.EditUser;


        public const string BannerType_Insert = "BannerType_Insert";
        public const string BannerType_Update = "BannerType_Update";
        public const string BannerType_Delete = "BannerType_Delete";
        public const string BannerType_SelectAll = "BannerType_SelectAll";
        public const string BannerType_SelectByID = "BannerType_SelectByID";
    }
}
