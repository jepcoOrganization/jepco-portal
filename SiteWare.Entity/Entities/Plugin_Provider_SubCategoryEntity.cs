using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_Provider_SubCategoryEntity
    {
        [DataMember]
        public long SubCategoryID { get; set; }
        [DataMember]
        public long CategoryID { get; set; }
        [DataMember]
        public string SubCatName { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Summury { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
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
