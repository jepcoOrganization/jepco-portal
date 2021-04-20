using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_ProviderEntity
    {

        [DataMember]
        public long ProviderID { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string ProviderName { get; set; }
        [DataMember]
        public string ProviderLogo { get; set; }
        [DataMember]
        public string TradeName { get; set; }
        [DataMember]
        public string ProviderGoal { get; set; }
        [DataMember]
        public string CEO { get; set; }
        [DataMember]
        public string GeneralManager { get; set; }
        [DataMember]
        public string ActingManagerName { get; set; }
        [DataMember]
        public string ActingManagerPhoneNo { get; set; }
        [DataMember]
        public string PartnerName { get; set; }
        [DataMember]
        public string PartnerPhoneNo { get; set; }
        [DataMember]
        public int CityID { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string Neighborhood { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PO { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int CertificationTypeID { get; set; }
        [DataMember]
        public string CertificationType { get; set; }
        [DataMember]
        public string Capital { get; set; }
        [DataMember]
        public long RegistrationNumber { get; set; }
        [DataMember]
        public DateTime RegistrationDate { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
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
        public bool IsApproved { get; set; }
        [DataMember]
        public DateTime MembershipDate { get; set; }



    }
}
