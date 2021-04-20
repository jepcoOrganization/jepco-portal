using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class Plugin_Focus_AreaEntity
    {
        public long FocusID { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Icon { get; set; }

        public string Image { get; set; }

        public string Color { get; set; }

        public string Link { get; set; }

        public string Target { get; set; }

        public int LanguageID { get; set; }

        public long FocusOrder { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool IsDelete { get; set; }

        public DateTime AddDate { get; set; }

        public string AddUser { get; set; }

        public DateTime EditDate { get; set; }

        public string EditUser { get; set; }

        public string LanguageName { get; set; }
    }
}
