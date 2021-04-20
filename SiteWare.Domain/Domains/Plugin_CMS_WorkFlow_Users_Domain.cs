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
   public static class Plugin_CMS_WorkFlow_Users_Domain
    {
        public static ResultList<Plugin_CMS_WorkFlow_Users_Entity> GetAllNotAsyncIdentity()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                result = Plugin_CMS_WorkFlow_Users_Repository.SelectAllNotAsync();
            }
            catch
            {
            }
            return result;
        }
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Entity>> GetAllIdentity()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                result = await Plugin_CMS_WorkFlow_Users_Repository.SelectAll();
            }
            catch
            {
            }
            return result;
        }
        public static ResultList<Plugin_CMS_WorkFlow_Users_Entity> GetLookup_IdentityByIDNotAsync(int ID)
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                result = Plugin_CMS_WorkFlow_Users_Repository.SelectByIDNotAsync(ID);
            }
            catch
            {
            }
            return result;
        }

        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Entity>> GetLookup_IdentityByID(int ID)
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                result = await Plugin_CMS_WorkFlow_Users_Repository.SelectByID(ID);
            }
            catch
            {
            }
            return result;
        }


    }
}
