using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfUnityInterception
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        public UnityContainer Container { set; get; }
        public Type ServiceType { set; get; }
        
        public UnityInstanceProvider() : this(null) { }

        public UnityInstanceProvider(Type type)
        {
            ServiceType = type;
            Container = new UnityContainer();
        }

        #region IInstanceProvider Members

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return Container.Resolve(typeof(IDataService));
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
        
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
        
        #endregion
    }
}
