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
    public static class Plugin_CarrerDomain
    {
        public async static Task<ResultList<Plugin_CarrerEntity>> GetAll()
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.SelectAll();

            return result;
        }
        public async static Task<ResultList<Plugin_CarrerEntity>> GetByCarrer(int CatID)
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.SelectByCarrer(CatID);

            return result;
        }
        public static ResultList<Plugin_CarrerEntity> GetAllNotAsync()
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            result = Plugin_CarrerRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<Plugin_CarrerEntity>> GetPlugin_CarrerByID(int ID)
        {
            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_CarrerEntity>> UpdatePlugin_Carrer(Plugin_CarrerEntity entity)
        {
            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_CarrerEntity>> InsertPlugin_Carrer(Plugin_CarrerEntity entity)
        {
            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_CarrerEntity>> DeletePlugin_Carrer(int ID)
        {
            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            result = await Plugin_CarrerRepository.Delete(ID);

            return result;
        }
    }
}
