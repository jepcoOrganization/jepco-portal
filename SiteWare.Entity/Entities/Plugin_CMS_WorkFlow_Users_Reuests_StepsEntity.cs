using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public int WF_ID { get; set; }
        [DataMember]
        public string StepName { get; set; }
        [DataMember]
        public bool CloseStep { get; set; }
        [DataMember]
        public long Order { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public DateTime Adddate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
    
    }
}
