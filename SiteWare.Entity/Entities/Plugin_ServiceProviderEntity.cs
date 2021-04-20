using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_ServiceProviderEntity
    {
        [DataMember]
        public long ProviderID { get; set; }
        [DataMember]
        public long CategoryID { get; set; }
        [DataMember]
        public long SubCategoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public long GovernateID { get; set; }
        [DataMember]
        public long RegionID { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public long Order { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public DateTime PublishedDate { get; set; }
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
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string SubCatName { get; set; }
        [DataMember]
        public string GovernateName { get; set; }
        [DataMember]
        public string RegionName { get; set; }
    }
}
