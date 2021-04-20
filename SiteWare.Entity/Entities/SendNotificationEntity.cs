using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class SendNotificationEntity
    {
        [DataMember]
        public long SendNotificationID { get; set; }
        [DataMember]
        public string DeviceID { get; set; }
        [DataMember]
        public string NotificationType { get; set; }
        [DataMember]
        public int NotificationID { get; set; }
        [DataMember]
        public string Notification { get; set; }
        [DataMember]
        public string IoSnotificationResult { get; set; }
        [DataMember]
        public string AndroidnotificationResult { get; set; }
        [DataMember]
        public DateTime DateGenerated { get; set; }
        [DataMember]
        public string DateGeneratedDate { get; set; }
    }
}
