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
    public class LanguageEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; } 
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
    }
}
