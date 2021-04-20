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
   public static class Plugin_CMS_WorkFlow_Domain
    {
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Entity>> GetAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            result = await Plugin_CMS_WorkFlow_Repository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Entity> GetAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            result = Plugin_CMS_WorkFlow_Repository.SelectAllNotAsync();

            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Entity> GetAllRequestIDNotAsync(long RequestID)
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            result = Plugin_CMS_WorkFlow_Repository.SelectAllRequestIDNotAsync(RequestID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> GetByID(long ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = await Plugin_CMS_WorkFlow_Repository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = Plugin_CMS_WorkFlow_Repository.SelectByIDNotAsync(ID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Update(Plugin_CMS_WorkFlow_Entity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = await Plugin_CMS_WorkFlow_Repository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> UpdateNotAsync(Plugin_CMS_WorkFlow_Entity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = Plugin_CMS_WorkFlow_Repository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Delete(long ID)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = await Plugin_CMS_WorkFlow_Repository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Insert(Plugin_CMS_WorkFlow_Entity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = await Plugin_CMS_WorkFlow_Repository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> InsertNotAsync(Plugin_CMS_WorkFlow_Entity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            result = Plugin_CMS_WorkFlow_Repository.InsertNotAsync(entity);

            return result;
        }

    }
}
