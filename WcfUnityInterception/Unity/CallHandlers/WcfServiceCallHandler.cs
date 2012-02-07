using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Reflection;

namespace WcfUnityInterception
{
    public class WcfServiceCallHandler : ICallHandler
    {
        public const string Key = "WcfServiceCallHandler";

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //var ret = input.CreateMethodReturn(
            //var retV = ret.ReturnValue;
            MemberInfo memInfo = input.MethodBase as MemberInfo;
            
            string className = input.MethodBase.DeclaringType.Name;
            string methodName = input.MethodBase.Name;
            //string arguments = GetArgumentList(input.Arguments);         
            /* CustomerDataAccess.GetById(123) */
            //string preMethodMessage = string.Format("{0}.{1}({2})", className, methodName, arguments); 
            //System.Diagnostics.Debug.WriteLine(preMethodMessage);         
            /* Call the method that was intercepted */
            IMethodReturn msg = getNext()(input, getNext);
            string postMethodMessage = string.Format("{0}.{1}() -> {2}", className, methodName, msg.ReturnValue); 
            System.Diagnostics.Debug.WriteLine(postMethodMessage);



            //getNext()(input,getNext).ReturnValue
            //input.
            return msg;
        }

        public int Order
        {
            get;
            set;
        }
    }
}