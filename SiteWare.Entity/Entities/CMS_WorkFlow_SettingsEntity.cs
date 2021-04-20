using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class CMS_WorkFlow_SettingsEntity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long SettingID { get; set; }
        [DataMember]
        public int WF_ID { get; set; }
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public bool Value { get; set; }

    }
}
