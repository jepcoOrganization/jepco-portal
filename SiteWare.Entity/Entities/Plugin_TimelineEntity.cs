using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_TimelineEntity
    {
        [DataMember]
        public long TimelineID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Summary { get; set; }      
        [DataMember]
        public long FocusID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public Boolean IsPublished { get; set; }
        [DataMember]
        public Boolean IsDelete { get; set; }
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
        [DataMember]
        public string PluginAreaTitle { get; set; }
   
    }
}
