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
    public class Plugin_TrainingDomain
    {
        public async static Task<ResultList<Plugin_TrainingEntity>> GetPluginTrainingAll()
        {
            ResultList<Plugin_TrainingEntity> result = new ResultList<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_TrainingEntity> GetPluginTrainingAllNotAsync()
        {
            ResultList<Plugin_TrainingEntity> result = new ResultList<Plugin_TrainingEntity>();

            result = Plugin_TrainingRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_TrainingEntity>> GetPluginTrainingByID(long ID)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.Plugin_Tarining_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_TrainingEntity>> UpdateTraining(Plugin_TrainingEntity entity)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.Plugin_Training_Update(entity);

            return result;
        }

            public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Training_ViewCount(long ID)
             {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.Plugin_Training_ViewCount(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_TrainingEntity>> InsertPluginTraining(Plugin_TrainingEntity entity)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.Plugin_Training_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<Plugin_TrainingEntity>> PluginTraining_Delete(long ID)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            result = await Plugin_TrainingRepository.Plugin_Training_Delete(ID);

            return result;
        }
    }
}
