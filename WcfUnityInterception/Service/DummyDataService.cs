using System;
using Microsoft.Practices.Unity;

namespace WcfUnityInterception.Service
{
    public class DummyDataService : IDataService
    {
        [Dependency]
        public DataAccessor DataAccessor { get; set; }

        public ResponseBase<LiquidsDataContract> GetLiquidsLevel(GetLiquidsLevelRequest request)
        {
            return new ResponseBase<LiquidsDataContract>()
                       {Response = DataAccessor.GetLiquidsLevel(request.Id), Error = "", IsSuccess = true};
        }

        public ResponseBase<LiquidsDataContract> SetLiquidsLevel(SetLiquidsLevelRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<ReallyLongDataContract> ReallyLongDataPull(ReallyLongDataPullRequest request)
        {
            return new ResponseBase<ReallyLongDataContract>()
            {
                Response = DataAccessor.ReallyLongDataPull(request.WellNumber, 1),
                IsSuccess = true,
                Error = string.Empty
            };
        }
    }
}