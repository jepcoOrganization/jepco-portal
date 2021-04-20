using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_CMS_WorkFlow_Users_Entity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long WF_ID { get; set; }
        [DataMember]
        public long FromUserID { get; set; }
        [DataMember]
        public long ToUserID { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        

    }
}
