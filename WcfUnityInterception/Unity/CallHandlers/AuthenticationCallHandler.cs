using System.Security.Authentication;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WcfUnityInterception.Unity.CallHandlers
{
    public class AuthenticationCallHandler : CallHandlerBase, ICallHandler
    {
        public const string Key = "AuthenticationCallHandler";

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            UserName = GetUserNameFromInputs(input.Inputs);

            //Authenticate user
            if (!UserName.Equals("jbavari"))
            {
                throw new AuthenticationException("You aren't an authenticated user. Quit trying to leech our data.");
            }

            var toReturn = getNext()(input, getNext);
            var actualReturn = input.CreateMethodReturn(toReturn.ReturnValue, input.Arguments);
            return actualReturn;
        }

        public int Order { get; set; }
    }
}