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
    public static class Plugin_ServiceNoteDomain
    {

        public async static Task<ResultList<Plugin_ServiceNoteEntity>> GetAll()
        {
            ResultList<Plugin_ServiceNoteEntity> result = new ResultList<Plugin_ServiceNoteEntity>();

            result = await Plugin_ServiceNoteRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_ServiceNoteEntity> GetAllNotAsync()
        {
            ResultList<Plugin_ServiceNoteEntity> result = new ResultList<Plugin_ServiceNoteEntity>();

            result = Plugin_ServiceNoteRepository.SelectAllNotAsync();

            return result;
        } 
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> UpdateServiceNote(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            result = await Plugin_ServiceNoteRepository.Update(entity);

          
            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> UpdateByIsDeleted(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();
            result = await Plugin_ServiceNoteRepository.Plugin_ServiceNote_UpdateByIsDelete(entity);
            return result;
        }

        public  static ResultEntity<Plugin_ServiceNoteEntity> UpdateByIsDeletedNotAsync(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();
            result =  Plugin_ServiceNoteRepository.Plugin_ServiceNote_UpdateByIsDeleteNotAsync(entity);
            return result;
        }
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> GetByID(int ID)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            result = await Plugin_ServiceNoteRepository.ServiceNote_SelectByID(ID);

            return result;
        }

        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> InsertServiceNote(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            result = await Plugin_ServiceNoteRepository.Insert(entity);

            return result;
        }
    }
}
