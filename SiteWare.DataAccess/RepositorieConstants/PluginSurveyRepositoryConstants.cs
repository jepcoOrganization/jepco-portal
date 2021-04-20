using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class PluginSurveyRepositoryConstants
    {
       public const string QuestionID = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.QuestionID;
       public const string Question = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.Question;
       public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.LanguageID;
       public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.AddDate;
       public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.AddUser;
       public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.EditDate;
       public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.EditUser;
       public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.IsDeleted;
       public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.IsPublished;
       public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.PublishDate;
       public const string ViewCount = CommonRepositoryConstants.PreSQLParameter + PluginSurveyEntityConstants.ViewCount;

        public const string SP_Insert = "Plugin_Survey_Insert";
        public const string SP_Update = "Plugin_Survey_Update";
        public const string SP_Update_IsPublished = "Plugin_Survey_Update_IsPublished";
        public const string SP_UpdateByIsDeleted = "Plugin_Survey_Update_IsDeleted";
        public const string SP_Delete = "Plugin_News_Delete";
        public const string SP_SelectAll = "Plugin_Survey_SelectAll";
        public const string SP_SelectAll_With_Pagination = "Plugin_News_SelectAll_With_Pagination";
        public const string SP_SelectByQuestionID = "Plugin_Survey_SelectByQuestionID";
        public const string SP_SelectByQuestionIDWithLanguage = "Plugin_News_SelectByNewsIDWithLanguage";
        public const string SP_SelectToDisplay = "Plugin_Survey_SelectToDisplay";
    }
}
