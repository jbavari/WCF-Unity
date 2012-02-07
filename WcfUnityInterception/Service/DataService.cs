using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Microsoft.Practices.Unity;
using WcfUnityInterception.Service;
using WcfUnityInterception.Unity;

namespace WcfUnityInterception
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    public class DataService : IDataService
    {
        [Dependency]
        public DataAccessor DataAccessor { get; set; }

        [Dependency]
        public LogHelper LogHelper { get; set; }

        //public ResponseBase<LiquidsDataContract> GetLiquidsLevel(GetLiquidsLevelRequest request)
        //{
        //    var response = new ResponseBase<LiquidsDataContract>();

        //    try
        //    {
        //        LogHelper.LogAction("User accessing GetLiquidsLevel");
        //        DataAccessor.StartTransaction();

        //        var liquidsDataContract = DataAccessor.GetLiquidsLevel(request.Id);

        //        response.IsSuccess = true;
        //        response.Response = liquidsDataContract;

        //        DataAccessor.CommitTransaction();

        //        LogHelper.LogAction("User successfully executed GetLiquidsLevel");

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Error = ex.Message;
        //        response.IsSuccess = false;

        //        DataAccessor.RollbackTransaction();

        //        LogHelper.LogError("User had error with GetLiquidsLevel");
        //    }

        //    return response;
        //}

        public ResponseBase<LiquidsDataContract> GetLiquidsLevel(GetLiquidsLevelRequest request)
        {
            var response = DataAccessor.GetLiquidsLevel(request.Id);
            return new ResponseBase<LiquidsDataContract>()
                       {
                           Response = response,
                           IsSuccess = true,
                           Error = string.Empty
                       };
        }

        public ResponseBase<ReallyLongDataContract> ReallyLongDataPull(ReallyLongDataPullRequest request)
        {
            Thread.Sleep(10000);
            return new ResponseBase<ReallyLongDataContract>()
            {
                Response = DataAccessor.ReallyLongDataPull(request.WellNumber, 50),
                IsSuccess = true,
                Error = string.Empty
            };
        }
    }
}
