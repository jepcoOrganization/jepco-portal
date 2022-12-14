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
    public class RenewableEnergyCompanyDeviceEntity
    {
        [DataMember] public long        RenewbleCompnyDevice    { get; set; }
        [DataMember] public string      CompanyName             { get; set; }
        [DataMember] public string      ModelNo                 { get; set; }
        [DataMember] public string      DevicePower             { get; set; }
        [DataMember] public string      CountryOfOrigin         { get; set; }
        [DataMember] public string      DeviceDocument          { get; set; }
        [DataMember] public int         Order                   { get; set; }
        [DataMember] public int         LanguageID              { get; set; }       
        [DataMember] public DateTime    PublishDate             { get; set; }
        [DataMember] public bool        IsPublished             { get; set; }
        [DataMember] public bool        IsDeleted               { get; set; }
        [DataMember] public DateTime    AddDate                 { get; set; }
        [DataMember] public string      AddUser                 { get; set; }
        [DataMember] public DateTime    EditDate                { get; set; }
        [DataMember] public string      EditUser                { get; set; }
        [DataMember] public string      LanguageName            { get; set; }



        [DataMember] public string Status { get; set; }
        [DataMember] public bool IsApproved { get; set; }
        [DataMember] public long CompanyID { get; set; }

        [DataMember] public string DeviceDocument2 { get; set; }
        [DataMember] public string DeviceDocument3 { get; set; }
        
        [DataMember] public string DeviceDocument4 { get; set; }
        




    }
}



