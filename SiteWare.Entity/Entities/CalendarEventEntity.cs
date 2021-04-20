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
    public class CalendarEventEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CalendarID { get; set; }
        [DataMember]
        public string EventTitle { get; set; }
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public string EventURL { get; set; }
        [DataMember]
        public byte? TargetID { get; set; }
        [DataMember]
        public long ViewCount { get; set; }
        [DataMember]
        public DateTime EventTime { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public Boolean IsPublished { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string MapEventID1 { get; set; }
        [DataMember]
        public string MapEventID2 { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public Boolean IsNotification { get; set; }
        [DataMember]
        public long EntityID { get; set; }
        [DataMember]
        public string EntityName { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Color { get; set; }
    }
}
