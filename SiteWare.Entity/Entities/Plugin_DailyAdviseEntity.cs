using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_DailyAdviseEntity
    {
        [DataMember]
        public long AdviseID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public DateTime DateTo { get; set; }

        [DataMember]
        public DateTime DateFrom { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public string Target { get; set; }

        [DataMember]
        public int LanguageID { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

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
