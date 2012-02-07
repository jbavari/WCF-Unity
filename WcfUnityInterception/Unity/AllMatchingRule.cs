using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WcfUnityInterception
{
    public class AllMatchingRule : IMatchingRule
    {
        public bool Matches(System.Reflection.MethodBase member)
        {
            return true;
        }
    }
}