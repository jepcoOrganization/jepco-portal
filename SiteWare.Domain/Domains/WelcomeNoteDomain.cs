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
    public static class WelcomeNoteDomain
    {
        public async static Task<ResultList<WelcomeNoteEntity>> GetWelcomeNoteAll()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.SelectAll();

            return result;
        }
        public static ResultList<WelcomeNoteEntity> GetWelcomeNoteAllNotAsync()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            result = WelcomeNoteRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<WelcomeNoteEntity>> GetWelcomeNoteTopOne()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.SelectTopOne();

            return result;
        }
        public async static Task<ResultEntity<WelcomeNoteEntity>> GetWelcomeNoteByID(int ID)
        {
            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<WelcomeNoteEntity>> UpdateWelcomeNote(WelcomeNoteEntity entity)
        {
            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<WelcomeNoteEntity>> UpdateWelcomeNoteIsDeleted(WelcomeNoteEntity entity)
        {
            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<WelcomeNoteEntity>> InsertWelcomeNote(WelcomeNoteEntity entity)
        {
            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            result = await WelcomeNoteRepository.InsertWelcomeNote(entity);

            return result;
        }
    }
}
