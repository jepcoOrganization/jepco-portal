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
    public class RenewableEnergyUserRequestsEntity
    {
        [DataMember] public long        RenwableEnergyID        { get; set; }
        [DataMember] public long        UserID                  { get; set; }
        [DataMember] public string      RenwableEnergyTypeID    { get; set; }
        //[DataMember] public long        RenewbleCompnyDevice    { get; set; }
        [DataMember] public string      MeterStatus             { get; set; }
        [DataMember] public string      ReferenceNumber         { get; set; }
        [DataMember] public long        CompanyID               { get; set; }
        [DataMember] public bool        CompanyAcceptedStatus   { get; set; }
        [DataMember] public DateTime    AcceptStatusDate        { get; set; }
        [DataMember] public string      AcceptStatusUser        { get; set; }
        [DataMember] public string      Attachemnt1             { get; set; }
        [DataMember] public string      Attachemnt2             { get; set; }
        [DataMember] public string      Attachemnt3             { get; set; }
        [DataMember] public string      Attachemnt4             { get; set; }
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
        [DataMember] public string      RefeenceType            { get; set; }

        [DataMember] public string Attachemnt5 { get; set; }

        [DataMember] public string GUID { get; set; }



    }
}




