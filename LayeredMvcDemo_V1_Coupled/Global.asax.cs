using LayeredMvcDemo.DataAccess;
using LayeredMvcDemo_V1_Coupled.Controllers;
using LayeredMvcDemo_V1_Coupled.Resolver;
using LayeredMvcDemo_V1_Coupled.Resolver.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LayeredMvcDemo_V1_Coupled
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // 換掉預設的Controller Factory
            // SetControllerFactory ⽅法就是 DI 注⼊模式中的「屬性注⼊」（Property Injection）。
            //IControllerFactory controllerFactory = new MyControllerFactory();
            //ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            // 設定 MVC 應⽤程式的全域 dependency resolver 物件。
            IDependencyResolver resolver = new MyDependencyResolver();
            DependencyResolver.SetResolver(resolver);

            IHttpControllerActivator controllerActivator = new MyHttpControllerActivator();
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), controllerActivator);

        }

        protected void Application_BeginRequest()
        {
            HttpContext.Current.Items["DbContext"] = new SouthwindContext();
        }

        protected void Application_EndRequest()
        {
            var db = HttpContext.Current.Items["DbContext"] as SouthwindContext;
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
