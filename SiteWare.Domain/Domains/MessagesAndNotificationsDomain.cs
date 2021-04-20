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
    public class MessagesAndNotificationsDomain
    {

        public async static Task<ResultList<MessagesAndNotificationsEntity>> GetAll()
        {
            ResultList<MessagesAndNotificationsEntity> result = new ResultList<MessagesAndNotificationsEntity>();

            result = await MessagesAndNotificationsRepository.SelectAll();

            return result;
        }
        public static ResultList<MessagesAndNotificationsEntity> GetAllNotAsync()
        {
            ResultList<MessagesAndNotificationsEntity> result = new ResultList<MessagesAndNotificationsEntity>();

            result = MessagesAndNotificationsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> GetByID(long ID)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            result = await MessagesAndNotificationsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<MessagesAndNotificationsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            result = MessagesAndNotificationsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> InsertRecord(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            result = await MessagesAndNotificationsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<MessagesAndNotificationsEntity> InsertRecordNotAsync(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            result = MessagesAndNotificationsRepository.InsertNotAsync(entity);

            return result;
        }



        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> Delete(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = await MessagesAndNotificationsRepository.Delete(entity);
            return result;
        }

        public static ResultEntity<MessagesAndNotificationsEntity> DeleteNotAsync(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = MessagesAndNotificationsRepository.DeleteNotAsync(entity);
            return result;
        }


        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> UnRead(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = await MessagesAndNotificationsRepository.UnRead(entity);
            return result;
        }

        public static ResultEntity<MessagesAndNotificationsEntity> UnReadNotAsync(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = MessagesAndNotificationsRepository.UnReadNotAsync(entity);
            return result;
        }


        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> Read(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = await MessagesAndNotificationsRepository.Read(entity);
            return result;
        }

        public static ResultEntity<MessagesAndNotificationsEntity> ReadNotAsync(MessagesAndNotificationsEntity entity)
        {
            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();
            result = MessagesAndNotificationsRepository.ReadNotAsync(entity);
            return result;
        }
    }
}
