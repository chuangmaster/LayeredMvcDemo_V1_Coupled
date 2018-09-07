using LayeredMvcDemo.Application;
using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo_V1_Coupled.Resolver.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;

namespace LayeredMvcDemo_V1_Coupled
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>();
            config.DependencyResolver = new MyAPIDependencyResolver(container);
        }
    }
}
