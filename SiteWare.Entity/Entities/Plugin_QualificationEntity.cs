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
    public class Plugin_QualificationEntity
    {
        [DataMember] public long QualificationID { get; set; }
        [DataMember] public long JobApplicationID { get; set; }
        [DataMember] public string UniName { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Year { get; set; }
        [DataMember] public string Major { get; set; }
        [DataMember] public string Major_Two { get; set; }
        [DataMember] public string Major_From { get; set; }
        [DataMember] public string AVG { get; set; }
        [DataMember] public string OverAllEval { get; set; }


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
