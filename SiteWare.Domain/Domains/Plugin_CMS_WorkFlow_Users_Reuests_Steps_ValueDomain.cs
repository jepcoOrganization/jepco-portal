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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueDomain
    {
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> GetAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> GetAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.SelectAllNotAsync();

            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> GetAllByRequestIDNotAsync(long RequestID)
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.GetAllByRequestIDNotAsync(RequestID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Update(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.Update(entity);


            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> UpdateNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.UpdateNotAsync(entity);


            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> UpdateStatusNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.UpdateStatusNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Delete(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.Delete(ID);
            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> DeleteNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();
            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.DeleteNotAsync(ID);
            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> GetByID(int ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> GetByIDNotAsync(int ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
