using System.Runtime.Serialization;

namespace WcfUnityInterception
{
    [DataContract]
    public class GetLiquidsLevelRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
    }
}
