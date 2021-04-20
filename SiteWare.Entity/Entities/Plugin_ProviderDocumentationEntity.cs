using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_ProviderDocumentationEntity
    {
        [DataMember]
        public long ProviderDocumentaionID { get; set; }

        [DataMember]
        public long ProviderID { get; set; }
        [DataMember]
        public int DocumentTypeID { get; set; }

        [DataMember]
        public string DocumentType { get; set; }
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public bool IsApproved { get; set; }

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
