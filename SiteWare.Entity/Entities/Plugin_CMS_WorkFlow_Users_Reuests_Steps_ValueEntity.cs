using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity
    {
        [DataMember] public long ID { get; set; }
        [DataMember] public long RequestID { get; set; }
        [DataMember] public long RequestUserStepID { get; set; }
        [DataMember] public string StepName { get; set; }
        [DataMember] public string StepNotes { get; set; }
        [DataMember] public bool IsDelete { get; set; }
        [DataMember] public DateTime Adddate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }
        [DataMember] public string AddUserName { get; set; }
        [DataMember] public string StepStatus { get; set; }
        [DataMember]
        public string Attachment { get; set; }
        [DataMember]
        public string Attachment2 { get; set; }
        [DataMember]
        public string Attachment3 { get; set; }



    }
}
