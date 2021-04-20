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
    public static class Plugin_SubmitCVDomain
    {
        public async static Task<ResultList<Plugin_SubmitCVEntity>> GetAll()
        {
            ResultList<Plugin_SubmitCVEntity> result = new ResultList<Plugin_SubmitCVEntity>();

            result = await Plugin_SubmitCVRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_SubmitCVEntity> GetAllNotAsync()
        {
            ResultList<Plugin_SubmitCVEntity> result = new ResultList<Plugin_SubmitCVEntity>();

            result = Plugin_SubmitCVRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> GetByID(int SubmitCVID)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = await Plugin_SubmitCVRepository.SelectByID(SubmitCVID);

            return result;
        }
        public static ResultEntity<Plugin_SubmitCVEntity> GetByIDNotAsync(int SubmitCVID)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = Plugin_SubmitCVRepository.SelectByIDNotAsync(SubmitCVID);

            return result;
        }


        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Update(Plugin_SubmitCVEntity entity)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = await Plugin_SubmitCVRepository.Update(entity);

            return result;
        }
        public static ResultEntity<Plugin_SubmitCVEntity> UpdateNotAsync(Plugin_SubmitCVEntity entity)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = Plugin_SubmitCVRepository.UpdateNotAsync(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Delete(int SubmitCVID)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = await Plugin_SubmitCVRepository.Delete(SubmitCVID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Insert(Plugin_SubmitCVEntity entity)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = await Plugin_SubmitCVRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_SubmitCVEntity> InsertNotAsync(Plugin_SubmitCVEntity entity)
        {
            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            result = Plugin_SubmitCVRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
