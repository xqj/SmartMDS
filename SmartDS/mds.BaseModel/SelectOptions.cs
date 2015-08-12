using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace mds.BaseModel
{
    [DataContract]
    public class SelectOptions
    {
        [DataMember]
        public string SelectName
        {
            set;
            get;
        }
         [DataMember]
        public string SelectVal
        {
            set;
            get;
        }
         [DataMember]
         public string Remark
         {
             set;
             get;
         }
    }
}
