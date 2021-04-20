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
    public static class MobileRegistationDomain
    {
        public async static Task<ResultEntity<MobileRegistationEntity>> GetByID(long ServiceUserID)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = await MobileRegistationRepository.SelectByServiceUserID(ServiceUserID);

            return result;
        }
        public static ResultEntity<MobileRegistationEntity> GetByIDNotAsync(long ServiceUserID)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = MobileRegistationRepository.SelectByServiceUserIDNotAsync(ServiceUserID);

            return result;
        }


        public async static Task<ResultEntity<MobileRegistationEntity>> Update(MobileRegistationEntity entity)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = await MobileRegistationRepository.Update(entity);

            return result;
        }
        public static ResultEntity<MobileRegistationEntity> UpdateNotAsync(MobileRegistationEntity entity)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = MobileRegistationRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<MobileRegistationEntity>> Insert(MobileRegistationEntity entity)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = await MobileRegistationRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<MobileRegistationEntity> InsertNotAsync(MobileRegistationEntity entity)
        {
            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            result = MobileRegistationRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultList<MobileRegistationEntity>> GetAll()
        {
            ResultList<MobileRegistationEntity> result = new ResultList<MobileRegistationEntity>();

            result = await MobileRegistationRepository.SelectAll();

            return result;
        }
        public static ResultList<MobileRegistationEntity> GetAllNotAsync()
        {
            ResultList<MobileRegistationEntity> result = new ResultList<MobileRegistationEntity>();

            result = MobileRegistationRepository.SelectAllNotAsync();

            return result;
        }

    }
}
