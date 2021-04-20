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
    public class RenwableEnergyType3Phase1AttachmentsEntity
    {
        [DataMember] public long            Type3Phase1Attachments  { get; set; }
        [DataMember] public long            DetailsID               { get; set; }
        [DataMember] public string          Attachments1            { get; set; }
        [DataMember] public string          Attachments2            { get; set; }
        [DataMember] public string          Attachments3            { get; set; }
        [DataMember] public string          Attachments4            { get; set; }
        [DataMember] public string          Attachments5            { get; set; }
        [DataMember] public string          Attachments6            { get; set; }
        [DataMember] public string          Attachments7            { get; set; }
        [DataMember] public string          Attachments8            { get; set; }
        [DataMember] public string          Attachments9            { get; set; }
        [DataMember] public string          Attachments10           { get; set; }
        [DataMember] public DateTime        AddDate                 { get; set; }
        [DataMember] public string          AddUser                 { get; set; }
        [DataMember] public DateTime        EditDate                { get; set; }
        [DataMember] public string          EditUser                { get; set; }

    }
}


 
