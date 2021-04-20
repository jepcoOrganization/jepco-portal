using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.Entity.Entities;
using SiteWare.Entity.Common.Entities;
using SiteWare.DataAccess.Repositories;

namespace SiteWare.Domain.Domains
{
    public static class Lookup_SurveyAnswerDomain
    {
        public static ResultList<Lookup_SurveyAnswerEntity> GetAllNotAsyncSurveyAnswer()
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();
            try
            {
                result = Lookup_SurveyAnswerRespository.SelectAllNotAsync();
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> GetLookup_SurveyAnswerByQuestionID(int ID)
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.SelectByQuestionId(ID);
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> GetAllSurveyAnswer()
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.SelectAll();
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> Insert(Lookup_SurveyAnswerEntity entity)
        {
            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.Insert(entity);
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> Update(Lookup_SurveyAnswerEntity entity)
        {
            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.Update(entity);
            }
            catch
            {
            }
            return result;
        }
        public static ResultList<Lookup_SurveyAnswerEntity> GetLookup_SurveyAnswerByQuestionIDNotAsync(int ID)
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();
            try
            {
                result= Lookup_SurveyAnswerRespository.SelectByQuestionIdNotAsync(ID);
            }
            catch
            {
            }
            return result;
        }

        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> GetLookup_SurveyAnswerByAnswerID(int ID)
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.SelectByAnswerId(ID);
            }
            catch
            {
            }
            return result;
        }

        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> UpdateNumberofVotes(Lookup_SurveyAnswerEntity entity)
        {
            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();
            try
            {
                result = await Lookup_SurveyAnswerRespository.UpdateNumberofVotes(entity);
            }
            catch
            {
            }

            return result;
        }
    }
}
