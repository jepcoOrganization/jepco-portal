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
    public static class MenuFooterDomain
    {
        public async static Task<ResultEntity<MenuFooterEntity>> GetMenuFooterByID(int ID)
        {
            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            result = await MenuFooterRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<MenuFooterEntity>> GetMenuFooterAll()
        {
            ResultList<MenuFooterEntity> result = new ResultList<MenuFooterEntity>();

            result = await MenuFooterRepository.SelectAll();

            return result;
        }
        public static ResultList<MenuFooterEntity> GetMenuFooterAllWithoutAsync()
        {
            ResultList<MenuFooterEntity> result = new ResultList<MenuFooterEntity>();

            result = MenuFooterRepository.SelectAllWithoutAsync();

            return result;
        }
        public async static Task<ResultEntity<MenuFooterEntity>> InsertMenuFooter(MenuFooterEntity entity)
        {
            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            result = await MenuFooterRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<MenuFooterEntity>> Update(MenuFooterEntity entity)
        {
            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            result = await MenuFooterRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<MenuFooterEntity>> UpdateByIsDeleted(MenuFooterEntity entity)
        {
            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            result = await MenuFooterRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
