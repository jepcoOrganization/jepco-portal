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
    public class ResultEntity<T> where T : new()
    {
        public ResultEntity()
        {
            Entity = new T();
        }

        [DataMember]
        public T Entity { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public ErrorEnums Status { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
