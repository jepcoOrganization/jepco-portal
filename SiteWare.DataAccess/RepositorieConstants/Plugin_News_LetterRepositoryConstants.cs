using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class Plugin_News_LetterRepositoryConstants
    {
        public const string IdNewsLetter = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.IdNewsLetter;
        public const string EmailNewsLetter = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.EmailNewsLetter;
        public const string SubscribeNewsLetter = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.SubscribeNewsLetter;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_News_LetterEntityConstants.EditUser;

        public const string SP_Insert = "Plugin_News_Letter_Insert";
        public const string SP_Update = "Plugin_News_Letter_Update";
        //public const string SP_UpdateIsDeleted = "Plugin_NewsTicker_UpdateByIsDeleted";
        //public const string SP_Delete = "Plugin_NewsTicker_Delete";
        public const string SP_SelectAll = "Plugin_News_Letter_SelectAll";
        //public const string SP_SelectByNewsTickerID = "Plugin_NewsTicker_SelectByNewsTickerID";
    }
}
