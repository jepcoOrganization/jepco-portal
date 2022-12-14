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
    public class Plugin_ServiceNoteEntity
    {
        [DataMember]
        public long ServiceNoteID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Title2 { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string ContactDetail { get; set; }        
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public long Order { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
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
