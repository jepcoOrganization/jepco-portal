using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Lookup_JobNameEntity
    {
        [DataMember] public int JobNameID { get; set; }
        [DataMember] public string JobName { get; set; }

        [DataMember] public int JobTypeID { get; set; }
        [DataMember] public int Order { get; set; }
        [DataMember] public int LanguageID { get; set; }
        [DataMember] public DateTime PublishDate { get; set; }
        [DataMember] public bool IsPublished { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime AddDate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }
    }
}
