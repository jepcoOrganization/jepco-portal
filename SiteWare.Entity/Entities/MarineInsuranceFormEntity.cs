using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class MarineInsuranceFormEntity
    {
        [DataMember]
        public long MarineInsuranceID { get; set; }
        [DataMember]
        public long InsuranceID { get; set; }
        [DataMember]
        public int TripTypeID { get; set; }
        [DataMember]
        public string CargoType { get; set; }
        [DataMember]
        public decimal CargoValue { get; set; }
        [DataMember]
        public int CargoSourceID { get; set; }
        [DataMember]
        public int TransportTypeID { get; set; }
        [DataMember]
        public string HowtoFill { get; set; }
        [DataMember]
        public int IncotermsID { get; set; }
    }
}
