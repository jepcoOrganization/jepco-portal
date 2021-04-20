using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace SiteWare.Entity.Common.Enums
{
    [DataContract]
    public enum ErrorEnums
    {
        [EnumMember]
        Exception = 1,
        [EnumMember]
        Error = 2,
        [EnumMember]
        Warning = 3,
        [EnumMember]
        Information = 4,
        [EnumMember]
        Success = 0
    }
    public enum DocumentEnums
    {
        Certifcation = 1,
        IDCard = 2,
        InternalPolicyDocument = 3,
        WorkingLicense = 4,
        OwnerImage = 5,
        CommercialNameDocument = 6,
        ActingManagerDocument = 7,
        CompanyStamp = 8

    }
}
