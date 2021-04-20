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
    public class MobileRegistationEntity
    {
        [DataMember]
        public long RegistationID { get; set; }


        [DataMember]
        public long ServiceUserID { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string OTP { get; set; }

        [DataMember]
        public bool IsVerify { get; set; }

        [DataMember]
        public DateTime AddDate { get; set; }

        [DataMember]
        public DateTime VerifyDate { get; set; }

    }
}
