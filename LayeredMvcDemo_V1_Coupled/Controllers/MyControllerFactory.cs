using LayeredMvcDemo.Application;
using LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayeredMvcDemo_V1_Coupled.Controllers
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Home")
            {
                //建立相依物件，並注入HomeController
                var service = new CustomerService();
                return new HomeController(service);
            }
            //若其他不須處理，就仰賴預設的ControllerFatory
            return base.CreateController(requestContext, controllerName);
        }

        public override void ReleaseController(IController controller)
        {
            // 如果需要釋放其他物件資源，可寫在這裡。
            base.ReleaseController(controller);
        }
    }
}