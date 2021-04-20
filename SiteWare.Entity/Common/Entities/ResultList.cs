using SiteWare.Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Common.Entities
{
    [DataContract]
    public class ResultList<T>
    {
        public ResultList()
        {
            List = new List<T>();
        }
        [DataMember]

        public string Details { get; set; }
        [DataMember]

        public List<T> List { get; set; }
        [DataMember]

        public ErrorEnums Status { get; set; }
        [DataMember]

        public string Message { get; set; }
    }
}
