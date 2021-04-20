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
    public static class DirectNoteDomain
    {
        public async static Task<ResultList<DirectNoteEntity>> GetWelcomeNoteAll()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            result = await DirectNoteRepository.SelectAll();

            return result;
        }
        public static ResultList<DirectNoteEntity> GetWelcomeNoteAllNotAsync()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            result = DirectNoteRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultList<DirectNoteEntity>> GetWelcomeNoteTopOne()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            result = await DirectNoteRepository.SelectTopOne();

            return result;
        }
        public async static Task<ResultEntity<DirectNoteEntity>> GetWelcomeNoteByID(int ID)
        {
            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            result = await DirectNoteRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<DirectNoteEntity>> UpdateWelcomeNote(DirectNoteEntity entity)
        {
            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            result = await DirectNoteRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<DirectNoteEntity>> UpdateWelcomeNoteIsDeleted(DirectNoteEntity entity)
        {
            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            result = await DirectNoteRepository.UpdateByIsDeleted(entity);

            return result;
        }
        public async static Task<ResultEntity<DirectNoteEntity>> InsertWelcomeNote(DirectNoteEntity entity)
        {
            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            result = await DirectNoteRepository.InsertWelcomeNote(entity);

            return result;
        }
    }
}
