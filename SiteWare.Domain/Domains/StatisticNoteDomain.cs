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
    public static class StatisticNoteDomain
    {
        public async static Task<ResultList<StatisticNoteEntity>> GetWelcomeNoteAll()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            result = await StatisticNoteRepository.SelectAll();

            return result;
        }
        public static ResultList<StatisticNoteEntity> GetWelcomeNoteAllNotAsync()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            result = StatisticNoteRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<StatisticNoteEntity>> GetWelcomeNoteTopOne()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            result = await StatisticNoteRepository.SelectTopOne();

            return result;
        }
        public async static Task<ResultEntity<StatisticNoteEntity>> GetWelcomeNoteByID(int ID)
        {
            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            result = await StatisticNoteRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<StatisticNoteEntity>> UpdateWelcomeNote(StatisticNoteEntity entity)
        {
            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            result = await StatisticNoteRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<StatisticNoteEntity>> UpdateWelcomeNoteIsDeleted(StatisticNoteEntity entity)
        {
            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            result = await StatisticNoteRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<StatisticNoteEntity>> InsertWelcomeNote(StatisticNoteEntity entity)
        {
            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            result = await StatisticNoteRepository.InsertWelcomeNote(entity);

            return result;
        }
    }
}
