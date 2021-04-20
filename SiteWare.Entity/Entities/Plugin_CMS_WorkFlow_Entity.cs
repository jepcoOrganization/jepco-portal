using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_CMS_WorkFlow_Entity
    {

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long RequestID { get; set; }
        [DataMember]
        public int WF_ID { get; set; }
        [DataMember]
        public string From_User { get; set; }
        [DataMember]
        public string To_User { get; set; }
        [DataMember]
        public DateTime Send_Date { get; set; }
        [DataMember]
        public string ProcessName { get; set; }
        [DataMember]
        public bool ShowToUser { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public bool ReqBackFlag { get; set; }
        [DataMember]
        public bool InsertMultiFlag { get; set; }
        [DataMember]
        public string Attachment { get; set; }
        [DataMember]
        public string Attachment2 { get; set; }
        [DataMember]
        public string Attachment3 { get; set; }



    }
}
