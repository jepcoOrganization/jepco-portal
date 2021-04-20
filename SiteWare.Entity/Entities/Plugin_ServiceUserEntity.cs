using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_ServiceUserEntity
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string ThirdName { get; set; }
        [DataMember]
        public string FamilyName     { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserType { get; set; }
        [DataMember]
        public int IDType { get; set; }
        [DataMember]
        public string IDNumber { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Country { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int Area1 { get; set; }
        [DataMember]
        public int Area2 { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        

        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
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
        public int NationalityID { get; set; }
        
    }
}
