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
    public class RenewableEnergyCompanyUserEntity
    {
        [DataMember] public long        RenewableEnergyCompanyUserID    { get; set; }
        [DataMember] public string      FirstName                       { get; set; }
        [DataMember] public string      FatherName                      { get; set; }
        [DataMember] public string      Grandfathername                 { get; set; }
        [DataMember] public string      FamilyName                      { get; set; }
        [DataMember] public string      DocumentType                    { get; set; }
        [DataMember] public string      DocumnetNo                      { get; set; }
        [DataMember] public string      MobileNo                        { get; set; }
        [DataMember] public string      EmailID                         { get; set; }       
        [DataMember] public DateTime    RegisterDate                    { get; set; }
        [DataMember] public DateTime    ExpireDate                      { get; set; }
        [DataMember] public string      DocumentUpload                  { get; set; }
        [DataMember] public string      DocumentUploadPhoto             { get; set; }
        [DataMember] public int         Order                           { get; set; }
        [DataMember] public int         LanguageID                      { get; set; }
        [DataMember] public DateTime    PublishDate                     { get; set; }
        [DataMember] public bool        IsPublished                     { get; set; }
        [DataMember] public bool        IsDeleted                       { get; set; }
        [DataMember] public DateTime    AddDate                         { get; set; }
        [DataMember] public string      AddUser                         { get; set; }
        [DataMember] public DateTime    EditDate                        { get; set; }
        [DataMember] public string      EditUser                        { get; set; }
        [DataMember] public string      LanguageName                    { get; set; }


        [DataMember] public long CompanyID { get; set; }
        [DataMember] public bool IsActive { get; set; }


    }
}
 



