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
    public class Plugin_CarrerEntity
    {
        [DataMember]
        public int Carrer_ID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string GrandFatherName { get; set; }
        [DataMember]
        public string FamilyName { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public string Place { get; set; }
        [DataMember]
        public int Nationality { get; set; }
        [DataMember]
        public string NationalID { get; set; }
        [DataMember]
        public string LanguageSpoken { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string GradeLevel { get; set; }
        [DataMember]
        public string AcademicYear { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string BuildingNO { get; set; }
        [DataMember]
        public string TelephoneNO { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
    }
}
