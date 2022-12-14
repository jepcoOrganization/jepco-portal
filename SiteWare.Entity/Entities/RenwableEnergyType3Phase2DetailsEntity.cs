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
    public class RenwableEnergyType3Phase2DetailsEntity
    {
        [DataMember] public long Type3Phase2Details { get; set; }
        [DataMember] public long DetailsID { get; set; }        
        [DataMember] public long CompanyUserID { get; set; }
        [DataMember] public string ACPower { get; set; }
        [DataMember] public string DCPower { get; set; }
        [DataMember] public string Attachment1 { get; set; }
        [DataMember] public string Attachment2 { get; set; }
        [DataMember] public string Attachment3 { get; set; }
        [DataMember] public string Attachment4 { get; set; }
        [DataMember] public bool IsAgree { get; set; }
        [DataMember] public int Order { get; set; }
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
