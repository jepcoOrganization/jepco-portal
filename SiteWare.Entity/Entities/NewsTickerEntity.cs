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
    public class NewsTickerEntity
    {
        [DataMember]
        public int NewsTickerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NewsURL { get; set; }
        [DataMember]
        public byte? TargetID { get; set; }
        [DataMember]
        public int? NewsOrder { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
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
    }
}
