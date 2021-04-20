using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
   public class CountryLanguageEntity
    {
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
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
    }
}
