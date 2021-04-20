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
    public class ContactUsFormEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Email { get; set; } 
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public long Contact { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
    }
}
