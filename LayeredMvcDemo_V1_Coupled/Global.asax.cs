using LayeredMvcDemo_V1_Coupled.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 換掉預設的Controller Factory
            // SetControllerFactory ⽅法就是 DI 注⼊模式中的「屬性注⼊」（Property Injection）。
            IControllerFactory controllerFactory = new MyControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
