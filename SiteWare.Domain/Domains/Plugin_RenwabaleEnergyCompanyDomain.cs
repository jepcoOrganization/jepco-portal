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
    public class Plugin_RenwabaleEnergyCompanyDomain
    {
        public async static Task<ResultList<Plugin_RenwabaleEnergyCompanyEntity>> GetAll()
        {
            ResultList<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_RenwabaleEnergyCompanyEntity> GetAllNotAsync()
        {
            ResultList<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();

            result = Plugin_RenwabaleEnergyCompanyRepository.SelectAllNotAsync();

            return result;
        }


        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> GetByID(long ID)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = Plugin_RenwabaleEnergyCompanyRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> UpdateRecordNotAsync(Plugin_RenwabaleEnergyCompanyEntity entity)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = Plugin_RenwabaleEnergyCompanyRepository.UpdateNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> DeleteRecord(long ID)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.Delete(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> InsertRecord(Plugin_RenwabaleEnergyCompanyEntity entity)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> InsertRecordNotAsync(Plugin_RenwabaleEnergyCompanyEntity entity)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = Plugin_RenwabaleEnergyCompanyRepository.InsertNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> UpdateRecord(Plugin_RenwabaleEnergyCompanyEntity entity)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.Update(entity);

            return result;
        }


        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> GetByServiceUserID(long ServiceUserID)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = await Plugin_RenwabaleEnergyCompanyRepository.SelectByServiceUserID(ServiceUserID);

            return result;
        }
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> GetByServiceUserIDNotAsync(long ServiceUserID)
        {
            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            result = Plugin_RenwabaleEnergyCompanyRepository.SelectByServiceUserIDNotAsync(ServiceUserID);

            return result;
        }
    }
}
