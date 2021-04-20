using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_JobApplicationEntity
    {
        [DataMember] public long JobApplicationID { get; set; }
        [DataMember] public int JobType { get; set; }
        [DataMember] public int JobName { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string SecondName { get; set; }
        [DataMember] public string ThirdName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string Nationalid { get; set; }
        [DataMember] public DateTime BirthDate { get; set; }
        [DataMember] public int MaritalState { get; set; }
        [DataMember] public string NoofChild { get; set; }
        [DataMember] public string HaveLicence { get; set; }
        [DataMember] public int LicenceType { get; set; }
        [DataMember] public int YearOfLicence { get; set; }
        [DataMember] public int Qualification { get; set; }



        [DataMember] public long Order { get; set; }
        [DataMember] public int LanguageID { get; set; }
        [DataMember] public DateTime PublishDate { get; set; }
        [DataMember] public bool IsPublished { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime AddDate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }

        [DataMember] public string LanguageName { get; set; }
    }
}
