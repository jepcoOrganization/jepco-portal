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
    public static class Plugin_JobApplicationDomain
    {
        public async static Task<ResultList<Plugin_JobApplicationEntity>> GetAll()
        {
            ResultList<Plugin_JobApplicationEntity> result = new ResultList<Plugin_JobApplicationEntity>();

            result = await Plugin_JobApplicationRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_JobApplicationEntity> GetAllNotAsync()
        {
            ResultList<Plugin_JobApplicationEntity> result = new ResultList<Plugin_JobApplicationEntity>();

            result = Plugin_JobApplicationRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> GetByID(long EmergencyID)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = await Plugin_JobApplicationRepository.SelectByID(EmergencyID);

            return result;
        }
        public static ResultEntity<Plugin_JobApplicationEntity> GetByIDNotAsync(long EmergencyID)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = Plugin_JobApplicationRepository.SelectByIDNotAsync(EmergencyID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Update(Plugin_JobApplicationEntity entity)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = await Plugin_JobApplicationRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_JobApplicationEntity> UpdateNotAsync(Plugin_JobApplicationEntity entity)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = Plugin_JobApplicationRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = await Plugin_JobApplicationRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Insert(Plugin_JobApplicationEntity entity)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = await Plugin_JobApplicationRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_JobApplicationEntity> InsertNotAsync(Plugin_JobApplicationEntity entity)
        {
            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            result = Plugin_JobApplicationRepository.InsertNotAsync(entity);

            return result;
        }


      
    }
}
