using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class LogCallHandler : CallHandlerBase, ICallHandler
    {
        public const string Key = "LogCallHandler";

        [Dependency]
        public LogHelper LogHelper { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            UserName = GetUserNameFromInputs(input.Inputs);

            var logMessage = "User " + UserName + " Is Accessing " + input.MethodBase.Name + ". Param Info: ";

            foreach (var input1 in input.Inputs)
            {
                var type = input1.GetType();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var something = type.GetProperty(propertyInfo.Name).GetValue(input1, null);
                    logMessage += " Property: " + propertyInfo.Name + " Value: " + something.ToString();
                }
            }

            LogHelper.LogAction(logMessage);

            var toReturn = getNext()(input, getNext);

            LogHelper.LogAction("User " + UserName + "Successfully access " + input.MethodBase.Name);

            return toReturn;

        }

        public int Order { get; set; }
    }
}