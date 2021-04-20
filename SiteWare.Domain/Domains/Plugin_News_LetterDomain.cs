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
    public static class Plugin_News_LetterDomain
    {
        public async static Task<ResultList<Plugin_News_LetterEntity>> GetPlugin_News_LetterAll()
        {
            ResultList<Plugin_News_LetterEntity> result = new ResultList<Plugin_News_LetterEntity>();

            result = await Plugin_News_LetterRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_News_LetterEntity> GetPlugin_News_LetterAllNotAsync()
        {
            ResultList<Plugin_News_LetterEntity> result = new ResultList<Plugin_News_LetterEntity>();

            result = Plugin_News_LetterRepository.SelectAllNotAsync();

            return result;
        }
        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> GetNewsTicerByPlugin_News_LetterID(int Plugin_News_LetterID)
        //{
        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    result = await Plugin_News_LetterRepository.SelectByPlugin_News_LetterID(Plugin_News_LetterID);

        //    return result;
        //}
        public async static Task<ResultEntity<Plugin_News_LetterEntity>> UpdatePlugin_News_Letter(Plugin_News_LetterEntity entity)
        {
            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            result = await Plugin_News_LetterRepository.Update(entity);

            return result;
        }
        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> UpdatePlugin_News_LetterByIsDeleted(Plugin_News_LetterEntity entity)
        //{
        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    result = await Plugin_News_LetterRepository.UpdateByIsDeleted(entity);

        //    return result;
        //}
        public async static Task<ResultEntity<Plugin_News_LetterEntity>> InsertPlugin_News_Letter(Plugin_News_LetterEntity entity)
        {
            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            result = await Plugin_News_LetterRepository.InsertPlugin_News_Letter(entity);

            return result;
        }

        public static ResultEntity<Plugin_News_LetterEntity> InsertPlugin_News_LetterNonasync(Plugin_News_LetterEntity entity)
        {
            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            result = Plugin_News_LetterRepository.InsertPlugin_News_LetterNonasync(entity);

            return result;
        }

        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> DeletePlugin_News_Letter(Plugin_News_LetterEntity entity)
        //{
        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    result = await Plugin_News_LetterRepository.DeletePlugin_News_Letter(entity);

        //    return result;
        //}
    }
}
