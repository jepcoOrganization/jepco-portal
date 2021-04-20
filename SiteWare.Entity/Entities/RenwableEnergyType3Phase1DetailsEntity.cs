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
    public class RenwableEnergyType3Phase1DetailsEntity
    {
        [DataMember] public long        Type3Phase1DetailsID    { get; set; }
        [DataMember] public long        DetailsID               { get; set; }
        [DataMember] public bool        IsApproved              { get; set; }
        [DataMember] public DateTime    ApprovedDate            { get; set; }
        [DataMember] public string      TotalPower              { get; set; }
        [DataMember] public DateTime    AddDate                 { get; set; }
        [DataMember] public string      AddUser                 { get; set; }
        [DataMember] public DateTime    EditDate                { get; set; }
        [DataMember] public string      EditUser                { get; set; }

    }
}
