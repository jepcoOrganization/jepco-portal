using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Lookup_AreaEntity
    {
        [DataMember]
        public int AreaID { get; set; }

        [DataMember]
        public long GovernateID { get; set; }

        [DataMember]
        public string AreaName { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }

        [DataMember]
        public DateTime AddDate { get; set; }

        [DataMember]
        public int AddUser { get; set; }

        [DataMember]
        public DateTime EditDate { get; set; }

        [DataMember]
        public int EditUser { get; set; }
    }
}
