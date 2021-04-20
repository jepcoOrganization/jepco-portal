using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.Common.Constants
{
    public static class CommonRepositoryConstants
    {
        public const string OracleDBConnection = "OracleConnection";
        public const string SQLDBConnection = "SiteWareCMS_DB";

        public const string SQLDBConnection_Intranet = "SiteWareCMS_DB_Intranet";

        public const string PreSQLParameter = "@";

        public const string PageIndex = "PageIndex";
        public const string PageSize = "PageSize";
        public const string ItemCount = "ItemCount";
        public const string TotalPages = "TotalPages";
    }
}
