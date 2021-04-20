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
    public static class Plugin_CVContactDomain
    {
        public async static Task<ResultList<Plugin_CVContactEntity>> GetAll()
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_CVContactEntity> GetAllNotAsync()
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            result = Plugin_CVContactRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVContactEntity>> GetByID(long EmergencyID)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.SelectByID(EmergencyID);

            return result;
        }
        public static ResultEntity<Plugin_CVContactEntity> GetByIDNotAsync(long EmergencyID)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = Plugin_CVContactRepository.SelectByIDNotAsync(EmergencyID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVContactEntity>> Update(Plugin_CVContactEntity entity)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_CVContactEntity> UpdateNotAsync(Plugin_CVContactEntity entity)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = Plugin_CVContactRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CVContactEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CVContactEntity>> Insert(Plugin_CVContactEntity entity)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_CVContactEntity> InsertNotAsync(Plugin_CVContactEntity entity)
        {
            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            result = Plugin_CVContactRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultList<Plugin_CVContactEntity>> GetByAdmissionID(long AdmissionID)
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            result = await Plugin_CVContactRepository.SelectByAdmissionID(AdmissionID);

            return result;
        }
        public static ResultList<Plugin_CVContactEntity> GetByAdmissionIDNotAsync(long AdmissionID)
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            result = Plugin_CVContactRepository.SelectByAdmissionIDNotAsync(AdmissionID);

            return result;
        }
    }
}
