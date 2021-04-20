using Siteware.DataAccess.Repositories;
using Siteware.Entity.Entities;
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
   public class Plugin_Project_Domain
    {
        public async static Task<ResultList<Plugin_ProjectEntities>> GetProjectAll()
        {
            ResultList<Plugin_ProjectEntities> result = new ResultList<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_ProjectEntities> GetProjectAllNotAsync()
        {
            ResultList<Plugin_ProjectEntities> result = new ResultList<Plugin_ProjectEntities>();

            result = Plugin_Project_Repository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_ProjectEntities>> GetProjectByID(long ID)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_ProjectEntities> GetProjectByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = Plugin_Project_Repository.SelectByIDNotAsync(ID);

            return result;
        }
     
       
        public async static Task<ResultEntity<Plugin_ProjectEntities>> UpdateProject(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_ProjectEntities> UpdateProjectNotAsync(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = Plugin_Project_Repository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Delete(long ID)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.Delete(ID);

            return result;
        }
  
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Insert(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_ProjectEntities> InsertNotAsync(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = Plugin_Project_Repository.InsertNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Update(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProjectEntities>> DeleteProject(Plugin_ProjectEntities entity)
        {
            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            result = await Plugin_Project_Repository.Delete(entity);

            return result;
        }
    }
}
