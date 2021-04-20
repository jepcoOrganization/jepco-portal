using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_PropertyEntity
    {
        [DataMember]
        public long PropertyID { get; set; }
        [DataMember]
        public string PropertyTitle { get; set; }
        [DataMember]
        public int PropertyTypeID { get; set; }
        [DataMember]
        public int ProviderID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public int GovernateID { get; set; }
        [DataMember]
        public int AreaID { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string PropertyType { get; set; }
        [DataMember]
        public string ProviderName { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string AreaName { get; set; }
        [DataMember]
        public string GovernateName { get; set; }
        [DataMember]
        public int PropertyCost { get; set; }
        [DataMember]
        public int PropertyAge { get; set; }
        [DataMember]
        public string PropertyArea { get; set; }
        [DataMember]
        public int NoOfBedrooms { get; set; }
        [DataMember]
        public int NoOfBathrooms { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int Order { get; set; }
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
        public string PhoneNumber { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
    }
}
