using System;
using System.Reflection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class CallHandlerBase
    {
        public CallHandlerBase()
        {
            Request = new RequestBase();
        }

        public RequestBase Request { get; set; }
        public string UserName { get; set; }

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        protected IMethodReturn GetProperResponseTypeForMethodToReturn(IMethodInvocation input, string message)
        {
            Type retType = (input.MethodBase as MethodInfo).ReturnType;
            object createdInstance = Activator.CreateInstance(retType);
            createdInstance.GetType().GetProperty("Error").SetValue(createdInstance, message, null);
            createdInstance.GetType().GetProperty("IsSuccess").SetValue(createdInstance, false, null);
            IMethodReturn retu = input.CreateMethodReturn(createdInstance, input.Arguments);
            return retu;
        }

        public string GetUserNameFromInputs(IParameterCollection inputs)
        {
            foreach (var requestInput in inputs)
            {
                Request = requestInput as RequestBase;

                if (Request != null)
                {
                    UserName = Request.UserName;
                    break;
                }
            }
            return UserName;
        }

    }
}