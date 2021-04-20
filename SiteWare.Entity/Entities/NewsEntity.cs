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
    public class NewsEntity
    {
        [DataMember]
        public int NewsID { get; set; }
        [DataMember]
        public string NewsImage { get; set; }
        [DataMember]
        public string Headline { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime NewsDate { get; set; }
        [DataMember]
        public long? ViewCount { get; set; }
        [DataMember]
        public float NewsOrder { get; set; }
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
        public Boolean ShowInMarquee { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string MappedNewsID1 { get; set; }
        [DataMember]
        public string MappedNewsID2 { get; set; }
        [DataMember]
        public Boolean IsNotification { get; set; }
    }
}
