using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Lookup_ComplainTypeEntity
    {
        [DataMember]
        public int ComplainTypeID { get; set; }

        [DataMember]
        public string ComplainType { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public DateTime AddDate { get; set; }

        [DataMember]
        public string AddUser { get; set; }

        [DataMember]
        public DateTime EditDate { get; set; }

        [DataMember]
        public string EditUser { get; set; }
    }
}
