using System;
using System.Reflection;
using System.Security.Authentication;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using WcfUnityInterception.Service;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class ExceptionCallHandler : ICallHandler
    {
        [Dependency]
        public LogHelper LogHandler { get; set; }

        [Dependency]
        public IDataAccessor LiquidsHelper { get; set; }

        public const string Key = "ExceptionCallHandler";

        protected IMethodReturn GetProperResponseTypeForMethodToReturn(IMethodInvocation input, string message)
        {
            Type retType = (input.MethodBase as MethodInfo).ReturnType;
            object createdInstance = Activator.CreateInstance(retType);
            createdInstance.GetType().GetProperty("Error").SetValue(createdInstance, message, null);
            createdInstance.GetType().GetProperty("IsSuccess").SetValue(createdInstance, false, null);
            IMethodReturn retu = input.CreateMethodReturn(createdInstance, input.Arguments);
            return retu;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn toReturn;
            try
            {
                toReturn = getNext()(input, getNext);
            }
            catch (AuthenticationException ex)
            {
                toReturn = GetProperResponseTypeForMethodToReturn(input, ex.Message);
            }
            catch (Exception e)
            {
                string currentUser = null;
                foreach (var param in input.Inputs)
                {
                    var requestBase = param as RequestBase;
                    if (requestBase != null)
                    {
                        currentUser = requestBase.UserName;
                    }
                }

                var error = currentUser + " had the following error: " + e.Message;

                LiquidsHelper.RollbackTransaction();

                LogHandler.LogError(error);

                toReturn = GetProperResponseTypeForMethodToReturn(input, error);
            }
            return toReturn;
        }

        public int Order { get; set; }
    }
}