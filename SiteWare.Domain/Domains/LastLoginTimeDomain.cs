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
    public static class LastLoginTimeDomain
    {
        public async static Task<ResultEntity<LastLoginTimeEntity>> GetByServiceUserID(long ServiceUserID)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = await LastLoginTimeRepository.SelectByServiceUserID(ServiceUserID);

            return result;
        }
        public static ResultEntity<LastLoginTimeEntity> GetByServiceUserIDNotAsync(long ServiceUserID)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = LastLoginTimeRepository.SelectByServiceUserIDNotAsync(ServiceUserID);

            return result;
        }

        public async static Task<ResultEntity<LastLoginTimeEntity>> Update(LastLoginTimeEntity entity)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = await LastLoginTimeRepository.UpdateLastLogin(entity);

            return result;
        }
        public static ResultEntity<LastLoginTimeEntity> UpdateNotAsync(LastLoginTimeEntity entity)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = LastLoginTimeRepository.UpdateNotAsyncLastLogin(entity);

            return result;
        }


        public async static Task<ResultEntity<LastLoginTimeEntity>> Insert(LastLoginTimeEntity entity)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = await LastLoginTimeRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<LastLoginTimeEntity> InsertNotAsync(LastLoginTimeEntity entity)
        {
            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            result = LastLoginTimeRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
