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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_StepsDomain
    {
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> GetAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> GetAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Update(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.Update(entity);


            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> UpdateNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.UpdateNotAsync(entity);


            return result;
        }


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Delete(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();
            result = await Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.Delete(ID);
            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> DeleteNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();
            result = Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.DeleteNotAsync(ID);
            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> GetByID(int ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> GetByIDNotAsync(int ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
