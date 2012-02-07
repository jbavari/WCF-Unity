using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;
using WcfcontainerInterception.container;

namespace WcfUnityInterception.Unity
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        public string PolicyName = "SecurityPolicy";
        public string MatchingRule = "AnyMatchingRule";
        public string LogCallHandler = "LogCallHandler";

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var host = new UnityServiceHost(serviceType, baseAddresses);
            var unity = new UnityContainer();

            UnityConfig.RegisterRepositoryTypes(unity);

            host.Container = unity;

            return host;
        }
    }
}