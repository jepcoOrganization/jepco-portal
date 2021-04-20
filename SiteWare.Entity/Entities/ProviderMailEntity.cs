using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class ProviderMailEntity
    {
        [DataMember]
        public string smtpServer { get; set; }

        [DataMember]
        public string userName { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string port { get; set; }

        [DataMember]
        public string toMail { get; set; }

        [DataMember]
        public string fromMail { get; set; }

        [DataMember]
        public string body { get; set; }

        [DataMember]
        public string fromName { get; set; }

        [DataMember]
        public string subject { get; set; }
    }
}
