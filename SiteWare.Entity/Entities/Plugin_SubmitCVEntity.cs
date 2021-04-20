using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_SubmitCVEntity
    {
        [DataMember]
        public int SubmitCVID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string Interest { get; set; }
        [DataMember]
        public string AttachCV { get; set; }


        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
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


       
