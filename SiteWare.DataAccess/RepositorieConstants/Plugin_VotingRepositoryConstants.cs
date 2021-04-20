using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public static class Plugin_VotingRepositoryConstants
    {
        public const string VotingID = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.VotingID;
        public const string VotingResult = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.VotingResult;

        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.LanguageID;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.IsDeleted;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.IsPublished;
        public const string PublishedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.PublishedDate;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.EditUser;
        public const string LanguageName = CommonRepositoryConstants.PreSQLParameter + Plugin_VotingEntityConstants.LanguageName;



        public const string SP_Insert = "Plugin_Voting_Insert";
        public const string SP_Update = "Plugin_Voting_Update";
        public const string SP_Delete = "Plugin_Voting_Delete";
        public const string SP_SelectAll = "Plugin_Voting_SelectAll";
        public const string SP_SelectByID = "Plugin_Voting_SelectByID";

    }
}
