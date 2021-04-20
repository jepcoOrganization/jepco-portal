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
    public class PluginAlbumDetailEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; } 
        [DataMember]
        public int ItemOredr { get; set; }
        [DataMember]
        public int AlbumID { get; set; }
        [DataMember]
        public int LanguageID { get; set; }
        [DataMember]
        public string ItemLink { get; set; } 
        [DataMember]
        public string CoverImage { get; set; }
        [DataMember]
        public bool IsPublish { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
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
        [DataMember]
        public string OpenIn { get; set; }
        [DataMember]
        public int TypeID { get; set; }
    }
}
