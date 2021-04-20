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
    public class RenwableEnergyType3Phase1LocationsEntity
    {
        [DataMember] public long        Type3Phase1LocationsID  { get; set; }
        [DataMember] public long        DetailsID               { get; set; }
        [DataMember] public string      LocationName            { get; set; }
        [DataMember] public string      Governate               { get; set; }
        [DataMember] public string      Area1                   { get; set; }
        [DataMember] public string      Area2                   { get; set; }
        [DataMember] public string      Area3                   { get; set; }
        [DataMember] public string      AreaNumber              { get; set; }
        [DataMember] public string      Longitude               { get; set; }
        [DataMember] public string      Latitude                { get; set; }
        [DataMember] public DateTime    AddDate                 { get; set; }
        [DataMember] public string      AddUser                 { get; set; }
        [DataMember] public DateTime    EditDate                { get; set; }
        [DataMember] public string      EditUser                { get; set; }
        [DataMember] public string      Attachment1             { get; set; }
    }
}

 