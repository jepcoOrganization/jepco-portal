using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_PriceRepositoryConstants
    {
        public const string PriceID = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.PriceID;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Title;
        public const string Title2 = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Title2;
        public const string Summery = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Summery;
        public const string Prices = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Prices;

        public const string Link = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Link;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Order;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.Target;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.LanguageID;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.IsDelete;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.PublishedDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_PriceEntityConstants.LanguageName;



        public const string SP_Insert = "Plugin_Price_Insert";
        public const string SP_Update = "Plugin_Price_Update";
        public const string SP_Delete = "Plugin_Price_Delete";
        public const string SP_SelectAll = "Plugin_Price_SelectAll";
        public const string SP_SelectByID = "Plugin_Price_SelectByID";


    }
}
