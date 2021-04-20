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
    public static class WelcomeNote_ImageDomain
    {
        public async static Task<ResultList<WelcomeNote_ImageEntity>> GetAll(long NoteID)
        {
            ResultList<WelcomeNote_ImageEntity> result = new ResultList<WelcomeNote_ImageEntity>();

            result = await WelcomeNote_ImageRepository.SelectAll(NoteID);

            return result;
        }
        public static ResultList<WelcomeNote_ImageEntity> GetAllNotAsync(long NoteID)
        {
            ResultList<WelcomeNote_ImageEntity> result = new ResultList<WelcomeNote_ImageEntity>();

            result = WelcomeNote_ImageRepository.SelectAllNotAsync(NoteID);

            return result;
        }
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> GetByID(long ID)
        {
            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            result = await WelcomeNote_ImageRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> UpdateImage(WelcomeNote_ImageEntity entity)
        {
            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            result = await WelcomeNote_ImageRepository.UpdateImage(entity);

            return result;
        }

        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> InsertImage(WelcomeNote_ImageEntity entity)
        {
            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            result = await WelcomeNote_ImageRepository.InsertImage(entity);

            return result;
        }

        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> DeleteImage(long ID)
        {
            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            result = await WelcomeNote_ImageRepository.DeleteImage(ID);

            return result;
        }
    }
}
