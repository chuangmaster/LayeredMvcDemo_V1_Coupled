using LayeredMvcDemo.Application;
using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo_V1_Coupled.Controllers.API;
using LayeredMvcDemo_V1_Coupled.Resolver.API;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LayeredMvcDemo_V1_Coupled.UnityWebApiActivator), nameof(LayeredMvcDemo_V1_Coupled.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(LayeredMvcDemo_V1_Coupled.UnityWebApiActivator), nameof(LayeredMvcDemo_V1_Coupled.UnityWebApiActivator.Shutdown))]

namespace LayeredMvcDemo_V1_Coupled
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            container.RegisterType<CustomerController>();
            container.RegisterType<ICustomerService, CustomerService>();
            var myControllerActovator = new MyHttpControllerActivator(container);
            config.Services.Replace(typeof(IHttpControllerActivator),
            myControllerActovator);
        }
        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}