using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class RenewableEnergyCompanySolarCellEntity
    {
        [DataMember] public long RenewbleCompnySolarCell { get; set; }
        [DataMember] public string CompanyName { get; set; }
        [DataMember] public string ModelNo { get; set; }
        [DataMember] public string DevicePower { get; set; }
        [DataMember] public string CountryOfOrigin { get; set; }
        [DataMember] public string SolarCellDocument { get; set; }
        [DataMember] public int Order { get; set; }
        [DataMember] public int LanguageID { get; set; }
        [DataMember] public DateTime PublishDate { get; set; }
        [DataMember] public bool IsPublished { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime AddDate { get; set; }
        [DataMember] public string AddUser { get; set; }
        [DataMember] public DateTime EditDate { get; set; }
        [DataMember] public string EditUser { get; set; }
        [DataMember] public string LanguageName { get; set; }
        [DataMember] public string Status { get; set; }
        [DataMember] public bool IsApproved { get; set; }
        [DataMember] public long CompanyID { get; set; }

        [DataMember] public string SolarCellDocument2 { get; set; }


    }
}
