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
   public class Plugin_Provider_DocumentationDomain
    {
        public async static Task<ResultList<Plugin_ProviderDocumentationEntity>> GetProviderDocumentAll()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            result = await Plugin_Provider_DocumentationRepository.SelectAll();

            return result;
        }
        public static ResultList<Plugin_ProviderDocumentationEntity> GetProviderAllNotAsync()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            result = Plugin_Provider_DocumentationRepository.SelectAllNotAsync();

            return result;
        }

        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> InsertProviderDocument(Plugin_ProviderDocumentationEntity entity)
        {
            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            result = await Plugin_Provider_DocumentationRepository.InsertProviderDocumentation(entity);

            return result;
        }
        public static ResultEntity<Plugin_ProviderDocumentationEntity> InsertProviderDocumentNotAsync(Plugin_ProviderDocumentationEntity entity)
        {
            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            result = Plugin_Provider_DocumentationRepository.InsertProviderDocumentationNotAsync(entity);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> UpdateProviderDocument(Plugin_ProviderDocumentationEntity entity)
        {
            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            result = await Plugin_Provider_DocumentationRepository.UpdateProviderDocument(entity);

            return result;
        }
        public static ResultEntity<Plugin_ProviderDocumentationEntity> UpdateProviderDocumentNotAsync(Plugin_ProviderDocumentationEntity entity)
        {
            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            result = Plugin_Provider_DocumentationRepository.UpdateProviderDocumentNotAsync(entity);

            return result;
        }
        public async static Task<ResultList<Plugin_ProviderDocumentationEntity>> GetDocumentsByProviderID(long ProviderID)
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            result = await Plugin_Provider_DocumentationRepository.SelectByProviderID(ProviderID);

            return result;
        }
        public static ResultList<Plugin_ProviderDocumentationEntity> GetDocumentsByProviderIDnon(long ProviderID)
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            result = Plugin_Provider_DocumentationRepository.SelectByProviderIDNonasync(ProviderID);

            return result;
        }
        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> UpdateDocumentByIsDeleted(Plugin_ProviderDocumentationEntity entity)
        {
            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            result = await Plugin_Provider_DocumentationRepository.ProviderDocumentUpdateByIsDeleted(entity);

            return result;
        }
    }
}
