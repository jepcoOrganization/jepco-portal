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
    public class Plugin_AboutCompanyDomain
    {
        public async static Task<ResultList<Plugin_AboutCompanyEntity>> GetAll()
        {
            ResultList<Plugin_AboutCompanyEntity> result = new ResultList<Plugin_AboutCompanyEntity>();

            result = await Plugin_AboutCompanyRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_AboutCompanyEntity> GetAllNotAsync()
        {
            ResultList<Plugin_AboutCompanyEntity> result = new ResultList<Plugin_AboutCompanyEntity>();

            result = Plugin_AboutCompanyRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> InsertRecord(Plugin_AboutCompanyEntity entity)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = await Plugin_AboutCompanyRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_AboutCompanyEntity> InsertRecordNotAsync(Plugin_AboutCompanyEntity entity)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = Plugin_AboutCompanyRepository.InsertNotAsync(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = await Plugin_AboutCompanyRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_AboutCompanyEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = Plugin_AboutCompanyRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public static ResultEntity<Plugin_AboutCompanyEntity> UpdateRecordNotAsync(Plugin_AboutCompanyEntity entity)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = Plugin_AboutCompanyRepository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> UpdateRecord(Plugin_AboutCompanyEntity entity)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = await Plugin_AboutCompanyRepository.Update(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            result = await Plugin_AboutCompanyRepository.Delete(ID);

            return result;
        }
    }
}
