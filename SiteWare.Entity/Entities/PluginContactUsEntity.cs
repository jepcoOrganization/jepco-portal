using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class PluginContactUsEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; } 
        [DataMember]
        public string Image { get; set; } 
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
        [DataMember]
        public string URL { get; set; } 
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
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }


    }
}
