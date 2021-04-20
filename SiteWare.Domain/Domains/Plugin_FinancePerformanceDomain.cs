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
   public static class Plugin_FinancePerformanceDomain
    {
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> GetByID(int ID)
        {
            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            result = await Plugin_FinancePerformanceRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<Plugin_FinancePerformanceEntity>> GetAll()
        {
            ResultList<Plugin_FinancePerformanceEntity> result = new ResultList<Plugin_FinancePerformanceEntity>();

            result = await Plugin_FinancePerformanceRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_FinancePerformanceEntity> GetAllWithoutAsync()
        {
            ResultList<Plugin_FinancePerformanceEntity> result = new ResultList<Plugin_FinancePerformanceEntity>();

            result = Plugin_FinancePerformanceRepository.SelectAllWithoutAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> Insert(Plugin_FinancePerformanceEntity entity)
        {
            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            result = await Plugin_FinancePerformanceRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> Update(Plugin_FinancePerformanceEntity entity)
        {
            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            result = await Plugin_FinancePerformanceRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> UpdateByIsDeleted(Plugin_FinancePerformanceEntity entity)
        {
            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            result = await Plugin_FinancePerformanceRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
