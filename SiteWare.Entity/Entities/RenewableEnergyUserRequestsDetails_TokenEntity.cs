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
    public class RenewableEnergyUserRequestsDetails_TokenEntity
    {
        [DataMember] public long        ID          { get; set; }
        [DataMember] public long        DetailsID   { get; set; }
        [DataMember] public string      TokenNo     { get; set; }
        [DataMember] public DateTime    AddDate     { get; set; }
        [DataMember] public string      AddYear     { get; set; }
        [DataMember] public string      AddMonth    { get; set; }
    }
}
