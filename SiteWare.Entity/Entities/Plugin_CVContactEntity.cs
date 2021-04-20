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
    public class Plugin_CVContactEntity
    {
        [DataMember] public long ContactID { get; set; }
        [DataMember] public long JobApplicationID { get; set; }
        [DataMember] public int Provenance { get; set; }
        [DataMember] public int AreaOne { get; set; }
        [DataMember] public int AreaTwo { get; set; }
        [DataMember] public string Street { get; set; }
        [DataMember] public string Building { get; set; }
        [DataMember] public string BuildingNumber { get; set; }
        [DataMember] public string TeliphoneOne { get; set; }
        [DataMember] public string TeliphoneTwo { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string Resume { get; set; }


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
