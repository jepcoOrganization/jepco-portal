using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class PluginProvider_Partner_Entity
    {

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long ProviderID { get; set; }
        [DataMember]
        public string PartnerName { get; set; }
        [DataMember]
        public string PartnerPhoneNo { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
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
