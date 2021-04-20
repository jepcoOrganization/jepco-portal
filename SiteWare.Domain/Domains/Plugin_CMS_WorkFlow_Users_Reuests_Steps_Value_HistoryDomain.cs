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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryDomain
    {        
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>();

            result = await Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepository.Insert(entity);

            return result;
        }

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity entity)
        {
            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>();

            result = Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepository.InsertNotAsync(entity);

            return result;
        }

    }
}
