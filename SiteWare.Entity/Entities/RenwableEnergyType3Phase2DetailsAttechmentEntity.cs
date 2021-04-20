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
    public class RenwableEnergyType3Phase2DetailsAttechmentEntity
    {
        [DataMember] public long ID { get; set; }
        [DataMember] public long DetailsID { get; set; }
        [DataMember] public string Attechment1 { get; set; }
        [DataMember] public string Attechment2 { get; set; }
        [DataMember] public string Attechment3 { get; set; }
        [DataMember] public string Attechment4 { get; set; }
        [DataMember] public string Attechment5 { get; set; }
        [DataMember] public string Attechment6 { get; set; }
        [DataMember] public string Attechment7 { get; set; }
        [DataMember] public string Attechment8 { get; set; }
        [DataMember] public string Attechment9 { get; set; }
        [DataMember] public string Attechment10 { get; set; }
        [DataMember] public DateTime AddDate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }
    }
}
