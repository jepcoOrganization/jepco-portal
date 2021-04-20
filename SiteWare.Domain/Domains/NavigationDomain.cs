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
    public static class NavigationDomain
    {
        public async static Task<ResultList<NavigationEntity>> GetNavigationAll()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = await NavigationRepository.SelectAll();

            return result;
        }
        public static ResultList<NavigationEntity> GetNavigationAllNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = NavigationRepository.SelectAllNotAsync();

            return result;
        }
        public static ResultList<NavigationEntity> GetNavigationWebsiteAllNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = NavigationRepository.SelectAllToWebSiteNotAsync();

            return result;
        }

        public async static Task<ResultList<NavigationEntity>> GetNavigationByRootMenu()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = await NavigationRepository.SelectByRootMenu();

            return result;
        }

        public static ResultList<NavigationEntity> GetNavigationByRootMenuNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = NavigationRepository.SelectByRootMenuNotAsync();

            return result;
        }

        public async static Task<ResultEntity<NavigationEntity>> GetNavigationByID(int ID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<NavigationEntity> GetNavigationByIDNotAsync(int ID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = NavigationRepository.SelectByIDNotAsync(ID);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> GetParentNavigationByID(int ID, byte langID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.SelectParentMenuByID(ID, langID);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> GetNavigationByUrl(string Url, byte langID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.SelectByUrl(Url, langID);

            return result;
        }


        public static ResultEntity<NavigationEntity> GetNavigationByUrlnotAsync(string Url , byte langID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = NavigationRepository.SelectByUrlNotAsync(Url, langID);

            return result;
        }

        public async static Task<ResultList<NavigationEntity>> GetNavigationByParentMenuID(int ParentMenuID)
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = await NavigationRepository.SelectByParentMenuID(ParentMenuID);

            return result;
        }
        public  static ResultList<NavigationEntity> GetNavigationByParentMenuIDNotAsync(int ParentMenuID)
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result =  NavigationRepository.SelectByParentMenuIDNotAsync(ParentMenuID);

            return result;
        }
        public static ResultList<NavigationEntity> GetNavigationByParentMenuID_Website(int ParentMenuID)
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            result = NavigationRepository.SelectAllSubItemByParentID(ParentMenuID);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> UpdateNavigation(NavigationEntity entity)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> UpdateNavigationByIsDeleted(int ID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.UpdateByIsDeleted(ID);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> UpdateParentMenu(int ParentID, int ID)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.UpdateParentID(ParentID, ID);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> InsertNavigation(NavigationEntity entity)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.InsertNavigation(entity);

            return result;
        }
        public async static Task<ResultEntity<NavigationEntity>> DeleteNavigation(NavigationEntity entity)
        {
            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            result = await NavigationRepository.DeleteNavigation(entity);

            return result;
        }
    }
}
