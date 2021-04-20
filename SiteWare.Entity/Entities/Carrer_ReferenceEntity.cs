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
    public class Carrer_ReferenceEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Carrer_ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TelephoneNO { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Relation { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; } 
    }
}
