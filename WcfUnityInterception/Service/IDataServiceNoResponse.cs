using System.ServiceModel;
using WcfUnityInterception.Service;

namespace WcfUnityInterception
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILiquidsDataService" in both code and config file together.
    [ServiceContract]
    public interface IDataServiceNoResponse
    {
        [OperationContract]
        LiquidsDataContract GetLiquidsLevel(GetLiquidsLevelRequest request);
        
        [OperationContract]
        ReallyLongDataContract ReallyLongDataPull(ReallyLongDataPullRequest request);
    }
}
