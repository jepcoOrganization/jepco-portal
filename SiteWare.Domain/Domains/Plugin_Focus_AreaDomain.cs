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
    public class Plugin_Focus_AreaDomain
    {
        public async static Task<ResultList<Plugin_Focus_AreaEntity>> GetAll()
        {
            ResultList<Plugin_Focus_AreaEntity> result = new ResultList<Plugin_Focus_AreaEntity>();

            result = await Plugin_Focus_AreaRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_Focus_AreaEntity> GetAllNotAsync()
        {
            ResultList<Plugin_Focus_AreaEntity> result = new ResultList<Plugin_Focus_AreaEntity>();

            result = Plugin_Focus_AreaRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = await Plugin_Focus_AreaRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_Focus_AreaEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = Plugin_Focus_AreaRepository.SelectByIDNotAsync(ID);

            return result;
        }
     
        public static ResultEntity<Plugin_Focus_AreaEntity> UpdateRecordNotAsync(Plugin_Focus_AreaEntity entity)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = Plugin_Focus_AreaRepository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = await Plugin_Focus_AreaRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> InsertRecord(Plugin_Focus_AreaEntity entity)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = await Plugin_Focus_AreaRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_Focus_AreaEntity> InsertRecordNotAsync(Plugin_Focus_AreaEntity entity)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = Plugin_Focus_AreaRepository.InsertNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> UpdateRecord(Plugin_Focus_AreaEntity entity)
        {
            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            result = await Plugin_Focus_AreaRepository.Update(entity);

            return result;
        }        
    }
}
