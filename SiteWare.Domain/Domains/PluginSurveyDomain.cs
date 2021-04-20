using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Domains
{
    public static class PluginSurveyDomain
    {
        public async static Task<ResultEntity<PluginSurveyEntity>> GetSurveyQuestionToDisplay(byte LanguageID)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.SelectToDisplay(LanguageID);

            return result;
        }
        public async static Task<ResultList<PluginSurveyEntity>> GetQuestionAll()
        {
            ResultList<PluginSurveyEntity> result = new ResultList<PluginSurveyEntity>();

            result = await PluginSurveyRepository.SelectAll();

            return result;
        }
        public static ResultList<PluginSurveyEntity> GetQuestionAllNotAsync()
        {
            ResultList<PluginSurveyEntity> result = new ResultList<PluginSurveyEntity>();

            result = PluginSurveyRepository.SelectAllNotAsync();

            return result;
        }
        
        public async static Task<ResultEntity<PluginSurveyEntity>> GetSurveyByQuestionID(int QuestionID)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.SelectByQuestionID(QuestionID);

            return result;
        }
        public async static Task<ResultEntity<PluginSurveyEntity>> GetSurveyByQuestionID(int QuestionID, byte lang)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.SelectByQuestionID(QuestionID, lang);

            return result;
        }

        public async static Task<ResultEntity<PluginSurveyEntity>> UpdateQuestion(PluginSurveyEntity entity)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginSurveyEntity>> UpdateQuestionByIsPublished(PluginSurveyEntity entity)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.UpdateByIsPublished(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginSurveyEntity>> UpdateQuestionByIsDeleted(PluginSurveyEntity entity)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<PluginSurveyEntity>> InsertQuestion(PluginSurveyEntity entity)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.InsertQuestion(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSurveyEntity>> DeleteQuestion(PluginSurveyEntity entity)
        {
            ResultEntity<PluginSurveyEntity> result = new ResultEntity<PluginSurveyEntity>();

            result = await PluginSurveyRepository.DeleteQuestion(entity);

            return result;
        }
    }
}
