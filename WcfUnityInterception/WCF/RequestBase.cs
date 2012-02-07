using System.Runtime.Serialization;

namespace WcfUnityInterception
{
    [DataContract]
    public class RequestBase
    {
        [DataMember]
        public string UserName { get; set; }
    }
}