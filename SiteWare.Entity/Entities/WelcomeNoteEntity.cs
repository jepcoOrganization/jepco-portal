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
    [DataContract]
    public class WelcomeNoteEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string TargetID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        public string ButtonText { get; set; }
        [DataMember]
        public string ButtonLink { get; set; }
        [DataMember]
        public string ButtonTarget { get; set; }
        [DataMember]
        public string ButtonText1 { get; set; }
        [DataMember]
        public string ButtonLink1 { get; set; }
        [DataMember]
        public string ButtonTarget1 { get; set; }
        [DataMember]
        public string ButtonText2 { get; set; }
        [DataMember]
        public string ButtonLink2 { get; set; }
        [DataMember]
        public string ButtonTarget2 { get; set; }
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
        public int Order { get; set; }
    }
}
