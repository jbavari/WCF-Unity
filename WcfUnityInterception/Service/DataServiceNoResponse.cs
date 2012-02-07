using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace WcfUnityInterception.Service
{
    public class DataServiceNoResponse : IDataServiceNoResponse
    {
        [Dependency]
        public DataAccessor DataAccessor { get; set; }

        public LiquidsDataContract GetLiquidsLevel(GetLiquidsLevelRequest request)
        {
            return DataAccessor.GetLiquidsLevel(request.Id);
        }

        public ReallyLongDataContract ReallyLongDataPull(ReallyLongDataPullRequest request)
        {
            return DataAccessor.ReallyLongDataPull(request.WellNumber, 20);
        }
    }
}