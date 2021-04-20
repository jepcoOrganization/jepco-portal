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
    public class Plugin_NOtificationDomain
    {
        public async static Task<ResultList<Plugin_NotificationEntity>> GetAll()
        {
            ResultList<Plugin_NotificationEntity> result = new ResultList<Plugin_NotificationEntity>();

            result = await Plugin_NotificationRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_NotificationEntity> GetAllNotAsync()
        {
            ResultList<Plugin_NotificationEntity> result = new ResultList<Plugin_NotificationEntity>();

            result = Plugin_NotificationRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_NotificationEntity>> GetByID(long NotificationID)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = await Plugin_NotificationRepository.SelectByID(NotificationID);

            return result;
        }
        public static ResultEntity<Plugin_NotificationEntity> GetByIDNotAsync(long NotificationID)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = Plugin_NotificationRepository.SelectByIDNotAsync(NotificationID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_NotificationEntity>> Update(Plugin_NotificationEntity entity)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = await Plugin_NotificationRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_NotificationEntity> UpdateNotAsync(Plugin_NotificationEntity entity)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = Plugin_NotificationRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_NotificationEntity>> Delete(long NotificationID)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = await Plugin_NotificationRepository.Delete(NotificationID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_NotificationEntity>> Insert(Plugin_NotificationEntity entity)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = await Plugin_NotificationRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_NotificationEntity> InsertNotAsync(Plugin_NotificationEntity entity)
        {
            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            result = Plugin_NotificationRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
