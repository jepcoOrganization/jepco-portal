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
    public static class Plugin_PropertyDomain
    {
        public async static Task<ResultList<Plugin_PropertyEntity>> GetPropertyAll()
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.SelectAll();

            return result;
        }

        public static ResultList<Plugin_PropertyEntity> GetPropertyAllNotAsync()
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            result = Plugin_PropertyRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyEntity>> GetPropertyByID(long ID)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.Property_SelectByID(ID);

            return result;
        }

        public static ResultEntity<Plugin_PropertyEntity> GetPropertyByIDNotAsync(int ID)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = Plugin_PropertyRepository.Property_SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyEntity>> UpdateProperty(Plugin_PropertyEntity entity)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.Property_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyEntity>> InsertProperty(Plugin_PropertyEntity entity)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.Property_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyEntity>> DeleteProperty(long ID)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.Property_Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_PropertyEntity>> UpdatePropertyByIsDeleted(Plugin_PropertyEntity entity)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            result = await Plugin_PropertyRepository.UpdateByIsDeleted(entity);

            return result;
        }

        public static ResultList<Plugin_PropertyEntity> GetPropertyByFilter(VMSearchEntity entity)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            result = Plugin_PropertyRepository.GetFilterPropertyAll(entity);

            return result;
        }

        public static ResultList<Plugin_PropertyEntity> GetPropertyIDSList(string propertyids)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            result = Plugin_PropertyRepository.GetPropertyIDSList(propertyids);

            return result;
        }

        public static ResultList<Plugin_PropertyEntity> GetPropertyByCMSFilter(int GovernateID, int AreaID, int NumofBedrooms,string PropertyArea,int PropertyCost,int PropertyAge)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            result = Plugin_PropertyRepository.GetCMSFilterPropertyAll(GovernateID, AreaID,NumofBedrooms,PropertyArea,PropertyCost,PropertyAge);

            return result;
        }

    }
}
