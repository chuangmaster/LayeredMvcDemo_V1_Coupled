using LayeredMvcDemo.Application;
using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo_V1_Coupled.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity;

namespace LayeredMvcDemo_V1_Coupled.Resolver.API
{
    public class MyHttpControllerActivator : IHttpControllerActivator
    {
        IUnityContainer _container;
        public MyHttpControllerActivator(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            //if (controllerType == typeof(CustomerController))
            //{
            //    ICustomerService customerSercie = new CustomerService();// 建⽴相依物件
            //    request.Properties.Add("CreateTime", DateTime.Now);
            //    return new CustomerController(customerSercie);// 建⽴ controller 並注⼊物件
            //}
            var controller = _container.Resolve(controllerType);
            return controller as IHttpController;
        }
    }
}
