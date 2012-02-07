using System.Runtime.Serialization;

namespace WcfUnityInterception
{
    [DataContract]
    public class ReallyLongDataPullRequest : RequestBase
    {
        [DataMember]
        public int WellNumber { get; set; }
    }
}