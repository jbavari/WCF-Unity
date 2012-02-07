using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class CommandCallHandler : CallHandlerBase, ICallHandler
    {
        public const string Key = "CommandCallHandler";
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var toReturn = getNext()(input, getNext);

            if (toReturn.Exception != null)
                throw toReturn.Exception;
            
            // Determine the return type and create an instance of it.
            //Type retType = (input.MethodBase as MethodInfo).ReturnType;
            //object createdInstance = Activator.CreateInstance(retType);
            //createdInstance.GetType().GetProperty("Response").SetValue(createdInstance, tempReturn, null);
            //createdInstance.GetType().GetProperty("IsSuccess").SetValue(createdInstance, true, null);

            return toReturn;
        }

        public int Order { get; set; }
    }
}