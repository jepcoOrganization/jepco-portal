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
    public static class Plugin_QualificationDomain
    {
        public async static Task<ResultList<Plugin_QualificationEntity>> GetAll()
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_QualificationEntity> GetAllNotAsync()
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            result = Plugin_QualificationRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_QualificationEntity>> GetByID(long EmergencyID)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.SelectByID(EmergencyID);

            return result;
        }
        public static ResultEntity<Plugin_QualificationEntity> GetByIDNotAsync(long EmergencyID)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = Plugin_QualificationRepository.SelectByIDNotAsync(EmergencyID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_QualificationEntity>> Update(Plugin_QualificationEntity entity)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_QualificationEntity> UpdateNotAsync(Plugin_QualificationEntity entity)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = Plugin_QualificationRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_QualificationEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_QualificationEntity>> Insert(Plugin_QualificationEntity entity)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_QualificationEntity> InsertNotAsync(Plugin_QualificationEntity entity)
        {
            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            result = Plugin_QualificationRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultList<Plugin_QualificationEntity>> GetByAdmissionID(long AdmissionID)
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            result = await Plugin_QualificationRepository.SelectByAdmissionID(AdmissionID);

            return result;
        }
        public static ResultList<Plugin_QualificationEntity> GetByAdmissionIDNotAsync(long AdmissionID)
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            result = Plugin_QualificationRepository.SelectByAdmissionIDNotAsync(AdmissionID);

            return result;
        }
    }
}
