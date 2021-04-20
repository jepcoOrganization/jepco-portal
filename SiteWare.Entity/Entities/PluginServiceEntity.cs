using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class PluginServiceEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ServiceName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Page { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public Boolean ShowonSlider { get; set; }
        [DataMember]
        public string ServiceIcon { get; set; }
        //[DataMember]
        //public string ServiceType { get; set; }
        [DataMember]
        public Boolean UserMustLoggedin { get; set; }
        [DataMember]
        public int ServiceTabID { get; set; }       
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public long Order { get; set; }
        [DataMember]
        public byte LanguageID { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public Boolean IsPublished { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Image2 { get; set; }       
    }
}
