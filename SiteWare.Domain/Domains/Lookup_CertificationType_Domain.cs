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
    public class Lookup_CertificationType_Domain
    {
        public async static Task<ResultList<Lookup_CertificationTypeEntity>> GetLookupCertificationTypeAll()
        {
            ResultList<Lookup_CertificationTypeEntity> result = new ResultList<Lookup_CertificationTypeEntity>();

            result = await Lookup_CertficationType_Repository.SelectAll();

            return result;
        }

        public static ResultList<Lookup_CertificationTypeEntity> GetLookupCertificationTypeAllNotAsync()
        {
            ResultList<Lookup_CertificationTypeEntity> result = new ResultList<Lookup_CertificationTypeEntity>();

            result = Lookup_CertficationType_Repository.SelectAllNotAsync();

            return result;
        }
    }
}
