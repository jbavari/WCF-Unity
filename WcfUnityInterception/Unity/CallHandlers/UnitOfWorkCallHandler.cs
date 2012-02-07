using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using WcfUnityInterception.Service;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class UnitOfWorkCallHandler : ICallHandler
    {
        public const string Key = "UnitOfWorkCallHandler";

        [Dependency]
        public IDataAccessor LiquidsHelper { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            LiquidsHelper.StartTransaction();

            var toReturn = getNext()(input, getNext);

            LiquidsHelper.CommitTransaction();

            return toReturn;
        }

        public int Order { get; set; }
    }
}