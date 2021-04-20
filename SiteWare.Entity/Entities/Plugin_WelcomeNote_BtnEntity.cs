using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class Plugin_WelcomeNote_BtnEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public byte LanguageID { get; set; }
        [DataMember]
        public float ButtonOrder { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
    }
}
