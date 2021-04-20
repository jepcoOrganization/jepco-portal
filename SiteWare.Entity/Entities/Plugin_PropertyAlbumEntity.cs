using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class Plugin_PropertyAlbumEntity
    {
        [DataMember]
        public int AlbumID { get; set; }
        [DataMember]
        public long PropertyID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string ImageTitle { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public bool IsPublish { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public int AlbumOrder { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }

    }
}
