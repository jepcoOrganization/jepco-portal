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
    public class PluginSocialIconEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; } 
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Imageover { get; set; }
        [DataMember]
        public int IconOrder { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public string ImageTitle { get; set; }
        [DataMember]
        public string AltIamge { get; set; } 
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
        public string LanguageName { get; set; }
    }
}
