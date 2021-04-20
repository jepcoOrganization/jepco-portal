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
    public class PagesEntity
    {
        [DataMember]
        public int PageID { get; set; }
        [DataMember]
        public string AliasPath { get; set; }
        [DataMember]
        public string NamePath { get; set; }
        [DataMember]
        public string LivePath { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public int ParentID { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
        [DataMember]
        public string LanguageName { get; set; }
        [DataMember]
        public Boolean IsList { get; set; }
        [DataMember]
        public string ListLink { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ContentHTML { get; set; }
        [DataMember]
        public string ContentHTML1 { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public Boolean IsPublished { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
        [DataMember]
        public long ViewCount { get; set; }
        [DataMember]
        public string SEOAttribute { get; set; }
        [DataMember]
        public string MetaTitle { get; set; }
        [DataMember]
        public string MetaDescription { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string MappedPage1 { get; set; }
        [DataMember]
        public string MappedPage2 { get; set; }
        [DataMember]
        public string MobileBanner { get; set; }
    }
}
