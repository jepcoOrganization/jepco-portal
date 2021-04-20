using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class Plugin_UserComplainEntity
    {
        [DataMember]
        public long ComplainID { get; set; }

        [DataMember]
        public string ComplainTitle { get; set; }

        [DataMember]
        public string ComplainDetails { get; set; }

        [DataMember]
        public int ComplainType { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string SecondName { get; set; }

        [DataMember]
        public string ThirdName { get; set; }

        [DataMember]
        public string FamilyName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int DocumentType { get; set; }

        [DataMember]
        public string DocumentNumber { get; set; }

        [DataMember]
        public long Nationality { get; set; }

        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public string MeterNumber { get; set; }

        [DataMember]
        public long Governate { get; set; }

        [DataMember]
        public int Area { get; set; }

        [DataMember]
        public string StreetName { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }


        [DataMember] public int Order { get; set; }
        [DataMember] public int LanguageID { get; set; }
        [DataMember] public DateTime PublishedDate { get; set; }
        [DataMember] public bool IsPublished { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime AddDate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }

        [DataMember] public string LanguageName { get; set; }

        [DataMember]
        public int Area2 { get; set; }

        [DataMember]
        public int StreetID { get; set; }

        [DataMember] public bool IssueStatus { get; set; }


        [DataMember]
        public string IssueResultNo { get; set; }
        

        [DataMember]
        public int LanguageIDAPI { get; set; }

        [DataMember]
        public long ServiceUserID { get; set; }
    }
}
