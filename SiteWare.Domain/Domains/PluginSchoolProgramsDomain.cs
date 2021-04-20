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
    public static class PluginSchoolProgramsDomain
    {

        public async static Task<ResultList<PluginSchoolProgramsEntity>> GetPluginSchoolProgramsAll()
        {
            ResultList<PluginSchoolProgramsEntity> result = new ResultList<PluginSchoolProgramsEntity>();

            result = await PluginSchoolProgramsRepository.SelectAll();

            return result;
        }


        public static ResultList<PluginSchoolProgramsEntity> GetPluginSchoolProgramsAllNotAsync()
        {
            ResultList<PluginSchoolProgramsEntity> result = new ResultList<PluginSchoolProgramsEntity>();

            result = PluginSchoolProgramsRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> GetPluginSchoolProgramsByID(long ID)
        {
            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            result = await PluginSchoolProgramsRepository.Plugin_SchoolProgramss_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> UpdatePluginSchoolPrograms(PluginSchoolProgramsEntity entity)
        {
            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            result = await PluginSchoolProgramsRepository.Plugin_SchoolProgramss_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> InsertPluginSchoolPrograms(PluginSchoolProgramsEntity entity)
        {
            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            result = await PluginSchoolProgramsRepository.Plugin_SchoolProgramss_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> SchoolProgramsType_Delete(int ID)
        {
            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            result = await PluginSchoolProgramsRepository.Plugin_SchoolProgramss_Delete(ID);

            return result;
        }
    }
}
