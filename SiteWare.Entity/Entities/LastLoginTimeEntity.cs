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
    public class LastLoginTimeEntity
    {
        [DataMember]
        public long LoginId { get; set; }

        [DataMember]
        public long ServiceUserID { get; set; }
       
        [DataMember]
        public DateTime LastLoginTime { get; set; }
    }
}
