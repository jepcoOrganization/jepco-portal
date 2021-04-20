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
    public static class Plugin_PreviuesExperianceDomain
    {
        public async static Task<ResultList<Plugin_PreviuesExperianceEntity>> GetAll()
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_PreviuesExperianceEntity> GetAllNotAsync()
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            result = Plugin_PreviuesExperianceRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> GetByID(long EmergencyID)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.SelectByID(EmergencyID);

            return result;
        }
        public static ResultEntity<Plugin_PreviuesExperianceEntity> GetByIDNotAsync(long EmergencyID)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = Plugin_PreviuesExperianceRepository.SelectByIDNotAsync(EmergencyID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Update(Plugin_PreviuesExperianceEntity entity)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_PreviuesExperianceEntity> UpdateNotAsync(Plugin_PreviuesExperianceEntity entity)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = Plugin_PreviuesExperianceRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Delete(long ID)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Insert(Plugin_PreviuesExperianceEntity entity)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_PreviuesExperianceEntity> InsertNotAsync(Plugin_PreviuesExperianceEntity entity)
        {
            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            result = Plugin_PreviuesExperianceRepository.InsertNotAsync(entity);

            return result;
        }


        public async static Task<ResultList<Plugin_PreviuesExperianceEntity>> GetByAdmissionID(long AdmissionID)
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            result = await Plugin_PreviuesExperianceRepository.SelectByAdmissionID(AdmissionID);

            return result;
        }
        public static ResultList<Plugin_PreviuesExperianceEntity> GetByAdmissionIDNotAsync(long AdmissionID)
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            result = Plugin_PreviuesExperianceRepository.SelectByAdmissionIDNotAsync(AdmissionID);

            return result;
        }
    }
}
