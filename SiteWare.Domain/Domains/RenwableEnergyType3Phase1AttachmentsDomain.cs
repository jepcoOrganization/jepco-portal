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
    public class RenwableEnergyType3Phase1AttachmentsDomain
    {
        public async static Task<ResultList<RenwableEnergyType3Phase1AttachmentsEntity>> GetAll()
        {
            ResultList<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultList<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = await RenwableEnergyType3Phase1AttachmentsRepository.SelectAll();

            return result;
        }
        public static ResultList<RenwableEnergyType3Phase1AttachmentsEntity> GetAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultList<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = RenwableEnergyType3Phase1AttachmentsRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>> GetByID(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = await RenwableEnergyType3Phase1AttachmentsRepository.SelectByID(ID);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> GetByIDNotAsync(long ID)
        {
            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = RenwableEnergyType3Phase1AttachmentsRepository.SelectByIDNotAsync(ID);

            return result;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>> InsertRecord(RenwableEnergyType3Phase1AttachmentsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = await RenwableEnergyType3Phase1AttachmentsRepository.Insert(entity);

            return result;
        }
        public static ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> InsertRecordNotAsync(RenwableEnergyType3Phase1AttachmentsEntity entity)
        {
            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            result = RenwableEnergyType3Phase1AttachmentsRepository.InsertNotAsync(entity);

            return result;
        }
    }
}
