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
    public class Plugin_RenwabaleEnergyCompanyEntity
    {
        [DataMember] public long        RenwabaleEnergyCompanyID       { get; set; }
        [DataMember] public long        ServiceUserID                  { get; set; }
        [DataMember] public string      CompanyName                     { get; set; }
        [DataMember] public string CompanyNationalID               { get; set; }
        [DataMember] public int         CompanyClassificationID         { get; set; }
        [DataMember] public string      Password                        { get; set; }
        [DataMember] public string      MobileNumber                    { get; set; }
        [DataMember] public string      TelephoneNumber                 { get; set; }
        [DataMember] public string      FaxNumber                       { get; set; }
        [DataMember] public string      EmailAddress                    { get; set; }
        [DataMember] public string      Website                         { get; set; }
        [DataMember] public int         Governate                       { get; set; }
        [DataMember] public int         Area                            { get; set; }
        [DataMember] public int         Area2                           { get; set; }
        [DataMember] public int         StreetID                        { get; set; }
        [DataMember] public string      Address                         { get; set; }
        [DataMember] public string      CompanyRegistrationDocument     { get; set; }
        [DataMember] public string      QualificationDocument           { get; set; }
        [DataMember] public int         Order                           { get; set; }
        [DataMember] public int         LanguageID                      { get; set; }
        [DataMember] public DateTime    QualificationExpiryDate         { get; set; }
        [DataMember] public bool        IsMobileVerfied                 { get; set; }
        [DataMember] public bool        ISEmailVerfied                  { get; set; }
        [DataMember] public DateTime    PublishDate                     { get; set; }
        [DataMember] public bool        IsPublished                     { get; set; }
        [DataMember] public bool        IsDeleted                       { get; set; }
        [DataMember] public DateTime    AddDate                         { get; set; }
        [DataMember] public string      AddUser                         { get; set; }
        [DataMember] public DateTime    EditDate                        { get; set; }
        [DataMember] public string      EditUser                        { get; set; }
        [DataMember] public string      LanguageName                    { get; set; }
    }
}


