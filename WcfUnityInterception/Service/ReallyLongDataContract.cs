using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfUnityInterception.Service
{
    [DataContract]
    public class ReallyLongDataContract
    {
        [DataMember]
        public IList<LiquidsDataContract> Data { get; set; }
    }
}