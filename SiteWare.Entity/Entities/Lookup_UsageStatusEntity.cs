using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Lookup_UsageStatusEntity
    {
        [DataMember]
        public int UsageStatusID { get; set; }
        [DataMember]
        public string UsageStatus { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
