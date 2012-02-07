using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfUnityInterception
{
    [DataContract]
    public class LiquidsDataContract
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Level { get; set; }
    }
}
