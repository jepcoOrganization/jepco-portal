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
    public class SendNotificationDomain
    {
        public async static Task<ResultEntity<SendNotificationEntity>> InsertNotification(SendNotificationEntity entity)
        {
            ResultEntity<SendNotificationEntity> result = new ResultEntity<SendNotificationEntity>();

            result = await SendNotificationRepository.InsertNotification(entity);

            return result;
        }

        public async static Task<ResultList<SendNotificationEntity>> GetSendNotificationAll()
        {
            ResultList<SendNotificationEntity> result = new ResultList<SendNotificationEntity>();

            result = await SendNotificationRepository.SelectAll();

            return result;
        }
    }
}
