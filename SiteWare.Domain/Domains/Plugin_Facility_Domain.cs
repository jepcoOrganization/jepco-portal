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
namespace Siteware.Domain.Domains
{
   public class Plugin_Facility_Domain
    {
        public async static Task<ResultList<Plugin_Facility_Entity>> GetFacilityAll()
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_Facility_Entity> GetFacilityAllNotAsync()
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            result = Plugin_Facility_Repository.SelectAllNotAsync();

            return result;
        }
      
      
        public async static Task<ResultEntity<Plugin_Facility_Entity>> GetFacilityByID(long ID)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_Facility_Entity> GetFacilityByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = Plugin_Facility_Repository.SelectByIDNotAsync(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> GetParentFacilityByID(int ID, byte langID)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.SelectParentMenuByID(ID, langID);

            return result;
        }
       

        public async static Task<ResultList<Plugin_Facility_Entity>> GetFacilityByParentMenuID(long ParentMenuID)
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.SelectByParentMenuID(ParentMenuID);

            return result;
        }
        public static ResultList<Plugin_Facility_Entity> GetFacilityByParentIDNotAsync(long ParentMenuID)
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            result = Plugin_Facility_Repository.SelectByParentMenuIDNotAsync(ParentMenuID);

            return result;
        }
        public static ResultList<Plugin_Facility_Entity> GetFacilityByParentID_Website(int ParentMenuID)
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            result = Plugin_Facility_Repository.SelectAllSubItemByParentID(ParentMenuID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> UpdateFacility(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.Update(entity);

            return result;
        }
        public  static ResultEntity<Plugin_Facility_Entity> UpdateFacilityNotAsync(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result =  Plugin_Facility_Repository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Delete(long ID)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.Delete(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> DeleteByParentID(long ParentID)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.DeleteByParentID(ParentID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Insert(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.Insert(entity);

            return result;
        }
        public  static ResultEntity<Plugin_Facility_Entity> InsertNotAsync(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result =  Plugin_Facility_Repository.InsertNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Update(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Facility_Entity>> DeleteFacility(Plugin_Facility_Entity entity)
        {
            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            result = await Plugin_Facility_Repository.Delete(entity);

            return result;
        }
    }
}
