using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Entities
{
    public class Lookup_SurveyAnswerEntity
    {
        [DataMember]
        public long AnswerID { get; set; }

        [DataMember]
        public long QuestionID { get; set; }

        [DataMember]
        public string OptionName { get; set; }

        [DataMember]
        public long NumberOfVotes { get; set; }

        [DataMember]
        public int LanguageID { get; set; }

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
