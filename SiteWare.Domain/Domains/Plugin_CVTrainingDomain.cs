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
    public static class Plugin_CVTrainingDomain
    { 
        public async static Task<ResultList<Plugin_CVTrainingEntity>> GetAll()
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_CVTrainingEntity> GetAllNotAsync()
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            result = Plugin_CVTrainingRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> GetByID(long EmergencyID)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.SelectByID(EmergencyID);

            return result;
        }
        public static ResultEntity<Plugin_CVTrainingEntity> GetByIDNotAsync(long EmergencyID)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = Plugin_CVTrainingRepository.SelectByIDNotAsync(EmergencyID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Update(Plugin_CVTrainingEntity entity)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_CVTrainingEntity> UpdateNotAsync(Plugin_CVTrainingEntity entity)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = Plugin_CVTrainingRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Insert(Plugin_CVTrainingEntity entity)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_CVTrainingEntity> InsertNotAsync(Plugin_CVTrainingEntity entity)
        {
            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            result = Plugin_CVTrainingRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultList<Plugin_CVTrainingEntity>> GetByAdmissionID(long AdmissionID)
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            result = await Plugin_CVTrainingRepository.SelectByAdmissionID(AdmissionID);

            return result;
        }
        public static ResultList<Plugin_CVTrainingEntity> GetByAdmissionIDNotAsync(long AdmissionID)
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            result = Plugin_CVTrainingRepository.SelectByAdmissionIDNotAsync(AdmissionID);

            return result;
        }
    }
}
