using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;
using WcfUnityInterception;
using WcfUnityInterception.Service;
using WcfUnityInterception.Unity;
using WcfUnityInterception.Unity.CallHandlers;

namespace WcfcontainerInterception.container
{
    public class UnityConfig
    {
        private const string PolicyName = "InjectionPolicy";
        private const string MatchingRule = "AnyMatchingRule";

        public static void RegisterRepositoryTypes(UnityContainer container)
        {
            /* Register types into the container */
            container.RegisterType<IDataService, DataService>();

            //container.RegisterType<IDataService, DummyDataService>();

            /* Register the Logger to be used by all calls from the container */
            container.RegisterType<LogHelper, LogHelper>(new ContainerControlledLifetimeManager());
            
            /* Register our data access helper to be used uniquely for each thread call from container */
            container.RegisterType<IDataAccessor, DataAccessor>(new PerThreadLifetimeManager());

            /* Register our matching rule and call handlers (AKA Aspects) */
            container.RegisterType<IMatchingRule, AllMatchingRule>(MatchingRule);
            container.RegisterType<ICallHandler, ExceptionCallHandler>(ExceptionCallHandler.Key);
            container.RegisterType<ICallHandler, UnitOfWorkCallHandler>(UnitOfWorkCallHandler.Key);
            container.RegisterType<ICallHandler, AuthenticationCallHandler>(AuthenticationCallHandler.Key);
            container.RegisterType<ICallHandler, CommandCallHandler>(CommandCallHandler.Key);
            container.RegisterType<ICallHandler, LogCallHandler>(LogCallHandler.Key);

            /* Create a new policy and reference the matching rule and call handler by name */
            container.AddNewExtension<Interception>();
            container.Configure<Interception>()
                .AddPolicy(PolicyName)
                .AddMatchingRule(MatchingRule)
                .AddCallHandler(ExceptionCallHandler.Key)
                .AddCallHandler(UnitOfWorkCallHandler.Key)
                //.AddCallHandler(LogCallHandler.Key)
                .AddCallHandler(AuthenticationCallHandler.Key)
                .AddCallHandler(CommandCallHandler.Key);

            /* Make IDataService interface elegible for interception */
            container.Configure<Interception>().SetInterceptorFor(typeof(IDataService), new TransparentProxyInterceptor());
        }
    }
}