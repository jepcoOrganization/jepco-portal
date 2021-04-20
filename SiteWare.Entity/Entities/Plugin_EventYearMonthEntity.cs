using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
   public class Plugin_EventYearMonthEntity
    {
        [DataMember]
        public long Months { get; set; }
        [DataMember]
        public long Years { get; set; }
    }
}
