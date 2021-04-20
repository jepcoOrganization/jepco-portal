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
    public static class FooterNavigationDomain
    {
        public async static Task<ResultEntity<FooterNavigationEntity>> GetFooterByID(int ID)
        {
            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            result = await FooterNavigationRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<FooterNavigationEntity>> GetFooterAll()
        {
            ResultList<FooterNavigationEntity> result = new ResultList<FooterNavigationEntity>();

            result = await FooterNavigationRepository.SelectAll();

            return result;
        }
        public static ResultList<FooterNavigationEntity> GetFooterAllWithoutAsync()
        {
            ResultList<FooterNavigationEntity> result = new ResultList<FooterNavigationEntity>();

            result = FooterNavigationRepository.SelectAllWithoutAsync();

            return result;
        }
        public async static Task<ResultEntity<FooterNavigationEntity>> InsertFooter(FooterNavigationEntity entity)
        {
            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            result = await FooterNavigationRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<FooterNavigationEntity>> Update(FooterNavigationEntity entity)
        {
            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            result = await FooterNavigationRepository.Update(entity);

            return result;
        }
        public async static Task<ResultEntity<FooterNavigationEntity>> UpdateByIsDeleted(FooterNavigationEntity entity)
        {
            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            result = await FooterNavigationRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
