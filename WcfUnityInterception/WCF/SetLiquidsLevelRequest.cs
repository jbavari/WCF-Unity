using System.Runtime.Serialization;

namespace WcfUnityInterception
{
    [DataContract]
    public class SetLiquidsLevelRequest : RequestBase
    {
        [DataMember]
        public string Level { get; set; }
    }
}