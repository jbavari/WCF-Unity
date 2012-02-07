using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace WcfUnityInterception
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityContainer Container { set; get; }
        public UnityServiceHost()
            : base()
        {
            Container = new UnityContainer();
        }

        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            Container = new UnityContainer();
        }

        protected override void OnOpening()
        {
            new UnityServiceBehavior(Container).AddToHost(this);
            base.OnOpening();
        }
    }
}