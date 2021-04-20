using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class User_Login_IntranetEntity
    {
        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public long ProviderID { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool IsFirstLogin { get; set; }

        [DataMember]
        public bool IsMail { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }

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
