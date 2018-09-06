using LayeredMvcDemo.Application;
using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo_V1_Coupled.Controllers.API;
using LayeredMvcDemo_V1_Coupled.Resolver.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
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

            //Web API
            var container = new UnityContainer();
            container.RegisterType<CustomerController>();
            container.RegisterType<ICustomerService, CustomerService>();
            IHttpControllerActivator controllerActivator = new MyHttpControllerActivator(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), controllerActivator);
        }
    }
}
