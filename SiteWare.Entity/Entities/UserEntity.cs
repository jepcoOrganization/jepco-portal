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
    public class UserEntity
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public string Passwordd { get; set; }
        [DataMember]
        public byte? CountryID { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime LastLoginDate { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public byte? MaritalStatusID { get; set; }
        [DataMember]
        public byte? GenderID { get; set; }
        [DataMember]
        public byte? DepartmentID { get; set; }
        [DataMember]
        public byte? SectionID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Ext { get; set; }
        [DataMember]
        public string Mobile { get; set; }      
        [DataMember]
        public DateTime HireDate { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public string Address { get; set; }
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
