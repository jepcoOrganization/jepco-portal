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
    public static class SecurityUserPluginDomain
    {
        public async static Task<ResultEntity<SecurityUserPluginEntity>> InsertContact(SecurityUserPluginEntity entity)
        {
            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            result = await SecurityUserPluginRepository.Security_UserPlugin_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<SecurityUserPluginEntity>> DeleteContact(int UserID,int PluginID)
        {
            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            result = await SecurityUserPluginRepository.Security_UserPlugin_Delete(UserID, PluginID);

            return result;
        }

        public async static Task<ResultEntity<SecurityUserPluginEntity>> DeleteAll(int UserID)
        {
            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            result = await SecurityUserPluginRepository.Security_UserPlugin_DeleteAll(UserID);

            return result;
        }

    }
}
