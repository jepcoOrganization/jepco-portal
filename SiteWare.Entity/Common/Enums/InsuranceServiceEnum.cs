using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Common.Enums
{
    [DataContract]
    public enum InsuranceServiceEnum
    {
        [EnumMember]
        Marine_Insurance = 1,
        [EnumMember]
        Car_Insurance = 2,
        [EnumMember]
        Life_Insurance = 3,
        [EnumMember]
        Travel_Insurance = 4,
        [EnumMember]
        Health_Insurance = 5,
        [EnumMember]
        Engineering_Insurance = 6,
        [EnumMember]
        Fire_Insurance = 7,
        [EnumMember]
        General_Insurance = 8,
        [EnumMember]
        Servant_Insurance = 9
    }

    [DataContract]
    public enum UsageStatusEnum
    {
        [EnumMember]
        PrivateSaloon = 1,
        [EnumMember]
        PublicTransport = 2,
        [EnumMember]
        PrivateBus = 3
    }


}
