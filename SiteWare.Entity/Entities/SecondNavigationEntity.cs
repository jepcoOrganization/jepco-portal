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
    public class SecondNavigationEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string Icon { get; set; }
        [DataMember]
        public byte? TargetID { get; set; } 
        [DataMember]
        public byte? MenuOrder { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
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
        public int MenuType { get; set; }
    }
}
