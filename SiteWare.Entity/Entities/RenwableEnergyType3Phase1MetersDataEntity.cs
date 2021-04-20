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
    public class RenwableEnergyType3Phase1MetersDataEntity
    {
        [DataMember] public long        Type3Phase1MetersData       { get; set; }
        [DataMember] public long        DetailsID                   { get; set; }
        [DataMember] public string      NumberofConnection          { get; set; }
        [DataMember] public string      Name                        { get; set; }
        [DataMember] public string      MeterNumber                 { get; set; }
        [DataMember] public string      FileNumber                  { get; set; }
        [DataMember] public string      MeterAddress                { get; set; }
        [DataMember] public DateTime    AddDate                     { get; set; }
        [DataMember] public string      AddUser                     { get; set; }
        [DataMember] public DateTime    EditDate                    { get; set; }
        [DataMember] public string      EditUser                    { get; set; }

        [DataMember] public string Attachment1 { get; set; }
    }
}

 
