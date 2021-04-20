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
    public static class SecondNavigationDomain
    {
        public async static Task<ResultList<SecondNavigationEntity>> GetNavigationAll()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            result = await SecondNavigationRepository.SelectAll();

            return result;
        }
        public static ResultList<SecondNavigationEntity> GetNavigationAllNotAsync()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            result = SecondNavigationRepository.SelectAllNotAsync();

            return result;
        }
        public static ResultList<SecondNavigationEntity> GetNavigationWebsiteAllNotAsync()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            result = SecondNavigationRepository.SelectAllToWebSiteNotAsync();

            return result;
        } 
        public async static Task<ResultEntity<SecondNavigationEntity>> GetNavigationByID(int ID)
        {
            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            result = await SecondNavigationRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<SecondNavigationEntity>> UpdateNavigation(SecondNavigationEntity entity)
        {
            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            result = await SecondNavigationRepository.Update(entity);

            return result;
        } 
        public async static Task<ResultEntity<SecondNavigationEntity>> InsertNavigation(SecondNavigationEntity entity)
        {
            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            result = await SecondNavigationRepository.InsertNavigation(entity);

            return result;
        }
        public async static Task<ResultEntity<SecondNavigationEntity>> DeleteByID(int ID)
        {
            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            result = await SecondNavigationRepository.Navigation_DeleteByID(ID);

            return result;
        }
    }
}
