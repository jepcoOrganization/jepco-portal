using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class VMSearchEntity
    {
        [DataMember]
        public int? PropertyTypeID { get; set; }
        [DataMember]
        public long? GovernateID { get; set; }
        [DataMember]
        public int? AreaID { get; set; }
        [DataMember]
        public string AreaMax { get; set; }
        [DataMember]
        public string AreaMin { get; set; }
        [DataMember]
        public int? PriceMax { get; set; }
        [DataMember]
        public int? PriceMin { get; set; }
        [DataMember]
        public string ProviderIDS { get; set; }
        [DataMember]
        public int? NumofBedrooms { get; set; }
        [DataMember]
        public int? NumofBathrooms { get; set; }
    }
}
