using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_NewsYearMonthEntity
    {
        [DataMember]
        public long Months { get; set; }
        [DataMember]
        public long Years { get; set; }
    }
}
