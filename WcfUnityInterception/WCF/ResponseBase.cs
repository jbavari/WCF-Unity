using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfUnityInterception
{
    [DataContract]
    public class ResponseBase<T>
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public T Response { get; set; }
    }
}
