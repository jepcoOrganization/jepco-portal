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
    public class ServicesStepsEntity
    {
       
        [DataMember] public long        StepID          { get; set; }
        [DataMember] public string      ServiceID       { get; set; }
        [DataMember] public string      StepNumber      { get; set; }
        [DataMember] public string      FromUser        { get; set; }
        [DataMember] public string      ToUser          { get; set; }
        [DataMember] public string      StepName        { get; set; }
        [DataMember] public bool        SendSMS         { get; set; }
        [DataMember] public string      SMSContent      { get; set; }
        [DataMember] public bool        SendMail        { get; set; }
        [DataMember] public string      MailContent     { get; set; }
        [DataMember] public string      Filed1          { get; set; }
        [DataMember] public string      Filed2          { get; set; }
        [DataMember] public string      Filed3          { get; set; }
        [DataMember] public string      Filed4          { get; set; }

    }
}

