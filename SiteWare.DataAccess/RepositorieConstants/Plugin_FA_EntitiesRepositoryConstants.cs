using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_FA_EntitiesRepositoryConstants
    {
        public const string FocusEntityId = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.FocusEntityId;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Title;
        public const string Summary = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Summary;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Image;
        public const string FocusID = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.FocusID;
        public const string Description = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Description;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Order;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.PublishedDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.IsPublished;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.IsDelete;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.EditUser;
        public const string MapEntity = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.MapEntity;
        public const string Address = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Address;
        public const string Telephone = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Telephone;
        public const string Fax = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Fax;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Email;
        public const string Website = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Website;
        public const string Title1 = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.Title1;
        public const string IsShowPage = CommonRepositoryConstants.PreSQLParameter + Plugin_FA_EntitiesEntityConstants.IsShowPage;


        public const string SP_Insert = "Plugin_FA_EntitiesInsert";
        public const string SP_Update = "Plugin_FA_Entities_Update";
        public const string SP_Delete = "Plugin_FA_Entities_Delete";
        public const string SP_SelectAll = "Plugin_FA_EntitiesSelectAll";
        public const string SP_SelectByID = "Plugin_FA_EntitiesSelectByID";
    }
}
