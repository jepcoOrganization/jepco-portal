using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class E_Plugin_ServiceTypeEntity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string ServiceName { get; set; }
        [DataMember]
        public bool HasUserType { get; set; }
        [DataMember]
        public int ParentID { get; set; }
        [DataMember]
        public int EServiceID { get; set; }

        [DataMember]
        public long Order { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
    }
}
