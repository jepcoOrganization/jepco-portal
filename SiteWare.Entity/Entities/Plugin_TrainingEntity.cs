using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class Plugin_TrainingEntity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public DateTime TrainingDate { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public long ViewCount { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public int Order { get; set; }
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
