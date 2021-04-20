using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class Plugin_CandidateEntity
    {
        [DataMember]
        public int CandidateID { get; set; }
        [DataMember]
        public int VacancyID { get; set; }
        [DataMember]
        public string VacancyName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Degree { get; set; }
        [DataMember]
        public string Major { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public int YearsofExperience { get; set; }
        [DataMember]
        public DateTime ApplyingDate { get; set; }
        [DataMember]
        public DateTime ApplyingTime { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string CoverLetter { get; set; }
        [DataMember]
        public string Resume { get; set; }
        [DataMember]
        public string OtherFiles { get; set; }
        [DataMember]
        public string OtherFileName { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
        [DataMember]
        public string CandiadteReview { get; set; }
    }
}
