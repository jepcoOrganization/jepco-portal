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
    public class RenewableEnergyUserRequestsDetailsDevicesEntity
    {
        [DataMember] public long        ID                                      { get; set; }
        [DataMember] public long        RenewableEnergyUserRequestsDetailsID    { get; set; }
        [DataMember] public long        DeviceID                                { get; set; }
        [DataMember] public string      DeviceName                              { get; set; }
        [DataMember] public string      DevicePower                             { get; set; }
        [DataMember] public string      DeviceDocument                          { get; set; }
        [DataMember] public string      NumberofUnits                           { get; set; }
        [DataMember] public DateTime    AddDate                                 { get; set; }
        [DataMember] public string      AddUser                                 { get; set; }
        [DataMember] public DateTime    EditDate                                { get; set; }
        [DataMember] public string      EditUser                                { get; set; }




    }
}

