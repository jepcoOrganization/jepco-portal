using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
   public class ServicesStepsValuesEntity
    {
        [DataMember] public     long        ID                  { get; set; }
        [DataMember] public     long        StepID              { get; set; }
        [DataMember] public     string      ServiceID           { get; set; }
        [DataMember] public     string      Value1              { get; set; }
        [DataMember] public     string      Value2              { get; set; }
        [DataMember] public     string      Value3              { get; set; }
        [DataMember] public     string      Value4              { get; set; }
        [DataMember] public     string      Notes               { get; set; }
        [DataMember] public     bool        IsDone              { get; set; }
        [DataMember] public     DateTime    ReceivedDateTime    { get; set; }
        [DataMember] public     DateTime    DoneDateTime        { get; set; }
        [DataMember] public     DateTime    AddDate             { get; set; }
        [DataMember] public     string      AddUser             { get; set; }
        [DataMember] public     DateTime    EditDate            { get; set; }
        [DataMember] public     string      EditUser            { get; set; }

    }
}
