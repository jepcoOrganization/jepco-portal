using SiteWare.DataAccess.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class Lookup_SurveyAnswerRepositoryConstant
    {
        public const string AnswerID = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.AnswerID;
        public const string QuestionID = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.QuestionID;
        public const string OptionName = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.OptionName;
        public const string NumberOfVotes = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.NumberOfVotes;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.LanguageID;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Lookup_SurveyAnswerConstants.EditUser;

        public const string SP_Insert = "Lookup_SurvayAnswer_Insert";
        public const string SP_Update = "Lookup_SurvayAnswer_Update";
        //public const string SP_Delete = "Lookup_SurvayAnswer_Delete";
        public const string SP_SelectAll = "Lookup_SurvayAnswer_SelectAll";
        public const string SP_SelectByID = "Lookup_SurvayAnswer_SelectByQuestionID";
        public const string SP_SelecByAnswerID = "Lookup_SurveyAnswerByAnswerID";
        public const string SP_UpdateNumberofvotes = "Lookup_SurvayAnswer_UpdateNumberofvotes";
    }
}
