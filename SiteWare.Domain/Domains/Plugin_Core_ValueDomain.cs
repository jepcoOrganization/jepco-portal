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
    public class Plugin_Core_ValueDomain
    {
        public async static Task<ResultList<Plugin_Core_ValueEntity>> GetAll()
        {
            ResultList<Plugin_Core_ValueEntity> result = new ResultList<Plugin_Core_ValueEntity>();

            result = await Plugin_Core_ValueRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_Core_ValueEntity> GetAllNotAsync()
        {
            ResultList<Plugin_Core_ValueEntity> result = new ResultList<Plugin_Core_ValueEntity>();

            result = Plugin_Core_ValueRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> InsertRecord(Plugin_Core_ValueEntity entity)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = await Plugin_Core_ValueRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_Core_ValueEntity> InsertRecordNotAsync(Plugin_Core_ValueEntity entity)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = Plugin_Core_ValueRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = await Plugin_Core_ValueRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_Core_ValueEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = Plugin_Core_ValueRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public static ResultEntity<Plugin_Core_ValueEntity> UpdateRecordNotAsync(Plugin_Core_ValueEntity entity)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = Plugin_Core_ValueRepository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> UpdateRecord(Plugin_Core_ValueEntity entity)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = await Plugin_Core_ValueRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            result = await Plugin_Core_ValueRepository.Delete(ID);

            return result;
        }
    }
}
