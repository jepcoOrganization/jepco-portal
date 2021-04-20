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
   public class Plugin_VotingDomain
    {
        public async static Task<ResultList<Plugin_VotingEntity>> GetAll()
        {
            ResultList<Plugin_VotingEntity> result = new ResultList<Plugin_VotingEntity>();

            result = await Plugin_VotingRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_VotingEntity> GetAllNotAsync()
        {
            ResultList<Plugin_VotingEntity> result = new ResultList<Plugin_VotingEntity>();

            result = Plugin_VotingRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_VotingEntity>> GetByID(long VotingID)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = await Plugin_VotingRepository.SelectByID(VotingID);

            return result;
        }
        public static ResultEntity<Plugin_VotingEntity> GetByIDNotAsync(long VotingID)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = Plugin_VotingRepository.SelectByIDNotAsync(VotingID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_VotingEntity>> Update(Plugin_VotingEntity entity)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = await Plugin_VotingRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_VotingEntity> UpdateNotAsync(Plugin_VotingEntity entity)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = Plugin_VotingRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_VotingEntity>> Delete(long VotingID)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = await Plugin_VotingRepository.Delete(VotingID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_VotingEntity>> Insert(Plugin_VotingEntity entity)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = await Plugin_VotingRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_VotingEntity> InsertNotAsync(Plugin_VotingEntity entity)
        {
            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            result = Plugin_VotingRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
