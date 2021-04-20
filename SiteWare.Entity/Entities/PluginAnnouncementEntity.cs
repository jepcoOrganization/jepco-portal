using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class PluginAnnouncementEntity
    {
        [DataMember]
        public int AnnouncementID { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Title { get; set; }      
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public DateTime AnnouncementDate { get; set; }
        [DataMember]
        public long ViewCount { get; set; }
        [DataMember]
        public float Order { get; set; }
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
        public string MapAnnouncementId1 { get; set; }
        [DataMember]
        public string MapAnnouncementId2 { get; set; }
        [DataMember]
        public bool IsNotication { get; set; }
        [DataMember]
        public string AnnouncementDateStr { get; set; }
        [DataMember]
        public int MediaType { get; set; }
        [DataMember]
        public int VideoType { get; set; }
    }
}
